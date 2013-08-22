using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace entCMS.Common
{
    public class StringUtil
    {
        // Fields
        public static readonly int PART_ENT_NAME_LONG;
        public static readonly int PART_ENT_NAME_MIDDLE;
        public static readonly int PART_ENT_NAME_SHORT;
        public static readonly int PART_POS_DIRECTOR_LONG;
        public static readonly int PART_POS_DIRECTOR_MIDDLE;
        public static readonly int PART_POS_DIRECTOR_SHORT;

        // Methods
        static StringUtil()
        {
            PART_ENT_NAME_SHORT = 14;
            PART_ENT_NAME_MIDDLE = 20;
            PART_ENT_NAME_LONG = 50;
            PART_POS_DIRECTOR_SHORT = 5;
            PART_POS_DIRECTOR_MIDDLE = 8;
            PART_POS_DIRECTOR_LONG = 11;
        }

        public static string CutRightString(object obj, int length)
        {
            string str = obj.ToString();
            string newString = str;
            if ((str != "") && (str.Length > length))
            {
                newString = str.Substring(str.Length - length);
            }
            return newString;
        }

        public static string CutString(string str)
        {
            string newString = "";
            if (!(str != ""))
            {
                return newString;
            }
            string[] aa = str.Split(new char[] { ',' });
            if (aa.Length > 3)
            {
                return (aa[0] + "," + aa[1] + "," + aa[2] + "等");
            }
            return str;
        }

        public static string DeleteLastComma(string origin)
        {
            if ((origin.IndexOf(",") != -1) && origin.EndsWith(","))
            {
                return origin.Substring(0, origin.LastIndexOf(","));
            }
            return origin;
        }

        public static string DeleteUnVisibleChar(string sourceString)
        {
            StringBuilder sBuilder = new StringBuilder(0x83);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 0x10)
                {
                    sBuilder.Append(sourceString[i].ToString());
                }
            }
            return sBuilder.ToString();
        }

        public static int GetByteCount(string str)
        {
            return Encoding.GetEncoding("gb2312").GetBytes(str).Length;
        }

        public static int GetByteIndex(int intIns, string strTmp)
        {
            int intReIns = 0;
            if (strTmp.Trim() == "")
            {
                return intIns;
            }
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intReIns += 2;
                }
                else
                {
                    intReIns++;
                }
                if (intReIns >= intIns)
                {
                    return (i + 1);
                }
            }
            return intReIns;
        }

        public static string GetCorrectCommaListStr(string first, string second, string seprator)
        {
            string result = first;
            result = (first + seprator + second).Replace(seprator + seprator, seprator).Trim();
            if (result.StartsWith(seprator))
            {
                result = result.Substring(1);
            }
            if (result.EndsWith(seprator))
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }

        public static string GetPartString(string OldStr, int length, string postString)
        {
            string result = string.Empty;
            if (length <= 0)
            {
                return OldStr;
            }
            if (!string.IsNullOrEmpty(OldStr))
            {
                string tempNoBlank = OldStr.Trim();
                if (tempNoBlank.Length > length)
                {
                    result = tempNoBlank.Substring(0, length) + postString;
                }
                else
                {
                    result = tempNoBlank;
                }
            }
            return result;
        }

        public static string GetPartStringEndDot(object OldStr, int length)
        {
            if (OldStr is string)
            {
                return GetPartString(OldStr as string, length, "...");
            }
            return OldStr.ToString();
        }

        public static string GetPartStringEndDot(string OldStr, int length)
        {
            return GetPartString(OldStr, length, "...");
        }

        public static string GetSafeString(string ParaValue)
        {
            return ParaValue.Trim().Replace("'", "’").Replace("\"", "“");
        }

        public static int GetStringCount(string sourceString, string findString)
        {
            int count = 0;
            int findStringLength = findString.Length;
            string subString = sourceString;
            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count++;
            }
            return count;
        }

        public static int GetStringCount(string[] stringArray, string findString)
        {
            int count = -1;
            string totalString = string.Join("", stringArray);
            string subString = totalString;
            while (subString.IndexOf(findString) >= 0)
            {
                subString = totalString.Substring(subString.IndexOf(findString));
                count++;
            }
            return count;
        }

        public static string GetSubString(string sourceString, string startString)
        {
            try
            {
                int index = sourceString.ToUpper().IndexOf(startString);
                if (index > 0)
                {
                    return sourceString.Substring(index);
                }
                return sourceString;
            }
            catch
            {
                return "";
            }
        }

        public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
        {
            try
            {
                if (sourceString.IndexOf(beginRemovedString) != 0)
                {
                    beginRemovedString = "";
                }
                if (sourceString.LastIndexOf(endRemovedString, (int)(sourceString.Length - endRemovedString.Length)) < 0)
                {
                    endRemovedString = "";
                }
                int startIndex = beginRemovedString.Length;
                int length = (sourceString.Length - beginRemovedString.Length) - endRemovedString.Length;
                if (length > 0)
                {
                    return sourceString.Substring(startIndex, length);
                }
                return sourceString;
            }
            catch
            {
                return sourceString;
            }
        }

        public static string LeftSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(new char[] { splitChar });
            if (tempString.Length > 0)
            {
                result = tempString[0];
            }
            return result;
        }

        public static string PadRight(string str, int length)
        {
            string newString = "";
            if (!(str != ""))
            {
                return newString;
            }
            length -= 3;
            if ((length > 0) && (str.Length > length))
            {
                return (str.Substring(0, length) + "...");
            }
            return str;
        }

        public static string PadRight(string str, int length, string replace)
        {
            string newString = "";
            if (!(str != ""))
            {
                return newString;
            }
            length -= 3;
            if ((length > 0) && (str.Length > length))
            {
                return (str.Substring(0, length - 2) + replace);
            }
            return str;
        }

        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                {
                    throw new Exception("原字符串中不包含移除字符串！");
                }
                string result = sourceString;
                int lengthOfSourceString = sourceString.Length;
                int lengthOfRemovedString = removedString.Length;
                int startIndex = lengthOfSourceString - lengthOfRemovedString;
                if (sourceString.Substring(startIndex).ToUpper() == removedString.ToUpper())
                {
                    result = sourceString.Remove(startIndex, lengthOfRemovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }

        public static string RightSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(new char[] { splitChar });
            if (tempString.Length > 0)
            {
                result = tempString[tempString.Length - 1];
            }
            return result;
        }

        public static string SqlReplace(string strSql)
        {
            if (strSql != "")
            {
                strSql = strSql.Replace("'", "''");
                strSql = strSql.Replace("--", "");
                strSql = strSql.Replace(";", "");
            }
            return strSql;
        }

        public static string ToHtml(string inputValue)
        {
            inputValue = inputValue.Replace("<", "&lt;");
            inputValue = inputValue.Replace(">", "&gt;");
            inputValue = inputValue.Replace("\n", "<br/>");
            inputValue = inputValue.Replace("\r\n", "<br/>");
            inputValue = inputValue.Replace(" ", "&nbsp;");
            inputValue = inputValue.Trim();
            return inputValue;
        }

        public static string ToText(string inputValue)
        {
            inputValue = inputValue.Replace("<br/>", "\r\n");
            inputValue = inputValue.Replace("&lt;", "<");
            inputValue = inputValue.Replace("&gt;", ">");
            inputValue = inputValue.Replace("&nbsp;", " ");
            inputValue = inputValue.Trim();
            return inputValue;
        }

        /// <summary>
        /// 提取摘要，是否清除HTML代码
        /// </summary>
        /// <param name="content"></param>
        /// <param name="length"></param>
        /// <param name="StripHTML"></param>
        /// <returns></returns>
        public static string GetContentSummary(string content, int length, bool StripHTML)
        {
            if (string.IsNullOrEmpty(content) || length == 0)
                return "";

            if (StripHTML)
            {
                Regex re = new Regex("<[^>]*>");
                content = re.Replace(content, "");
                content = content.Replace("　", "").Replace(" ", "");
                if (content.Length <= length)
                    return content;
                else
                    return content.Substring(0, length) + "……";
            }
            else
            {
                if (content.Length <= length)
                    return content;

                int pos = 0, npos = 0, size = 0;
                bool firststop = false, notr = false, noli = false;
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    if (pos >= content.Length)
                        break;
                    string cur = content.Substring(pos, 1);
                    if (cur == "<")
                    {
                        string next = content.Substring(pos + 1, 3).ToLower();
                        if (next.IndexOf("p") == 0 && next.IndexOf("pre") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                        }
                        else if (next.IndexOf("/p") == 0 && next.IndexOf("/pr") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br/>");
                        }
                        else if (next.IndexOf("br") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br/>");
                        }
                        else if (next.IndexOf("img") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                                size += npos - pos + 1;
                            }
                        }
                        else if (next.IndexOf("li") == 0 || next.IndexOf("/li") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!noli && next.IndexOf("/li") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    noli = true;
                                }
                            }
                        }
                        else if (next.IndexOf("tr") == 0 || next.IndexOf("/tr") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr && next.IndexOf("/tr") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    notr = true;
                                }
                            }
                        }
                        else if (next.IndexOf("td") == 0 || next.IndexOf("/td") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                }
                            }
                        }
                        else
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        if (npos <= pos)
                            npos = pos + 1;
                        pos = npos;
                    }
                    else
                    {
                        if (size < length)
                        {
                            sb.Append(cur);
                            size++;
                        }
                        else
                        {
                            if (!firststop)
                            {
                                sb.Append("……");
                                firststop = true;
                            }
                        }
                        pos++;
                    }

                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={  
                      @"<script[^>]*?>.*?</script>",  
                      @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(http://www.cnblogs.com/xchit/admin/file://[%22%22'tbnr]%7c[%5e/7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                      @"([\r\n])[\s]+",  
                      @"&(quot|#34);",  
                      @"&(amp|#38);",  
                      @"&(lt|#60);",  
                      @"&(gt|#62);",    
                      @"&(nbsp|#160);",    
                      @"&(iexcl|#161);",  
                      @"&(cent|#162);",  
                      @"&(pound|#163);",  
                      @"&(copy|#169);",  
                      @"&#(\d+);",  
                      @"-->",  
                      @"<!--.*\n"  
                    };

            string[] aryRep =   {  
                    "",  
                    "",  
                    "",  
                    "\"",  
                    "&",  
                    "<",  
                    ">",  
                    "   ",  
                    "\xa1",//chr(161),  
                    "\xa2",//chr(162),  
                    "\xa3",//chr(163),  
                    "\xa9",//chr(169),  
                    "",  
                    "\r\n",  
                    ""  
                    };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        } 

        /// <summary>
        /// 移除HTML标签
        /// </summary>
        /// <param name="HTMLStr"></param>
        /// <returns></returns>
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }   

        /// <summary>
        /// 取出文本中的图片地址
        /// </summary>
        /// <param name="HTMLStr"></param>
        /// <returns></returns>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
                    RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }   
    }
}
