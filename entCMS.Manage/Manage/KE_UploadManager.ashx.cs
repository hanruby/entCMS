using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using LitJson;
using entCMS.Common;
using System.Configuration;

namespace entCMS.Manage
{
    /// <summary>
    /// KE_UploadManager 的摘要说明
    /// </summary>
    public class KE_UploadManager : IHttpHandler
    {
        private HttpContext context;
        private string configFile = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;

            this.configFile = context.Request["configFile"];        // 配置文件
            string action = this.context.Request["Action"];         // 操作名称
            string type = context.Request["type"];                  // 类别
            string dirName = context.Request["dir"];                // 路径 = 类别
            HttpPostedFile file = context.Request.Files["imgFile"]; // 上传的文件
            string fileMaxSize = ConfigHelper.GetVal("FileMaxSize"); // 最大文件大小

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "rtf,txt,doc,docx,xls,xlsx,ppt,pptx,pdf,zip,rar,gz,bz2");

            if (file == null)
            {
                showError("请选择文件。");
            }

            string uploadUrl = GetUploadUrl();

            //文件保存目录URL
            string saveUrl = uploadUrl;
            //文件保存目录路径
            string savePath = context.Server.MapPath(uploadUrl);

            //最大文件大小
            int maxSize = 5; //5M            
            if (!string.IsNullOrEmpty(fileMaxSize)) maxSize = Convert.ToInt32(fileMaxSize);
            maxSize = maxSize * 1024 * 1024;
            // 上传文件大小是否超过限制
            if (file.InputStream == null || file.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            string fileName = file.FileName;
            // 获取扩展名
            string fileExt = Path.GetExtension(fileName).ToLower();
            // 上传文件是否为允许的文件类型
            if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((string)extTable[dirName]) + "格式。");
            }

            if (!Directory.Exists(savePath))
            {
                //showError("上传目录不存在。");
                Directory.CreateDirectory(savePath);
            }

            if (string.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                showError("目录名不正确。");
            }


            //创建文件夹
            savePath += dirName + "\\";
            saveUrl += dirName + "/";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            savePath += ymd + "\\";
            saveUrl += ymd + "/";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            // 新文件名
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff_b", DateTimeFormatInfo.InvariantInfo) + fileExt;
            // 新文件的完成路径
            string filePath = savePath + newFileName;
            // 保存
            file.SaveAs(filePath);

            // 需要返回的文件
            string fileUrl = saveUrl + newFileName;

            // 如果是图片文件
            if (!string.IsNullOrEmpty(configFile) &&
                !string.IsNullOrEmpty(dirName) && 
                dirName.Equals("image") && 
                IsRealImage(file))
            {
                string thumbnailFile = newFileName.Replace("_b", "_s");
                string thumbnailFilePath = savePath + thumbnailFile;

                int thumbnailWidth = 0, thumbnailHeight = 0;
                int t = 0;
                if (!int.TryParse(type, out t))
                {
                    t = 0;
                }
                switch (t)
                {
                    case 1://1：图文
                    case 2://2：产品
                        thumbnailWidth = ConfigHelper.GetVal<int>(configFile, "NewsThumbnailWidth");
                        thumbnailHeight = ConfigHelper.GetVal<int>(configFile, "NewsThumbnailHeight");
                        break;
                    case 3://3：图片
                        thumbnailWidth = ConfigHelper.GetVal<int>(configFile, "ImageThumbnailWidth");
                        thumbnailHeight = ConfigHelper.GetVal<int>(configFile, "ImageThumbnailHeight");
                        break;
                    case 4://4：产品
                        thumbnailWidth = ConfigHelper.GetVal<int>(configFile, "ProductThumbnailWidth");
                        thumbnailHeight = ConfigHelper.GetVal<int>(configFile, "ProductThumbnailHeight");
                        break;
                }
                thumbnailWidth = (thumbnailWidth == 0) ? 200 : thumbnailWidth;
                thumbnailHeight = (thumbnailHeight == 0) ? 200 : thumbnailHeight;

                ImageHelper.CreateThumbnailMode mode = ImageHelper.CreateThumbnailMode.CTM_NONE;
                int m = ConfigHelper.GetVal<int>(configFile, "CreateThumbnailMode");
                mode = (ImageHelper.CreateThumbnailMode)m;

                ImageHelper imgHelper = new ImageHelper();
                imgHelper.WatermarkInfo = getWatermarkInfo();

                bool ret = true;
                if (mode != ImageHelper.CreateThumbnailMode.CTM_NONE && (thumbnailWidth > 0 && thumbnailHeight > 0))
                {
                    // 生成缩略图
                    ret = imgHelper.CreateThumbnail(filePath, thumbnailFilePath, thumbnailWidth, thumbnailHeight, mode);
                    if(ret) fileUrl = saveUrl + thumbnailFile;
                }
                // 添加水印
                if (imgHelper.WatermarkInfo.AddWatermark == 1 || imgHelper.WatermarkInfo.AddWatermark == 3)
                {
                    newFileName = "w_" + newFileName;
                    ret = imgHelper.addWaterMark(filePath, savePath + newFileName, true);
                    if (ret) fileUrl = saveUrl + newFileName;
                }
                if (imgHelper.WatermarkInfo.AddWatermark == 2 || imgHelper.WatermarkInfo.AddWatermark == 3)
                {
                    thumbnailFile = "w_" + thumbnailFile;
                    ret = imgHelper.addWaterMark(thumbnailFilePath, savePath + thumbnailFile, false);
                    if (ret) fileUrl = saveUrl + thumbnailFile;
                }
            }

            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["name"] = fileName;
            hash["ext"] = fileExt;
            hash["size"] = file.ContentLength;
            hash["url"] = fileUrl;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            if (action == "swfupload") // 如果是swfupload的请求，则直接返回文件路径
            {
                context.Response.Write(fileUrl);
            }
            else
            {
                context.Response.Write(JsonMapper.ToJson(hash));
            }
            context.Response.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ImageHelper.WaterMarkInfo getWatermarkInfo()
        {            
            if (string.IsNullOrEmpty(configFile)) 
                return new ImageHelper.WaterMarkInfo() { AddWatermark = 0 };
            
            string addWatermark = ConfigHelper.GetVal(configFile, "AddWaterMark");

            int add = 0;
            if (addWatermark.Contains("|1|") && addWatermark.Contains("|2|")) add = 3;
            else if (addWatermark.Contains("|2|")) add = 2;
            else if (addWatermark.Contains("|1|")) add = 1;
            else add = 0;
            int watermarkType = ConfigHelper.GetVal<int>(configFile, "WaterMarkType");
            string watermarkImage = ConfigHelper.GetVal(configFile, "WaterMarkImg");
            watermarkImage = context.Server.MapPath(watermarkImage);
            if (!File.Exists(watermarkImage)) addWatermark = addWatermark.Replace("|1|", "");
            string thumbnailWatermarkImage = ConfigHelper.GetVal(configFile, "ThumbnailWaterMarkImg");
            thumbnailWatermarkImage = context.Server.MapPath(thumbnailWatermarkImage);
            if (!File.Exists(thumbnailWatermarkImage)) addWatermark = addWatermark.Replace("|2|", "");
            string watermarkText = ConfigHelper.GetVal(configFile, "WaterMarkText");
            string watermarkTextFont = ConfigHelper.GetVal(configFile, "WaterMarkTextFont");
            watermarkTextFont = context.Server.MapPath(watermarkTextFont);
            float watermarkTextFontSize = ConfigHelper.GetVal<float>(configFile, "WaterMarkTextFontSize");
            float thumbnailWatermarkTextFontSize = ConfigHelper.GetVal<float>(configFile, "ThumbnailWaterMarkTextFontSize");
            string watermarkTextColor = ConfigHelper.GetVal(configFile, "WaterMarkTextColor");
            float watermarkAngle = ConfigHelper.GetVal<float>(configFile, "WaterMarkAngle");
            float watermarkAlpha = ConfigHelper.GetVal<float>(configFile, "WaterMarkAlpha");
            int watermarkPosition = ConfigHelper.GetVal<int>(configFile, "WaterMarkPosition");

            ImageHelper.WaterMarkInfo wmInfo = new ImageHelper.WaterMarkInfo();
            wmInfo.AddWatermark = add;
            wmInfo.WatermarkType = (ImageHelper.WatermarkType)watermarkType;
            wmInfo.WatermarkImage = watermarkImage;
            wmInfo.ThumbnailWatermarkImage = thumbnailWatermarkImage;
            wmInfo.WatermarkText = watermarkText;
            wmInfo.WatermarkTextFont = watermarkTextFont;
            wmInfo.WatermarkTextFontSize = watermarkTextFontSize;
            wmInfo.ThumbnailWatermarkTextFontSize = thumbnailWatermarkTextFontSize;
            wmInfo.WatermarkTextColor = watermarkTextColor;
            wmInfo.WatermarkAngle = watermarkAngle;
            wmInfo.WatermarkAlpha = watermarkAlpha;
            wmInfo.WatermarkPosition = (ImageHelper.WatermarkPosition)watermarkPosition;

            return wmInfo;
        }

        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(hash));
            context.Response.End();
        }

        /// <summary>
        /// 获取顶层上传路径的Url
        /// </summary>
        /// <returns></returns>
        private string GetUploadUrl()
        {
            string appPath = context.Request.ApplicationPath;
            if (!appPath.EndsWith("/")) appPath += "/";

            string uploadPath = ConfigHelper.GetVal("UploadPath");
            if (string.IsNullOrEmpty(uploadPath)) // 如果没有设置上传路径，则指定为默认路径
            {
                uploadPath = "~/Files/";
            }
            if (uploadPath.StartsWith("~")) // 去掉相对路径的替代符(~)
            {
                uploadPath = uploadPath.Substring(1);
            }
            if (uploadPath.StartsWith("/"))
            {
                uploadPath = appPath + uploadPath.Substring(1);
            }
            else
            {
                uploadPath = appPath + uploadPath;
            }
            if (!uploadPath.EndsWith("/")) uploadPath += "/";

            return uploadPath;
        }
        /// <summary>
        /// 是否为真实的图片文件
        /// </summary>
        /// <param name="hpfile"></param>
        /// <returns></returns>
        private bool IsRealImage(HttpPostedFile hpfile)
        {
            bool ret = false;
            
            System.IO.BinaryReader r = new System.IO.BinaryReader(hpfile.InputStream);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                fileclass = buffer.ToString();
                buffer = r.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
                return false;
            }
            r.Close();
            /*文件扩展名说明
                *7173        gif 
                *255216      jpg
                *13780       png
                *6677        bmp
            */
            String[] fileType = { "255216", "7173", "6677", "13780" };

            ret = Array.IndexOf(fileType, fileclass) >= 0;

            return ret;
        }
        /// <summary>
        /// 检测上传文件的真实类型
        /// </summary>
        /// <param name="hpfile"></param>
        /// <returns></returns>
        private bool IsAllowedExtension(HttpPostedFile hpfile)
        {
            bool ret = false;

            System.IO.FileStream fs = new System.IO.FileStream(hpfile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                fileclass = buffer.ToString();
                buffer = r.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
                return false;
            }
            r.Close();
            fs.Close();

            /*文件扩展名说明
                *7173        gif 
                *255216      jpg
                *13780       png
                *6677        bmp
                *239187      txt,aspx,asp,sql
                *208207      xls.doc.ppt
                *6063        xml
                *6033        htm,html
                *4742        js
                *8075        xlsx,zip,pptx,mmap,zip
                *8297        rar   
                *01          accdb,mdb
                *7790        exe,dll           
                *5666        psd 
                *255254      rdp 
                *10056       bt种子 
                *64101       bat 
            */

            String[] fileType = { "255216", "7173", "6677", "13780", "8297", "5549", "870", "87111", "8075" };

            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        } 
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}