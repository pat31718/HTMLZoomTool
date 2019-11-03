using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLZoomTool {

    enum ConfigType { DontRemindImgInfo, UseUrl, IsYouTubeChecked,  };
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

        }

        private static void InitConfigDictionary() {

            try {

                userConfigValueType = new Dictionary<ConfigType, ValueType>();
                userBoolConfig = new Dictionary<ConfigType, bool>();
                userIntConfig = new Dictionary<ConfigType, int>();

                //如果沒有則使用預設值建立
                if (!File.Exists(userConfigPath)) {
                    SetDefaultValueToConfig();
                    WriteConfig();
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
                bool eachValue = Convert.ToBoolean(line.Split(':')[1]);
                SetConfig(eachKey, eachValue);

                Console.WriteLine(eachKey.ToString() + ":" + eachValue.ToString());
            }
        }

        public static bool GetConfigValueByKey(ConfigType configType) {
            if (!userBoolConfig.ContainsKey(configType)) {
                MessageBox.Show("設定值讀取錯誤，重設為預設值");

                //重設預設值
                SetDefaultValueToConfig();
                WriteConfig();                
            }
            return userBoolConfig[configType];
        }

        public static void SetAndWriteConfig(ConfigType configType, bool configValue) {
            SetConfig(configType, configValue);
            WriteConfig();
        }

        public static void SetConfig<T>(ConfigType configType, T configValue) {
            //Bool
            if (configValue is bool) {
                //原本沒有這個config，直接加入直接加入Dictionary
                if (!userBoolConfig.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Bool);
                    userBoolConfig.Add(configType, (bool)(Object)configValue);
                }
                else {
                    //有則更新
                    userBoolConfig[configType] = (bool)(Object)configValue;
                }
            }
            //Int
            else if (configValue is int) {
                //原本沒有這個config，直接加入Dictionary
                if (!userBoolConfig.ContainsKey(configType)) {
                    userConfigValueType.Add(configType, ValueType.Int);
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
            //寫檔
            File.WriteAllText(userConfigPath, sb.ToString());
        }
    }
}
