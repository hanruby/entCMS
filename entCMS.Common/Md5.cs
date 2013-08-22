using System;
using System.Security.Cryptography;
using System.Text;

namespace entCMS.Common
{
    /// <summary>
    /// Md5 的摘要说明
    /// </summary>
    public class Md5
    {
        public Md5()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /**/
        /// <summary>
        /// MD5 16位加密 加密后密码为小/大写
        /// </summary>
        /// <param name="ConvertString">原字符串</param>
        /// <param name="toLower">输出的结果：true-小写,false-大写</param>
        /// <returns></returns>
        public static string Get16Md5(string ConvertString, bool toLower = true)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            if (toLower)
                t2 = t2.ToLower();
            return t2;
        }

        /**/
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="toLower">输出的结果：true-小写,false-大写</param>
        /// <returns></returns>
        public static string Get32Md5(string str, bool toLower = true)
        {
            string cl = str;
            string pwd = "";
            string x = "x";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            if (!toLower) x = "X";
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符

                pwd = pwd + s[i].ToString(x + "2");

            }
            return pwd;
        }
    }
}