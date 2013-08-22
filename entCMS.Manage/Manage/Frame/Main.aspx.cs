using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using entCMS.Models;
using entCMS.Services;
using System.Data;
using Hxj.Data;

namespace entCMS.Manage.Frame
{
    public partial class Main1 : BasePage
    {
        protected DataTable LastedFeedbacks = null;
        protected DataTable LastedProducts = null;
        protected DataTable LastedNewses = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as MasterPage).ShowPositionBar(false);

            if (!IsPostBack)
            {
                ltlName.Text = LoginUser.UName;
                ltlCnt.Text = LoginUser.LoginCount.ToString();
                ltlIP.Text = LoginUser.LastIp;
                ltlTime.Text = LoginUser.LastTime.HasValue ? LoginUser.LastTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // 服务器信息
                ltlVer.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                ltlMem.Text = PhisicalMemory();
                ltlPST.Text = ProcessStartTime();
                ltlANM.Text = AspNetMemory();
                ltlANCT.Text = AspNetCPUTime();

                Literal1.Text = NewsService.GetInstance().Count(1).ToString();
                Literal2.Text = NewsService.GetInstance().Count(2).ToString();
                Literal3.Text = NewsService.GetInstance().Count(3).ToString();
                Literal4.Text = NewsService.GetInstance().Count(4).ToString();
                Literal5.Text = FeedbackService.GetInstance().Count(null).ToString();
                Literal6.Text = JobService.GetInstance().Count(null).ToString();
                Literal7.Text = LinkService.GetInstance().Count(null).ToString();
            }

            LastedFeedbacks = GetLastedFeedbackList();
            LastedProducts = GetLastedProductList();
            LastedNewses = GetLastedNewsList();
        }

        protected DataTable GetLastedFeedbackList()
        {
            int count = 0;
            return FeedbackService.GetInstance().GetDataTable(CurrentLanguageId, false, 1, 5, ref count);
        }

        protected DataTable GetLastedProductList()
        {
            int count = 0;
            return NewsService.GetInstance().GetListByType(CurrentLanguageId, 4, 1, 5, ref count);
        }

        protected DataTable GetLastedNewsList()
        {
            int count = 0;
            return NewsService.GetInstance().GetListByType(CurrentLanguageId, 2, 1, 5, ref count);
        }
        #region 服务器信息相关

        /// <summary>
        /// 获取物理内存数
        /// </summary>
        /// <returns></returns>
        private string PhisicalMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            return (computerInfo.TotalPhysicalMemory / 1048576).ToString("N2");

            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(); //用于查询一些如系统信息的管理对象
            //searcher.Query = new SelectQuery("Win32_PhysicalMemory", "", new string[] { "Capacity" });//设置查询条件
            //ManagementObjectCollection collection = searcher.Get(); //获取内存容量
            //ManagementObjectCollection.ManagementObjectEnumerator em = collection.GetEnumerator();

            //int capacity = 0;
            //while (em.MoveNext())
            //{
            //    ManagementBaseObject baseObj = em.Current;
            //    if (baseObj.Properties["Capacity"].Value != null)
            //    {
            //        try
            //        {
            //            capacity += int.Parse(baseObj.Properties["Capacity"].Value.ToString());
            //        }
            //        catch
            //        {
            //            return 0;
            //        }
            //    }
            //}
            //return capacity;
        }
        /// <summary>
        /// 获取进程开始时间
        /// </summary>
        /// <returns></returns>
        private string ProcessStartTime()
        {
            try
            {
                return System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString();
            }
            catch
            {
                return "未知";
            }
        }
        /// <summary>
        /// AspNet内存占用
        /// </summary>
        /// <returns></returns>
        private string AspNetMemory()
        {
            try
            {
                Process proc = Process.GetCurrentProcess();

                return (((Double)proc.WorkingSet64 / 1048576).ToString("N2"));
            }
            catch
            {
                return "未知";
            }
        }
        /// <summary>
        /// 获取AspNet CPU时间
        /// </summary>
        /// <returns></returns>
        private string AspNetCPUTime()
        {
            try
            {
                return ((TimeSpan)System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime).TotalSeconds.ToString("N0");
            }
            catch
            {
                return "未知";
            }
        }
        #endregion
    }
}