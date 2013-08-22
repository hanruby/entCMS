using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using System.Data;

namespace entCMS.Manage.Module
{
    public partial class ImageList : BasePage
    {
        NewsService ns = NewsService.GetInstance();
        NewsCatalogService ncs = NewsCatalogService.GetInstance();

        public ImageList() : base(PagePurviewType.PPT_NEWS) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化分页控件和数据绑定控件
            base.InitializePageControls(pager, gv);

            if (!IsPostBack)
            {
                InitControls();

                BindGrid();
            }
        }

        private void InitControls()
        {
            txtAddTime1.Attributes.Add("readonly", "true");
            txtAddTime2.Attributes.Add("readonly", "true");
            txtEditTime1.Attributes.Add("readonly", "true");
            txtEditTime2.Attributes.Add("readonly", "true");
            lblPosition.Text = ncs.GetNavStr(NodeCode, " >> ");

            if (IsAdmin)
            {
                ddlAudit.Items.Add(new ListItem("已删除", "3"));
            }
        }

        private void BindGrid()
        {
            int recordCount = 0;
            DataTable dt = ns.GetListByFilter(
                NodeCode,
                txtTitle.Text,
                txtTags.Text,
                Convert.ToInt32(ddlIndex.SelectedValue),
                Convert.ToInt32(ddlTop.SelectedValue),
                Convert.ToInt32(ddlAudit.SelectedValue),
                txtAddTime1.Text,
                txtAddTime2.Text,
                txtEditTime1.Text,
                txtEditTime2.Text,
                LoginUser.Id,
                IsAdmin,
                pager.CurrentPageIndex,
                pager.PageSize,
                ref recordCount);

            // 绑定数据到GridView
            base.BindGrid(recordCount, dt);
        }

        string[] status = { "未审核", "已审核", "未通过", "已删除" };
        protected string getAuditStatus(object dataItem)
        {
            DataRowView drv = dataItem as DataRowView;

            if (!DBNull.Value.Equals(drv["IsAudit"]))
            {
                int isAudit = Convert.ToInt32(drv["IsAudit"]);
                if (isAudit == 2)
                {
                    string s = "<a href='javascript:void(0);' class='tooltip' title='{0}'>{1}</a>";
                    string c = Convert.ToString(drv["AuditComment"]);
                    c = c.Replace("\r", "").Replace("\n", "<br/>");
                    c = Server.HtmlEncode(c);
                    return string.Format(s, c, status[2]);
                }
                else
                {
                    return status[isAudit];
                }
            }
            else
            {
                return status[0];
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void pager_PageChanged(object src, EventArgs e)
        {
            BindGrid();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtTags.Text = "";
            ddlIndex.SelectedIndex = 0;
            ddlTop.SelectedIndex = 0;
            ddlAudit.SelectedIndex = 0;
            txtAddTime1.Text = "";
            txtAddTime2.Text = "";
            txtEditTime1.Text = "";
            txtEditTime2.Text = "";
        }

        //<a href='<%#Eval("SmallPic") %>' class='img' onclick='top.$.fancybox.open({href: this.href, hideOnContentClick: true, live: false});return false;'><%#(string.IsNullOrEmpty(Eval("SmallPic").ToString())?"":"图") %></a>
        protected string GetTitle(object dataItem)
        {
            DataRowView drv = dataItem as DataRowView;

            if (drv == null) return "";

            //string spic = drv["SmallPic"].ToString();
            string title = drv["Title"].ToString();

            //if (!string.IsNullOrEmpty(spic))
            //{
            //    spic =  "<a href='" + spic + "' class='img' onclick='top.$.fancybox.open({href: this.href, hideOnContentClick: true, live: false});return false;'>[图]</a>";
            //}

            return "&nbsp;" + title;
        }
    }
}