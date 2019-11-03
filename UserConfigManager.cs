using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLZoomTool {

    enum ConfigType {
        DontRemindImgInfo,
        UseUrl,
        IsYouTubeChecked,
        IsPreViewAtRight,
        UpOffet,
        ZoomPercentage,
        IsBeforePreviewChecked,
        IsAfterPreviewChecked,
        IsCenterChecked
    };
    enum ValueType {Bool, Int};
        
    class UserConfigManager {
        private static string userConfigPath = "userConfig.tmp";
        private static Dictionary<ConfigType, ValueType> userConfigValueType;
        private static Dictionary<ConfigType, bool> userBoolConfig;
        private static Dictionary<ConfigType, int> userIntConfig;

        //設定預設值
        private static void SetDefaultValueToConfig() {
            SetConfig(ConfigType.DontRemindImgInfo, false);
            SetConfig(ConfigType.UseUrl, false);
            SetConfig(ConfigType.IsYouTubeChecked, true);
            SetConfig(ConfigType.IsPreViewAtRight, true);
            SetConfig(ConfigType.UpOffet, 0);
            SetConfig(ConfigType.ZoomPercentage, 100);
            SetConfig(ConfigType.IsBeforePreviewChecked, true);
            SetConfig(ConfigType.IsAfterPreviewChecked, true);
            SetConfig(ConfigType.IsCenterChecked, false);
        }

        //重設並寫檔
        private static void ResetToDefaultConfig() {
            SetDefaultValueToConfig();
            WriteConfig();
        }

        private static void InitConfigDictionary() {

            try {
                userConfigValueType = new Dictionary<ConfigType, ValueType>();
                userBoolConfig = new Dictionary<ConfigType, bool>();
                userIntConfig = new Dictionary<ConfigType, int>();

                //如果沒有則使用預設值建立
                if (!File.Exists(userConfigPath)) {
                    ResetToDefaultConfig();
                }
                else {
                    //原本就有則讀取上次的設定
                    ReadConfig();
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
                      
        }

        //建構子
        public UserConfigManager(){
            InitConfigDictionary();
        }

        //讀檔並存入Dictionary
        public static void ReadConfig() {
            string[] configString = File.ReadAllLines(userConfigPath);

            //每一行
            foreach (string line in configString) {
                ConfigType eachKey = (ConfigType) Enum.Parse(typeof(ConfigType), line.Split(':')[0]);
                string valueString = line.Split(':')[1];
                bool boolValue;
                int intValue;

                //Bool <有例外>
                if (Boolean.TryParse(valueString, out boolValue)) {
                    SetConfig(eachKey, boolValue);
                    Console.WriteLine("[Set Bool]" + eachKey.ToString() + ":" + boolValue.ToString());
                }
                //Int
                else if (int.TryParse(valueString, out intValue)) {
                    SetConfig(eachKey, intValue);
                    Console.WriteLine("[Set Int]" + eachKey.ToString() + ":" + intValue.ToString());
                }
                else {
                    MessageBox.Show("Fatal error:無法解析 Config");

                    //刪除config並關閉程式 <待寫>
                }

            }
        }

        
        //取得configValue, 使用上須使用Try Catch
        public static Object GetConfigValueByKey(ConfigType configType) {

            Object returnValue = null;

            //檢查ValueType是否存在Key
            if (!userConfigValueType.ContainsKey(configType)) {
                MessageBox.Show("無法讀取設定值ValueType:" + configType + "，重設為預設值");

                //重設預設值
                ResetToDefaultConfig();
            }
            else {
                //Bool
                if (userConfigValueType[configType] == ValueType.Bool) {
                    //檢查BoolConfig是否存在Key
                    if (!userBoolConfig.ContainsKey(configType)) {
                        MessageBox.Show("無法讀取設定值userBoolConfig:" + configType +  "，重設為預設值");

                        //重設預設值
                        ResetToDefaultConfig();
                    }
                    else {
                        returnValue = (Object)userBoolConfig[configType];
                    }
                }
                //Int
                else if (userConfigValueType[configType] == ValueType.Int) {
                    if (!userIntConfig.ContainsKey(configType)) {
                        MessageBox.Show("無法讀取設定值userIntConfig:" + configType + "，重設為預設值");
                        //重設預設值
                        ResetToDefaultConfig();
                    }
                    else {
                        returnValue = (Object)userIntConfig[configType];
                    }
                }
            }
            return returnValue;
        }

        public static void SetAndWriteConfig<T>(ConfigType configType, T configValue) {
            SetConfig(configType, configValue);
            WriteConfig();
        }

        public static void SetConfig<T>(ConfigType configType, T configValue) {
            
            //Bool
            if (configValue is bool) {

                if (!userConfigValueType.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Bool);
                }

                //原本沒有這個config，直接加入直接加入Dictionary
                if (!userBoolConfig.ContainsKey(configType)) {                    
                    userBoolConfig.Add(configType, (bool)(Object)configValue);
                }
                else {
                    //有則更新
                    userBoolConfig[configType] = (bool)(Object)configValue;
                }
            }
            //Int
            else if (configValue is int) {

                if (!userConfigValueType.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Int);
                }

                //原本沒有這個config，直接加入Dictionary
                if (!userIntConfig.ContainsKey(configType)) {
                    userIntConfig.Add(configType, (int)(Object)configValue);
                }
                else {
                    //有則更新
                    userIntConfig[configType] = (int)(Object)configValue;
                }

            }
        }

        //寫進去Config
        private static void WriteConfig() {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<ConfigType, bool> item in userBoolConfig) {
                sb.AppendLine(item.Key.ToString() + ":" + item.Value.ToString());
            }

            foreach (KeyValuePair<ConfigType, int> item in userIntConfig) {
                sb.AppendLine(item.Key.ToString() + ":" + item.Value.ToString());
            }

            //寫檔
            File.WriteAllText(userConfigPath, sb.ToString());
        }
    }
}
