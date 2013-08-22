using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Models;
using entCMS.Services;
using entCMS.Common;

namespace entCMS.Manage.Plugins
{
    public partial class ServicerAdd : BasePage
    {
        ServicerService ss = ServicerService.GetInstance();
        cmsServicer serv = null;
        cmsLanguage lang = null;

        string id = "";
        string action = "";

        public ServicerAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = (string.IsNullOrEmpty(Request["action"])) ? "add" : Request["action"];

            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);

            if (!IsPostBack && lang != null)
            {
                InitData();
            }
        }
        
        private void InitData()
        {
            serv = ss.GetModel(id);
            if (serv != null)
            {
                hidID.Value = serv.Id.ToString();

                txtName.Text = serv.Name;
                txtQQ.Text = serv.QQ;
                txtMSN.Text = serv.MSN;
                txtTaobao.Text = serv.TaobaoWW;
                txtAli.Text = serv.AliWW;
                txtSkype.Text = serv.SKYPE;
                txtOrder.Text = serv.OrderNo.ToString();
                chkEnabled.Checked = serv.IsEnabled.HasValue ? serv.IsEnabled.Value == 1 : false;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (action.Equals("add"))
            {
                serv = new cmsServicer();
            }
            else
            {
                serv = ss.GetModel(id);
                serv.Attach();
            }
            serv.LangId = CurrentLanguageId;
            serv.Name = txtName.Text;
            serv.QQ = txtQQ.Text;
            serv.MSN = txtMSN.Text;
            serv.TaobaoWW = txtTaobao.Text;
            serv.AliWW = txtAli.Text;
            serv.SKYPE = txtSkype.Text;
            serv.OrderNo = Convert.ToInt32(txtOrder.Text);
            serv.IsEnabled = chkEnabled.Checked ? 1 : 0;
            try
            {
                long r = ss.SaveModel(serv);
                if (action.Equals("edit")) r = serv.Id;
                hidID.Value = r.ToString();
                if (action.Equals("add"))
                {

                    ScriptUtil.ConfirmAndRedirect(@"客服添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "ServicerAdd.aspx?node=" + NodeCode, "ServicerList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"客服修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "ServicerAdd.aspx?node=" + NodeCode + "&id=" + id, "ServicerList.aspx?node=" + NodeCode);
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
            if (lang == null)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}