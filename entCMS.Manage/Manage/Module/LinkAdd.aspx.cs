using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;
using System.Configuration;

namespace entCMS.Manage.Module
{
    public partial class LinkAdd : BasePage
    {
        LinkService ls = LinkService.GetInstance();
        cmsLink link = null;

        string id = "";
        string action = "";
        public LinkAdd()
            : base(PagePurviewType.PPT_NEWS)
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
            List<cmsLinkGroup> types = LinkGroupService.GetInstance().GetList(CurrentLanguageId, 1);
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Id";
            ddlType.DataSource = types;
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("默认", "0"));
        }

        private void InitData()
        {
            link = ls.GetModel(id);
            if (null != link)
            {
                ddlType.SelectedValue = link.GroupId.ToString();
                txtName.Text = link.Name;
                txtUrl.Text = link.Url;
                txtLogo.Text = link.Logo;
                txtOrder.Text = link.OrderNo.ToString();
                chkEnabled.Checked = (link.IsEnabled.HasValue && link.IsEnabled == 1) ? true : false;
                txtMemo.Text = link.Remark;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";


            if (action.Equals("add"))
            {
                link = new cmsLink();
            }
            else
            {
                link = ls.GetModel(id);
                if (link != null)
                {
                    link.Attach();
                }
            }
            link.GroupId = Convert.ToInt64(ddlType.SelectedValue);
            link.Name = txtName.Text.Trim();
            link.Url = txtUrl.Text.Trim();
            link.Logo = txtLogo.Text;
            link.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            link.IsEnabled = chkEnabled.Checked ? 1 : 0;
            link.Remark = txtMemo.Text;
            link.LangId = CurrentLanguageId;
            try
            {
                int r = ls.SaveModel(link);

                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"链接添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "LinkAdd.aspx?node=" + NodeCode, "LinkList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"链接修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "LinkAdd.aspx?node=?" + NodeCode + "&id=" + id + "&action=edit", "LinkList.aspx?node=" + NodeCode);
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