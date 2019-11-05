using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLZoomTool
{

    enum ConfigKey
    {
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
    enum ValueType { Bool, Int };

    class UserConfigManager
    {
        private static string userConfigPath = "userConfig.tmp";
        private static Dictionary<ConfigKey, ValueType> userConfigValueType;
        private static Dictionary<ConfigKey, object> userConfig;

        //設定預設值
        private static void SetDefaultValueToConfig()
        {
            SetConfig(ConfigKey.DontRemindImgInfo, false);
            SetConfig(ConfigKey.UseUrl, false);
            SetConfig(ConfigKey.IsYouTubeChecked, true);
            SetConfig(ConfigKey.IsPreViewAtRight, true);
            SetConfig(ConfigKey.UpOffet, 0);
            SetConfig(ConfigKey.ZoomPercentage, 100);
            SetConfig(ConfigKey.IsBeforePreviewChecked, true);
            SetConfig(ConfigKey.IsAfterPreviewChecked, true);
            SetConfig(ConfigKey.IsCenterChecked, false);
        }

        //重設並寫檔
        private static void ResetToDefaultConfig()
        {
            SetDefaultValueToConfig();
            WriteConfig();
        }

        private static void InitConfigDictionary()
        {

            try {
                userConfigValueType = new Dictionary<ConfigKey, ValueType>();
                userConfig = new Dictionary<ConfigKey, object>();

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
        public UserConfigManager()
        {
            InitConfigDictionary();
        }

        //讀檔並存入Dictionary
        public static void ReadConfig()
        {
            string[] configString = File.ReadAllLines(userConfigPath);

            //每一行
            foreach (string line in configString) {

                ConfigKey eachKey = (ConfigKey)Enum.Parse(typeof(ConfigKey), line.Split(':')[0]);
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
        public static object GetConfigValueByKey(ConfigKey configKey)
        {
            object returnValue = null;            

            //檢查ValueType是否存在Key，不存在就設為預設值
            if (!userConfigValueType.ContainsKey(configKey)) {
                MessageBox.Show("無法讀取設定值ValueType:" + configKey + "，重設為預設值");

                //重設預設值
                ResetToDefaultConfig();
            }

            //Bool
            if (userConfigValueType[configKey] == ValueType.Bool) {
                //檢查userConfig是否存在Key
                if (!userConfig.ContainsKey(configKey)) {
                    MessageBox.Show("無法讀取設定值userConfig:" + configKey + "，重設為預設值");

                    //重設預設值
                    ResetToDefaultConfig();
                }
                else {
                    returnValue = (bool)userConfig[configKey];
                }
            }
            //Int
            else if (userConfigValueType[configKey] == ValueType.Int) {
                //檢查userConfig是否存在Key
                if (!userConfig.ContainsKey(configKey)) {
                    MessageBox.Show("無法讀取設定值userConfig:" + configKey + "，重設為預設值");

                    //重設預設值
                    ResetToDefaultConfig();
                }
                else {
                    returnValue = (int)userConfig[configKey];

                }
            }
            return returnValue;
        }

        public static void SetAndWriteConfig<T>(ConfigKey configType, T configValue)
        {
            SetConfig(configType, configValue);
            WriteConfig();
        }

        public static void SetConfig<T>(ConfigKey configType, T configValue)
        {

            //Bool
            if (configValue is bool) {

                if (!userConfigValueType.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Bool);
                }


            }
            //Int
            else if (configValue is int) {

                if (!userConfigValueType.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Int);
                }

            }

            //原本沒有這個config，直接加入直接加入Dictionary
            if (!userConfig.ContainsKey(configType)) {
                userConfig.Add(configType, configValue);
            }
            else {
                //有則更新
                userConfig[configType] = configValue;
            }

        }

        //寫進去Config
        private static void WriteConfig()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<ConfigKey, object> item in userConfig) {
                sb.AppendLine(item.Key.ToString() + ":" + item.Value.ToString());
            }

            //寫檔
            File.WriteAllText(userConfigPath, sb.ToString());
        }
    }
}
