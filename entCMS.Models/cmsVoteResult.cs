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
	/// 实体类cmsVoteResult 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class cmsVoteResult : Entity 
	{
		public cmsVoteResult():base("cmsVoteResult") {}

		#region Model
		private string _Id;
		private long _VoteId;
		private DateTime? _VoteTime;
		private string _VoteIp;
		private string _UserAgent;
		private string _Platform;
		private string _Browser;
		private string _BrowserVersion;
		private string _UserLanguages;
		/// <summary>
		/// 
		/// </summary>
		public string Id
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
		public long VoteId
		{
			get{ return _VoteId; }
			set
			{
				this.OnPropertyValueChange(_.VoteId,_VoteId,value);
				this._VoteId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? VoteTime
		{
			get{ return _VoteTime; }
			set
			{
				this.OnPropertyValueChange(_.VoteTime,_VoteTime,value);
				this._VoteTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoteIp
		{
			get{ return _VoteIp; }
			set
			{
				this.OnPropertyValueChange(_.VoteIp,_VoteIp,value);
				this._VoteIp=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserAgent
		{
			get{ return _UserAgent; }
			set
			{
				this.OnPropertyValueChange(_.UserAgent,_UserAgent,value);
				this._UserAgent=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Platform
		{
			get{ return _Platform; }
			set
			{
				this.OnPropertyValueChange(_.Platform,_Platform,value);
				this._Platform=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Browser
		{
			get{ return _Browser; }
			set
			{
				this.OnPropertyValueChange(_.Browser,_Browser,value);
				this._Browser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BrowserVersion
		{
			get{ return _BrowserVersion; }
			set
			{
				this.OnPropertyValueChange(_.BrowserVersion,_BrowserVersion,value);
				this._BrowserVersion=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserLanguages
		{
			get{ return _UserLanguages; }
			set
			{
				this.OnPropertyValueChange(_.UserLanguages,_UserLanguages,value);
				this._UserLanguages=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.Id,
				_.VoteId,
				_.VoteTime,
				_.VoteIp,
				_.UserAgent,
				_.Platform,
				_.Browser,
				_.BrowserVersion,
				_.UserLanguages};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._VoteId,
				this._VoteTime,
				this._VoteIp,
				this._UserAgent,
				this._Platform,
				this._Browser,
				this._BrowserVersion,
				this._UserLanguages};
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(IDataReader reader)
		{
			this._Id = DataUtils.ConvertValue<string>(reader["Id"]);
			this._VoteId = DataUtils.ConvertValue<long>(reader["VoteId"]);
			this._VoteTime = DataUtils.ConvertValue<DateTime?>(reader["VoteTime"]);
			this._VoteIp = DataUtils.ConvertValue<string>(reader["VoteIp"]);
			this._UserAgent = DataUtils.ConvertValue<string>(reader["UserAgent"]);
			this._Platform = DataUtils.ConvertValue<string>(reader["Platform"]);
			this._Browser = DataUtils.ConvertValue<string>(reader["Browser"]);
			this._BrowserVersion = DataUtils.ConvertValue<string>(reader["BrowserVersion"]);
			this._UserLanguages = DataUtils.ConvertValue<string>(reader["UserLanguages"]);
		}
		/// <summary>
		/// 给当前实体赋值
		/// </summary>
		public override void SetPropertyValues(DataRow row)
		{
			this._Id = DataUtils.ConvertValue<string>(row["Id"]);
			this._VoteId = DataUtils.ConvertValue<long>(row["VoteId"]);
			this._VoteTime = DataUtils.ConvertValue<DateTime?>(row["VoteTime"]);
			this._VoteIp = DataUtils.ConvertValue<string>(row["VoteIp"]);
			this._UserAgent = DataUtils.ConvertValue<string>(row["UserAgent"]);
			this._Platform = DataUtils.ConvertValue<string>(row["Platform"]);
			this._Browser = DataUtils.ConvertValue<string>(row["Browser"]);
			this._BrowserVersion = DataUtils.ConvertValue<string>(row["BrowserVersion"]);
			this._UserLanguages = DataUtils.ConvertValue<string>(row["UserLanguages"]);
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
			public readonly static Field All = new Field("*","cmsVoteResult");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","cmsVoteResult","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field VoteId = new Field("VoteId","cmsVoteResult","VoteId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field VoteTime = new Field("VoteTime","cmsVoteResult","VoteTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field VoteIp = new Field("VoteIp","cmsVoteResult","VoteIp");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserAgent = new Field("UserAgent","cmsVoteResult","UserAgent");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Platform = new Field("Platform","cmsVoteResult","Platform");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Browser = new Field("Browser","cmsVoteResult","Browser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BrowserVersion = new Field("BrowserVersion","cmsVoteResult","BrowserVersion");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserLanguages = new Field("UserLanguages","cmsVoteResult","UserLanguages");
		}
		#endregion


	}
}

