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
    public partial class ServicerSet : BasePage
    {
        string configFile = string.Empty;
        cmsLanguage lang = null;
        protected string type = "0";
        protected string x = "10";
        protected string y = "110";
        protected string style = "1";
        protected string color = "4";
        protected string qq = "1";
        protected string msn = "1";
        protected string tb = "1";
        protected string ali = "1";
        protected string skype = "1";
        protected string onname = "1";
        protected string info = "";

        public ServicerSet()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);
            if (lang != null)
            {
                configFile = Server.MapPath(string.Format("~/Manage/Config/{0}.config", lang.Code));
                type = ConfigHelper.GetVal(configFile, "OnlineType", type);
                x = ConfigHelper.GetVal(configFile, "OnlineX", x);
                y = ConfigHelper.GetVal(configFile, "OnlineY", y);
                style = ConfigHelper.GetVal(configFile, "OnlineStyle", style);
                color = ConfigHelper.GetVal(configFile, "OnlineStyleColor", color);
                qq = ConfigHelper.GetVal(configFile, "OnlineIconQQ", qq);
                msn = ConfigHelper.GetVal(configFile, "OnlineIconMSN", msn);
                tb = ConfigHelper.GetVal(configFile, "OnlineIconTaobao", tb);
                ali = ConfigHelper.GetVal(configFile, "OnlineIconAli", ali);
                skype = ConfigHelper.GetVal(configFile, "OnlineIconSkype", skype);
                onname = ConfigHelper.GetVal(configFile, "OnlineOnName", onname);
                info = ConfigHelper.GetVal(configFile, "OnlineOtherInfo", info);
            }
            if (!IsPostBack && lang != null)
            {
                InitData();
            }

            foreach (ListItem item in rblType.Items)
            {
                item.Attributes.Add("onclick", "onlineposition(" + item.Value + ",  '');");
            }
        }

        private void InitData()
        {
            if (lang != null)
            {
                rblType.SelectedValue = type;
                txtX1.Text = x;
                txtY1.Text = y;
                txtX2.Text = x;
                txtY2.Text = y;
                ddlStyle.SelectedValue = style;
                ddlStyleColor.SelectedValue = color;
                chkOnName.Checked = (onname == "0");
                txtOtherInfo.Text = info;
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            type = rblType.SelectedValue;
            int t = int.Parse(type);
            if (t==1 || t==2)
            {
                x = txtX1.Text;
                y = txtY1.Text;
            }
            else if (t == 3 || t == 4)
            {
                x = txtX2.Text;
                y = txtY2.Text;
            }
            style = ddlStyle.SelectedValue;
            color = ddlStyleColor.SelectedValue;
            qq = Request["met_qq_type"];
            msn = Request["met_msn_type"];
            tb = Request["met_taobao_type"];
            ali = Request["met_alibaba_type"];
            skype = Request["met_skype_type"];
            onname = chkOnName.Checked ? "0" : "1";
            info = txtOtherInfo.Text;

            dic.Add("OnlineType", rblType.SelectedValue);
            dic.Add("OnlineX", x);
            dic.Add("OnlineY", y);
            dic.Add("OnlineStyle", style);
            dic.Add("OnlineStyleColor", color);
            dic.Add("OnlineIconQQ", qq);
            dic.Add("OnlineIconMSN", msn);
            dic.Add("OnlineIconTaobao", tb);
            dic.Add("OnlineIconAli", ali);
            dic.Add("OnlineIconSkype", skype);
            dic.Add("OnlineOnName", onname);
            dic.Add("OnlineOtherInfo", info);

            ConfigHelper.SetVal(configFile, dic);
            ScriptUtil.Alert("设置保存成功");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ScriptUtil.RegisterStartupScript("onlineposition(" + type + ",'')", true);
            if (lang == null)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}