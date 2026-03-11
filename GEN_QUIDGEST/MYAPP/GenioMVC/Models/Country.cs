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
	public class Country : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcountry klass { get { return baseklass as CSGenioAcountry; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Country.ValCodcountry")]
		public string ValCodcountry { get { return klass.ValCodcountry; } set { klass.ValCodcountry = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Country.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Country.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Updated by")]
		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Country.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Country.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Created at")]
		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Country.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Country.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Country(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcountry(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Country(UserContext userContext, CSGenioAcountry val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcountry csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Country Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcountry>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Country(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Country> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcountry>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Country>((r) => new Country(userCtx, r));
		}

// USE /[MANUAL FPV MODEL COUNTRY]/
	}
}
