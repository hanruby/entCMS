using System;
using System.Collections.Generic;
using System.Text;
using entCMS.Models;
using System.Data;
using Hxj.Data;

namespace entCMS.Services
{
    public class FeedbackService : BaseService<cmsFeedback>
    {
        #region 私有构造函数，防止实例化
        private FeedbackService()
        {
        }
        #endregion

        #region 实现单例模式
        static FeedbackService()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    instance = new FeedbackService();
                }
            }
        }

        public static FeedbackService GetInstance()
        {
            return (FeedbackService)instance;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <param name="isReplied"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetDataTable(long langId, bool? isReplied, int pageIndex, int pageSize, ref int count)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsFeedback._.LangId==langId);
            if(isReplied.HasValue){
                wcb.And(cmsFeedback._.IsReplied == isReplied.Value);
            }
            return GetDataTable(wcb.ToWhereClip(), cmsFeedback._.PostTime.Desc, 1, 5, ref count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langId"></param>
        /// <param name="isReplied"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<cmsFeedback> GetList(long langId, bool? isReplied, int pageIndex, int pageSize, ref int count)
        {
            WhereClipBuilder wcb = new WhereClipBuilder();
            wcb.And(cmsFeedback._.LangId == langId);
            if (isReplied.HasValue)
            {
                wcb.And(cmsFeedback._.IsReplied == isReplied.Value);
            }
            return GetList(wcb.ToWhereClip(), cmsFeedback._.PostTime.Desc, 1, 5, ref count);
        }
    }
}
