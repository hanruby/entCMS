using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class NewsCatalogService : BaseService<cmsNewsCatalog>
    {
        #region 实现单例模式
        private NewsCatalogService()
        {
        }
        static NewsCatalogService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new NewsCatalogService();
                }
            }
        }

        public static NewsCatalogService GetInstance()
        {
            return (NewsCatalogService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCode"></param>
        /// <returns></returns>
        public cmsNewsCatalog GetTopNode(string nodeCode)
        {
            string topCode = nodeCode.Substring(0, 4);

            return Get(topCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodecode"></param>
        /// <returns></returns>
        public cmsNewsCatalog GetFirstChildNode(string nodecode)
        {
            return GetModel(cmsNewsCatalog._.ParentCode == nodecode && cmsNewsCatalog._.IsEnabled == 1, cmsNewsCatalog._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCode"></param>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetNavNodes(string nodeCode)
        {
            int len = nodeCode.Length / 4;

            List<cmsNewsCatalog> list = new List<cmsNewsCatalog>(len);

            for (int i = 0; i < len; i++)
            {
                cmsNewsCatalog catalog = Get(nodeCode.Substring(0, (i + 1) * 4));
                if(catalog != null) list.Add(catalog);
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCode"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetNavStr(string nodeCode, string separator)
        {
            if (string.IsNullOrEmpty(nodeCode)) return "";

            StringBuilder sb = new StringBuilder();
            List<cmsNewsCatalog> list = GetNavNodes(nodeCode);
            foreach (cmsNewsCatalog item in list)
            {
                sb.Append(separator + item.NodeName);
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCode"></param>
        /// <param name="urlFormat">newsList.aspx?node={0}或者newlist/{0}.aspx</param>
        /// <param name="separator"> >> </param>
        /// <returns></returns>
        public string GetNavStrWithUrl(string nodeCode, string urlFormat, string separator)
        {
            StringBuilder sb = new StringBuilder();
            List<cmsNewsCatalog> list = GetNavNodes(nodeCode);
            if (list != null)
            {
                foreach (cmsNewsCatalog item in list)
                {
                    string url = !string.IsNullOrEmpty(item.LinkUrl) ? item.LinkUrl : string.Format(urlFormat, item.NodeCode);
                    sb.Append(separator + "<a href='" + url + "'>" + item.NodeName + "</a>");
                }
            }
            return sb.ToString();
        }

        public string GetNextChildCode(string parentCode)
        {
            string code = "";

            object o = Max(cmsNewsCatalog._.NodeCode, cmsNewsCatalog._.ParentCode == parentCode);
            if (o == DBNull.Value || o == null)
            {
                code = "0001";
            }
            else
            {
                string c = o.ToString();
                c = c.Substring(c.Length - 4);
                code = (Convert.ToInt32(c) + 1).ToString("0000");
            }

            if (parentCode != "0000") code = parentCode + code;

            return code;
        }

        /// <summary>
        /// 新增栏目时获取下个子栏目的排序号，Max+1
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public int GetNextOrder(string parentCode)
        {
            object o = Max(cmsNewsCatalog._.OrderNo, cmsNewsCatalog._.ParentCode == parentCode);
            if (o != DBNull.Value)
                return Convert.ToInt32(o) + 1;
            else
                return 1;
        }
        /// <summary>
        /// 返回全部栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetAllList()
        {
            return GetList(null, cmsNewsCatalog._.NodeCode.Asc);
        }
        /// <summary>
        /// 返回全部有效栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetCatalogs()
        {
            return GetList(cmsNewsCatalog._.IsEnabled == 1, cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);
        }
        /// <summary>
        /// 返回某语言下全部有效栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetCatalogs(long langId)
        {
            return GetList(cmsNewsCatalog._.LangId == langId && cmsNewsCatalog._.IsEnabled == 1, cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);
        }
        /// <summary>
        /// 返回某语言下指定类别的全部有效栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetCatalogs(long langId, params int[] types)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNewsCatalog._.LangId == langId && cmsNewsCatalog._.IsEnabled == 1);
            if (types != null && types.Length > 0)
            {
                wcb.And(cmsNewsCatalog._.NodeType.SelectIn(types));
            }
            List<cmsNewsCatalog> ls = GetList(wcb.ToWhereClip(), cmsNewsCatalog._.LangId.Asc && cmsNewsCatalog._.OrderNo.Asc);
            List<cmsNewsCatalog> allList = new List<cmsNewsCatalog>();
            foreach (var item in ls)
            {
                if (!allList.Exists(x => x.Id == item.Id))
                {
                    allList.Add(item);
                }
                AddParentToList(allList, item);
            }

            return allList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="nc"></param>
        private void AddParentToList(List<cmsNewsCatalog> ls, cmsNewsCatalog nc)
        {
            cmsNewsCatalog pnc = Get(nc.ParentCode);
            if (pnc != null)
            {
                if (!ls.Exists(x => x.Id == pnc.Id))
                {
                    ls.Add(pnc);
                }

                AddParentToList(ls, pnc);
            }
        }
        /// <summary>
        /// 返回全部类型为内容树的有效栏目
        /// </summary>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetNewsCatalogs()
        {
            return GetList(cmsNewsCatalog._.IsEnabled == 1 && cmsNewsCatalog._.NodeType == 99, cmsNewsCatalog._.NodeCode.Asc);
        }
        /// <summary>
        /// 返回全部parentCode下的子栏目
        /// </summary>
        /// <param name="parentCode"></param>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetChildList(string parentCode, bool? isEnabled)
        {
            return GetChildList(parentCode, false, isEnabled);
        }
        /// <summary>
        /// 返回全部parentCode下的子栏目
        /// </summary>
        /// <param name="parentCode">上级栏目</param>
        /// <param name="isLike">是否包含</param>
        /// <param name="isEnabled">是否有效</param>
        /// <returns></returns>
        public List<cmsNewsCatalog> GetChildList(string parentCode, bool isLike, bool? isEnabled)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (isLike)
            {
                wcb.And(cmsNewsCatalog._.ParentCode.BeginWith(parentCode));
            }
            else
            {
                wcb.And(cmsNewsCatalog._.ParentCode == parentCode);
            }
            if (isEnabled.HasValue)
            {
                wcb.And(cmsNewsCatalog._.IsEnabled == (isEnabled.Value ? 1 : 0));
            }

            return GetList(wcb.ToWhereClip(), cmsNewsCatalog._.OrderNo.Asc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public int ChangeOrder(string code, int order)
        {
            cmsNewsCatalog m = Get(code);
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
        public int Nav(string code)
        {
            cmsNewsCatalog m = Get(code);
            if (m != null)
            {
                m.Attach();
                //m.IsNav = !m.IsNav;
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
            cmsNewsCatalog m = Get(code);
            if (m != null)
            {
                m.Attach();
                m.IsEnabled = (m.IsEnabled == 1) ? 0 : 1;
                return UpdateModel(m);
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public cmsNewsCatalog Get(string code)
        {
            return GetModelWithWhere(cmsNewsCatalog._.NodeCode == code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int Delete(string code)
        {
            return DeleteModels(cmsNewsCatalog._.NodeCode == code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Save(cmsNewsCatalog m)
        {
            return SaveModel(m);
        }
    }
}
