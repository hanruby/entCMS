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
	/// 实体类cmsMemberGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsMemberGroup : Entity 
	{
		public cmsMemberGroup():base("cmsMemberGroup") {}

		#region Model
		private long _Id;
		private string _Name;
		private int? _Level;
		private string _Remark;
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
		public string Name
		{
			get{ return _Name; }
			set
			{
				this.OnPropertyValueChange(_.Name,_Name,value);
				this._Name=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Level
		{
			get{ return _Level; }
			set
			{
				this.OnPropertyValueChange(_.Level,_Level,value);
				this._Level=value;
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
				_.Name,
				_.Level,
				_.Remark,
				_.IsEnabled};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._Name,
				this._Level,
				this._Remark,
				this._IsEnabled};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<long>(reader["Id"]);
			this._Name = DataUtils.ConvertValue<string>(reader["Name"]);
			this._Level = DataUtils.ConvertValue<int?>(reader["Level"]);
			this._Remark = DataUtils.ConvertValue<string>(reader["Remark"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(reader["IsEnabled"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<long>(row["Id"]);
			this._Name = DataUtils.ConvertValue<string>(row["Name"]);
			this._Level = DataUtils.ConvertValue<int?>(row["Level"]);
			this._Remark = DataUtils.ConvertValue<string>(row["Remark"]);
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
			public readonly static Field All = new Field("*","cmsMemberGroup");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsMemberGroup","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","cmsMemberGroup","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Level = new Field("Level","cmsMemberGroup","Level");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Remark = new Field("Remark","cmsMemberGroup","Remark");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnabled = new Field("IsEnabled","cmsMemberGroup","IsEnabled");
		}
		#endregion


	}
}

