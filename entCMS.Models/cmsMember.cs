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
	/// 实体类cmsMember 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsMember : Entity 
	{
		public cmsMember():base("cmsMember") {}

		#region Model
		private long _Id;
		private string _UName;
		private string _UPwd;
		private string _Name;
		private int? _Sex;
		private string _Telephone;
		private string _Mobile;
		private string _Email;
		private string _QQ;
		private string _MSN;
		private string _TaoBao;
		private string _Remark;
		private string _ComNameZh;
		private string _ComNameEn;
		private string _ComTel;
		private string _ComFax;
		private string _ComAddr;
		private string _ComZipcode;
		private string _ComUrl;
		private long? _GroupId;
		private int? _IsEnabled;
		private DateTime? _CreateTime;
		private DateTime? _CheckTime;
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
		public string UName
		{
			get{ return _UName; }
			set
			{
				this.OnPropertyValueChange(_.UName,_UName,value);
				this._UName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UPwd
		{
			get{ return _UPwd; }
			set
			{
				this.OnPropertyValueChange(_.UPwd,_UPwd,value);
				this._UPwd=value;
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
		public int? Sex
		{
			get{ return _Sex; }
			set
			{
				this.OnPropertyValueChange(_.Sex,_Sex,value);
				this._Sex=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			get{ return _Telephone; }
			set
			{
				this.OnPropertyValueChange(_.Telephone,_Telephone,value);
				this._Telephone=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			get{ return _Mobile; }
			set
			{
				this.OnPropertyValueChange(_.Mobile,_Mobile,value);
				this._Mobile=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			get{ return _Email; }
			set
			{
				this.OnPropertyValueChange(_.Email,_Email,value);
				this._Email=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			get{ return _QQ; }
			set
			{
				this.OnPropertyValueChange(_.QQ,_QQ,value);
				this._QQ=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MSN
		{
			get{ return _MSN; }
			set
			{
				this.OnPropertyValueChange(_.MSN,_MSN,value);
				this._MSN=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaoBao
		{
			get{ return _TaoBao; }
			set
			{
				this.OnPropertyValueChange(_.TaoBao,_TaoBao,value);
				this._TaoBao=value;
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
		public string ComNameZh
		{
			get{ return _ComNameZh; }
			set
			{
				this.OnPropertyValueChange(_.ComNameZh,_ComNameZh,value);
				this._ComNameZh=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComNameEn
		{
			get{ return _ComNameEn; }
			set
			{
				this.OnPropertyValueChange(_.ComNameEn,_ComNameEn,value);
				this._ComNameEn=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComTel
		{
			get{ return _ComTel; }
			set
			{
				this.OnPropertyValueChange(_.ComTel,_ComTel,value);
				this._ComTel=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComFax
		{
			get{ return _ComFax; }
			set
			{
				this.OnPropertyValueChange(_.ComFax,_ComFax,value);
				this._ComFax=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComAddr
		{
			get{ return _ComAddr; }
			set
			{
				this.OnPropertyValueChange(_.ComAddr,_ComAddr,value);
				this._ComAddr=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComZipcode
		{
			get{ return _ComZipcode; }
			set
			{
				this.OnPropertyValueChange(_.ComZipcode,_ComZipcode,value);
				this._ComZipcode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComUrl
		{
			get{ return _ComUrl; }
			set
			{
				this.OnPropertyValueChange(_.ComUrl,_ComUrl,value);
				this._ComUrl=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? GroupId
		{
			get{ return _GroupId; }
			set
			{
				this.OnPropertyValueChange(_.GroupId,_GroupId,value);
				this._GroupId=value;
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
		public DateTime? CreateTime
		{
			get{ return _CreateTime; }
			set
			{
				this.OnPropertyValueChange(_.CreateTime,_CreateTime,value);
				this._CreateTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckTime
		{
			get{ return _CheckTime; }
			set
			{
				this.OnPropertyValueChange(_.CheckTime,_CheckTime,value);
				this._CheckTime=value;
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
				_.UName,
				_.UPwd,
				_.Name,
				_.Sex,
				_.Telephone,
				_.Mobile,
				_.Email,
				_.QQ,
				_.MSN,
				_.TaoBao,
				_.Remark,
				_.ComNameZh,
				_.ComNameEn,
				_.ComTel,
				_.ComFax,
				_.ComAddr,
				_.ComZipcode,
				_.ComUrl,
				_.GroupId,
				_.IsEnabled,
				_.CreateTime,
				_.CheckTime};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._UName,
				this._UPwd,
				this._Name,
				this._Sex,
				this._Telephone,
				this._Mobile,
				this._Email,
				this._QQ,
				this._MSN,
				this._TaoBao,
				this._Remark,
				this._ComNameZh,
				this._ComNameEn,
				this._ComTel,
				this._ComFax,
				this._ComAddr,
				this._ComZipcode,
				this._ComUrl,
				this._GroupId,
				this._IsEnabled,
				this._CreateTime,
				this._CheckTime};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<long>(reader["Id"]);
			this._UName = DataUtils.ConvertValue<string>(reader["UName"]);
			this._UPwd = DataUtils.ConvertValue<string>(reader["UPwd"]);
			this._Name = DataUtils.ConvertValue<string>(reader["Name"]);
			this._Sex = DataUtils.ConvertValue<int?>(reader["Sex"]);
			this._Telephone = DataUtils.ConvertValue<string>(reader["Telephone"]);
			this._Mobile = DataUtils.ConvertValue<string>(reader["Mobile"]);
			this._Email = DataUtils.ConvertValue<string>(reader["Email"]);
			this._QQ = DataUtils.ConvertValue<string>(reader["QQ"]);
			this._MSN = DataUtils.ConvertValue<string>(reader["MSN"]);
			this._TaoBao = DataUtils.ConvertValue<string>(reader["TaoBao"]);
			this._Remark = DataUtils.ConvertValue<string>(reader["Remark"]);
			this._ComNameZh = DataUtils.ConvertValue<string>(reader["ComNameZh"]);
			this._ComNameEn = DataUtils.ConvertValue<string>(reader["ComNameEn"]);
			this._ComTel = DataUtils.ConvertValue<string>(reader["ComTel"]);
			this._ComFax = DataUtils.ConvertValue<string>(reader["ComFax"]);
			this._ComAddr = DataUtils.ConvertValue<string>(reader["ComAddr"]);
			this._ComZipcode = DataUtils.ConvertValue<string>(reader["ComZipcode"]);
			this._ComUrl = DataUtils.ConvertValue<string>(reader["ComUrl"]);
			this._GroupId = DataUtils.ConvertValue<long?>(reader["GroupId"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(reader["IsEnabled"]);
			this._CreateTime = DataUtils.ConvertValue<DateTime?>(reader["CreateTime"]);
			this._CheckTime = DataUtils.ConvertValue<DateTime?>(reader["CheckTime"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<long>(row["Id"]);
			this._UName = DataUtils.ConvertValue<string>(row["UName"]);
			this._UPwd = DataUtils.ConvertValue<string>(row["UPwd"]);
			this._Name = DataUtils.ConvertValue<string>(row["Name"]);
			this._Sex = DataUtils.ConvertValue<int?>(row["Sex"]);
			this._Telephone = DataUtils.ConvertValue<string>(row["Telephone"]);
			this._Mobile = DataUtils.ConvertValue<string>(row["Mobile"]);
			this._Email = DataUtils.ConvertValue<string>(row["Email"]);
			this._QQ = DataUtils.ConvertValue<string>(row["QQ"]);
			this._MSN = DataUtils.ConvertValue<string>(row["MSN"]);
			this._TaoBao = DataUtils.ConvertValue<string>(row["TaoBao"]);
			this._Remark = DataUtils.ConvertValue<string>(row["Remark"]);
			this._ComNameZh = DataUtils.ConvertValue<string>(row["ComNameZh"]);
			this._ComNameEn = DataUtils.ConvertValue<string>(row["ComNameEn"]);
			this._ComTel = DataUtils.ConvertValue<string>(row["ComTel"]);
			this._ComFax = DataUtils.ConvertValue<string>(row["ComFax"]);
			this._ComAddr = DataUtils.ConvertValue<string>(row["ComAddr"]);
			this._ComZipcode = DataUtils.ConvertValue<string>(row["ComZipcode"]);
			this._ComUrl = DataUtils.ConvertValue<string>(row["ComUrl"]);
			this._GroupId = DataUtils.ConvertValue<long?>(row["GroupId"]);
			this._IsEnabled = DataUtils.ConvertValue<int?>(row["IsEnabled"]);
			this._CreateTime = DataUtils.ConvertValue<DateTime?>(row["CreateTime"]);
			this._CheckTime = DataUtils.ConvertValue<DateTime?>(row["CheckTime"]);
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
			public readonly static Field All = new Field("*","cmsMember");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsMember","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UName = new Field("UName","cmsMember","UName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UPwd = new Field("UPwd","cmsMember","UPwd");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","cmsMember","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Sex = new Field("Sex","cmsMember","Sex");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Telephone = new Field("Telephone","cmsMember","Telephone");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Mobile = new Field("Mobile","cmsMember","Mobile");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Email = new Field("Email","cmsMember","Email");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field QQ = new Field("QQ","cmsMember","QQ");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MSN = new Field("MSN","cmsMember","MSN");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TaoBao = new Field("TaoBao","cmsMember","TaoBao");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Remark = new Field("Remark","cmsMember","Remark");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComNameZh = new Field("ComNameZh","cmsMember","ComNameZh");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComNameEn = new Field("ComNameEn","cmsMember","ComNameEn");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComTel = new Field("ComTel","cmsMember","ComTel");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComFax = new Field("ComFax","cmsMember","ComFax");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComAddr = new Field("ComAddr","cmsMember","ComAddr");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComZipcode = new Field("ComZipcode","cmsMember","ComZipcode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ComUrl = new Field("ComUrl","cmsMember","ComUrl");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field GroupId = new Field("GroupId","cmsMember","GroupId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsEnabled = new Field("IsEnabled","cmsMember","IsEnabled");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CreateTime = new Field("CreateTime","cmsMember","CreateTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CheckTime = new Field("CheckTime","cmsMember","CheckTime");
		}
		#endregion


	}
}

