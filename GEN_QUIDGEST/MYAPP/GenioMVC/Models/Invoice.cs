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
	public class Invoice : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinvoice klass { get { return baseklass as CSGenioAinvoice; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Invoice.ValCodinvoice")]
		public string ValCodinvoice { get { return klass.ValCodinvoice; } set { klass.ValCodinvoice = value; } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$" Formula: SR "[ITEM->TOTALPRICE]"</summary>
		[ShouldSerialize("Invoice.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("Shipping Cost")]
		/// <summary>Field : "Shipping Cost" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Invoice.ValShippingcost")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValShippingcost { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValShippingcost, 2)); } set { klass.ValShippingcost = Convert.ToDecimal(value); } }

		[DisplayName("Taxes")]
		/// <summary>Field : "Taxes" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Invoice.ValTaxes")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTaxes { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTaxes, 2)); } set { klass.ValTaxes = Convert.ToDecimal(value); } }

		[DisplayName("Total Price")]
		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[INVOICE->TOTALPRICE] + [INVOICE->SHIPPINGCOST] + [INVOICE->TAXES]"</summary>
		[ShouldSerialize("Invoice.ValTotalprice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTotalprice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTotalprice, 2)); } set { klass.ValTotalprice = Convert.ToDecimal(value); } }

		[DisplayName("Number of Items")]
		/// <summary>Field : "Number of Items" Tipo: "N" Formula: SR "[ITEM->1]"</summary>
		[ShouldSerialize("Invoice.ValNumberofitems")]
		[NumericAttribute(0)]
		public decimal? ValNumberofitems { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNumberofitems, 0)); } set { klass.ValNumberofitems = Convert.ToDecimal(value); } }

		[DisplayName("Store")]
		/// <summary>Field : "Store" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Invoice.ValStore")]
		public string ValStore { get { return klass.ValStore; } set { klass.ValStore = value; } }

		private Store _store;
		[DisplayName("Store")]
		[ShouldSerialize("Store")]
		public virtual Store Store
		{
			get
			{
				if (!isEmptyModel && (_store == null || (!string.IsNullOrEmpty(ValStore) && (_store.isEmptyModel || _store.klass.QPrimaryKey != ValStore))))
					_store = Models.Store.Find(ValStore, m_userContext, Identifier, _fieldsToSerialize);
				_store ??= new Models.Store(m_userContext, true, _fieldsToSerialize);
				return _store;
			}
			set { _store = value; }
		}

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Invoice.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Invoice.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Invoice(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAinvoice(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Invoice(UserContext userContext, CSGenioAinvoice val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAinvoice csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "store":
						_store ??= new Store(m_userContext, true, _fieldsToSerialize);
						_store.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Invoice Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinvoice>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Invoice(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Invoice> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinvoice>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Invoice>((r) => new Invoice(userCtx, r));
		}

// USE /[MANUAL FPV MODEL INVOICE]/
	}
}
