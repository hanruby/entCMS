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
	/// 实体类cmsProduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsProduct : Entity 
	{
		public cmsProduct():base("cmsProduct") {}

		#region Model
		private long _Id;
		private string _RGuid;
		private string _NodeCode;
		private string _Title;
		private string _Content;
		private string _Summary;
		private string _SmallPic;
		private int? _Hits;
		private DateTime? _AddTime;
		private long? _AddUser;
		private DateTime? _EditTime;
		private long? _EditUser;
		private int? _OrderNo;
		private int? _IsIndex;
		private int? _IsTop;
		private string _ProductNo;
		private string _Model;
		private string _Parameter1;
		private string _Parameter2;
		private string _Parameter3;
		private string _Parameter4;
		private string _Parameter5;
		private long _LangId;
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
		public string RGuid
		{
			get{ return _RGuid; }
			set
			{
				this.OnPropertyValueChange(_.RGuid,_RGuid,value);
				this._RGuid=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NodeCode
		{
			get{ return _NodeCode; }
			set
			{
				this.OnPropertyValueChange(_.NodeCode,_NodeCode,value);
				this._NodeCode=value;
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
		public string Content
		{
			get{ return _Content; }
			set
			{
				this.OnPropertyValueChange(_.Content,_Content,value);
				this._Content=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			get{ return _Summary; }
			set
			{
				this.OnPropertyValueChange(_.Summary,_Summary,value);
				this._Summary=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmallPic
		{
			get{ return _SmallPic; }
			set
			{
				this.OnPropertyValueChange(_.SmallPic,_SmallPic,value);
				this._SmallPic=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Hits
		{
			get{ return _Hits; }
			set
			{
				this.OnPropertyValueChange(_.Hits,_Hits,value);
				this._Hits=value;
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
		/// <summary>
		/// 
		/// </summary>
		public long? AddUser
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
		public DateTime? EditTime
		{
			get{ return _EditTime; }
			set
			{
				this.OnPropertyValueChange(_.EditTime,_EditTime,value);
				this._EditTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? EditUser
		{
			get{ return _EditUser; }
			set
			{
				this.OnPropertyValueChange(_.EditUser,_EditUser,value);
				this._EditUser=value;
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
		public int? IsIndex
		{
			get{ return _IsIndex; }
			set
			{
				this.OnPropertyValueChange(_.IsIndex,_IsIndex,value);
				this._IsIndex=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsTop
		{
			get{ return _IsTop; }
			set
			{
				this.OnPropertyValueChange(_.IsTop,_IsTop,value);
				this._IsTop=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductNo
		{
			get{ return _ProductNo; }
			set
			{
				this.OnPropertyValueChange(_.ProductNo,_ProductNo,value);
				this._ProductNo=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			get{ return _Model; }
			set
			{
				this.OnPropertyValueChange(_.Model,_Model,value);
				this._Model=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parameter1
		{
			get{ return _Parameter1; }
			set
			{
				this.OnPropertyValueChange(_.Parameter1,_Parameter1,value);
				this._Parameter1=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parameter2
		{
			get{ return _Parameter2; }
			set
			{
				this.OnPropertyValueChange(_.Parameter2,_Parameter2,value);
				this._Parameter2=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parameter3
		{
			get{ return _Parameter3; }
			set
			{
				this.OnPropertyValueChange(_.Parameter3,_Parameter3,value);
				this._Parameter3=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parameter4
		{
			get{ return _Parameter4; }
			set
			{
				this.OnPropertyValueChange(_.Parameter4,_Parameter4,value);
				this._Parameter4=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parameter5
		{
			get{ return _Parameter5; }
			set
			{
				this.OnPropertyValueChange(_.Parameter5,_Parameter5,value);
				this._Parameter5=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public long LangId
		{
			get{ return _LangId; }
			set
			{
				this.OnPropertyValueChange(_.LangId,_LangId,value);
				this._LangId=value;
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
				_.RGuid,
				_.NodeCode,
				_.Title,
				_.Content,
				_.Summary,
				_.SmallPic,
				_.Hits,
				_.AddTime,
				_.AddUser,
				_.EditTime,
				_.EditUser,
				_.OrderNo,
				_.IsIndex,
				_.IsTop,
				_.ProductNo,
				_.Model,
				_.Parameter1,
				_.Parameter2,
				_.Parameter3,
				_.Parameter4,
				_.Parameter5,
				_.LangId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._RGuid,
				this._NodeCode,
				this._Title,
				this._Content,
				this._Summary,
				this._SmallPic,
				this._Hits,
				this._AddTime,
				this._AddUser,
				this._EditTime,
				this._EditUser,
				this._OrderNo,
				this._IsIndex,
				this._IsTop,
				this._ProductNo,
				this._Model,
				this._Parameter1,
				this._Parameter2,
				this._Parameter3,
				this._Parameter4,
				this._Parameter5,
				this._LangId};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<long>(reader["Id"]);
			this._RGuid = DataUtils.ConvertValue<string>(reader["RGuid"]);
			this._NodeCode = DataUtils.ConvertValue<string>(reader["NodeCode"]);
			this._Title = DataUtils.ConvertValue<string>(reader["Title"]);
			this._Content = DataUtils.ConvertValue<string>(reader["Content"]);
			this._Summary = DataUtils.ConvertValue<string>(reader["Summary"]);
			this._SmallPic = DataUtils.ConvertValue<string>(reader["SmallPic"]);
			this._Hits = DataUtils.ConvertValue<int?>(reader["Hits"]);
			this._AddTime = DataUtils.ConvertValue<DateTime?>(reader["AddTime"]);
			this._AddUser = DataUtils.ConvertValue<long?>(reader["AddUser"]);
			this._EditTime = DataUtils.ConvertValue<DateTime?>(reader["EditTime"]);
			this._EditUser = DataUtils.ConvertValue<long?>(reader["EditUser"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(reader["OrderNo"]);
			this._IsIndex = DataUtils.ConvertValue<int?>(reader["IsIndex"]);
			this._IsTop = DataUtils.ConvertValue<int?>(reader["IsTop"]);
			this._ProductNo = DataUtils.ConvertValue<string>(reader["ProductNo"]);
			this._Model = DataUtils.ConvertValue<string>(reader["Model"]);
			this._Parameter1 = DataUtils.ConvertValue<string>(reader["Parameter1"]);
			this._Parameter2 = DataUtils.ConvertValue<string>(reader["Parameter2"]);
			this._Parameter3 = DataUtils.ConvertValue<string>(reader["Parameter3"]);
			this._Parameter4 = DataUtils.ConvertValue<string>(reader["Parameter4"]);
			this._Parameter5 = DataUtils.ConvertValue<string>(reader["Parameter5"]);
			this._LangId = DataUtils.ConvertValue<long>(reader["LangId"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<long>(row["Id"]);
			this._RGuid = DataUtils.ConvertValue<string>(row["RGuid"]);
			this._NodeCode = DataUtils.ConvertValue<string>(row["NodeCode"]);
			this._Title = DataUtils.ConvertValue<string>(row["Title"]);
			this._Content = DataUtils.ConvertValue<string>(row["Content"]);
			this._Summary = DataUtils.ConvertValue<string>(row["Summary"]);
			this._SmallPic = DataUtils.ConvertValue<string>(row["SmallPic"]);
			this._Hits = DataUtils.ConvertValue<int?>(row["Hits"]);
			this._AddTime = DataUtils.ConvertValue<DateTime?>(row["AddTime"]);
			this._AddUser = DataUtils.ConvertValue<long?>(row["AddUser"]);
			this._EditTime = DataUtils.ConvertValue<DateTime?>(row["EditTime"]);
			this._EditUser = DataUtils.ConvertValue<long?>(row["EditUser"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(row["OrderNo"]);
			this._IsIndex = DataUtils.ConvertValue<int?>(row["IsIndex"]);
			this._IsTop = DataUtils.ConvertValue<int?>(row["IsTop"]);
			this._ProductNo = DataUtils.ConvertValue<string>(row["ProductNo"]);
			this._Model = DataUtils.ConvertValue<string>(row["Model"]);
			this._Parameter1 = DataUtils.ConvertValue<string>(row["Parameter1"]);
			this._Parameter2 = DataUtils.ConvertValue<string>(row["Parameter2"]);
			this._Parameter3 = DataUtils.ConvertValue<string>(row["Parameter3"]);
			this._Parameter4 = DataUtils.ConvertValue<string>(row["Parameter4"]);
			this._Parameter5 = DataUtils.ConvertValue<string>(row["Parameter5"]);
			this._LangId = DataUtils.ConvertValue<long>(row["LangId"]);
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
			public readonly static Field All = new Field("*","cmsProduct");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsProduct","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RGuid = new Field("RGuid","cmsProduct","RGuid");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NodeCode = new Field("NodeCode","cmsProduct","NodeCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Title = new Field("Title","cmsProduct","Title");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Content = new Field("Content","cmsProduct","Content");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Summary = new Field("Summary","cmsProduct","Summary");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SmallPic = new Field("SmallPic","cmsProduct","SmallPic");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Hits = new Field("Hits","cmsProduct","Hits");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddTime = new Field("AddTime","cmsProduct","AddTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddUser = new Field("AddUser","cmsProduct","AddUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EditTime = new Field("EditTime","cmsProduct","EditTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EditUser = new Field("EditUser","cmsProduct","EditUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNo = new Field("OrderNo","cmsProduct","OrderNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsIndex = new Field("IsIndex","cmsProduct","IsIndex");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsTop = new Field("IsTop","cmsProduct","IsTop");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProductNo = new Field("ProductNo","cmsProduct","ProductNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Model = new Field("Model","cmsProduct","Model");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Parameter1 = new Field("Parameter1","cmsProduct","Parameter1");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Parameter2 = new Field("Parameter2","cmsProduct","Parameter2");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Parameter3 = new Field("Parameter3","cmsProduct","Parameter3");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Parameter4 = new Field("Parameter4","cmsProduct","Parameter4");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Parameter5 = new Field("Parameter5","cmsProduct","Parameter5");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LangId = new Field("LangId","cmsProduct","LangId");
		}
		#endregion


	}
}

