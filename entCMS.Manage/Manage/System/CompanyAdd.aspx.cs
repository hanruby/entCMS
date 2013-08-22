using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class CompanyAdd : BasePage
    {
        CompanyService cs = CompanyService.GetInstance();
        cmsCompany com = null;

        string id = "";
        string action = "";

        public CompanyAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = (string.IsNullOrEmpty(Request["action"])) ? "add" : Request["action"];

            if (!IsPostBack)
            {
                LangBind();

                InitData();
            }
        }

        private void LangBind()
        {
            List<cmsLanguage> ls = LanguageService.GetInstance().GetLanguages();
            ddlLanguage.DataTextField = "Name";
            ddlLanguage.DataValueField = "Id";
            ddlLanguage.DataSource = ls;
            ddlLanguage.DataBind();
            ddlLanguage.Items.Insert(0, new ListItem("- 请选择 -", "0"));
        }

        private void InitData()
        {
            com = cs.GetModel(id);
            if (com != null)
            {
                hidID.Value = com.Id.ToString();

                txtName.Text = com.ComName;
                txtAddr.Text = com.ComAddr;
                txtZipCode.Text = com.ComZipcode;
                txtTel.Text = com.ComTel;
                txtFax.Text = com.ComFax;
                txtEmail.Text = com.ComEmail;
                txtUrl.Text = com.ComUrl;
                txtSummary.Text = com.Summary;
                ddlLanguage.SelectedValue = com.LangId.ToString();
            }
            else
            {
                ddlLanguage.SelectedValue = CurrentLanguageId.ToString();
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            long lngId = long.Parse(ddlLanguage.SelectedValue);
            if (lngId == 0)
            {
                ScriptUtil.Alert("请先选择所属语言");
                return;
            }
            if (action.Equals("add"))
            {
                if (cs.Exists(lngId))
                {
                    ScriptUtil.Alert("该语言下已有公司信息不能再次添加");
                    return;
                }
                com = new cmsCompany();
            }
            else
            {
                com = cs.GetModel(id);
                com.Attach();
            }

            com.LangId = lngId;
            com.ComName = txtName.Text;
            com.ComAddr = txtAddr.Text;
            com.ComZipcode = txtZipCode.Text;
            com.ComTel = txtTel.Text;
            com.ComFax = txtFax.Text;
            com.ComEmail = txtEmail.Text;
            com.ComUrl = txtUrl.Text;
            com.Summary = txtSummary.Text;
            try
            {
                long r = cs.SaveModel(com);
                if (action.Equals("edit")) r = com.Id;
                hidID.Value = r.ToString();
                if (action.Equals("add"))
                {

                    ScriptUtil.ConfirmAndRedirect(@"公司信息添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "CompanyAdd.aspx?node=" + NodeCode, "CompanyList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"公司信息修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "CompanyAdd.aspx?node=" + NodeCode + "&id=" + id, "CompanyList.aspx?node=" + NodeCode);
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