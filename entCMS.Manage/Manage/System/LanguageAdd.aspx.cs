using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;
using System.IO;

namespace entCMS.Manage
{
    public partial class LanguageAdd : BasePage
    {
        LanguageService lgs = LanguageService.GetInstance();
        cmsLanguage lang = null;

        string id = "";
        string action = "";

        public LanguageAdd()
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
                InitData();
            }

        }

        private void InitData()
        {
            lang = lgs.Get(id);
            if (lang != null)
            {
                hidID.Value = lang.Id.ToString();

                txtName.Text = lang.Name;
                txtShortName.Text = lang.ShortName;
                txtCode.Text = lang.Code;
                txtCode.Enabled = false; // 代码不允许修改
                txtUrl.Text = lang.HomeUrl;
                txtOrder.Text = lang.OrderNo.ToString();
                chkDefault.Checked = lang.IsDefault.HasValue ? lang.IsDefault.Value == 1 : false;
                chkEnabled.Checked = lang.IsEnabled.HasValue ? lang.IsEnabled.Value == 1 : false;
                txtRemark.Text = lang.Remark;
            }

        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";

            if (action.Equals("add"))
            {
                lang = new cmsLanguage();
            }
            else
            {
                lang = lgs.Get(id);
                if (lang != null)
                {
                    lang.Attach();
                }
                else
                {
                    lang = new cmsLanguage();
                }
            }
            lang.Name = txtName.Text;
            lang.ShortName = txtShortName.Text;
            lang.Code = txtCode.Text;
            lang.HomeUrl = string.IsNullOrEmpty(txtUrl.Text) ? "/" : txtUrl.Text;
            lang.OrderNo = Convert.ToInt32(txtOrder.Text);
            lang.IsDefault = chkDefault.Checked ? 1 : 0;
            lang.IsEnabled = chkEnabled.Checked ? 1 : 0;
            lang.Remark = txtRemark.Text;
            try
            {
                long r = lgs.Save(lang);
                if (action.Equals("edit"))
                {
                    r = lang.Id;
                }
                hidID.Value = r.ToString();
                // 创建模板目录下的语言配置文件
                CreateLangConfigFile(lang);
                //
                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"语言添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "LanguageAdd.aspx?node=" + NodeCode, "LanguageList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"语言修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "LanguageAdd.aspx?node=" + NodeCode + "&id=" + id, "LanguageList.aspx?node=" + NodeCode);
                }
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);

                Logger.Error(ex.Message);
            }
        }
        /// <summary>
        /// 如果不同语言模板是同一个，则不能执行此方法
        /// </summary>
        /// <param name="lang"></param>
        private void CreateLangConfigFile(cmsLanguage lang)
        {
            /*
            string path = Server.MapPath(lang.HomeUrl);
            if (!path.EndsWith("\\")) path += "\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string file = path + "lang.config";
            //if (!File.Exists(file))
            //{
            //    using (StreamWriter sw = File.CreateText(file)) { sw.Close(); }
            //}
            ConfigHelper.SetVal(file, "langName", lang.Name);
            ConfigHelper.SetVal(file, "langId", lang.Id.ToString());
            */
        }
    }
}