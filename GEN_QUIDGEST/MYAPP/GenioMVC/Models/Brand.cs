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
	public class Brand : ModelBase
	{
		[JsonIgnore]
		public CSGenioAbrand klass { get { return baseklass as CSGenioAbrand; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Brand.ValCodbrand")]
		public string ValCodbrand { get { return klass.ValCodbrand; } set { klass.ValCodbrand = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Brand.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Brand.ValCountry")]
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }

		private Country _country;
		[DisplayName("Country")]
		[ShouldSerialize("Country")]
		public virtual Country Country
		{
			get
			{
				if (!isEmptyModel && (_country == null || (!string.IsNullOrEmpty(ValCountry) && (_country.isEmptyModel || _country.klass.QPrimaryKey != ValCountry))))
					_country = Models.Country.Find(ValCountry, m_userContext, Identifier, _fieldsToSerialize);
				_country ??= new Models.Country(m_userContext, true, _fieldsToSerialize);
				return _country;
			}
			set { _country = value; }
		}

		[DisplayName("Logotype")]
		/// <summary>Field : "Logotype" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Brand.ValLogotype")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogotype { get { return new ImageModel(klass.ValLogotype) { Ticket = ValLogotypeQTicket }; } set { klass.ValLogotype = value; } }
		[JsonIgnore]
		public string ValLogotypeQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Brand.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Brand(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAbrand(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Brand(UserContext userContext, CSGenioAbrand val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAbrand csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "country":
						_country ??= new Country(m_userContext, true, _fieldsToSerialize);
						_country.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Brand Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAbrand>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Brand(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Brand> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAbrand>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Brand>((r) => new Brand(userCtx, r));
		}

// USE /[MANUAL FPV MODEL BRAND]/
	}
}
