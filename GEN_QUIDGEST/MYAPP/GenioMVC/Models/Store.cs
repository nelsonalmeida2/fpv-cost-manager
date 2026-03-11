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
	public class Store : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstore klass { get { return baseklass as CSGenioAstore; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Store.ValCodstore")]
		public string ValCodstore { get { return klass.ValCodstore; } set { klass.ValCodstore = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Store.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Website")]
		/// <summary>Field : "Website" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Store.ValSite")]
		public string ValSite { get { return klass.ValSite; } set { klass.ValSite = value; } }

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Store.ValCurrency")]
		[DataArray("Currency", GenioMVC.Helpers.ArrayType.Character)]
		public string ValCurrency { get { return klass.ValCurrency; } set { klass.ValCurrency = value; } }
		[JsonIgnore]
		public SelectList ArrayValcurrency { get { return new SelectList(CSGenio.business.ArrayCurrency.GetDictionary(), "Key", "Value", ValCurrency); } set { ValCurrency = value.SelectedValue as string; } }

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Store.ValCountry")]
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
		[ShouldSerialize("Store.ValLogotype")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogotype { get { return new ImageModel(klass.ValLogotype) { Ticket = ValLogotypeQTicket }; } set { klass.ValLogotype = value; } }
		[JsonIgnore]
		public string ValLogotypeQTicket = null;

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Store.ValDescription")]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Store.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Updated by")]
		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Store.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Store.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Created at")]
		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Store.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Store.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Store(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAstore(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Store(UserContext userContext, CSGenioAstore val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAstore csgenioa)
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
		public static Store Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstore>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Store(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Store> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstore>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Store>((r) => new Store(userCtx, r));
		}

// USE /[MANUAL FPV MODEL STORE]/
	}
}
