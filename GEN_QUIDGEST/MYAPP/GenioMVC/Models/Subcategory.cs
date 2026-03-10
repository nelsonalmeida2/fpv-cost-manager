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
	public class Subcategory : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsubcategory klass { get { return baseklass as CSGenioAsubcategory; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Subcategory.ValCodsubcategory")]
		public string ValCodsubcategory { get { return klass.ValCodsubcategory; } set { klass.ValCodsubcategory = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Subcategory.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Subcategory.ValCategory")]
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

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Subcategory.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Subcategory(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAsubcategory(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Subcategory(UserContext userContext, CSGenioAsubcategory val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAsubcategory csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "category":
						_category ??= new Category(m_userContext, true, _fieldsToSerialize);
						_category.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Subcategory Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsubcategory>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Subcategory(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Subcategory> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsubcategory>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Subcategory>((r) => new Subcategory(userCtx, r));
		}

// USE /[MANUAL FPV MODEL SUBCATEGORY]/
	}
}
