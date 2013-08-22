using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;
using entCMS.Common;

namespace entCMS.Manage.Module
{
    public partial class JobAdd : BasePage
    {
        NewsCatalogService ncs = NewsCatalogService.GetInstance();
        cmsNewsCatalog catalog = null;
        JobService js = JobService.GetInstance();
        cmsJob job = null;

        string id = "";
        string action = "";

        public JobAdd() : base(PagePurviewType.PPT_NEWS) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];
            action = Request["action"];
            action = (string.IsNullOrEmpty(action)) ? "add" : action;

            catalog = ncs.Get(NodeCode);

            if (!IsPostBack)
            {
                InitControls();

                InitData();
            }
        }

        private void InitData()
        {
            job = js.GetModel(id);
            if (job != null)
            {
                hidID.Value = job.Id.ToString();
                ddlCatalog.SelectedValue = job.NodeCode;
                txtName.Text = job.Name;
                txtNumbers.Text = job.Numbers.ToString();
                txtAddress.Text = job.Address;
                txtResponsibilities.Text = job.Responsibilities;
                txtRequirements.Text = job.Requirements;
                txtRemark.Text = job.Remark;
                txtOrder.Text = job.OrderNo.ToString();
                chkEnabled.Checked = (job.IsEnabled == 1);
                txtHits.Text = job.Hits.ToString();
                txtEndTime.Text = job.EndTime.HasValue ? job.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                txtTime.Text = job.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void InitControls()
        {
            txtTime.Attributes.Add("readonly", "true");
            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtEndTime.Attributes.Add("readonly", "true");
            
            List<cmsNewsCatalog> catalogs = ncs.GetCatalogs(CurrentLanguageId, 0, 6);
            List<cmsNewsCatalog> newsCatalogs = catalogs.FindAll(c => (c.ParentCode == "0000"));

            foreach (cmsNewsCatalog item in newsCatalogs)
            {
                if (IsAdmin || PurviewExists(item.NodeCode, 0))
                {
                    var c = new ListItem(item.NodeName, item.NodeCode);
                    ddlCatalog.Items.Add(c);

                    List<cmsNewsCatalog> childs = catalogs.FindAll(m => m.ParentCode == item.NodeCode);
                    if (childs.Count > 0)
                    {
                        buildNewsCatalogTree(ddlCatalog, catalogs, item.NodeCode, childs, "");
                    }
                    else
                    {
                        if (item.NodeType == 0) ddlCatalog.Items.Remove(c);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="catalogs"></param>
        /// <param name="purviews"></param>
        /// <param name="parentCode"></param>
        /// <param name="prefix"></param>
        private void buildNewsCatalogTree(DropDownList ddl, List<cmsNewsCatalog> catalogs, string parentCode, List<cmsNewsCatalog> childs, string prefix)
        {
            string pf = "";

            for (int i = 0; i < childs.Count; i++)
            {
                cmsNewsCatalog item = childs[i];
                if (IsAdmin || PurviewExists(item.NodeCode, 0))
                {
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

                    List<cmsNewsCatalog> children = catalogs.FindAll(m => m.ParentCode == item.NodeCode);
                    if (children.Count > 0)
                    {
                        buildNewsCatalogTree(ddl, catalogs, item.NodeCode, children, pf);
                    }
                    else
                    {
                        if (item.NodeType == 0) ddlCatalog.Items.Remove(itm);
                    }
                }
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (!int.TryParse(txtNumbers.Text.Trim(), out num)) num = 1;

            int order = 0;
            if (!int.TryParse(txtOrder.Text.Trim(), out order)) order = 1;

            int hits = 0;
            if (!int.TryParse(txtHits.Text.Trim(), out hits)) hits = 0;

            DateTime dt1, dt2;
            if (!DateTime.TryParse(txtTime.Text.Trim(), out dt1)) dt1 = DateTime.Now;
            if (!DateTime.TryParse(txtEndTime.Text.Trim(), out dt2)) dt2 = DateTime.MaxValue;
            
            if (action.Equals("add"))
            {
                job = new cmsJob();
                job.AddTime = DateTime.Now;
            }
            else
            {
                job = js.GetModel(id);
                job.Attach();
            }
            job.NodeCode = ddlCatalog.SelectedValue;
            job.Name = txtName.Text.Trim();
            job.Numbers = num;
            job.Address = txtAddress.Text;
            job.Responsibilities = txtResponsibilities.Text;
            job.Requirements = txtRequirements.Text;
            job.Remark = txtRemark.Text;
            job.OrderNo = order;
            job.IsEnabled = chkEnabled.Checked ? 1 : 0;
            job.Hits = Convert.ToInt32(txtHits.Text);
            job.AddTime = dt1;
            if (dt2 != DateTime.MaxValue) job.EndTime = dt2;
            job.LangId = CurrentLanguageId;

            try
            {
                int r = js.SaveModel(job);

                if (action.Equals("add"))
                {
                    ScriptUtil.ConfirmAndRedirect(@"职位添加成功！\n“确定”继续添加，“取消”则跳转到列表页。", "JobAdd.aspx?node=" + NodeCode, "JobList.aspx?node=" + NodeCode);
                }
                else
                {
                    ScriptUtil.ConfirmAndRedirect(@"职位修改成功！\n“确定”留在本页，“取消”则跳转到列表页。", "JobAdd.aspx?node=" + NodeCode + "&id=" + id + "&action=edit", "JobList.aspx?node=" + NodeCode);
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