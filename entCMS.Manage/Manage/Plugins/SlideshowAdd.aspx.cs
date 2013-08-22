using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using entCMS.Common;

namespace entCMS.Manage.Plugins
{
    public partial class SlideshowAdd : BasePage
    {
        SlideshowService ss = SlideshowService.GetInstance();
        cmsSlideshow mdl = null;

        string id = "";
        string action = "";
        public SlideshowAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            if (!IsPostBack)
            {
                InitControls();

                InitData();
            }
        }

        private void InitControls()
        {
        }

        private void InitData()
        {
            mdl = ss.GetModel(id);
            if (null != mdl)
            {
                txtTitle.Text = mdl.Title;
                txtSummary.Text = mdl.Summary;
                txtImgSrc.Text = mdl.ImgSrc;
                txtImgThumb.Text = mdl.ImgThumb;
                txtUrl.Text = mdl.Url;
                ddlTarget.SelectedValue = mdl.Target;
                txtOrder.Text = mdl.OrderNo.ToString();
                chkEnabled.Checked = mdl.IsEnabled == 1;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";
            if (action.Equals("add"))
            {
                mdl = new cmsSlideshow();
                mdl.AddTime = DateTime.Now;
            }
            else
            {
                mdl = ss.GetModel(id);
                if (mdl != null)
                {
                    mdl.Attach();
                }
            }
            mdl.LangId = CurrentLanguageId;
            mdl.Title = txtTitle.Text;
            mdl.Summary = txtSummary.Text;
            mdl.ImgSrc = txtImgSrc.Text;
            mdl.ImgThumb = txtImgThumb.Text;
            mdl.Url = txtUrl.Text;
            mdl.Target = ddlTarget.SelectedValue;
            mdl.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            mdl.IsEnabled = chkEnabled.Checked ? 1 : 0;
            try
            {
                int r = ss.SaveModel(mdl);

                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"幻灯片添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "SlideshowAdd.aspx?node=" + NodeCode, "SlideshowList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"幻灯片修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "SlideshowAdd.aspx?node=" + NodeCode + "&id=" + id + "&action=" + action, "SlideshowList.aspx?node=" + NodeCode);
                }
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }
    }
}