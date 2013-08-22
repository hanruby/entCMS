using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using System.Data;
using System.Text;
using entCMS.Common;
using System.IO;

namespace entCMS.Manage.Module
{
    public partial class ImageAdd : BasePage
    {
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        NewsService ns = NewsService.GetInstance();
        NewsTopicService nts = NewsTopicService.GetInstance();
        NewsTopicRelService ntrs = NewsTopicRelService.GetInstance();

        cmsNewsCatalog catalog = null;
        cmsNews news = null;
        cmsLanguage lang = null;

        protected string configFile = string.Empty;

        string id = "";
        string action = "";

        public ImageAdd()
            : base(PagePurviewType.PPT_NEWS)
        {
            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);
            if (lang != null)
            {
                configFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            catalog = ncs.Get(NodeCode);

            if (!IsPostBack)
            {
                InitControls();

                InitData();
            }
        }

        private void InitData()
        {
            news = ns.GetModel(id);
            if (news != null)
            {
                hidID.Value = news.Id.ToString();
                txtTitle.Text = news.Title;
                txtContent.Text = news.Content;
                txtSummary.Text = news.Summary;
                txtTags.Text = news.Tags;
                hidImages1.Value = news.SmallPic;
                txtAuthor.Text = news.Author;
                txtSource.Text = news.Source;
                txtHits.Text = news.Hits.ToString();
                txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ddlCatalog.SelectedValue = news.NodeCode;

                // 选中专题
                List<cmsNewsTopicRel> ls = ntrs.GetList(cmsNewsTopicRel._.NewsId == news.Id, null);
                foreach (cmsNewsTopicRel r in ls)
                {
                    foreach (ListItem item in cblZt.Items)
                    {
                        if (item.Value == r.TopicId.ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            else
            {
                ddlCatalog.SelectedValue = NodeCode;

                txtAuthor.Text = LoginUser.Name;
            }
        }

        private void InitControls()
        {
            txtTime.Attributes.Add("readonly", "true");
            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            List<cmsNewsCatalog> catalogs = ncs.GetCatalogs(CurrentLanguageId, 0, 3);
            //List<cmsNewsCatalog> catalogs = ncs.GetCatalogs(CurrentLanguageId);
            List<cmsNewsCatalog> newsCatalogs = catalogs.FindAll(c => (c.ParentCode == "0000"));

            foreach (cmsNewsCatalog item in newsCatalogs)
            {
                if (IsAdmin || PurviewExists(item.NodeCode, 0))
                {
                    var c = new ListItem(item.NodeName, item.NodeCode);
                    ddlCatalog.Items.Add(c);

                    List<cmsNewsCatalog> childs = catalogs.FindAll(m => m.ParentCode == item.NodeCode);
                    if (childs.Count > 0)
                    {
                        buildNewsCatalogTree(ddlCatalog, catalogs, item.NodeCode, childs, "");
                    }
                    else
                    {
                        if (item.NodeType == 0) ddlCatalog.Items.Remove(c);
                    }
                }
            }

            List<cmsNewsTopic> ls = nts.GetList(cmsNewsTopic._.IsEnabled == true, cmsNewsTopic._.SortNo.Asc);

            cblZt.DataTextField = "Name";
            cblZt.DataValueField = "Id";
            cblZt.DataSource = ls;
            cblZt.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="catalogs"></param>
        /// <param name="purviews"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildNewsCatalogTree(DropDownList ddl, List<cmsNewsCatalog> catalogs, string parentCode, List<cmsNewsCatalog> childs, string prefix)
        {
            string pf = "";

            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];
                if (IsAdmin || PurviewExists(item.NodeCode, 0))
                {
                    ListItem itm = new ListItem();
                    itm.Value = item.NodeCode;
                    if (i < childs.Count - 1)
                    {
                        itm.Text = prefix + "├" + item.NodeName;
                        pf = prefix + "│";
                    }
                    else
                    {
                        itm.Text = prefix + "└" + item.NodeName;
                        pf = prefix + "　"; // 全角空格[　]制表符[│][├][└]
                    }
                    ddl.Items.Add(itm);

                    List<cmsNewsCatalog> children = catalogs.FindAll(m => m.ParentCode == item.NodeCode);
                    if (children.Count > 0)
                    {
                        buildNewsCatalogTree(ddl, catalogs, item.NodeCode, children, pf);
                    }
                    else
                    {
                        if (item.NodeType == 0) ddlCatalog.Items.Remove(itm);
                    }
                }


            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHits.Text.Trim())) txtHits.Text = "0";

            DateTime dt;
            if (!DateTime.TryParse(txtTime.Text.Trim(), out dt))
            {
                dt = DateTime.Now;
            }

            if (action.Equals("add"))
            {
                news = new cmsNews();

                news.RGuid = Guid.NewGuid().ToString();
                news.AddUser = LoginUser.Id;
                news.AddTime = DateTime.Now;

                news.IsIndex = 0;
                news.IsTop = 0;
            }
            else
            {
                news = ns.GetModel(id);
                news.Attach();
            }
            news.NodeCode = ddlCatalog.SelectedValue;
            news.Title = txtTitle.Text.Trim();
            news.Content = txtContent.Text.Trim();
            news.Summary = txtSummary.Text.Trim();
            news.Tags = txtTags.Text.Trim();
            news.SmallPic = hidImages1.Value;
            news.Author = txtAuthor.Text;
            news.Source = txtSource.Text;
            news.Hits = Convert.ToInt32(txtHits.Text);
            news.OrderNo = 0;
            news.EditUser = LoginUser.Id;
            news.EditTime = dt;
            news.IsAudit = 0;
            if (true)//WebConfig.NoAudit
            {
                news.IsAudit = 1;
                news.AuditUser = LoginUser.Id;
                news.AuditTime = DateTime.Now;

                news.IsIndex = 1;
            }
            news.LangId = CurrentLanguageId;
            List<int> ztList = new List<int>();
            foreach (ListItem item in cblZt.Items)
            {
                if (item.Selected)
                {
                    ztList.Add(Convert.ToInt32(item.Value));
                }
            }
            try
            {
                int r = ns.Save(news);

                ntrs.Save(news.RGuid, ztList.ToArray());

                if (action.Equals("add"))
                {

                    ScriptUtil.ConfirmAndRedirect(@"图片添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "ImageAdd.aspx?node=" + NodeCode, "ImageList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"图片修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "ImageAdd.aspx?node=" + NodeCode + "&id=" + id + "&action=edit", "ImageList.aspx?node=" + NodeCode);
                }

            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ImageHelper.WaterMarkInfo getWatermarkInfo()
        {
            string addWatermark = ConfigHelper.GetVal(configFile, "AddWaterMark");

            int add = 0;
            if (addWatermark.Contains("|1|") && addWatermark.Contains("|2|")) add = 3;
            else if (addWatermark.Contains("|2|")) add = 2;
            else if (addWatermark.Contains("|1|")) add = 1;
            else add = 0;
            int watermarkType = ConfigHelper.GetVal<int>(configFile, "WaterMarkType");
            string watermarkImage = ConfigHelper.GetVal(configFile, "WaterMarkImg");
            watermarkImage = Server.MapPath(watermarkImage);
            if (!File.Exists(watermarkImage)) addWatermark = addWatermark.Replace("|1|", "");
            string thumbnailWatermarkImage = ConfigHelper.GetVal(configFile, "ThumbnailWaterMarkImg");
            thumbnailWatermarkImage = Server.MapPath(thumbnailWatermarkImage);
            if (!File.Exists(thumbnailWatermarkImage)) addWatermark = addWatermark.Replace("|2|", "");
            string watermarkText = ConfigHelper.GetVal(configFile, "WaterMarkText");
            string watermarkTextFont = ConfigHelper.GetVal(configFile, "WaterMarkTextFont");
            watermarkTextFont = Server.MapPath(watermarkTextFont);
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
    }
}