using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace HookKeyV2
{
    public class KeyConfig
    {
        public static string cfgFilePath = Application.StartupPath + "\\keycfg.bin";
        public static Dictionary<int, int> DicKeys;
        public static object PickedKey = null;
        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void Initialize()
        {
            if (File.Exists(cfgFilePath))
            {
                DicKeys = DictionarySerializer.DeSeralize(cfgFilePath);
            }
            else
            {
                DicKeys = new Dictionary<int, int>();
            }
        }
    }
    public class DictionarySerializer
    {
        public static void Serialize(string filePath, Dictionary<int, int> dic)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false);
                foreach (KeyValuePair<int, int> kv in dic)
                {
                    sw.WriteLine(kv.Key.ToString() + "," + kv.Value.ToString());
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public static Dictionary<int, int> DeSeralize(string filePath)
        {
            Dictionary<int, int> dic = null;
            try
            {
                dic = new Dictionary<int, int>();
                StreamReader sr = new StreamReader(filePath);
                while (sr.Peek() != -1)
                {
                    string s = sr.ReadLine();
                    string[] sArray = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dic.Add(int.Parse(sArray[0]), int.Parse(sArray[1]));
                }
                sr.Close();
            }
            catch (Exception ex)
            {

            }
            return dic;
        }
    }
}
