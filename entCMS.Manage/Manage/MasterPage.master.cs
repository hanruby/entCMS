using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entCMS.Manage
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected bool TitleIsShown = true;
        protected bool PositionIsShown = true;
        protected bool MainIsShown = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 是否显示页面标题
        /// </summary>
        /// <param name="isShow"></param>
        public void ShowTitleBar(bool isShow)
        {
            TitleIsShown = isShow;
        }
        /// <summary>
        /// 是否显示页面标题
        /// </summary>
        /// <param name="isShow"></param>
        public void ShowPositionBar(bool isShow)
        {
            PositionIsShown = isShow;
        }
        /// <summary>
        /// 是否显示页面主内容
        /// </summary>
        /// <param name="isShow"></param>
        public void ShowMainBody(bool isShow)
        {
            MainIsShown = isShow;
        }
        /// <summary>
        /// 显示页面信息
        /// </summary>
        /// <param name="info"></param>
        public void SetPageInfo(string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                ShowMainBody(false);

                ltlInfo.Text = info;
            }
        }
    }
}