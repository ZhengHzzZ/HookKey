using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace HookKey
{
    public class KeyConfig
    {
        public static string cfgFilePath = Application.StartupPath + "\\keycfg.bin";
        public static KeyConfigFile KeyCfg;
        public static Hashtable HashKeys;
        public static object PickedKey = null;
        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void Initialize()
        {
            if (File.Exists(cfgFilePath))
            {
                KeyCfg = XMLSerializer.DeSeralize<KeyConfigFile>("keycfg.bin");
            }
            else
            {
                KeyCfg.Num1 = Keys.NumPad1;
                KeyCfg.Num2 = Keys.NumPad2;
                KeyCfg.Num4 = Keys.NumPad4;
                KeyCfg.Num5 = Keys.NumPad5;
                KeyCfg.Num7 = Keys.NumPad7;
                KeyCfg.Num8 = Keys.NumPad8;
                XMLSerializer.Serialize<KeyConfigFile>(KeyCfg, "keycfg.bin");
            }
        }

        public static void LoadHashKeys()
        {
            HashKeys = new Hashtable();
            HashKeys.Add(KeyCfg.Num7, Keys.NumPad7);
            HashKeys.Add(KeyCfg.Num8, Keys.NumPad8);
            HashKeys.Add(KeyCfg.Num4, Keys.NumPad4);
            HashKeys.Add(KeyCfg.Num5, Keys.NumPad5);
            HashKeys.Add(KeyCfg.Num1, Keys.NumPad1);
            HashKeys.Add(KeyCfg.Num2, Keys.NumPad2);
        }

        public static void RefreshConfig()
        {
            LoadHashKeys();
            XMLSerializer.Serialize<KeyConfigFile>(KeyCfg, "keycfg.bin");
        }
    }
    /// <summary>
    /// 配置文件结构
    /// </summary>
    [Serializable]
    public struct KeyConfigFile
    {
        public System.Windows.Forms.Keys Num7
        { get; set; }
        public System.Windows.Forms.Keys Num8
        { get; set; }
        public System.Windows.Forms.Keys Num4
        { get; set; }
        public System.Windows.Forms.Keys Num5
        { get; set; }
        public System.Windows.Forms.Keys Num1
        { get; set; }
        public System.Windows.Forms.Keys Num2
        { get; set; }
    }

    public class XMLSerializer
    {
        public static void Serialize<T>(T o, string filePath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(filePath, false);
                formatter.Serialize(sw, o);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            { 
                
            }
        }

        public static T DeSeralize<T>(string filePath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(filePath);
                T o = (T)formatter.Deserialize(sr);
                sr.Close();
                return o;
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }
    }
}
