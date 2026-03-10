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
