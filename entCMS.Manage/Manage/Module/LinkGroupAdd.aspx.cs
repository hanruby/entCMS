using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage.Module
{
    public partial class LinkGroupAdd : BasePage
    {
        LinkGroupService lts = LinkGroupService.GetInstance();
        cmsLinkGroup linkGroup = null;

        string id = "";
        string action = "";

        public LinkGroupAdd()
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
                InitData();
            }
        }

        private void InitData()
        {
            linkGroup = lts.GetModel(id);

            if (null != linkGroup)
            {
                txtName.Text = linkGroup.Name;
                txtOrder.Text = linkGroup.OrderNo.ToString();
                chkEnabled.Checked = linkGroup.IsEnabled.HasValue ? linkGroup.IsEnabled.Value == 1 : false ;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";

            
            if (action.Equals("add"))
            {
                linkGroup = new cmsLinkGroup();
            }
            else
            {
                linkGroup = lts.GetModel(id);
                linkGroup.Attach();
            }

            linkGroup.Name = txtName.Text.Trim();
            linkGroup.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            linkGroup.IsEnabled = chkEnabled.Checked ? 1 : 0;
            linkGroup.LangId = CurrentLanguageId;
            try
            {
                int r = lts.SaveModel(linkGroup);

                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"链接类别添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "LinkGroupAdd.aspx?node=" + NodeCode, "LinkGroupList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"链接类别修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "LinkGroupAdd.aspx?node=" + NodeCode + "&id" + id + "&action=" + action, "LinkGroupList.aspx?node=" + NodeCode);
                }
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (CurrentLanguageId == 0)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}