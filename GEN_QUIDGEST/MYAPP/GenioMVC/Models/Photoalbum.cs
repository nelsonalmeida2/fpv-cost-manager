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
	public class Photoalbum : ModelBase
	{
		[JsonIgnore]
		public CSGenioAphotoalbum klass { get { return baseklass as CSGenioAphotoalbum; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValCodphotoalbum")]
		public string ValCodphotoalbum { get { return klass.ValCodphotoalbum; } set { klass.ValCodphotoalbum = value; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("Item")]
		/// <summary>Field : "Item" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValItem")]
		public string ValItem { get { return klass.ValItem; } set { klass.ValItem = value; } }

		private Item _item;
		[DisplayName("Item")]
		[ShouldSerialize("Item")]
		public virtual Item Item
		{
			get
			{
				if (!isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValItem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValItem))))
					_item = Models.Item.Find(ValItem, m_userContext, Identifier, _fieldsToSerialize);
				_item ??= new Models.Item(m_userContext, true, _fieldsToSerialize);
				return _item;
			}
			set { _item = value; }
		}

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Updated by")]
		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Created at")]
		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Photoalbum.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Photoalbum.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Photoalbum(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAphotoalbum(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Photoalbum(UserContext userContext, CSGenioAphotoalbum val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAphotoalbum csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						_item ??= new Item(m_userContext, true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Photoalbum Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAphotoalbum>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Photoalbum(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Photoalbum> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAphotoalbum>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Photoalbum>((r) => new Photoalbum(userCtx, r));
		}

// USE /[MANUAL FPV MODEL PHOTOALBUM]/
	}
}
