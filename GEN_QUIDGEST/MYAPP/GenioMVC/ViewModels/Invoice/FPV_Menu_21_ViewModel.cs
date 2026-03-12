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

namespace GenioMVC.ViewModels.Invoice
{
	public class FPV_Menu_21_ViewModel : MenuListViewModel<Models.Invoice>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<FPV_Menu_21_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "invoice";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "4a9dfeb1-6fc5-4de5-bee6-4e3fcd3352a5";

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
// USE /[MANUAL FPV LIST_LIMITS 21]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("invoice", user, "FPV");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML21");
			conditions.Equal(CSGenioAinvoice.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldZzstate, CSGenioAinvoice.FldCodinvoicestore, CSGenioAinvoice.FldDate, CSGenioAinvoice.FldStore, CSGenioAstore.FldCodstore, CSGenioAstore.FldName, CSGenioAinvoice.FldPrice, CSGenioAinvoice.FldTaxes, CSGenioAinvoice.FldShippingcost, CSGenioAinvoice.FldTotalprice, CSGenioAinvoice.FldNumberofitems };

			ListingMVC<CSGenioAinvoice> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);



			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public FPV_Menu_21_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="FPV_Menu_21_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public FPV_Menu_21_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_5;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FPV_Menu_21_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public FPV_Menu_21_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAinvoice.FldCodinvoicestore, FieldType.TEXT, Resources.Resources.CODINVOICESTORE44054, 30, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAstore.FldName, FieldType.TEXT, Resources.Resources.STORE16493, 30, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 10, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldTaxes, FieldType.CURRENCY, Resources.Resources.TAXES34617, 10, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldShippingcost, FieldType.CURRENCY, Resources.Resources.SHIPPING_COST12785, 10, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldTotalprice, FieldType.CURRENCY, Resources.Resources.TOTAL_PRICE46894, 10, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldNumberofitems, FieldType.NUMERIC, Resources.Resources.NUMBER_OF_ITEMS22472, 10, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAinvoice> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAinvoice> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				new Exports.QColumn(CSGenioAinvoice.FldShippingcost, FieldType.CURRENCY, Resources.Resources.SHIPPING_COST12785, 9, 2, true),
				new Exports.QColumn(CSGenioAinvoice.FldTaxes, FieldType.CURRENCY, Resources.Resources.TAXES34617, 9, 2, true),
				new Exports.QColumn(CSGenioAinvoice.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldReceipt, FieldType.DOCUMENT, Resources.Resources.RECEIPT15218, 50, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldUpdated_at, FieldType.DATETIMESECONDS, Resources.Resources.UPDATED_AT48366, 8, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldUpdated_by, FieldType.TEXT, Resources.Resources.UPDATED_BY17808, 100, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldCreated_by, FieldType.TEXT, Resources.Resources.CREATED_BY12292, 100, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldCreated_at, FieldType.DATETIMESECONDS, Resources.Resources.CREATED_AT29089, 8, 0, true),
				new Exports.QColumn(CSGenioAinvoice.FldCodinvoicestore, FieldType.TEXT, Resources.Resources.CODINVOICESTORE44054, 50, 0, true),
				new Exports.QColumn(CSGenioAstore.FldName, FieldType.TEXT, Resources.Resources.STORE16493, 30, 0, true),
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

			Menu ??= new TablePartial<FPV_Menu_21_RowViewModel>();
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

			if (isToExport)
			{
				// EPH
				crs = Models.Invoice.AddEPH<CSGenioAinvoice>(ref u, crs, "ML21");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAinvoice.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("INVOICE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAinvoice.FldZzstate, CSGenioAinvoice.FldCreated_by);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_invoice");
				Navigation.DestroyEntry("QMVC_POS_RECORD_invoice");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Invoice.AddEPH<CSGenioAinvoice>(ref u, null, "ML21"));
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
			ListingMVC<CSGenioAinvoice> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinvoice> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAinvoice> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinvoice> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<FPV_Menu_21_RowViewModel>();

			CriteriaSet fpv_menu_21Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "invoice", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldZzstate, CSGenioAinvoice.FldCodinvoicestore, CSGenioAinvoice.FldDate, CSGenioAinvoice.FldStore, CSGenioAstore.FldCodstore, CSGenioAstore.FldName, CSGenioAinvoice.FldPrice, CSGenioAinvoice.FldTaxes, CSGenioAinvoice.FldShippingcost, CSGenioAinvoice.FldTotalprice, CSGenioAinvoice.FldNumberofitems };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("invoice", "codinvoicestore");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAinvoice model_limit_area = new CSGenioAinvoice(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML21");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(fpv_menu_21Conds);
			fpv_menu_21Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL FPV OVERRQ 21]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAinvoice>(m_userContext, false, ref fpv_menu_21Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML21", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL FPV OVERRQLSTEXP 21]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL FPV OVERRQLIST 21]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_invoice");
				Navigation.DestroyEntry("QMVC_POS_RECORD_invoice");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAinvoice.GetInformation(), QMVC_POS_RECORD, sorts, fpv_menu_21Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAinvoice> listing = Models.ModelBase.Where<CSGenioAinvoice>(m_userContext, distinct, fpv_menu_21Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML21", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapFPV_Menu_21(listing);

				Menu.Identifier = "ML21";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML21";

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

		private List<FPV_Menu_21_RowViewModel> MapFPV_Menu_21(ListingMVC<CSGenioAinvoice> Qlisting)
		{
			List<FPV_Menu_21_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapFPV_Menu_21(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAinvoice row
		/// to a FPV_Menu_21_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private FPV_Menu_21_RowViewModel MapFPV_Menu_21(CSGenioAinvoice row)
		{
			var model = new FPV_Menu_21_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "invoice":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "store":
						model.Store.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAinvoice> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Invoice m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Invoice m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FPV_MENU_21]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Invoice", "Invoice.ValCodinvoice", "Invoice.ValZzstate", "Invoice.ValCodinvoicestore", "Invoice.ValDate", "Store", "Store.ValName", "Invoice.ValPrice", "Invoice.ValTaxes", "Invoice.ValShippingcost", "Invoice.ValTotalprice", "Invoice.ValNumberofitems", "Invoice.ValCodperson", "Invoice.ValStore"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValCodinvoicestore", CSGenioAinvoice.FldCodinvoicestore, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDate", CSGenioAinvoice.FldDate, typeof(DateTime?)),
			new TableSearchColumn("Store_ValName", CSGenioAstore.FldName, typeof(string)),
			new TableSearchColumn("ValPrice", CSGenioAinvoice.FldPrice, typeof(decimal?)),
			new TableSearchColumn("ValTaxes", CSGenioAinvoice.FldTaxes, typeof(decimal?)),
			new TableSearchColumn("ValShippingcost", CSGenioAinvoice.FldShippingcost, typeof(decimal?)),
			new TableSearchColumn("ValTotalprice", CSGenioAinvoice.FldTotalprice, typeof(decimal?)),
			new TableSearchColumn("ValNumberofitems", CSGenioAinvoice.FldNumberofitems, typeof(decimal?)),
		];
	}
}
