using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Personpsw : ModelBase
	{
		[JsonIgnore]
		public CSGenioApersonpsw klass { get { return baseklass as CSGenioApersonpsw; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValCodpersonpsw")]
		public string ValCodpersonpsw { get { return klass.ValCodpersonpsw; } set { klass.ValCodpersonpsw = value; } }

		[DisplayName("PERSON")]
		/// <summary>Field : "PERSON" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValCodperson")]
		public string ValCodperson { get { return klass.ValCodperson; } set { klass.ValCodperson = value; } }

		private Person _person;
		[DisplayName("Person")]
		[ShouldSerialize("Person")]
		public virtual Person Person
		{
			get
			{
				if (!isEmptyModel && (_person == null || (!string.IsNullOrEmpty(ValCodperson) && (_person.isEmptyModel || _person.klass.QPrimaryKey != ValCodperson))))
					_person = Models.Person.Find(ValCodperson, m_userContext, Identifier, _fieldsToSerialize);
				_person ??= new Models.Person(m_userContext, true, _fieldsToSerialize);
				return _person;
			}
			set { _person = value; }
		}

		[DisplayName("PSW")]
		/// <summary>Field : "PSW" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValCodpsw")]
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }

		private Psw _psw;
		[DisplayName("Psw")]
		[ShouldSerialize("Psw")]
		public virtual Psw Psw
		{
			get
			{
				if (!isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw))))
					_psw = Models.Psw.Find(ValCodpsw, m_userContext, Identifier, _fieldsToSerialize);
				_psw ??= new Models.Psw(m_userContext, true, _fieldsToSerialize);
				return _psw;
			}
			set { _psw = value; }
		}

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Updated by")]
		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Created at")]
		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Personpsw.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Personpsw.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Personpsw(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApersonpsw(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Personpsw(UserContext userContext, CSGenioApersonpsw val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioApersonpsw csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "person":
						_person ??= new Person(m_userContext, true, _fieldsToSerialize);
						_person.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "psw":
						_psw ??= new Psw(m_userContext, true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Personpsw Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApersonpsw>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Personpsw(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Personpsw> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApersonpsw>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Personpsw>((r) => new Personpsw(userCtx, r));
		}

// USE /[MANUAL FPV MODEL PERSONPSW]/
	}
}
