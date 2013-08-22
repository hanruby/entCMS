using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using entCMS.Common;

namespace entCMS.Manage
{
    public partial class NewsCatalogAdd : BasePage
    {
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        cmsNewsCatalog catalog = null;

        string code = "";
        string action = "";
        protected string lang = "0";
        public NewsCatalogAdd()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            code = Request["code"];
            code = (string.IsNullOrEmpty(code)) ? "0000" : code;

            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            lang = Request["lang"];
            lang = (string.IsNullOrEmpty(lang)) ? CurrentLanguageId.ToString() : lang;

            if (!IsPostBack)
            {
                LangBind();

                MdlBind();

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
            ddlLanguage.SelectedValue = lang;
            ddlLanguage_SelectedIndexChanged(ddlLanguage, null);
        }

        private void MdlBind()
        {
            List<cmsModule> ls = ModuleService.GetInstance().GetList(true);
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Id";
            ddlType.DataSource = ls;
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("默认", "0"));
        }

        private void CatalogBind()
        {
            ddlParentNode.Items.Clear();

            ddlParentNode.Items.Add(new ListItem("顶级栏目", "0000"));

            List<cmsNewsCatalog> menus = ncs.GetList(cmsNewsCatalog._.LangId == ddlLanguage.SelectedValue && cmsNewsCatalog._.IsEnabled == true, cmsNewsCatalog._.OrderNo.Asc);

            buildNewsCatalogTree(ddlParentNode, menus, "0000", "");
        }

        private void InitData()
        {
            if (!string.IsNullOrEmpty(code))
            {
                catalog = ncs.Get(code);
                if (action.Equals("add"))
                {
                    ddlParentNode.SelectedValue = code;
                    txtOrder.Text = ncs.GetNextOrder(code).ToString();
                    if (catalog != null) ddlType.SelectedValue = catalog.NodeType.ToString();
                }
                else if (action.Equals("edit") && catalog != null)
                {
                    hidCode.Value = catalog.NodeCode;
                    ddlLanguage.SelectedValue = catalog.LangId + "";
                    ddlLanguage.Enabled = false;
                    
                    CatalogBind();
                    ddlParentNode.SelectedValue = catalog.ParentCode;
                    txtName.Text = catalog.NodeName;
                    txtTitle.Text = catalog.Title;
                    txtSubTitle.Text = catalog.SubTitle;
                    txtLinkUrl.Text = catalog.LinkUrl;
                    txtBackUrl.Text = catalog.BackUrl;
                    hidImages1.Value = catalog.BigPic;
                    hidImages2.Value = catalog.SmallPic;
                    ddlType.SelectedValue = catalog.NodeType.ToString();
                    if (!ConfigHelper.GetVal<bool>("NodeTypeIsEditable"))
                    {
                        ddlType.Enabled = false;
                    }
                    txtOrder.Text = catalog.OrderNo.ToString();
                    rblNavType.SelectedValue = catalog.NavType.ToString();
                    chkEnabled.Checked = catalog.IsEnabled == 1;
                }
            }
            else
            {
                CatalogBind();
            }
        }

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlParentNode.Items.Clear();

            CatalogBind();
        }

        protected void ddlParentNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            catalog = ncs.Get(ddlParentNode.SelectedValue);
            if (catalog != null) ddlType.SelectedValue = catalog.NodeType.ToString();
            txtOrder.Text = ncs.GetNextOrder(ddlParentNode.SelectedValue).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="catalogs"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildNewsCatalogTree(DropDownList ddl, List<cmsNewsCatalog> catalogs, string parentCode, string prefix)
        {
            string pf = "";
            List<cmsNewsCatalog> childs = catalogs.FindAll(delegate(cmsNewsCatalog m) { return m.ParentCode == parentCode; });
            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];

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

                buildNewsCatalogTree(ddl, catalogs, item.NodeCode, pf);
            }
        }


        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlLanguage.SelectedValue == "0")
            {
                ScriptUtil.Alert("请选择所属语言！");
                return;
            }

            if (string.IsNullOrEmpty(txtOrder.Text.Trim())) txtOrder.Text = "0";

            if (action.Equals("add"))
            {
                catalog = new cmsNewsCatalog();
                catalog.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
            }
            else if (action.Equals("edit"))
            {
                if (ddlParentNode.SelectedValue.StartsWith(hidCode.Value))
                {
                    ScriptUtil.Alert("上级栏目不能设为自身或其子级！");
                    return;
                }
                catalog = ncs.Get(code);
                if (catalog != null)
                {
                    catalog.Attach();
                }
                else
                {
                    catalog = new cmsNewsCatalog();
                    catalog.LangId = Convert.ToInt64(ddlLanguage.SelectedValue);
                }
            }
            if (catalog.ParentCode != ddlParentNode.SelectedValue)
            {
                catalog.NodeCode = ncs.GetNextChildCode(ddlParentNode.SelectedValue);
            }
            catalog.ParentCode = ddlParentNode.SelectedValue;
            catalog.NodeName = txtName.Text.Trim();
            catalog.NodeType = Convert.ToInt32(ddlType.SelectedValue);
            catalog.Title = string.IsNullOrEmpty(txtTitle.Text) ? catalog.NodeName : txtTitle.Text;
            catalog.SubTitle = txtSubTitle.Text;
            catalog.LinkUrl = txtLinkUrl.Text.Trim();
            if (catalog.NodeType == 0)
            {
                catalog.BackUrl = "";
            }
            //if (action == "add")
            {
                cmsModule mdl = ModuleService.GetInstance().GetModel(catalog.NodeType);
                if (mdl != null && !string.IsNullOrEmpty(mdl.Url)) catalog.BackUrl = mdl.Url;//txtBackUrl.Text.Trim();
            }
            catalog.OrderNo = Convert.ToInt32(txtOrder.Text.Trim());
            catalog.NavType = int.Parse(rblNavType.SelectedValue);
            catalog.IsEnabled = chkEnabled.Checked ? 1 : 0;
            catalog.BigPic = hidImages1.Value;
            catalog.SmallPic = hidImages2.Value;
            try
            {
                int r = ncs.Save(catalog);
                //if (r > 0)
                {
                    hidCode.Value = catalog.NodeCode;

                    if (action.Equals("add"))
                    {
                        ScriptUtil.ConfirmAndRedirect(@"栏目添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "NewsCatalogAdd.aspx?node=" + NodeCode + "&code=" + ddlParentNode.SelectedValue + "&lang=" + ddlLanguage.SelectedValue, "NewsCatalogList.aspx?node=" + NodeCode + "&lang=" + ddlLanguage.SelectedValue);
                    }
                    else
                    {
                        ScriptUtil.ConfirmAndRedirect(@"栏目修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "NewsCatalogAdd.aspx?node=" + NodeCode + "&code=" + code + "&action=" + action, "NewsCatalogList.aspx?node=" + NodeCode + "&lang=" + ddlLanguage.SelectedValue);
                        //ScriptUtil.Alert("栏目修改成功！");
                    }
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