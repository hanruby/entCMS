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
	/// 实体类cmsRole 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsRole : Entity 
	{
		public cmsRole():base("cmsRole") {}

		#region Model
		private long _Id;
		private string _RoleName;
		private int? _OrderNo;
		private int? _IsEnabled;
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
		public string RoleName
		{
			get{ return _RoleName; }
			set
			{
				this.OnPropertyValueChange(_.RoleName,_RoleName,value);
				this._RoleName=value;
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
				_.RoleName,
				_.OrderNo,
				_.IsEnabled};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._RoleName,
				this._OrderNo,
				this._IsEnabled};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<long>(reader["Id"]);
			this._RoleName = DataUtils.ConvertValue<string>(reader["RoleName"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(reader["OrderNo"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(reader["IsEnabled"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<long>(row["Id"]);
			this._RoleName = DataUtils.ConvertValue<string>(row["RoleName"]);
			this._OrderNo = DataUtils.ConvertValue<int?>(row["OrderNo"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(row["IsEnabled"]);
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
			public readonly static Field All = new Field("*","cmsRole");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsRole","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleName = new Field("RoleName","cmsRole","RoleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNo = new Field("OrderNo","cmsRole","OrderNo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnabled = new Field("IsEnabled","cmsRole","IsEnabled");
		}
		#endregion


	}
}

