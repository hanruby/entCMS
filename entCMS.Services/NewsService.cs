using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using entCMS.Models;
using Hxj.Data;

namespace entCMS.Services
{
    public class NewsService : BaseService<cmsNews>
    {
        #region 实现单例模式
        private NewsService()
        {
        }
        static NewsService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new NewsService();
                }
            }
        }

        public static NewsService GetInstance()
        {
            return (NewsService)instance;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <param name="keyword">搜索关键字</param>
        /// <param name="type">搜索类别：0-按标题搜，1-按内容搜，2-按标题或内容搜</param>
        /// <param name="nodecode">如果为空，则全局搜；不为空，则在本类下搜</param>
        /// <param name="isLike">是否搜索子类</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable Search(int langId, string keyword, int type, string nodecode, bool isLike, int pageIndex, int pageSize, ref int recordCount)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode) && nodecode != "0000")
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            wcb.And(cmsNews._.IsIndex == 1); // 已推荐的

            if (!string.IsNullOrEmpty(keyword))
            {
                switch (type)
                {
                    case -1:
                        break;
                    case 0:
                        wcb.And(cmsNews._.Title.Contain(keyword));
                        break;
                    case 1:
                        wcb.And(cmsNews._.Content.Contain(keyword));
                        break;
                    case 2:
                        wcb.And(cmsNews._.Title.Contain(keyword) || cmsNews._.Content.Contain(keyword));
                        break;
                }
            }

            if (langId > 0)
            {
                wcb.And(cmsNewsCatalog._.LangId == langId);
            }
            FromSection fs = GetFromSection(null, null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All,cmsNewsCatalog._.NodeName)
                .Where(wcb.ToWhereClip())
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);
            
            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable Search(string keyword, int type, string nodecode, bool isLike, int pageIndex, int pageSize, ref int recordCount)
        {
            return Search(1, keyword, type, nodecode, isLike, pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public int GetListCount(long langId, string nodecode, bool isLike)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNews._.LangId == langId);
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            return fs.Count();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetList(long langId, string nodecode, bool isLike, int pageIndex, int pageSize, ref int recordCount)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNews._.LangId == langId);
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);
            
            recordCount = fs.Count();

            return fs.Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 根据模块类别获取列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListByType(long langId, int type, int pageIndex, int pageSize, ref int recordCount)
        {
            return GetListByType(langId, type.ToString(), pageIndex, pageSize, ref recordCount);
        }
        /// <summary>
        /// 根据模块类别获取列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListByType(long langId, string type, int pageIndex, int pageSize, ref int recordCount)
        {
            string[] types = type.Split('|');

            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNewsCatalog._.LangId == langId);
            if (types.Length > 0)
            {
                wcb.And(cmsNewsCatalog._.NodeType.SelectIn(types));
            }
            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs.Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 根据栏目编号获取推荐到首页的列表
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="top"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetIndexList(long langId, string nodecode, int top, bool isLike)
        {
            if (top <= 0 || top > 10) top = 10;
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNews._.LangId == langId);
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            wcb.And(cmsNews._.IsIndex == 1); // 推荐到首页的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .Top(top)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            return fs.ToDataTable();
        }
        /// <summary>
        /// 根据栏目类型获取推荐到首页的列表
        /// </summary>
        /// <param name="nodetype"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetIndexList(long langId, int nodetype, int top)
        {
            if (top <= 0 || top > 10) top = 10;
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsNews._.LangId == langId);
            wcb.And(cmsNewsCatalog._.NodeType == nodetype);
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            wcb.And(cmsNews._.IsIndex == 1); // 推荐到首页的
            
            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .Top(top)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            return fs.ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <param name="isAudit"></param>
        /// <param name="isIndex"></param>
        /// <returns></returns>
        public DataTable GetTopNews(int top, string nodecode, bool isLike, bool isAudit, bool isIndex)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            if(isAudit) wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            if(isIndex) wcb.And(cmsNews._.IsIndex == 1); // 已推荐的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            if (top > 0)
                fs = fs.Top(top);

            return fs.ToDataTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <param name="nodecode"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetTopNews(int top, string nodecode, bool isLike)
        {
            return GetTopNews(top, nodecode, isLike, true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <param name="nodecode"></param>
        /// <param name="notInNodecode"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public DataTable GetTopNews(int top, string nodecode, string notInNodecode, bool isLike, bool isAudit, bool isIndex)
        {

            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                if (!isLike)
                {
                    wcb.And(cmsNews._.NodeCode == nodecode);
                }
                else
                {
                    wcb.And(cmsNews._.NodeCode.BeginWith(nodecode));
                }
            }
            if(!string.IsNullOrEmpty(notInNodecode))
            {
                string[] Arr = notInNodecode.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                wcb.And(cmsNews._.NodeCode.SelectNotIn(Arr));
            }
            if (isAudit) wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            if (isIndex) wcb.And(cmsNews._.IsIndex == 1); // 已推荐的

            FromSection fs = GetFromSection(wcb.ToWhereClip(), null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .OrderBy(cmsNews._.IsTop.Desc && cmsNews._.EditTime.Desc);

            if (top > 0)
                fs = fs.Top(top);

            return fs.ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <param name="node"></param>
        /// <param name="like"></param>
        /// <param name="audit"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable GetTopHitNews(HitType type, int top, string node, int like, int audit, int index)
        {
            DataTable dt = null;

            DateTime now = DateTime.Now;
            DateTime dt1 = now, dt2 = now;
            int n = 0;

            switch (type)
            {
                case HitType.DAY:
                    dt1 = now.Date;
                    dt2 = dt1.AddDays(1);
                    break;
                case HitType.WEEK:
                    n = Convert.ToInt32(now.DayOfWeek.ToString("d"));
                    if (n == 0) // 如果本周周日
                        n = 7;
                    dt1 = now.Date.AddDays(1 - n);  //本周周一
                    dt2 = dt1.AddDays(7); //下周周一
                    break;
                case HitType.MONTH:
                    dt1 = now.Date.AddDays(1 - now.Day);  //本月月初
                    dt2 = dt1.AddMonths(1);  //下月月初
                    break;
                case HitType.YEAR:
                    dt1 = new DateTime(now.Year, 1, 1);  //今年岁首
                    dt2 = dt1.AddYears(1); // 下年岁首
                    break;
            }

            dt = DBSession.CurrentSession.FromProc("proc_GetTopHitNews")
                .AddInParameter("@top", DbType.Int32, top)
                .AddInParameter("@dt1", DbType.DateTime, dt1)
                .AddInParameter("@dt2", DbType.DateTime, dt2)
                .AddInParameter("@node", DbType.String, node)
                .AddInParameter("@like", DbType.Int16, like)
                .AddInParameter("@audit", DbType.Int16, audit)
                .AddInParameter("@index", DbType.Int16, index)
                .ToDataTable();

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="top">top=0取全部，top>0取top条</param>
        /// <param name="nodecode"></param>
        /// <param name="isAudit"></param>
        /// <param name="isIndex"></param>
        /// <returns></returns>
        public DataTable GetTopZtNews(int top, int ztId, bool isAudit, bool isIndex)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (ztId>0)
            {
                wcb.And(cmsNewsTopicRel._.TopicId == ztId);
            }
            if (isAudit) wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            if (isIndex) wcb.And(cmsNews._.IsIndex == 1); // 已推荐的

            FromSection fs = GetFromSection(null, null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .InnerJoin<cmsNewsTopicRel>(cmsNews._.Id == cmsNewsTopicRel._.NewsId)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .Where(wcb.ToWhereClip())
                .OrderBy(cmsNews._.EditTime.Desc);

            if (top > 0)
                fs = fs.Top(top);

            return fs.ToDataTable();
        }
        /// <summary>
        /// 提取某专题下的分页文章
        /// </summary>
        /// <param name="ztId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetZtNewsList(int ztId, int pageSize, int pageIndex, ref int recordCount)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (ztId > 0)
            {
                wcb.And(cmsNewsTopicRel._.TopicId == ztId);
            }
            wcb.And(cmsNews._.IsAudit == 1); // 已审核的
            wcb.And(cmsNews._.IsIndex == 1); // 已推荐的

            FromSection fs = GetFromSection(null, null)
                .InnerJoin<cmsNewsCatalog>(cmsNewsCatalog._.NodeCode == cmsNews._.NodeCode)
                .InnerJoin<cmsNewsTopicRel>(cmsNews._.Id == cmsNewsTopicRel._.NewsId)
                .Select(cmsNews._.All, cmsNewsCatalog._.NodeName)
                .Where(wcb.ToWhereClip())
                .OrderBy(cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs.Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 根据条件取得自己所有文章
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="title"></param>
        /// <param name="source"></param>
        /// <param name="author"></param>
        /// <param name="tags"></param>
        /// <param name="iIndex"></param>
        /// <param name="iTop"></param>
        /// <param name="iAudit"></param>
        /// <param name="dtAdd1"></param>
        /// <param name="dtAdd2"></param>
        /// <param name="dtEdit1"></param>
        /// <param name="dtEdit2"></param>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListByFilter(
            string nodecode,
            string title,
            string tags,
            int iIndex,
            int iTop,
            int iAudit,
            string dtAdd1,
            string dtAdd2,
            string dtEdit1,
            string dtEdit2,
            long userId,
            bool isAdmin,
            int pageIndex,
            int pageSize, 
            ref int recordCount
            )
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                wcb.And(cmsNews._.NodeCode == nodecode); // 当前栏目
            }
            if (!isAdmin)
            {
                wcb.And(cmsNews._.IsAudit < 3);
            }
            if (!string.IsNullOrEmpty(title.Trim()))
            {
                wcb.And(cmsNews._.Title.Contain(title.Trim()));
            }
            if (!string.IsNullOrEmpty(tags.Trim()))
            {
                wcb.And(cmsNews._.Tags.Contain(tags.Trim()));
            }
            if (iIndex >= 0)
            {
                wcb.And(cmsNews._.IsIndex == iIndex);
            }
            if (iTop >= 0)
            {
                wcb.And(cmsNews._.IsTop == iTop);
            }
            if (iAudit >= 0)
            {
                wcb.And(cmsNews._.IsAudit == iAudit);
            }
            if (!isAdmin && userId > 0)
            {
                wcb.And(cmsNews._.AddUser == userId);
            }
            DateTime dt;
            if (DateTime.TryParse(dtAdd1.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime >= dt);
            }
            if (DateTime.TryParse(dtAdd2.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime <= dt);
            }
            if (DateTime.TryParse(dtEdit1.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime >= dt);
            }
            if (DateTime.TryParse(dtEdit2.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime <= dt);
            }

            FromSection fs = GetFromSection(wcb.ToWhereClip(), cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();
        }
        /// <summary>
        /// 根据条件取得下级所有文章
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="title"></param>
        /// <param name="source"></param>
        /// <param name="author"></param>
        /// <param name="tags"></param>
        /// <param name="iIndex"></param>
        /// <param name="iTop"></param>
        /// <param name="iAudit"></param>
        /// <param name="dtAdd1"></param>
        /// <param name="dtAdd2"></param>
        /// <param name="dtEdit1"></param>
        /// <param name="dtEdit2"></param>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListByFilter2(
            string nodecode,
            string title,
            string source,
            string author,
            string tags,
            int iIndex,
            int iTop,
            int iAudit,
            string dtAdd1,
            string dtAdd2,
            string dtEdit1,
            string dtEdit2,
            int userId,
            bool isAdmin,
            int pageIndex,
            int pageSize,
            ref int recordCount
            )
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                wcb.And(cmsNews._.NodeCode == nodecode); // 当前栏目
            }
            if (!string.IsNullOrEmpty(title.Trim()))
            {
                wcb.And(cmsNews._.Title.Contain(title.Trim()));
            }
            if (!string.IsNullOrEmpty(source.Trim()))
            {
                wcb.And(cmsNews._.Source.Contain(source.Trim()));
            }
            if (!string.IsNullOrEmpty(author.Trim()))
            {
                wcb.And(cmsNews._.Author.Contain(author.Trim()));
            }
            if (!string.IsNullOrEmpty(tags.Trim()))
            {
                wcb.And(cmsNews._.Tags.Contain(tags.Trim()));
            }
            if (iIndex >= 0)
            {
                wcb.And(cmsNews._.IsIndex == iIndex);
            }
            if (iTop >= 0)
            {
                wcb.And(cmsNews._.IsTop == iTop);
            }
            if (iAudit >= 0)
            {
                wcb.And(cmsNews._.IsAudit == iAudit);
            }
            if (!isAdmin && userId > 0)
            {
                //wcb.And(cmsNews._.AddUser == userId);
                wcb.And(cmsNews._.AddUser.SubQueryIn(
                    DBSession.CurrentSession.From<cmsUserMap>()
                    .Select(cmsUserMap._.UserId)
                    .Where(cmsUserMap._.UpUserId == userId)
                    )
                );
            }
            DateTime dt;
            if (DateTime.TryParse(dtAdd1.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime >= dt);
            }
            if (DateTime.TryParse(dtAdd2.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime <= dt);
            }
            if (DateTime.TryParse(dtEdit1.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime >= dt);
            }
            if (DateTime.TryParse(dtEdit2.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime <= dt);
            }

            FromSection fs = GetFromSection(wcb.ToWhereClip(), cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs
                .Select(cmsNews._.All)
                .Page(pageSize, pageIndex)
                .ToDataTable();
        }
        /// <summary>
        /// 根据条件取得专题下所有文章
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="title"></param>
        /// <param name="source"></param>
        /// <param name="author"></param>
        /// <param name="tags"></param>
        /// <param name="iIndex"></param>
        /// <param name="iTop"></param>
        /// <param name="iAudit"></param>
        /// <param name="dtAdd1"></param>
        /// <param name="dtAdd2"></param>
        /// <param name="dtEdit1"></param>
        /// <param name="dtEdit2"></param>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetListInTopicByFilter(
            int ztId,
            string title,
            string source,
            string author,
            string tags,
            int iIndex,
            int iTop,
            int iAudit,
            string dtAdd1,
            string dtAdd2,
            string dtEdit1,
            string dtEdit2,
            int userId,
            bool isAdmin,
            int pageIndex,
            int pageSize,
            ref int recordCount
            )
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (ztId > 0)
            {
                wcb.And(cmsNewsTopicRel._.TopicId == ztId);
            }
            if (!isAdmin)
            {
                wcb.And(cmsNews._.IsAudit < 3);
            }
            if (!string.IsNullOrEmpty(title.Trim()))
            {
                wcb.And(cmsNews._.Title.Contain(title.Trim()));
            }
            if (!string.IsNullOrEmpty(source.Trim()))
            {
                wcb.And(cmsNews._.Source.Contain(source.Trim()));
            }
            if (!string.IsNullOrEmpty(author.Trim()))
            {
                wcb.And(cmsNews._.Author.Contain(author.Trim()));
            }
            if (!string.IsNullOrEmpty(tags.Trim()))
            {
                wcb.And(cmsNews._.Tags.Contain(tags.Trim()));
            }
            if (iIndex >= 0)
            {
                wcb.And(cmsNews._.IsIndex == iIndex);
            }
            if (iTop >= 0)
            {
                wcb.And(cmsNews._.IsTop == iTop);
            }
            if (iAudit >= 0)
            {
                wcb.And(cmsNews._.IsAudit == iAudit);
            }
            if (!isAdmin && userId > 0)
            {
                wcb.And(cmsNews._.AddUser == userId);
            }
            DateTime dt;
            if (DateTime.TryParse(dtAdd1.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime >= dt);
            }
            if (DateTime.TryParse(dtAdd2.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime <= dt);
            }
            if (DateTime.TryParse(dtEdit1.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime >= dt);
            }
            if (DateTime.TryParse(dtEdit2.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime <= dt);
            }

            FromSection fs = entCMS.Services.DBSession.CurrentSession.From<cmsNews>()
                .InnerJoin<cmsNewsCatalog>(cmsNews._.NodeCode == cmsNewsCatalog._.NodeCode)
                .InnerJoin<cmsNewsTopicRel>(cmsNews._.Id == cmsNewsTopicRel._.NewsId)
                .Select(cmsNewsTopicRel._.TopicId, cmsNewsCatalog._.NodeName, cmsNews._.All)
                .Where(wcb.ToWhereClip())
                .OrderBy(cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodecode"></param>
        /// <param name="title"></param>
        /// <param name="productNo"></param>
        /// <param name="productModel"></param>
        /// <param name="tags"></param>
        /// <param name="iIndex"></param>
        /// <param name="iTop"></param>
        /// <param name="iAudit"></param>
        /// <param name="dtAdd1"></param>
        /// <param name="dtAdd2"></param>
        /// <param name="dtEdit1"></param>
        /// <param name="dtEdit2"></param>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetProductsByFilter(
            string nodecode,
            string title,
            string productNo,
            string productModel,
            string tags,
            int iIndex,
            int iTop,
            int iAudit,
            string dtAdd1,
            string dtAdd2,
            string dtEdit1,
            string dtEdit2,
            long userId,
            bool isAdmin,
            int pageIndex,
            int pageSize,
            ref int recordCount
            )
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            if (!string.IsNullOrEmpty(nodecode))
            {
                wcb.And(cmsNews._.NodeCode == nodecode); // 当前栏目
            }
            if (!isAdmin)
            {
                wcb.And(cmsNews._.IsAudit < 3);
            }
            if (!string.IsNullOrEmpty(title.Trim()))
            {
                wcb.And(cmsNews._.Title.Contain(title.Trim()));
            }
            if (!string.IsNullOrEmpty(productNo.Trim()))
            {
                wcb.And(cmsNews._.ProductNo.Contain(productNo.Trim()));
            }
            if (!string.IsNullOrEmpty(productModel.Trim()))
            {
                wcb.And(cmsNews._.ProductModel.Contain(productModel.Trim()));
            }
            if (!string.IsNullOrEmpty(tags.Trim()))
            {
                wcb.And(cmsNews._.Tags.Contain(tags.Trim()));
            }
            if (iIndex >= 0)
            {
                wcb.And(cmsNews._.IsIndex == iIndex);
            }
            if (iTop >= 0)
            {
                wcb.And(cmsNews._.IsTop == iTop);
            }
            if (iAudit >= 0)
            {
                wcb.And(cmsNews._.IsAudit == iAudit);
            }
            if (!isAdmin && userId > 0)
            {
                wcb.And(cmsNews._.AddUser == userId);
            }
            DateTime dt;
            if (DateTime.TryParse(dtAdd1.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime >= dt);
            }
            if (DateTime.TryParse(dtAdd2.Trim(), out dt))
            {
                wcb.And(cmsNews._.AddTime <= dt);
            }
            if (DateTime.TryParse(dtEdit1.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime >= dt);
            }
            if (DateTime.TryParse(dtEdit2.Trim(), out dt))
            {
                wcb.And(cmsNews._.EditTime <= dt);
            }

            FromSection fs = GetFromSection(wcb.ToWhereClip(), cmsNews._.EditTime.Desc);

            recordCount = fs.Count();

            return fs
                .Page(pageSize, pageIndex)
                .ToDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Save(cmsNews m)
        {
            return SaveModel(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int EnableIndex(string gid)
        {
            cmsNews n = GetModel(gid);
            if (n != null)
            {
                n.Attach();

                n.IsIndex = (n.IsIndex == 0) ? 1 : 0;

                return UpdateModel(n);
            }
            return 0;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int EnableTop(string gid)
        {
            cmsNews n = GetModel(gid);
            if (n != null)
            {
                n.Attach();

                n.IsTop = (n.IsTop == 0) ? 1 : 0;

                return UpdateModel(n);
            }
            return 0;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddNewsHit(string id)
        {
            NewsHitService nhs = NewsHitService.GetInstance();
            try
            {
                using (DbTrans t = BeginTransaction())
                {
                    cmsNews n = GetModel(id);
                    if (n != null)
                    {
                        n.Attach();

                        n.Hits++;

                        UpdateModel(n);
                    }

                    nhs.SetTransaction(t);
                    DateTime now = DateTime.Now;
                    cmsNewsHit nh = nhs.GetModelWithWhere(cmsNewsHit._.NewsId == id && cmsNewsHit._.HitDate == now.ToString("yyyy-MM-dd"));
                    if (nh == null)
                    {
                        nh = new cmsNewsHit();
                        nh.NewsId = id;
                        nh.Hits = 1;
                        nh.HitDate = DateTime.Parse(now.ToString("yyyy-MM-dd"));

                        nhs.AddModel(nh);
                    }
                    else
                    {
                        nh.Attach();
                        nh.Hits = nh.Hits + 1;

                        nhs.UpdateModel(nh);
                    }

                    t.Commit();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public int CopyTo(string[] ids, string[] nodes)
        {
            if (ids.Length == 0) throw new Exception("被复制的文章未选择！");
            if (nodes.Length == 0) throw new Exception("要复制到的栏目未选择！");
            
            int r = 0;

            try
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    cmsNewsCatalog nc = NewsCatalogService.GetInstance().Get(nodes[i]);

                    for (int j = 0; j < ids.Length; j++)
                    {
                        string sql = @"insert into cmsNews(RGuid,NodeCode,Title,Content,Summary,Tags,Author,Source,SmallPic,Pics,Hits,AddTime,AddUser,EditTime,EditUser,OrderNo,IsIndex,IsTop,IsAudit,AuditTime,AuditUser,AuditComment,ProductNo,ProductModel,Parameter1,Parameter2,Parameter3,Parameter4,Parameter5,langId)
                                   select '{0}','{1}',Title,Content,Summary,Tags,Author,Source,SmallPic,Pics,Hits,AddTime,AddUser,EditTime,EditUser,OrderNo,IsIndex,IsTop,IsAudit,AuditTime,AuditUser,AuditComment,ProductNo,ProductModel,Parameter1,Parameter2,Parameter3,Parameter4,Parameter5,{2} from cmsNews 
                                   where 1=1 and Id='{3}'";
                        sql = string.Format(sql, Guid.NewGuid().ToString(), nodes[i], nc.LangId, ids[j]);
                        r = DBSession.CurrentSession.FromSql(sql).ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public int MoveTo(string[] ids, string[] nodes)
        {
            if (ids.Length == 0) throw new Exception("被移动的文章未选择！");
            if (nodes.Length == 0) throw new Exception("要移动到的栏目未选择！");

            int r = 0;

            try
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    cmsNewsCatalog nc = NewsCatalogService.GetInstance().Get(nodes[i]);

                    string sql = @"update cmsNews set nodecode='{0}',langId={1} where 1=1 and Id in ('{2}')";
                    sql = string.Format(sql, nodes[i], nc.LangId, string.Join("','", ids).Replace("'0',", ""));

                    r = DBSession.CurrentSession.FromSql(sql).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Count(int type)
        {
            FromSection fs = entCMS.Services.DBSession.CurrentSession.From<cmsNews>()
                .InnerJoin<cmsNewsCatalog>(cmsNews._.NodeCode == cmsNewsCatalog._.NodeCode)
                .Select(cmsNewsCatalog._.NodeName, cmsNews._.All)
                .Where(cmsNewsCatalog._.NodeType == type)
                .OrderBy(cmsNews._.EditTime.Desc);

            return fs.Count();
        }
    }
}
