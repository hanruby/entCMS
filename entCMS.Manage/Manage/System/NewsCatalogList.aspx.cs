using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage
{
    public partial class NewsCatalogList : BasePage
    {
        NewsCatalogService ncs = NewsCatalogService.GetInstance();        
        Dictionary<int, string> dictonaries = new Dictionary<int, string>();
        /*
        {
            {0, "默认"},
            {1, "图文模块"},
            {2, "文章模块"},
            {3, "图片模块"},
            {4, "产品模块"},
            {5, "下载模块"},
            {6, "招聘模块"},
            {7, "友链模块"},
            {8, "留言模块"},
            {9, "调用模块"},
            {20, "外部链接"},
            {30, "网站地图"},
            {40, "全站搜索"},
            {50, "会员模块"}
        };
        */
        LanguageService lgs = LanguageService.GetInstance();
        Dictionary<long, string> dicLang = new Dictionary<long, string>();

        protected string language = "0";

        public NewsCatalogList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            language = string.IsNullOrEmpty(Request["lang"]) ? CurrentLanguageId.ToString() : Request["lang"];

            MdlBind();

            if (!IsPostBack)
            {
                LangBind();

                CatalogsBind();
            }

        }

        private void MdlBind()
        {
            List<cmsModule> ls = ModuleService.GetInstance().GetList(true);
            foreach (var item in ls)
            {
                dictonaries.Add(item.Id, item.Name);
            }
            dictonaries.Add(0, "默认");
        }

        private void LangBind()
        {
            List<cmsLanguage> ls = lgs.GetList();
            ddlLanguage.DataTextField = "Name";
            ddlLanguage.DataValueField = "Id";
            ddlLanguage.DataSource = ls;
            ddlLanguage.DataBind();
            if (language.Equals("0"))
            {
                ddlLanguage.SelectedIndex = 0;
                language = ddlLanguage.SelectedValue;
            }
            else
            {
                ddlLanguage.SelectedValue = language;
            }

            foreach (cmsLanguage item in ls)
            {
                dicLang.Add(item.Id, item.Name);
            }
            dicLang.Add(0, "");
        }

        private void CatalogsBind()
        {
            List<cmsNewsCatalog> menus = ncs.GetList(cmsNewsCatalog._.LangId == ddlLanguage.SelectedValue, cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);

            buildCatalogTree(tblMenus, menus, "0000", "", 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="menus"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildCatalogTree(Table tbl, List<cmsNewsCatalog> menus, string parentCode, string prefix, long language)
        {
            string pf = "";
            List<cmsNewsCatalog> childs = menus.FindAll(delegate(cmsNewsCatalog m) { return m.ParentCode == parentCode; });
            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];

                TableRow tr = new TableRow();
                tr.CssClass = "Row";

                TableCell td = null;
                // 
                //if (!language.Equals(item.Language.Value) && i == 0)
                //{
                //    td = new TableCell();
                //    tr.Cells.Add(td);
                //    //tr.CssClass = "HeaderRow";
                //    td = new TableCell();
                //    td.ColumnSpan = 6;
                //    td.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddddd");
                //    td.Font.Size = FontUnit.Larger;
                //    td.Font.Bold = true;
                //    td.Style.Add("text-align", "left");
                //    td.Style.Add("padding-left", "10px");
                //    td.Text = dicLang[item.Language.Value];
                //    tr.Cells.Add(td);
                //    tbl.Rows.Add(tr);

                //    tr = new TableRow();
                //    tr.CssClass = "Row";
                //}
                // 所属语言
                //td = new TableCell();
                //td.Style.Add("text-align", "left");
                //td.Style.Add("padding-left", "10px");
                //td.Text = dicLang[item.Language.Value];
                //tr.Cells.Add(td);

                // 排序号
                td = new TableCell();
                HtmlInputText inp = new HtmlInputText();
                inp.ID = item.NodeCode;
                inp.Size = 4;
                inp.Style.Add("text-align", "center");
                inp.Attributes.Add("onblur", "changeOrder('" + inp.ID + "'," + item.OrderNo + ",this.value);");
                inp.Value = item.OrderNo.ToString();
                //td.Text = item.OrderNo.ToString();
                td.Controls.Add(inp);
                tr.Cells.Add(td);
                // 栏目名称
                td = new TableCell();
                td.Style.Add("text-align", "left");
                td.Style.Add("padding-left", "10px");
                if (i < childs.Count - 1)
                {
                    td.Text = prefix + "├" + item.NodeName;
                    pf = prefix + "│";
                }
                else
                {
                    td.Text = prefix + "└" + item.NodeName;
                    pf = prefix + "　"; // 全角空格[　]制表符[│][├][└]
                }
                tr.Cells.Add(td);
                // 栏目前台链接
                td = new TableCell();
                td.Style.Add("text-align", "left");
                td.Text = item.LinkUrl;
                tr.Cells.Add(td);
                // 栏目后台链接
                //td = new TableCell();
                //td.Style.Add("text-align", "left");
                //td.Text = item.BackUrl;
                //tr.Cells.Add(td);
                // 栏目类别
                td = new TableCell();
                td.Text = dictonaries[item.NodeType];
                tr.Cells.Add(td);
                // 导航
                td = new TableCell();                
                //HtmlAnchor nav = new HtmlAnchor();
                //nav.InnerText = getNavTypeStr(item.NavType);
                //nav.HRef = "javascript:void(0);";
                //nav.Attributes.Add("onclick", "nav(this, '" + item.NodeCode + "'); return false;");
                //td.Controls.Add(nav);
                td.Text = getNavTypeStr(item.NavType);
                tr.Cells.Add(td);
                // 启用
                td = new TableCell();
                HtmlAnchor enable = new HtmlAnchor();
                enable.InnerText = item.IsEnabled == 1 ? "是" : "否";
                enable.HRef = "javascript:void(0);";
                enable.Attributes.Add("onclick", "enable(this, '" + item.NodeCode + "'); return false;");
                td.Controls.Add(enable);
                tr.Cells.Add(td);
                // 操作
                td = new TableCell();
                HtmlAnchor add = new HtmlAnchor();
                add.InnerText = "添加";
                add.HRef = "NewsCatalogAdd.aspx?node=" + NodeCode + "&code=" + item.NodeCode + "&action=add&lang=" + ddlLanguage.SelectedValue;
                td.Controls.Add(add);
                HtmlGenericControl blank = new HtmlGenericControl();
                blank.InnerText = " ";
                td.Controls.Add(blank);
                HtmlAnchor edit = new HtmlAnchor();
                edit.InnerText = "编辑";
                edit.HRef = "NewsCatalogAdd.aspx?node=" + NodeCode + "&code=" + item.NodeCode + "&action=edit";
                td.Controls.Add(edit);
                blank = new HtmlGenericControl();
                blank.InnerText = " ";
                td.Controls.Add(blank);
                HtmlAnchor del = new HtmlAnchor();
                del.InnerText = "删除";
                del.HRef = "javascript:void(0);";
                del.Attributes.Add("onclick", "del('" + item.NodeCode + "'); return false;");
                td.Controls.Add(del);
                tr.Cells.Add(td);

                tbl.Rows.Add(tr);

                buildCatalogTree(tbl, menus, item.NodeCode, pf, item.LangId);
            }
        }

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("NewsCatalogList.aspx?node=" + NodeCode + "&lang=" + ddlLanguage.SelectedValue);
        }

        private string getNavTypeStr(int? navType)
        {
            if (navType.HasValue)
            {
                switch (navType.Value)
                {
                    case 0: return "不显示";
                    case 1: return "头部显示";
                    case 2: return "底部显示";
                    case 3: return "两者都显示";
                }
            }
            return "不显示";
        }
    }
}