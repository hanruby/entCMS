using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.DAL;
using entCMS.Model;
using entCMS.Common;

namespace entCMS.Manage.Module
{
    public partial class NewsAudit : BasePage
    {
        NewsService ns = new NewsService();
        cmsNews news = null;

        string id = "";

        public NewsAudit()
            : base(PagePurviewType.PPT_NEWS)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            news = ns.GetModel(id);

            if (news != null)
            {
                lblTitle.Text = news.Title;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                news = ns.GetModel(id);

                if (news != null)
                {
                    news.Attach();

                    news.IsAudit = Convert.ToInt32(ddlResult.SelectedValue);
                    news.AuditComment = txtComment.Text;

                    ns.Save(news);

                    ScriptUtil.AlertAndCloseDialog("审核完成！", true);
                }
            }
            catch (Exception ex)
            {
                ScriptUtil.Alert(ex.Message);
            }
        }
    }
}