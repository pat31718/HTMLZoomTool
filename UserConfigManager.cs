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
        IsImgInfoRemind,
        UseUrl,
        IsYouTubeChecked,
        IsPreViewAtRight,
        UpOffet,
        ZoomPercentage,
        IsBeforePreviewChecked,
        IsAfterPreviewChecked,
        IsCenterChecked
    };
    enum ConfigType { Bool, Int };

    class UserConfigManager
    {
        private static string userConfigPath = "userConfig.tmp";
        private static Dictionary<ConfigKey, ConfigType> userConfigTypeTable = new Dictionary<ConfigKey, ConfigType>();
        private static Dictionary<ConfigKey, object> userConfigTable = new Dictionary<ConfigKey, object>();

        //設定預設值用
        public delegate void SetDefaultValueToConfigEvent();
        public static SetDefaultValueToConfigEvent SetDefaultValueToConfigHandler;
               
        //重設Config並寫檔
        private static void ResetToDefaultConfig()
        {
            SetDefaultValueToConfigHandler();            
            WriteConfigToFile();
        }

        //設定
        public static void InitConfigDictionary()
        {
            try {               

                //如果沒有則使用預設值建立
                if (!File.Exists(userConfigPath)) {
                    ResetToDefaultConfig();
                }
                else {
                    //原本就有則讀取上次的設定
                    ReadConfigFromFile();
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

        }        

        //讀檔並存入Dictionary
        private static void ReadConfigFromFile()
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

            //檢查類型的Table是否有這個Key
            if (!userConfigTypeTable.ContainsKey(configKey)) {
                MessageBox.Show("無法讀取設定值ValueType:" + configKey + "，重設為預設值");

                //重設預設值
                ResetToDefaultConfig();
            }

            //Bool
            if (userConfigTypeTable[configKey] == ConfigType.Bool) {
                //檢查設定檔的Table是否有這個Key
                if (!userConfigTable.ContainsKey(configKey)) {
                    MessageBox.Show("無法讀取設定值userConfig:" + configKey + "，重設為預設值");

                    //重設預設值
                    ResetToDefaultConfig();
                }
                else {
                    returnValue = (bool)userConfigTable[configKey];
                }
            }
            //Int
            else if (userConfigTypeTable[configKey] == ConfigType.Int) {
                //檢查設定檔的Table是否有這個Key
                if (!userConfigTable.ContainsKey(configKey)) {
                    MessageBox.Show("無法讀取設定值userConfig:" + configKey + "，重設為預設值");

                    //重設預設值
                    ResetToDefaultConfig();
                }
                else {
                    returnValue = (int)userConfigTable[configKey];

                }
            }
            return returnValue;
        }

        //這個Method是給其他Class用的，用來直接更新設定值
        public static void SetAndWriteConfig<T>(ConfigKey configType, T configValue)
        {
            SetConfig(configType, configValue);
            WriteConfigToFile();
        }

        //設定Config
        public static void SetConfig<T>(ConfigKey configType, T configValue)
        {

            #region Update userConfigType
            //Bool
            if (configValue is bool) {

                if (!userConfigTypeTable.ContainsKey(configType)) {
                    userConfigTypeTable.Add(configType, ConfigType.Bool);
                }


            }
            //Int
            else if (configValue is int) {

                if (!userConfigTypeTable.ContainsKey(configType)) {
                    userConfigTypeTable.Add(configType, ConfigType.Int);
                }

            }
            #endregion

            
            if (!userConfigTable.ContainsKey(configType)) {
                userConfigTable.Add(configType, configValue);
            }
            else {
                //有則更新
                userConfigTable[configType] = configValue;
            }

        }

        //寫進去Config
        private static void WriteConfigToFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<ConfigKey, object> item in userConfigTable) {
                sb.AppendLine(item.Key.ToString() + ":" + item.Value.ToString());
            }

            //寫檔
            File.WriteAllText(userConfigPath, sb.ToString());
        }
    }
}
