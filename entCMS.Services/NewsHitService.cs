using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using Hxj.Data;
using System.Data;

namespace entCMS.Services
{
    public enum HitType
    {
        DAY = 0,
        WEEK = 1,
        MONTH = 2,
        YEAR = 3
    }
    public class NewsHitService : BaseService<cmsNewsHit>
    {
        NewsService ns = NewsService.GetInstance();

        #region 实现单例模式
        private NewsHitService()
        {
        }
        static NewsHitService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new NewsHitService();
                }
            }
        }

        public static NewsHitService GetInstance()
        {
            return (NewsHitService)instance;
        }
        #endregion

        public int Add(string newsId)
        {
            int ret = 0;
            DateTime dt = DateTime.Now;

            cmsNews n = ns.GetModel(newsId);
            if (n == null) throw new Exception("文章不存在！");

            using (DbTrans t = ns.BeginTransaction())
            {
                n.Attach();
                n.Hits += 1;
                ns.UpdateModel(n);

                SetTransaction(t);

                cmsNewsHit h = GetModelWithWhere(
                    cmsNewsHit._.NewsId == newsId && (
                    cmsNewsHit._.HitDate.Year == dt.Year &&
                    cmsNewsHit._.HitDate.Month == dt.Month &&
                    cmsNewsHit._.HitDate.Day == dt.Day)
                );
                if (h == null)
                {
                    h = new cmsNewsHit();
                    h.NewsId = newsId;
                    h.HitDate = DateTime.Now.Date;
                    h.Hits = 1;
                    ret = AddModel(h);
                }
                else
                {
                    h.Attach();
                    h.Hits += 1;
                    ret = UpdateModel(h);
                }

                t.Commit();
            }
            return ret;
        }

    }
}
