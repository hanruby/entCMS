﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5444
//     Support: http://www.cnblogs.com/huxj
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data;
using System.Data.Common;
using Hxj.Data;
using Hxj.Data.Common;

namespace entCMS.Models
{

	/// <summary>
	/// 实体类cmsAd 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsAd : Entity 
	{
		public cmsAd():base("cmsAd") {}

		#region Model
		private long _Id;
		private int? _Type;
		private string _Title;
		private string _Remark;
		private string _Pics;
		private string _Urls;
		private int? _OrderNo;
		private int? _IsEnabled;
		private int? _AddUser;
		private DateTime? _AddTime;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			get{ return _Id; }
			set
			{
				this.OnPropertyValueChange(_.Id,_Id,value);
				this._Id=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type
		{
			get{ return _Type; }
			set
			{
				this.OnPropertyValueChange(_.Type,_Type,value);
				this._Type=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			get{ return _Title; }
			set
			{
				this.OnPropertyValueChange(_.Title,_Title,value);
				this._Title=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			get{ return _Remark; }
			set
			{
				this.OnPropertyValueChange(_.Remark,_Remark,value);
				this._Remark=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pics
		{
			get{ return _Pics; }
			set
			{
				this.OnPropertyValueChange(_.Pics,_Pics,value);
				this._Pics=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Urls
		{
			get{ return _Urls; }
			set
			{
				this.OnPropertyValueChange(_.Urls,_Urls,value);
				this._Urls=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderNo
		{
			get{ return _OrderNo; }
			set
			{
				this.OnPropertyValueChange(_.OrderNo,_OrderNo,value);
				this._OrderNo=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsEnabled
		{
			get{ return _IsEnabled; }
			set
			{
				this.OnPropertyValueChange(_.IsEnabled,_IsEnabled,value);
				this._IsEnabled=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddUser
		{
			get{ return _AddUser; }
			set
			{
				this.OnPropertyValueChange(_.AddUser,_AddUser,value);
				this._AddUser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			get{ return _AddTime; }
			set
			{
				this.OnPropertyValueChange(_.AddTime,_AddTime,value);
				this._AddTime=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.Id;
		}
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.Id};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.Id,
				_.Type,
				_.Title,
				_.Remark,
				_.Pics,
				_.Urls,
				_.OrderNo,
				_.IsEnabled,
				_.AddUser,
				_.AddTime};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._Type,
				this._Title,
				this._Remark,
				this._Pics,
				this._Urls,
				this._OrderNo,
				this._IsEnabled,
				this._AddUser,
				this._AddTime};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<long>(reader["Id"]);
			this._Type = DataUtils.ConvertValue<int?>(reader["Type"]);
			this._Title = DataUtils.ConvertValue<string>(reader["Title"]);
			this._Remark = DataUtils.ConvertValue<string>(reader["Remark"]);
			this._Pics = DataUtils.ConvertValue<string>(reader["Pics"]);
			this._Urls = DataUtils.ConvertValue<string>(reader["Urls"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(reader["OrderNo"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(reader["IsEnabled"]);
			this._AddUser = DataUtils.ConvertValue<int?>(reader["AddUser"]);
			this._AddTime = DataUtils.ConvertValue<DateTime?>(reader["AddTime"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<long>(row["Id"]);
			this._Type = DataUtils.ConvertValue<int?>(row["Type"]);
			this._Title = DataUtils.ConvertValue<string>(row["Title"]);
			this._Remark = DataUtils.ConvertValue<string>(row["Remark"]);
			this._Pics = DataUtils.ConvertValue<string>(row["Pics"]);
			this._Urls = DataUtils.ConvertValue<string>(row["Urls"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(row["OrderNo"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(row["IsEnabled"]);
			this._AddUser = DataUtils.ConvertValue<int?>(row["AddUser"]);
			this._AddTime = DataUtils.ConvertValue<DateTime?>(row["AddTime"]);
		}
		#endregion

		#region _Field
		/// <summary>
		/// 字段信息
		/// </summary>
		public class _
		{
			/// <summary>
			/// * 
			/// </summary>
			public readonly static Field All = new Field("*","cmsAd");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsAd","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Type = new Field("Type","cmsAd","Type");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Title = new Field("Title","cmsAd","Title");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Remark = new Field("Remark","cmsAd","Remark");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Pics = new Field("Pics","cmsAd","Pics");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Urls = new Field("Urls","cmsAd","Urls");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNo = new Field("OrderNo","cmsAd","OrderNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnabled = new Field("IsEnabled","cmsAd","IsEnabled");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddUser = new Field("AddUser","cmsAd","AddUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddTime = new Field("AddTime","cmsAd","AddTime");
		}
		#endregion


	}
}

