using System;
using System.Collections.Generic;
using System.Text;
using Hxj.Data;
using System.Data;

namespace entCMS.Services
{
    public class BaseService<T> where T : Hxj.Data.Entity
    {
        protected static BaseService<T> instance = null;
        protected static object lockObj = new object();
        
        #region 事务相关
        private DbTrans _trans = null;
        /// <summary>
        /// 获取事务
        /// </summary>
        /// <returns></returns>
        public DbTrans GetTransaction()
        {
            return _trans;
        }
        /// <summary>
        /// 设置事务
        /// </summary>
        /// <param name="trans"></param>
        public void SetTransaction(DbTrans trans)
        {
            _trans = trans;
        }
        /// <summary>
        /// 启动事务
        /// </summary>
        /// <returns></returns>
        public DbTrans BeginTransaction()
        {
            _trans = DBSession.CurrentSession.BeginTransaction();
            return _trans;
        }
        /// <summary>
        /// 关闭事务
        /// </summary>
        public void CloseTransaction()
        {
            if (_trans != null)
                _trans.Close();
            _trans = null;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            if (_trans != null)
                _trans.Commit();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            if (_trans != null)
                _trans.Rollback();
        }
        #endregion

        /// <summary>
        /// 是否存在符合条件的记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Exists(WhereClip where)
        {
            return DBSession.CurrentSession.Exists<T>(where);
        }

        /// <summary>
        /// 取field字段的最大值
        /// </summary>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public object Max(Field field, WhereClip where)
        {
            return DBSession.CurrentSession.Max<T>(field, where);
        }
        /// <summary>
        /// 取符合条件的记录数
        /// </summary>
        /// <param name="where0"></param>
        /// <returns></returns>
        public int Count(WhereClip where)
        {
            return DBSession.CurrentSession.Count<T>(where);
        }
        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(T model)
        {
            if (_trans != null)
                return _trans.Insert<T>(model);

            return DBSession.CurrentSession.Insert<T>(model);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateModel(T model)
        {
            if (_trans != null)
                return _trans.Update<T>(model);

            return DBSession.CurrentSession.Update<T>(model);
        }

        /// <summary>
        /// 根据条件批量更新数据
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int UpdateModels(Field field, object value, WhereClip where)
        {
            return DBSession.CurrentSession.Update<T>(field, value, where);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveModel(T model)
        {
            if (model.GetModifyFields().Count>0)
            {
                return UpdateModel(model);
            }
            else
            {
                return AddModel(model);
            }
        }
        /// <summary>
        /// 通过主键删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteModel(string ID)
        {
            if (_trans != null)
                return _trans.Delete<T>(ID);
            return DBSession.CurrentSession.Delete<T>(ID);
        }
        /// <summary>
        /// 通过主键数组删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public int DeleteModels(string[] IDs)
        {
            if (_trans != null)
                return _trans.Delete<T>(Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>()[0].SelectIn<string>(IDs));
            return DBSession.CurrentSession.Delete<T>(Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>()[0].SelectIn<string>(IDs));
        }
        /// <summary>
        /// 通过指定条件删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int DeleteModels(WhereClip where)
        {
            if (_trans != null)
                return _trans.Delete<T>(where);

            return DBSession.CurrentSession.Delete<T>(where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetModel(object id)
        {
            Field[] pkfields = Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>();
            if (pkfields.Length == 1)
            {
                if (_trans != null)
                {
                    return _trans.From<T>().Where(pkfields[0] == id).ToFirst();
                }
                return DBSession.CurrentSession.From<T>().Where(pkfields[0] == id).ToFirst();
            }
            else if (pkfields.Length > 1)
            {
                return GetModel((id as Array));
            }
            else
            {
                throw new Exception("数据表[" + Hxj.Data.Common.EntityCache.GetTableName<T>() + "]不存在任何主键！");
            }
        }
        /// <summary>
        /// 得到实体类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetModel(params object[] id)
        {
            if (id == null || id.Length == 0) return null;

            Field[] pkfields = Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>();
            if (id == null) throw new ArgumentNullException("请指定主键值！");
            if (pkfields==null || pkfields.Length == 0) throw new Exception("数据表[" + Hxj.Data.Common.EntityCache.GetTableName<T>() + "]不存在任何主键！");

            T t = null;
            if (pkfields.Length == 1)
            {
                if (_trans != null)
                {
                    t = _trans.From<T>().Where(Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>()[0] == id).ToFirst();
                }
                t = DBSession.CurrentSession.From<T>().Where(Hxj.Data.Common.EntityCache.GetPrimaryKeyFields<T>()[0] == id[0]).ToFirst();
            }
            else
            {
                if (id.Length != pkfields.Length) throw new Exception("指定的主键值个数与数据表的主键个数不符！");

                FromSection<T> section = null;
                if (_trans != null)
                {
                    section = _trans.From<T>();
                }
                else
                {
                    section = DBSession.CurrentSession.From<T>();
                }
                WhereClipBuilder wcb = new WhereClipBuilder();
                for (int i=0; i<pkfields.Length; i++)
                {
                    wcb.And(pkfields[i] == id[i]);
                }
                t = section.Where(wcb.ToWhereClip()).ToFirst();
            }
            GetRelations(ref t);
            return t;
        }
        /// <summary>
        /// 得到实体类
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public T GetModelWithWhere(WhereClip where)
        {
            if (where == null || string.IsNullOrEmpty(where.WhereString)) return null;

            T t = default(T);
            if (_trans != null)
            {
                t = _trans.From<T>().Where(where).ToFirst();
            }
            else
            {
                t = DBSession.CurrentSession.From<T>().Where(where).ToFirst();
            }
            GetRelations(ref t);
            return t;
        }
        /// <summary>
        /// 得到实体类
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public T GetModel(WhereClip where, OrderByClip order)
        {
            T t = default(T);
            if (_trans != null)
            {
                t = _trans.From<T>().Where(where).OrderBy(order).ToFirst();
            }
            else
            {
                t=DBSession.CurrentSession.From<T>().Where(where).OrderBy(order).ToFirst();
            }
            GetRelations(ref t);
            return t;
        }
        /// <summary>
        /// 返回FromSection
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public FromSection<T> GetFromSection(WhereClip where, OrderByClip order)
        {
            if (_trans != null)
            {
                return _trans.From<T>().Where(where).OrderBy(order);
            }
            return DBSession.CurrentSession.From<T>().Where(where).OrderBy(order);
        }
        /// <summary>
        /// 返回实体数据集
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable GetDataTable(WhereClip where, OrderByClip order)
        {
            return GetFromSection(where, order).ToDataTable();
        }
        /// <summary>
        /// 返回实体数据集分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(WhereClip where, OrderByClip order, int pageIndex, int pageSize, ref int recordCount)
        {
            recordCount = Count(where);
            return GetFromSection(where, order).Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 返回实体数据集分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(FromSection fromSection, WhereClip where, OrderByClip order, int pageIndex, int pageSize, ref int recordCount)
        {
            recordCount = fromSection.Where(where).Count();
            return fromSection.Where(where).OrderBy(order).Page(pageSize, pageIndex).ToDataTable();
        }
        /// <summary>
        /// 返回实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<T> GetList(WhereClip where, OrderByClip order)
        {
            return GetFromSection(where, order).ToList();
        }
        /// <summary>
        /// 返回实体列表分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<T> GetList(WhereClip where, OrderByClip order, int pageIndex, int pageSize, ref int recordCount)
        {
            recordCount = Count(where);
            return GetFromSection(where, order).Page(pageSize, pageIndex).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            if (_trans != null)
                return _trans.FromSql(sql).ExecuteNonQuery();
            return DBSession.CurrentSession.FromSql(sql).ExecuteNonQuery();
        }

        /*
        /// <summary>
        /// 虚方法测试
        /// </summary>
        public virtual void Test()
        {
        }
        */
        /// <summary>
        /// 对象初始化
        /// </summary>
        public virtual void Initialize() { }


        /// <summary>
        /// 获取相关对象
        /// </summary>
        /// <param name="t"></param>
        protected virtual void GetRelations(ref T t) { }
    }
}
