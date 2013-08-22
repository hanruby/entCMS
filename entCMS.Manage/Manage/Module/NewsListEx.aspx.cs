using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.DAL;
using entCMS.Model;
using jtSoft.Data;
using System.Configuration;

namespace entCMS.Manage.Module
{
    public partial class NewsListEx : BasePage
    {
        NewsService ns = new NewsService();
        NewsCatalogService ncs = new NewsCatalogService();

        protected string type = "";

        public NewsListEx()
            : base(PagePurviewType.PPT_NEWS)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            type = string.IsNullOrEmpty(Request["t"]) ? "0" : Request["t"];

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

            ddlAudit.SelectedValue = type;
            ddlAudit.Enabled = false;
        }

        private void BindGrid()
        {
            bool isAdmin = IsAdmin;
            // 审核员角色Id
            string role = ConfigurationManager.AppSettings["CheckRoleId"];
            int roleId = Convert.ToInt32(role);
            UserRoleService urs = new UserRoleService();
            // 如果用户有审核员的角色，则能审核全部文章
            if (urs.Exists(cmsUserRole._.UserId == UserID && cmsUserRole._.RoleId == roleId))
            {
                isAdmin = true;
            }
            int recordCount = 0;
            DataTable dt = ns.GetListByFilter2(
                "",
                txtTitle.Text,
                txtSource.Text,
                txtAuthor.Text,
                txtTags.Text,
                Convert.ToInt32(ddlIndex.SelectedValue),
                Convert.ToInt32(ddlTop.SelectedValue),
                Convert.ToInt32(type),
                txtAddTime1.Text,
                txtAddTime2.Text,
                txtEditTime1.Text,
                txtEditTime2.Text,
                UserID,
                isAdmin,
                pager.CurrentPageIndex,
                pager.PageSize,
                ref recordCount);

            // 绑定数据到GridView
            base.BindGrid(recordCount, dt);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                string audit = drv["IsAudit"]+"";

                LinkButton btnEdit = e.Row.FindControl("btnEdit") as LinkButton;
                LinkButton btnDel = e.Row.FindControl("btnDel") as LinkButton;
                LinkButton btnRst = e.Row.FindControl("btnRst") as LinkButton;
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                LinkButton btnAudit = e.Row.FindControl("btnAudit") as LinkButton;

                if (audit.Equals("3"))
                {
                    btnRst.Visible = true;
                    btnRst.OnClientClick = "return restore(\"" + drv["Id"] + "\");";
                }
                else
                {
                    btnEdit.Visible = true;
                    btnEdit.OnClientClick = "return edit(\"" + drv["Id"] + "\");";
                    btnEdit.Attributes["href"] = "NewsAdd.aspx?node=" + drv["NodeCode"] + "&id=" + drv["Id"] + "&action=edit";

                    btnDel.Visible = true;
                    btnDel.OnClientClick = "return del(\"" + drv["Id"] + "\", 0);";

                    btnAudit.Visible = true;
                    btnAudit.OnClientClick = "return audit(\"" + NodeCode + "\",\"" + drv["Id"] + "\");";
                }

                if (IsAdmin)
                {
                    btnDelete.Visible = true;
                    btnDelete.OnClientClick = "return del(\"" + drv["Id"] + "\", 1);";
                }
            }
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
            txtSource.Text = "";
            txtAuthor.Text = "";
            txtTags.Text = "";
            ddlIndex.SelectedIndex = 0;
            ddlTop.SelectedIndex = 0;
            ddlAudit.SelectedIndex = 0;
            txtAddTime1.Text = "";
            txtAddTime2.Text = "";
            txtEditTime1.Text = "";
            txtEditTime2.Text = "";
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
    }
}