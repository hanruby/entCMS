using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Collections;
using System.Globalization;

namespace entCMS.Common
{
    public class ImageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public enum WatermarkPosition
        {
            WM_TOP_LEFT         = 1,
            WM_TOP_CENTER       = 2,
            WM_TOP_RIGHT        = 3,
            WM_MIDDLE_LEFT      = 4,
            WM_MIDDLE_CENTER    = 5,
            WM_MIDDLE_RIGHT     = 6,
            WM_BOTTOM_LEFT      = 7,
            WM_BOTTOM_CENTER    = 8,
            WM_BOTTOM_RIGHT     = 9,
        }
        /// <summary>
        /// 
        /// </summary>
        public enum WatermarkType
        {
            WM_NONE = 0,
            WM_TEXT,
            WM_IMAGE,
        }
        /// <summary>
        /// 
        /// </summary>
        public enum CreateThumbnailMode
        {
            CTM_NONE = 0,
            CTM_WIDTH_HEIGHT,       //指定高宽缩放（可能变形） 
            CTM_WIDTH,              //指定宽，高按比例  
            CTM_HEIGHT,             //指定高，宽按比例
            CTM_CUT                 //指定高宽裁减（不变形） 
        }
        /// <summary>
        /// 上传文件返回值
        /// </summary>
        public enum UploadStatus
        {
            US_NOT_FOUND = 0,   // 上传文件不存在
            US_TOO_LONG,        // 文件太大
            US_NOT_SUPPORT,     // 格式不支持
            US_FAILED,          // 上传不成功
            US_SUCCESSED        // 上传成功
        }
        /// <summary>
        /// 水印相关属性
        /// </summary>
        public class WaterMarkInfo
        {
            private int _addwatermark = 0;
            /// <summary>
            /// 需要增加水印的图片
            /// 0：none，1：大图，2：小图，3：大小图
            /// </summary>
            public int AddWatermark
            {
                get { return _addwatermark; }
                set { _addwatermark = value; }
            }
            private WatermarkType _watermarkType = WatermarkType.WM_NONE;
            /// <summary>
            /// 水印类型
            /// </summary>
            public WatermarkType WatermarkType
            {
                get { return _watermarkType; }
                set { _watermarkType = value; }
            }

            private string _watermarkImage = "";
            /// <summary>
            /// 大图水印图片
            /// </summary>
            public string WatermarkImage
            {
                get { return _watermarkImage; }
                set { _watermarkImage = value; }
            }
            private string _thumbnailWatermarkImage = "";
            /// <summary>
            /// 小图水印图片
            /// </summary>
            public string ThumbnailWatermarkImage
            {
                get { return _thumbnailWatermarkImage; }
                set { _thumbnailWatermarkImage = value; }
            }
            private string _watermarkText = "";
            /// <summary>
            /// 水印文字
            /// </summary>
            public string WatermarkText
            {
                get { return _watermarkText; }
                set { _watermarkText = value; }
            }
            private string _watermarkFont = "";
            /// <summary>
            /// 水印文字字体
            /// </summary>
            public string WatermarkTextFont
            {
                get { return _watermarkFont; }
                set { _watermarkFont = value; }
            }
            private float _watermarkTextFontSize = 35;
            /// <summary>
            /// 大图水印文字大小
            /// </summary>
            public float WatermarkTextFontSize
            {
                get { return _watermarkTextFontSize; }
                set { _watermarkTextFontSize = value; }
            }
            private float _thumbnailWatermarkTextFontSize = 10;
            /// <summary>
            /// 小图水印文字大小
            /// </summary>
            public float ThumbnailWatermarkTextFontSize
            {
                get { return _thumbnailWatermarkTextFontSize; }
                set { _thumbnailWatermarkTextFontSize = value; }
            }
            private string _watermarkTextColor = "#000000";
            /// <summary>
            /// 水印文字颜色
            /// </summary>
            public string WatermarkTextColor
            {
                get { return _watermarkTextColor; }
                set { _watermarkTextColor = value; }
            }
            private float _watermarkAngle = 0.0f;
            /// <summary>
            /// 水印角度
            /// </summary>
            public float WatermarkAngle
            {
                get { return _watermarkAngle; }
                set { _watermarkAngle = value; }
            }
            private float _watermarkAlpha = 0.5f;
            /// <summary>
            /// 水印透明度，从0-1
            /// </summary>
            public float WatermarkAlpha
            {
                get { return _watermarkAlpha; }
                set { _watermarkAlpha = value; }
            }

            private WatermarkPosition _watermarkPosition = WatermarkPosition.WM_MIDDLE_CENTER;
            /// <summary>
            /// 水印位置
            /// </summary>
            public WatermarkPosition WatermarkPosition
            {
                get { return _watermarkPosition; }
                set { _watermarkPosition = value; }
            }
        }
        private WaterMarkInfo _watermarkInfo = null;
        /// <summary>
        /// 水印信息
        /// </summary>
        public WaterMarkInfo WatermarkInfo
        {
            get { return (_watermarkInfo == null) ? new WaterMarkInfo() { AddWatermark = 0 } : _watermarkInfo; }
            set { _watermarkInfo = value; }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public bool CreateThumbnail(string originalImagePath, string thumbnailPath, int width, int height, CreateThumbnailMode mode)
        {
            bool ret = true;
            Image originalImage = Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case CreateThumbnailMode.CTM_WIDTH_HEIGHT://指定高宽缩放（可能变形）                
                    break;
                case CreateThumbnailMode.CTM_WIDTH://指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case CreateThumbnailMode.CTM_HEIGHT://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case CreateThumbnailMode.CTM_CUT://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                //throw e;
                ret = false;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

            return ret;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">原图片地址</param>
        /// <param name="thumbnailPath">新图片地址</param>
        /// <param name="tWidth">缩略图的宽</param>
        /// <param name="tHeight">缩略图的高</param>
        public void CreateThumbnail(string originalImagePath, string thumbnailPath, int tWidth, int tHeight)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(originalImagePath);
                double bl = 1d;
                if ((image.Width <= image.Height) && (tWidth >= tHeight))
                {
                    bl = Convert.ToDouble(image.Height) / Convert.ToDouble(tHeight);
                }
                else if ((image.Width > image.Height) && (tWidth < tHeight))
                {
                    bl = Convert.ToDouble(image.Width) / Convert.ToDouble(tWidth);

                }
                else
                {

                    if ((image.Width <= image.Height) && (tWidth <= tHeight))
                    {
                        if (image.Height / tHeight >= image.Width / tWidth)
                        {
                            bl = Convert.ToDouble(image.Width) / Convert.ToDouble(tWidth);

                        }
                        else
                        {
                            bl = Convert.ToDouble(image.Height) / Convert.ToDouble(tHeight);
                        }
                    }
                    else
                    {
                        if (image.Height / tHeight >= image.Width / tWidth)
                        {
                            bl = Convert.ToDouble(image.Height) / Convert.ToDouble(tHeight);

                        }
                        else
                        {
                            bl = Convert.ToDouble(image.Width) / Convert.ToDouble(tWidth);

                        }

                    }
                }

                Bitmap b = new Bitmap(image, Convert.ToInt32(image.Width / bl), Convert.ToInt32(image.Height / bl));
                
                b.Save(thumbnailPath);
                b.Dispose();
                image.Dispose();

            }
            catch
            {


            }

        }
        /// <summary>
        /// 创建字体
        /// </summary>
        /// <param name="fontFile">字体文件</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns></returns>
        private Font createWatermarkFont(string fontFile, float fontSize)
        {
            Font font = null;
            
            if (!File.Exists(fontFile)) return new Font("arial", fontSize, FontStyle.Regular);

            System.Drawing.Text.PrivateFontCollection FM = new System.Drawing.Text.PrivateFontCollection();
            FM.AddFontFile(fontFile);
            FontFamily fontFamily = FM.Families[0];
            font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);

            return font;
        }
        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="WaterMarkPicPath">水印图片的地址</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="width">被加水印图片的宽</param>
        /// <param name="height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, string watermarkImg, WatermarkPosition pos, int width, int height)
        {
            if (!File.Exists(watermarkImg))
            {
                throw new FileNotFoundException("水印文件：" + watermarkImg + "不存在");
            }
            Image watermark = new Bitmap(watermarkImg);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = 
            {
                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;

            //计算水印图片的比率
            //取背景的1/4宽度来比较
            if ((width > watermark.Width * 4) && (height > watermark.Height * 4))
            {
                bl = 1;
            }
            else if ((width > watermark.Width * 4) && (height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(height / 4) / Convert.ToDouble(watermark.Height);
            }
            else
            {
                if ((width < watermark.Width * 4) && (height > watermark.Height * 4))
                {
                    bl = Convert.ToDouble(width / 4) / Convert.ToDouble(watermark.Width);
                }
                else
                {
                    if ((width * watermark.Height) > (height * watermark.Width))
                    {
                        bl = Convert.ToDouble(height / 4) / Convert.ToDouble(watermark.Height);

                    }
                    else
                    {
                        bl = Convert.ToDouble(width / 4) / Convert.ToDouble(watermark.Width);

                    }
                }
            }

            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

            switch (pos)
            {
                case WatermarkPosition.WM_TOP_LEFT:
                    xpos = 10;
                    ypos = 10;
                    break;
                case WatermarkPosition.WM_TOP_CENTER:
                    xpos = (width - WatermarkWidth) / 2;
                    ypos = 10;
                    break;
                case WatermarkPosition.WM_TOP_RIGHT:
                    xpos = width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case WatermarkPosition.WM_MIDDLE_LEFT:
                    xpos = 10;
                    ypos = (height - WatermarkHeight) / 2;
                    break;
                case WatermarkPosition.WM_MIDDLE_CENTER:
                    xpos = (width - WatermarkWidth) / 2;
                    ypos = (height - WatermarkHeight) / 2;
                    break;
                case WatermarkPosition.WM_MIDDLE_RIGHT:
                    xpos = width - WatermarkWidth - 10;
                    ypos = (height - WatermarkHeight) / 2;
                    break;
                case WatermarkPosition.WM_BOTTOM_LEFT:
                    xpos = 10;
                    ypos = height - WatermarkHeight - 10;
                    break;
                case WatermarkPosition.WM_BOTTOM_CENTER:
                    xpos = (width - WatermarkWidth) / 2;
                    ypos = height - WatermarkHeight - 10;
                    break;
                case WatermarkPosition.WM_BOTTOM_RIGHT:
                    xpos = width - WatermarkWidth - 10;
                    ypos = height - WatermarkHeight - 10;
                    break;
            }

            picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);


            watermark.Dispose();
            imageAttributes.Dispose();
        }

        /// <summary>
        ///  加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="watermarkText">水印文字内容</param>
        /// <param name="watermarkPosition">水印位置</param>
        /// <param name="width">被加水印图片的宽</param>
        /// <param name="height">被加水印图片的高</param>
        /// <param name="isBig">true:大图，false:小图</param>
        private void addWatermarkText(Graphics picture, string watermarkText, WatermarkPosition watermarkPosition, int width, int height, bool isBig)
        {
            Font crFont = null;
            SizeF crSize = new SizeF();

            //int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            //for (int i = 0; i < 7; i++)
            //{
            //    crFont = new Font("arial", sizes[i], FontStyle.Bold);
            //    crSize = picture.MeasureString(watermarkText, crFont);

            //    if ((ushort)crSize.Width < (ushort)width)  break;
            //}
            float size = 12.0f;
            if (isBig) size = WatermarkInfo.WatermarkTextFontSize;
            else size = WatermarkInfo.ThumbnailWatermarkTextFontSize;
            crFont = createWatermarkFont(WatermarkInfo.WatermarkTextFont, size);
            crSize = picture.MeasureString(watermarkText, crFont);

            float xpos = 0;
            float ypos = 0;

            switch (watermarkPosition)
            {
                case WatermarkPosition.WM_TOP_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.WM_TOP_CENTER:
                    xpos = ((float)width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.WM_TOP_RIGHT:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WatermarkPosition.WM_MIDDLE_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)height * (float).50) - crSize.Height / 2;
                    break;
                case WatermarkPosition.WM_MIDDLE_CENTER:
                    xpos = ((float)width / 2);
                    ypos = ((float)height * (float).50) - crSize.Height / 2;
                    break;
                case WatermarkPosition.WM_MIDDLE_RIGHT:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)height * (float).50) - crSize.Height / 2;
                    break;
                case WatermarkPosition.WM_BOTTOM_LEFT:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
                case WatermarkPosition.WM_BOTTOM_CENTER:
                    xpos = ((float)width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
                case WatermarkPosition.WM_BOTTOM_RIGHT:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
            }

            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            int alpha = Convert.ToInt32 ( 256 * WatermarkInfo.WatermarkAlpha ); 
            Color color = ColorTranslator.FromHtml(WatermarkInfo.WatermarkTextColor);
            Color color1 = Color.FromArgb(alpha, 0, 0, 0);
            Color color2 = Color.FromArgb(alpha, color.R, color.G, color.B);

            SolidBrush semiTransBrush2 = new SolidBrush(color2);
            picture.DrawString(watermarkText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(color1);
            picture.DrawString(watermarkText, crFont, semiTransBrush, xpos, ypos, StrFormat);

            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();

        }
        /// <summary>
        /// 添加图片水印
        /// </summary>
        /// <param name="oldpath">原图片绝对地址</param>
        /// <param name="newpath">新图片放置的绝对地址</param>
        /// <param name="isBig">true：大图，false：小图</param>
        public bool addWaterMark(string oldpath, string newpath, bool isBig)
        {
            bool isDelOldFile = true;
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(oldpath);

                Bitmap b = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(b);
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.High;

                g.DrawImage(image, 0, 0, image.Width, image.Height);

                try
                {
                    switch (WatermarkInfo.WatermarkType)
                    {
                        //是图片的话
                        case WatermarkType.WM_IMAGE:
                            string watermarkImg = isBig ? WatermarkInfo.WatermarkImage : WatermarkInfo.ThumbnailWatermarkImage;
                            this.addWatermarkImage(g, watermarkImg, WatermarkInfo.WatermarkPosition, image.Width, image.Height);
                            break;
                        //如果是文字                    
                        case WatermarkType.WM_TEXT:
                            this.addWatermarkText(g, WatermarkInfo.WatermarkText, WatermarkInfo.WatermarkPosition, image.Width, image.Height, isBig);
                            break;
                    }
                }
                catch (FileNotFoundException)  // 水印图片不存在
                {
                    isDelOldFile = false;
                }
                catch (Exception)
                {
                }
                finally
                {
                    b.Save(newpath);
                    b.Dispose();
                    image.Dispose();
                }
            }
            catch(Exception)
            {
            }
            finally
            {
                if (isDelOldFile && File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }

            return isDelOldFile;
        }
        /// <summary>
        /// 添加图片水印
        /// </summary>
        /// <param name="oldpath">原图片绝对地址</param>
        /// <param name="newpath">新图片放置的绝对地址</param>
        /// <param name="waterType">水印类型</param>
        /// <param name="isBig">true：大图，false：小图</param>
        public void addWaterMark(string oldpath, string newpath, WatermarkPosition watermarkPos, WatermarkType waterType, bool isBig)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(oldpath);

                Bitmap b = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(b);
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.High;

                g.DrawImage(image, 0, 0, image.Width, image.Height);


                switch (waterType)
                {
                    //是图片的话               
                    case WatermarkType.WM_IMAGE:
                        this.addWatermarkImage(g, WatermarkInfo.WatermarkImage, watermarkPos, image.Width, image.Height);
                        break;
                    //如果是文字                    
                    case WatermarkType.WM_TEXT:
                        this.addWatermarkText(g, WatermarkInfo.WatermarkText, watermarkPos, image.Width, image.Height, isBig);
                        break;
                }

                b.Save(newpath);
                b.Dispose();
                image.Dispose();

            }
            catch
            {

                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
            finally
            {

                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
        }

        /// <summary>
        /// 上传图片，只有在宽度>0且高度>0时创建缩略图
        /// </summary>
        /// <param name="imgFile">上传控件</param>
        /// <param name="maxSize">最大上传文件大小（单位：M）</param>
        /// <param name="thumbnailWidth">缩略图宽度</param>
        /// <param name="thumbnailHeight">缩略图高度</param>
        /// <param name="mode">创建缩略图方式</param>
        /// <param name="imgUrl">返回的图片链接</param>
        /// <returns></returns>
        public UploadStatus UploadImage(HttpPostedFile imgFile, int maxSize, int thumbnailWidth, int thumbnailHeight, CreateThumbnailMode mode, ref string imgUrl)
        {
            if (imgFile == null || string.IsNullOrEmpty(imgFile.FileName))
            {
                return UploadStatus.US_NOT_FOUND;
            }
            else
            {
                try
                {
                    HttpContext context = HttpContext.Current;
                    string appPath = context.Request.ApplicationPath;
                    if (!appPath.EndsWith("/")) appPath += "/";

                    string uploadPath = ConfigurationManager.AppSettings["UploadPath"];
                    if (string.IsNullOrEmpty(uploadPath))
                    {
                        uploadPath = "~/Files/";
                    }
                    if (uploadPath.StartsWith("~/"))
                    {
                        uploadPath = appPath + uploadPath.Substring(2);
                    }
                    else if (uploadPath.StartsWith("/"))
                    {
                        uploadPath = appPath + uploadPath.Substring(1);
                    }
                    else
                    {
                        uploadPath = appPath + uploadPath;
                    }
                    if (!uploadPath.EndsWith("/")) uploadPath += "/";

                    //文件保存目录路径
                    string savePath = context.Server.MapPath(uploadPath);

                    //文件保存目录URL
                    string saveUrl = uploadPath;


                    //定义允许上传的文件扩展名
                    Hashtable extTable = new Hashtable();
                    extTable.Add("image", "gif,jpg,jpeg,png,bmp");

                    //最大文件大小
                    //int maxSize = 5; //5M
                    //string fileMaxSize = ConfigurationManager.AppSettings["FileMaxSize"];
                    //if (!string.IsNullOrEmpty(fileMaxSize))
                    //    maxSize = Convert.ToInt32(fileMaxSize);
                    if (maxSize < 1) maxSize = 5;
                    maxSize = maxSize * 1024 * 1024;

                    string dirPath = savePath;
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string dirName = "image";

                    string fileName = imgFile.FileName;
                    string fileExt = Path.GetExtension(fileName).ToLower();

                    if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
                    {
                        //上传文件大小超过限制
                        return UploadStatus.US_TOO_LONG;
                    }

                    if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                    {
                        //上传文件扩展名是不允许的扩展名。
                        return UploadStatus.US_NOT_SUPPORT;
                    }

                    //创建文件夹
                    dirPath += dirName + "\\";
                    saveUrl += dirName + "/";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                    dirPath += ymd + "\\";
                    saveUrl += ymd + "/";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff_b", DateTimeFormatInfo.InvariantInfo) + fileExt;
                    string filePath = dirPath + newFileName;

                    imgFile.SaveAs(filePath);

                    string thumbnailFile = newFileName.Replace("_b", "_s");
                    string thumbnailFilePath = dirPath + thumbnailFile;
                    if (mode != CreateThumbnailMode.CTM_NONE && (thumbnailWidth > 0 && thumbnailHeight > 0))
                    {
                        // 生成缩略图
                        CreateThumbnail(filePath, thumbnailFilePath, thumbnailWidth, thumbnailHeight, mode);
                    }
                    // 添加水印
                    if (WatermarkInfo.AddWatermark == 1 || WatermarkInfo.AddWatermark == 3)
                    {
                        newFileName = "w_" + newFileName;
                        addWaterMark(filePath, dirPath + newFileName, true);
                    }
                    if (WatermarkInfo.AddWatermark == 2 || WatermarkInfo.AddWatermark == 3)
                    {
                        thumbnailFile = "w_" + thumbnailFile;
                        addWaterMark(thumbnailFilePath, dirPath + thumbnailFile, false);
                    }
                    // 返回图片链接
                    imgUrl = saveUrl + newFileName;

                    return UploadStatus.US_SUCCESSED;
                }
                catch
                {
                    return UploadStatus.US_FAILED;
                }
            }
        }
        /*
        public bool UpPic(System.Web.UI.HtmlControls.HtmlInputFile image_file, string ImgPath, string ImgLink)
        {
            if (image_file.PostedFile.FileName != null && image_file.PostedFile.FileName.Trim() != "")
            {
                try
                {
                    if (!System.IO.Directory.Exists(ImgPath))
                    {
                        System.IO.Directory.CreateDirectory(ImgPath);
                    }
                    //生成缩略图
                    this.CreateThumbnail((ImgPath + "\\" + "old_" + ImgLink), (ImgPath + "\\" + "mini_" + ImgLink), 50, 50);
                    //如果显示水印
                    if (ShowWatermark)
                    {
                        image_file.PostedFile.SaveAs(ImgPath + "\\" + "old_" + ImgLink);
                        //加水印
                        this.addWaterMark((ImgPath + "\\" + "old_" + ImgLink), (ImgPath + "\\" + ImgLink));
                    }
                    else
                    {
                        image_file.PostedFile.SaveAs(ImgPath + "\\" + ImgLink);
                    }
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        */
    }
}