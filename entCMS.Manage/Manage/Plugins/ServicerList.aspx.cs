using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using entCMS.Services;
using entCMS.Models;

namespace entCMS.Manage.Plugins
{
    public partial class ServicerList : BasePage
    {
        ServicerService ss = ServicerService.GetInstance();
        cmsLanguage lang = null;
        public ServicerList()
            : base(PagePurviewType.PPT_SYSTEM)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.InitializePageControls(null, gv);

            lang = LanguageService.GetInstance().GetModel(CurrentLanguageId);

            if (!IsPostBack && lang != null)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<cmsServicer> ls = ss.GetList(cmsServicer._.LangId == CurrentLanguageId, cmsServicer._.OrderNo.Asc);

            // 绑定数据到GridView
            base.BindGrid<cmsServicer>(ls);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (CurrentLanguageId == 0)
            {
                (Master as MasterPage).SetPageInfo(GetPageInfo("当前语言未指定", "请在左边栏里选择当前语言。如果还未设置站点语言，请点击 <a href='LanguageList.aspx'>[语言设置]</a>"));
            }
        }
    }
}