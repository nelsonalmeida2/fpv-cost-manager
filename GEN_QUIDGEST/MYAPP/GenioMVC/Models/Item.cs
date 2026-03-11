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
	public class Item : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitem klass { get { return baseklass as CSGenioAitem; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCoditem")]
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Item.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Quantity")]
		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Item.ValQuantity")]
		[NumericAttribute(0)]
		public decimal? ValQuantity { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQuantity, 0)); } set { klass.ValQuantity = Convert.ToDecimal(value); } }

		[DisplayName("Unit Price")]
		/// <summary>Field : "Unit Price" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Item.ValUnitprice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValUnitprice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValUnitprice, 2)); } set { klass.ValUnitprice = Convert.ToDecimal(value); } }

		[DisplayName("Total Price")]
		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[ITEM->QUANTITY] * [ITEM->TOTALPRICE]"</summary>
		[ShouldSerialize("Item.ValTotalprice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTotalprice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTotalprice, 2)); } set { klass.ValTotalprice = Convert.ToDecimal(value); } }

		[DisplayName("Brand")]
		/// <summary>Field : "Brand" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValBrand")]
		public string ValBrand { get { return klass.ValBrand; } set { klass.ValBrand = value; } }

		private Brand _brand;
		[DisplayName("Brand")]
		[ShouldSerialize("Brand")]
		public virtual Brand Brand
		{
			get
			{
				if (!isEmptyModel && (_brand == null || (!string.IsNullOrEmpty(ValBrand) && (_brand.isEmptyModel || _brand.klass.QPrimaryKey != ValBrand))))
					_brand = Models.Brand.Find(ValBrand, m_userContext, Identifier, _fieldsToSerialize);
				_brand ??= new Models.Brand(m_userContext, true, _fieldsToSerialize);
				return _brand;
			}
			set { _brand = value; }
		}

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCategory")]
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }

		private Category _category;
		[DisplayName("Category")]
		[ShouldSerialize("Category")]
		public virtual Category Category
		{
			get
			{
				if (!isEmptyModel && (_category == null || (!string.IsNullOrEmpty(ValCategory) && (_category.isEmptyModel || _category.klass.QPrimaryKey != ValCategory))))
					_category = Models.Category.Find(ValCategory, m_userContext, Identifier, _fieldsToSerialize);
				_category ??= new Models.Category(m_userContext, true, _fieldsToSerialize);
				return _category;
			}
			set { _category = value; }
		}

		[DisplayName("Sub-Category")]
		/// <summary>Field : "Sub-Category" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValSubcategory")]
		public string ValSubcategory { get { return klass.ValSubcategory; } set { klass.ValSubcategory = value; } }

		private Subcategory _subcategory;
		[DisplayName("Subcategory")]
		[ShouldSerialize("Subcategory")]
		public virtual Subcategory Subcategory
		{
			get
			{
				if (!isEmptyModel && (_subcategory == null || (!string.IsNullOrEmpty(ValSubcategory) && (_subcategory.isEmptyModel || _subcategory.klass.QPrimaryKey != ValSubcategory))))
					_subcategory = Models.Subcategory.Find(ValSubcategory, m_userContext, Identifier, _fieldsToSerialize);
				_subcategory ??= new Models.Subcategory(m_userContext, true, _fieldsToSerialize);
				return _subcategory;
			}
			set { _subcategory = value; }
		}

		[DisplayName("Invoice")]
		/// <summary>Field : "Invoice" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValInvoice")]
		public string ValInvoice { get { return klass.ValInvoice; } set { klass.ValInvoice = value; } }

		private Invoice _invoice;
		[DisplayName("Invoice")]
		[ShouldSerialize("Invoice")]
		public virtual Invoice Invoice
		{
			get
			{
				if (!isEmptyModel && (_invoice == null || (!string.IsNullOrEmpty(ValInvoice) && (_invoice.isEmptyModel || _invoice.klass.QPrimaryKey != ValInvoice))))
					_invoice = Models.Invoice.Find(ValInvoice, m_userContext, Identifier, _fieldsToSerialize);
				_invoice ??= new Models.Invoice(m_userContext, true, _fieldsToSerialize);
				return _invoice;
			}
			set { _invoice = value; }
		}

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Item.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Updated by")]
		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Item.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Created at")]
		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Item.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Item(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAitem(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Item(UserContext userContext, CSGenioAitem val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAitem csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "brand":
						_brand ??= new Brand(m_userContext, true, _fieldsToSerialize);
						_brand.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "category":
						_category ??= new Category(m_userContext, true, _fieldsToSerialize);
						_category.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "subcategory":
						_subcategory ??= new Subcategory(m_userContext, true, _fieldsToSerialize);
						_subcategory.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "invoice":
						_invoice ??= new Invoice(m_userContext, true, _fieldsToSerialize);
						_invoice.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Item Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Item(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Item> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitem>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Item>((r) => new Item(userCtx, r));
		}

// USE /[MANUAL FPV MODEL ITEM]/
	}
}
