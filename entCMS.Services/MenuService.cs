using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class MenuService : BaseService<cmsMenu>
    {
        BaseService<cmsMenu> bs = new BaseService<cmsMenu>();
        
        #region 实现单例模式
        private MenuService()
        {
        }
        static MenuService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new MenuService();
                }
            }
        }

        public static MenuService GetInstance()
        {
            return (MenuService)instance;
        }
        #endregion

        public string GetNextChildCode(string parentCode)
        {
            string code = "";

            object o = Max(cmsMenu._.MenuCode, cmsMenu._.ParentCode == parentCode);
            if (o == DBNull.Value || o == null)
            {
                code = "0001";
            }
            else
            {
                string c = o.ToString();
                c = c.Substring(c.Length-4);
                code = (Convert.ToInt32(c) + 1).ToString("0000");
            }

            if (parentCode != "0000") code = parentCode + code;

            return code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cmsMenu> GetAllList()
        {
            return GetList(null, null);
        }
        /// <summary>
        /// 取得全部启用的系统栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsMenu> GetMenus()
        {
            return GetList(cmsMenu._.IsEnabled == 1, cmsMenu._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public List<cmsMenu> GetChildList(string parentCode)
        {
            return GetList(cmsMenu._.ParentCode == parentCode, cmsMenu._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string code, int order)
        {
            cmsMenu m = Get(code);
            if (m != null)
            {
                m.Attach();
                m.OrderNo = order;
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int Enable(string code)
        {
            cmsMenu m = Get(code);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = m.IsEnabled.HasValue ? (m.IsEnabled.Value == 0 ? 1 : 0) : 1;
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public cmsMenu Get(string code)
        {
            return GetModelWithWhere(cmsMenu._.MenuCode == code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int Delete(string code)
        {
            return DeleteModels(cmsMenu._.MenuCode == code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Save(cmsMenu m)
        {
            return SaveModel(m);
        }
    }
}
