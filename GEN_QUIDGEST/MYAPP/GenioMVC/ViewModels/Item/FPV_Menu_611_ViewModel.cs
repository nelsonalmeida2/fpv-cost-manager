using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Item
{
	public class FPV_Menu_611_ViewModel : MenuListViewModel<Models.Item>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<FPV_Menu_611_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "item";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "5d0ff2ba-b4fa-47a2-a2d2-6638ab894fdc";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();
				// Limitations

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAitem.FldCodperson, Navigation.GetValue("person"));

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL FPV LIST_LIMITS 611]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("item", user, "FPV");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML611");
			conditions.Equal(CSGenioAitem.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldCategory, CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName, CSGenioAitem.FldCreated_at, CSGenioAitem.FldQuantity, CSGenioAitem.FldUpdated_at, CSGenioAitem.FldTotalprice, CSGenioAitem.FldInvoice, CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldCodinvoicestore, CSGenioAitem.FldCreated_by, CSGenioAitem.FldName, CSGenioAitem.FldSubcategory, CSGenioAsubcategory.FldCodsubcategory, CSGenioAsubcategory.FldName, CSGenioAitem.FldBrand, CSGenioAbrand.FldCodbrand, CSGenioAbrand.FldName, CSGenioAitem.FldUpdated_by, CSGenioAitem.FldUnitprice };

			ListingMVC<CSGenioAitem> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaPERSON.Alias))
				qs.Join(CSGenio.business.Area.AreaPERSON, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAperson.FldCodperson, CSGenioAitem.FldCodperson));



			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public FPV_Menu_611_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="FPV_Menu_611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public FPV_Menu_611_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_5;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FPV_Menu_611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public FPV_Menu_611_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAcategory.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldCreated_at, FieldType.DATETIMESECONDS, Resources.Resources.CREATED_AT29089, 8, 0, true),
				new Exports.QColumn(CSGenioAitem.FldQuantity, FieldType.NUMERIC, Resources.Resources.QUANTITY06415, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldUpdated_at, FieldType.DATETIMESECONDS, Resources.Resources.UPDATED_AT48366, 8, 0, true),
				new Exports.QColumn(CSGenioAitem.FldTotalprice, FieldType.CURRENCY, Resources.Resources.TOTAL_PRICE46894, 10, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldCodinvoicestore, FieldType.TEXT, Resources.Resources.CODINVOICESTORE44054, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldCreated_by, FieldType.TEXT, Resources.Resources.CREATED_BY12292, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAsubcategory.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAbrand.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldUpdated_by, FieldType.TEXT, Resources.Resources.UPDATED_BY17808, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldUnitprice, FieldType.CURRENCY, Resources.Resources.UNIT_PRICE24898, 10, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAitem> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAitem> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAitem.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 255, 0, true),
				new Exports.QColumn(CSGenioAitem.FldQuantity, FieldType.NUMERIC, Resources.Resources.QUANTITY06415, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldUnitprice, FieldType.CURRENCY, Resources.Resources.UNIT_PRICE24898, 9, 2, true),
				new Exports.QColumn(CSGenioAitem.FldUpdated_at, FieldType.DATETIMESECONDS, Resources.Resources.UPDATED_AT48366, 8, 0, true),
				new Exports.QColumn(CSGenioAitem.FldUpdated_by, FieldType.TEXT, Resources.Resources.UPDATED_BY17808, 100, 0, true),
				new Exports.QColumn(CSGenioAitem.FldCreated_by, FieldType.TEXT, Resources.Resources.CREATED_BY12292, 100, 0, true),
				new Exports.QColumn(CSGenioAitem.FldCreated_at, FieldType.DATETIMESECONDS, Resources.Resources.CREATED_AT29089, 8, 0, true),
				new Exports.QColumn(CSGenioAcategory.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldCodinvoicestore, FieldType.TEXT, Resources.Resources.CODINVOICESTORE44054, 30, 0, true),
				new Exports.QColumn(CSGenioAsubcategory.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAbrand.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
			};
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<FPV_Menu_611_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAitem.FldCodperson, Navigation.GetValue("person"));
			if (isToExport)
			{
				// EPH
				crs = Models.Item.AddEPH<CSGenioAitem>(ref u, crs, "ML611");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAitem.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ITEM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAitem.FldZzstate, CSGenioAitem.FldCreated_by);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
				Navigation.DestroyEntry("QMVC_POS_RECORD_item");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Item.AddEPH<CSGenioAitem>(ref u, null, "ML611"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAitem> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAitem> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAitem> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAitem> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<FPV_Menu_611_RowViewModel>();

			CriteriaSet fpv_menu_611Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ITEM.CREATED_AT", new OrderedDictionary());
			allSortOrders["ITEM.CREATED_AT"].Add("ITEM.CREATED_AT", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "item", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldCreated_at), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldCategory, CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName, CSGenioAitem.FldCreated_at, CSGenioAitem.FldQuantity, CSGenioAitem.FldUpdated_at, CSGenioAitem.FldTotalprice, CSGenioAitem.FldInvoice, CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldCodinvoicestore, CSGenioAitem.FldCreated_by, CSGenioAitem.FldName, CSGenioAitem.FldSubcategory, CSGenioAsubcategory.FldCodsubcategory, CSGenioAsubcategory.FldName, CSGenioAitem.FldBrand, CSGenioAbrand.FldCodbrand, CSGenioAbrand.FldName, CSGenioAitem.FldUpdated_by, CSGenioAitem.FldUnitprice };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("category", "name");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAitem model_limit_area = new CSGenioAitem(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML611");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "ITEM"
			//1st Area Limit: "PERSON"
			//1st Area Field: "CODPERSON"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAperson model_limit_area = new CSGenioAperson(m_userContext.User);
				string limit_field = "codperson", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(fpv_menu_611Conds);
			fpv_menu_611Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL FPV OVERRQ 611]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAitem>(m_userContext, false, ref fpv_menu_611Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL FPV OVERRQLSTEXP 611]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL FPV OVERRQLIST 611]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
				Navigation.DestroyEntry("QMVC_POS_RECORD_item");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAitem.GetInformation(), QMVC_POS_RECORD, sorts, fpv_menu_611Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, distinct, fpv_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapFPV_Menu_611(listing);

				Menu.Identifier = "ML611";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML611";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<FPV_Menu_611_RowViewModel> MapFPV_Menu_611(ListingMVC<CSGenioAitem> Qlisting)
		{
			List<FPV_Menu_611_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapFPV_Menu_611(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAitem row
		/// to a FPV_Menu_611_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private FPV_Menu_611_RowViewModel MapFPV_Menu_611(CSGenioAitem row)
		{
			var model = new FPV_Menu_611_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "category":
						model.Category.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "invoice":
						model.Invoice.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "subcategory":
						model.Subcategory.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "brand":
						model.Brand.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAitem> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Item m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Item m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FPV_MENU_611]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Item", "Item.ValCoditem", "Item.ValZzstate", "Category", "Category.ValName", "Item.ValCreated_at", "Item.ValQuantity", "Item.ValUpdated_at", "Item.ValTotalprice", "Invoice", "Invoice.ValCodinvoicestore", "Item.ValCreated_by", "Item.ValName", "Subcategory", "Subcategory.ValName", "Brand", "Brand.ValName", "Item.ValUpdated_by", "Item.ValUnitprice", "Item.ValBrand", "Item.ValCategory", "Item.ValInvoice", "Item.ValCodperson", "Item.ValSubcategory"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Category_ValName", CSGenioAcategory.FldName, typeof(string)),
			new TableSearchColumn("ValCreated_at", CSGenioAitem.FldCreated_at, typeof(DateTime?)),
			new TableSearchColumn("ValQuantity", CSGenioAitem.FldQuantity, typeof(decimal?)),
			new TableSearchColumn("ValUpdated_at", CSGenioAitem.FldUpdated_at, typeof(DateTime?)),
			new TableSearchColumn("ValTotalprice", CSGenioAitem.FldTotalprice, typeof(decimal?)),
			new TableSearchColumn("Invoice_ValCodinvoicestore", CSGenioAinvoice.FldCodinvoicestore, typeof(string)),
			new TableSearchColumn("ValCreated_by", CSGenioAitem.FldCreated_by, typeof(string)),
			new TableSearchColumn("ValName", CSGenioAitem.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("Subcategory_ValName", CSGenioAsubcategory.FldName, typeof(string)),
			new TableSearchColumn("Brand_ValName", CSGenioAbrand.FldName, typeof(string)),
			new TableSearchColumn("ValUpdated_by", CSGenioAitem.FldUpdated_by, typeof(string)),
			new TableSearchColumn("ValUnitprice", CSGenioAitem.FldUnitprice, typeof(decimal?)),
		];
	}
}
