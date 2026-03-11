using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Item
{
	public class Form_item_ViewModel : FormViewModel<Models.Item>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Brand" | Type: "CE"
		/// </summary>
		public string ValBrand { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "CE"
		/// </summary>
		public string ValCategory { get; set; }
		/// <summary>
		/// Title: "Invoice" | Type: "CE"
		/// </summary>
		public string ValInvoice { get; set; }
		/// <summary>
		/// Title: "Sub-Category" | Type: "CE"
		/// </summary>
		public string ValSubcategory { get; set; }

		#endregion
		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreated_by { get; set; }
		/// <summary>
		/// Title: "Created at" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreated_at { get; set; }
		/// <summary>
		/// Title: "Updated by" | Type: "EN"
		/// </summary>
		[ValidateSetAccess]
		public string ValUpdated_by { get; set; }
		/// <summary>
		/// Title: "Updated At" | Type: "ED"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValUpdated_at { get; set; }
		/// <summary>
		/// Title: "Invoice" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Invoice> TableInvoiceCodinvoicestore { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Quantity" | Type: "N"
		/// </summary>
		public decimal? ValQuantity { get; set; }
		/// <summary>
		/// Title: "Unit Price" | Type: "$"
		/// </summary>
		public decimal? ValUnitprice { get; set; }
		/// <summary>
		/// Title: "Total Price" | Type: "$"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValTotalprice { get; set; }
		/// <summary>
		/// Title: "Brand" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Brand> TableBrandName { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Category> TableCategoryName { get; set; }
		/// <summary>
		/// Title: "Sub-Category" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Subcategory> TableSubcategoryName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCoditem { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Form_item_ViewModel() : base(null!) { }

		public Form_item_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFORM_ITEM", nestedForm) { }

		public Form_item_ViewModel(UserContext userContext, Models.Item row, bool nestedForm = false) : base(userContext, "FFORM_ITEM", row, nestedForm) { }

		public Form_item_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("item", id);
			Model = Models.Item.Find(id, userContext, "FFORM_ITEM", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_5;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_5;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Item model = new Models.Item(userContext) { Identifier = "FFORM_ITEM" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFORM_ITEM");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Form_item) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValBrand = ViewModelConversion.ToString(m.ValBrand);
				ValCategory = ViewModelConversion.ToString(m.ValCategory);
				ValInvoice = ViewModelConversion.ToString(m.ValInvoice);
				ValSubcategory = ViewModelConversion.ToString(m.ValSubcategory);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValQuantity = ViewModelConversion.ToNumeric(m.ValQuantity);
				ValUnitprice = ViewModelConversion.ToNumeric(m.ValUnitprice);
				ValTotalprice = ViewModelConversion.ToNumeric(m.ValTotalprice);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (Form_item) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Form_item) to Model (Item) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValBrand = ViewModelConversion.ToString(ValBrand);
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValInvoice = ViewModelConversion.ToString(ValInvoice);
				m.ValSubcategory = ViewModelConversion.ToString(ValSubcategory);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValQuantity = ViewModelConversion.ToNumeric(ValQuantity);
				m.ValUnitprice = ViewModelConversion.ToNumeric(ValUnitprice);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCreated_by = ViewModelConversion.ToString(ValCreated_by);
				m.ValCreated_at = ViewModelConversion.ToDateTime(ValCreated_at);
				m.ValUpdated_by = ViewModelConversion.ToString(ValUpdated_by);
				m.ValUpdated_at = ViewModelConversion.ToDateTime(ValUpdated_at);
				m.ValTotalprice = ViewModelConversion.ToNumeric(ValTotalprice);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Form_item) to Model (Item) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "item.brand":
						this.ValBrand = ViewModelConversion.ToString(_value);
						break;
					case "item.category":
						this.ValCategory = ViewModelConversion.ToString(_value);
						break;
					case "item.invoice":
						this.ValInvoice = ViewModelConversion.ToString(_value);
						break;
					case "item.subcategory":
						this.ValSubcategory = ViewModelConversion.ToString(_value);
						break;
					case "item.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "item.quantity":
						this.ValQuantity = ViewModelConversion.ToNumeric(_value);
						break;
					case "item.unitprice":
						this.ValUnitprice = ViewModelConversion.ToNumeric(_value);
						break;
					case "item.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Form_item) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Form_item)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Item.Find(id ?? Navigation.GetStrValue("item"), m_userContext, "FFORM_ITEM"); }
			finally { Model ??= new Models.Item(m_userContext) { Identifier = "FFORM_ITEM" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FFORM_ITEM");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FFORM_ITEM";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Item row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Item.Find(Navigation.GetStrValue("item"), m_userContext, "FFORM_ITEM");
				if (Model == null)
				{
					Model = new Models.Item(m_userContext) { Identifier = "FFORM_ITEM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("item");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Form_item__invoice__codinvoicestore(qs, lazyLoad);
			Load_Form_item__brand__name(qs, lazyLoad);
			Load_Form_item__category__name(qs, lazyLoad);
			Load_Form_item__subcategory__name(qs, lazyLoad);

// USE /[MANUAL FPV VIEWMODEL_LOADPARTIAL FORM_ITEM]/
		}

// USE /[MANUAL FPV VIEWMODEL_NEW FORM_ITEM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValBrand", Resources.Resources.BRAND05002, ViewModelConversion.ToString(ValBrand), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCategory", Resources.Resources.CATEGORY18978, ViewModelConversion.ToString(ValCategory), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValInvoice", Resources.Resources.INVOICE63068, ViewModelConversion.ToString(ValInvoice), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValSubcategory", Resources.Resources.SUB_CATEGORY39956, ViewModelConversion.ToString(ValSubcategory), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCreated_by", Resources.Resources.CREATED_BY12292, ViewModelConversion.ToString(ValCreated_by), FieldType.TEXT.GetFormatting());

			validator.Required("ValCreated_at", Resources.Resources.CREATED_AT29089, ViewModelConversion.ToDateTime(ValCreated_at), FieldType.DATETIMESECONDS.GetFormatting());
			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 255);

			validator.Required("ValName", Resources.Resources.NAME31974, ViewModelConversion.ToString(ValName), FieldType.TEXT.GetFormatting());

			validator.Required("ValQuantity", Resources.Resources.QUANTITY06415, ViewModelConversion.ToNumeric(ValQuantity), FieldType.NUMERIC.GetFormatting());

			validator.Required("ValUnitprice", Resources.Resources.UNIT_PRICE24898, ViewModelConversion.ToNumeric(ValUnitprice), FieldType.CURRENCY.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL FPV VIEWMODEL_SAVE FORM_ITEM]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL FPV VIEWMODEL_APPLY FORM_ITEM]/

// USE /[MANUAL FPV VIEWMODEL_DUPLICATE FORM_ITEM]/

// USE /[MANUAL FPV VIEWMODEL_DESTROY FORM_ITEM]/
		public override void Destroy(string id)
		{
			Model = Models.Item.Find(id, m_userContext, "FFORM_ITEM");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableInvoiceCodinvoicestore -> (F1)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_item__invoice__codinvoicestore(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_item__invoice__codinvoicestoreDoLoad = true;
			CriteriaSet form_item__invoice__codinvoicestoreConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("invoice", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_item__invoice__codinvoicestoreConds.Equal(CSGenioAinvoice.FldCodinvoice, hValue);
					this.ValInvoice = DBConversion.ToString(hValue);
				}
			}

			TableInvoiceCodinvoicestore = new TableDBEdit<Models.Invoice>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_invoice") != null)
				{
					this.ValInvoice = Navigation.GetStrValue("RETURN_invoice");
					Navigation.CurrentLevel.SetEntry("RETURN_invoice", null);
				}
				FillDependant_Form_itemTableInvoiceCodinvoicestore(lazyLoad);
				return;
			}

			if (form_item__invoice__codinvoicestoreDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableInvoiceCodinvoicestore, "sTableInvoiceCodinvoicestore", "dTableInvoiceCodinvoicestore", qs, "invoice");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableInvoiceCodinvoicestore_tableFilters"]))
					TableInvoiceCodinvoicestore.TableFilters = bool.Parse(qs["TableInvoiceCodinvoicestore_tableFilters"]);
				else
					TableInvoiceCodinvoicestore.TableFilters = false;

				query = qs["qTableInvoiceCodinvoicestore"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAinvoice.FldCodinvoicestore, query + "%");
				}
				form_item__invoice__codinvoicestoreConds.SubSet(search_filters);

				string tryParsePage = qs["pTableInvoiceCodinvoicestore"] != null ? qs["pTableInvoiceCodinvoicestore"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldCodinvoicestore, CSGenioAinvoice.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_ITEM_INVOICECODINVOICESTORE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("invoice", FormMode.New) || Navigation.checkFormMode("invoice", FormMode.Duplicate))
					form_item__invoice__codinvoicestoreConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAinvoice.FldZzstate, 0)
						.Equal(CSGenioAinvoice.FldCodinvoice, Navigation.GetStrValue("invoice")));
				else
					form_item__invoice__codinvoicestoreConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAinvoice.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAinvoice> listing = Models.ModelBase.Where<CSGenioAinvoice>(m_userContext, false, form_item__invoice__codinvoicestoreConds, fields, offset, numberItems, sorts, "LED_FORM_ITEM__INVOICE__CODINVOICESTORE", true, false, firstVisibleColumn: firstVisibleColumn);

				TableInvoiceCodinvoicestore.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableInvoiceCodinvoicestore.Query = query;
				TableInvoiceCodinvoicestore.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Invoice(m_userContext, r, true, _fieldsToSerialize_FORM_ITEM__INVOICE__CODINVOICESTORE));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_invoice") != null)
				{
					this.ValInvoice = Navigation.GetStrValue("RETURN_invoice");
					Navigation.CurrentLevel.SetEntry("RETURN_invoice", null);
				}

				TableInvoiceCodinvoicestore.List = new SelectList(TableInvoiceCodinvoicestore.Elements.ToSelectList(x => x.ValCodinvoicestore, x => x.ValCodinvoice,  x => x.ValCodinvoice == this.ValInvoice), "Value", "Text", this.ValInvoice);
				//Seleciona se só um
				if (TableInvoiceCodinvoicestore.List != null && TableInvoiceCodinvoicestore.List.Count() == 1)
				{
					this.ValInvoice = TableInvoiceCodinvoicestore.List.First().Value;
					Navigation.SetValue("invoice", this.ValInvoice);
				}
				FillDependant_Form_itemTableInvoiceCodinvoicestore();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableInvoiceCodinvoicestore (F1)
		/// </summary>
		/// <param name="PKey">Primary Key of Invoice</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_itemTableInvoiceCodinvoicestore(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAinvoice.FldCodinvoice, CSGenioAinvoice.FldCodinvoicestore];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAinvoice tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAinvoice.FldCodinvoice, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableInvoiceCodinvoicestore (F1)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_itemTableInvoiceCodinvoicestore(bool lazyLoad = false)
		{
			var row = GetDependant_Form_itemTableInvoiceCodinvoicestore(this.ValInvoice);
			try
			{

				// Fill List fields
				this.ValInvoice = ViewModelConversion.ToString(row["invoice.codinvoice"]);
				TableInvoiceCodinvoicestore.Value = (string)row["invoice.codinvoicestore"];
				if (GenFunctions.emptyG(this.ValInvoice) == 1)
				{
					this.ValInvoice = "";
					TableInvoiceCodinvoicestore.Value = "";
					Navigation.ClearValue("invoice");
				}
				else if (lazyLoad)
				{
					TableInvoiceCodinvoicestore.SetPagination(1, 0, false, false, 1);
					TableInvoiceCodinvoicestore.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValInvoice),
							Text = Convert.ToString(TableInvoiceCodinvoicestore.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValInvoice);
				}

				TableInvoiceCodinvoicestore.Selected = this.ValInvoice;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableInvoiceCodinvoicestore): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_ITEM__INVOICE__CODINVOICESTORE = ["Invoice", "Invoice.ValCodinvoice", "Invoice.ValZzstate"];

		/// <summary>
		/// TableBrandName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_item__brand__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_item__brand__nameDoLoad = true;
			CriteriaSet form_item__brand__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("brand", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_item__brand__nameConds.Equal(CSGenioAbrand.FldCodbrand, hValue);
					this.ValBrand = DBConversion.ToString(hValue);
				}
			}

			TableBrandName = new TableDBEdit<Models.Brand>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_brand") != null)
				{
					this.ValBrand = Navigation.GetStrValue("RETURN_brand");
					Navigation.CurrentLevel.SetEntry("RETURN_brand", null);
				}
				FillDependant_Form_itemTableBrandName(lazyLoad);
				return;
			}

			if (form_item__brand__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableBrandName, "sTableBrandName", "dTableBrandName", qs, "brand");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAbrand.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableBrandName_tableFilters"]))
					TableBrandName.TableFilters = bool.Parse(qs["TableBrandName_tableFilters"]);
				else
					TableBrandName.TableFilters = false;

				query = qs["qTableBrandName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAbrand.FldName, query + "%");
				}
				form_item__brand__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableBrandName"] != null ? qs["pTableBrandName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAbrand.FldCodbrand, CSGenioAbrand.FldName, CSGenioAbrand.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_ITEM_BRANDNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("brand", FormMode.New) || Navigation.checkFormMode("brand", FormMode.Duplicate))
					form_item__brand__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAbrand.FldZzstate, 0)
						.Equal(CSGenioAbrand.FldCodbrand, Navigation.GetStrValue("brand")));
				else
					form_item__brand__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAbrand.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("brand", "name");
				ListingMVC<CSGenioAbrand> listing = Models.ModelBase.Where<CSGenioAbrand>(m_userContext, false, form_item__brand__nameConds, fields, offset, numberItems, sorts, "LED_FORM_ITEM__BRAND__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableBrandName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableBrandName.Query = query;
				TableBrandName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Brand(m_userContext, r, true, _fieldsToSerialize_FORM_ITEM__BRAND__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_brand") != null)
				{
					this.ValBrand = Navigation.GetStrValue("RETURN_brand");
					Navigation.CurrentLevel.SetEntry("RETURN_brand", null);
				}

				TableBrandName.List = new SelectList(TableBrandName.Elements.ToSelectList(x => x.ValName, x => x.ValCodbrand,  x => x.ValCodbrand == this.ValBrand), "Value", "Text", this.ValBrand);
				//Seleciona se só um
				if (TableBrandName.List != null && TableBrandName.List.Count() == 1)
				{
					this.ValBrand = TableBrandName.List.First().Value;
					Navigation.SetValue("brand", this.ValBrand);
				}
				FillDependant_Form_itemTableBrandName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableBrandName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Brand</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_itemTableBrandName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAbrand.FldCodbrand, CSGenioAbrand.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAbrand tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAbrand.FldCodbrand, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableBrandName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_itemTableBrandName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_itemTableBrandName(this.ValBrand);
			try
			{

				// Fill List fields
				this.ValBrand = ViewModelConversion.ToString(row["brand.codbrand"]);
				TableBrandName.Value = (string)row["brand.name"];
				if (GenFunctions.emptyG(this.ValBrand) == 1)
				{
					this.ValBrand = "";
					TableBrandName.Value = "";
					Navigation.ClearValue("brand");
				}
				else if (lazyLoad)
				{
					TableBrandName.SetPagination(1, 0, false, false, 1);
					TableBrandName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValBrand),
							Text = Convert.ToString(TableBrandName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValBrand);
				}

				TableBrandName.Selected = this.ValBrand;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableBrandName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_ITEM__BRAND__NAME = ["Brand", "Brand.ValCodbrand", "Brand.ValZzstate", "Brand.ValName"];

		/// <summary>
		/// TableCategoryName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_item__category__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_item__category__nameDoLoad = true;
			CriteriaSet form_item__category__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("category", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_item__category__nameConds.Equal(CSGenioAcategory.FldCodcategory, hValue);
					this.ValCategory = DBConversion.ToString(hValue);
				}
			}

			TableCategoryName = new TableDBEdit<Models.Category>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_category") != null)
				{
					this.ValCategory = Navigation.GetStrValue("RETURN_category");
					Navigation.CurrentLevel.SetEntry("RETURN_category", null);
				}
				FillDependant_Form_itemTableCategoryName(lazyLoad);
				return;
			}

			if (form_item__category__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCategoryName, "sTableCategoryName", "dTableCategoryName", qs, "category");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcategory.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCategoryName_tableFilters"]))
					TableCategoryName.TableFilters = bool.Parse(qs["TableCategoryName_tableFilters"]);
				else
					TableCategoryName.TableFilters = false;

				query = qs["qTableCategoryName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcategory.FldName, query + "%");
				}
				form_item__category__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategoryName"] != null ? qs["pTableCategoryName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName, CSGenioAcategory.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_ITEM_CATEGORYNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("category", FormMode.New) || Navigation.checkFormMode("category", FormMode.Duplicate))
					form_item__category__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcategory.FldZzstate, 0)
						.Equal(CSGenioAcategory.FldCodcategory, Navigation.GetStrValue("category")));
				else
					form_item__category__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcategory.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("category", "name");
				ListingMVC<CSGenioAcategory> listing = Models.ModelBase.Where<CSGenioAcategory>(m_userContext, false, form_item__category__nameConds, fields, offset, numberItems, sorts, "LED_FORM_ITEM__CATEGORY__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategoryName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategoryName.Query = query;
				TableCategoryName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Category(m_userContext, r, true, _fieldsToSerialize_FORM_ITEM__CATEGORY__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_category") != null)
				{
					this.ValCategory = Navigation.GetStrValue("RETURN_category");
					Navigation.CurrentLevel.SetEntry("RETURN_category", null);
				}

				TableCategoryName.List = new SelectList(TableCategoryName.Elements.ToSelectList(x => x.ValName, x => x.ValCodcategory,  x => x.ValCodcategory == this.ValCategory), "Value", "Text", this.ValCategory);
				//Seleciona se só um
				if (TableCategoryName.List != null && TableCategoryName.List.Count() == 1)
				{
					this.ValCategory = TableCategoryName.List.First().Value;
					Navigation.SetValue("category", this.ValCategory);
				}
				FillDependant_Form_itemTableCategoryName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategoryName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Category</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_itemTableCategoryName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcategory tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcategory.FldCodcategory, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCategoryName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_itemTableCategoryName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_itemTableCategoryName(this.ValCategory);
			try
			{

				// Fill List fields
				this.ValCategory = ViewModelConversion.ToString(row["category.codcategory"]);
				TableCategoryName.Value = (string)row["category.name"];
				if (GenFunctions.emptyG(this.ValCategory) == 1)
				{
					this.ValCategory = "";
					TableCategoryName.Value = "";
					Navigation.ClearValue("category");
				}
				else if (lazyLoad)
				{
					TableCategoryName.SetPagination(1, 0, false, false, 1);
					TableCategoryName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCategory),
							Text = Convert.ToString(TableCategoryName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCategory);
				}

				TableCategoryName.Selected = this.ValCategory;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategoryName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_ITEM__CATEGORY__NAME = ["Category", "Category.ValCodcategory", "Category.ValZzstate", "Category.ValName"];

		/// <summary>
		/// TableSubcategoryName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_item__subcategory__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_item__subcategory__nameDoLoad = true;
			CriteriaSet form_item__subcategory__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("subcategory", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_item__subcategory__nameConds.Equal(CSGenioAsubcategory.FldCodsubcategory, hValue);
					this.ValSubcategory = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			form_item__subcategory__nameDoLoad &= AddCriteriaAreaLimit(form_item__subcategory__nameConds, CSGenio.business.CSGenioAcategory.FldCodcategory, "category", this.ValCategory, true);

			TableSubcategoryName = new TableDBEdit<Models.Subcategory>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_subcategory") != null)
				{
					this.ValSubcategory = Navigation.GetStrValue("RETURN_subcategory");
					Navigation.CurrentLevel.SetEntry("RETURN_subcategory", null);
				}
				FillDependant_Form_itemTableSubcategoryName(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCategory))
				form_item__subcategory__nameDoLoad = false;

			if (form_item__subcategory__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableSubcategoryName, "sTableSubcategoryName", "dTableSubcategoryName", qs, "subcategory");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsubcategory.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableSubcategoryName_tableFilters"]))
					TableSubcategoryName.TableFilters = bool.Parse(qs["TableSubcategoryName_tableFilters"]);
				else
					TableSubcategoryName.TableFilters = false;

				query = qs["qTableSubcategoryName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAsubcategory.FldName, query + "%");
				}
				form_item__subcategory__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableSubcategoryName"] != null ? qs["pTableSubcategoryName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAsubcategory.FldCodsubcategory, CSGenioAsubcategory.FldName, CSGenioAsubcategory.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_ITEM_SUBCATEGORYNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("subcategory", FormMode.New) || Navigation.checkFormMode("subcategory", FormMode.Duplicate))
					form_item__subcategory__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAsubcategory.FldZzstate, 0)
						.Equal(CSGenioAsubcategory.FldCodsubcategory, Navigation.GetStrValue("subcategory")));
				else
					form_item__subcategory__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAsubcategory.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("subcategory", "name");
				ListingMVC<CSGenioAsubcategory> listing = Models.ModelBase.Where<CSGenioAsubcategory>(m_userContext, false, form_item__subcategory__nameConds, fields, offset, numberItems, sorts, "LED_FORM_ITEM__SUBCATEGORY__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableSubcategoryName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableSubcategoryName.Query = query;
				TableSubcategoryName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Subcategory(m_userContext, r, true, _fieldsToSerialize_FORM_ITEM__SUBCATEGORY__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_subcategory") != null)
				{
					this.ValSubcategory = Navigation.GetStrValue("RETURN_subcategory");
					Navigation.CurrentLevel.SetEntry("RETURN_subcategory", null);
				}

				TableSubcategoryName.List = new SelectList(TableSubcategoryName.Elements.ToSelectList(x => x.ValName, x => x.ValCodsubcategory,  x => x.ValCodsubcategory == this.ValSubcategory), "Value", "Text", this.ValSubcategory);
				//Seleciona se só um
				if (TableSubcategoryName.List != null && TableSubcategoryName.List.Count() == 1)
				{
					this.ValSubcategory = TableSubcategoryName.List.First().Value;
					Navigation.SetValue("subcategory", this.ValSubcategory);
				}
				FillDependant_Form_itemTableSubcategoryName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableSubcategoryName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Subcategory</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_itemTableSubcategoryName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAsubcategory.FldCodsubcategory, CSGenioAsubcategory.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("category");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAsubcategory.FldCategory, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAsubcategory tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAsubcategory.FldCodsubcategory, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableSubcategoryName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_itemTableSubcategoryName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_itemTableSubcategoryName(this.ValSubcategory);
			try
			{

				// Fill List fields
				this.ValSubcategory = ViewModelConversion.ToString(row["subcategory.codsubcategory"]);
				TableSubcategoryName.Value = (string)row["subcategory.name"];
				if (GenFunctions.emptyG(this.ValSubcategory) == 1)
				{
					this.ValSubcategory = "";
					TableSubcategoryName.Value = "";
					Navigation.ClearValue("subcategory");
				}
				else if (lazyLoad)
				{
					TableSubcategoryName.SetPagination(1, 0, false, false, 1);
					TableSubcategoryName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValSubcategory),
							Text = Convert.ToString(TableSubcategoryName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValSubcategory);
				}

				TableSubcategoryName.Selected = this.ValSubcategory;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSubcategoryName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_ITEM__SUBCATEGORY__NAME = ["Subcategory", "Subcategory.ValCodsubcategory", "Subcategory.ValZzstate", "Subcategory.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"item.brand" => ViewModelConversion.ToString(modelValue),
				"item.category" => ViewModelConversion.ToString(modelValue),
				"item.invoice" => ViewModelConversion.ToString(modelValue),
				"item.subcategory" => ViewModelConversion.ToString(modelValue),
				"item.created_by" => ViewModelConversion.ToString(modelValue),
				"item.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"item.updated_by" => ViewModelConversion.ToString(modelValue),
				"item.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"item.name" => ViewModelConversion.ToString(modelValue),
				"item.quantity" => ViewModelConversion.ToNumeric(modelValue),
				"item.unitprice" => ViewModelConversion.ToNumeric(modelValue),
				"item.totalprice" => ViewModelConversion.ToNumeric(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"invoice.codinvoice" => ViewModelConversion.ToString(modelValue),
				"invoice.codinvoicestore" => ViewModelConversion.ToString(modelValue),
				"brand.codbrand" => ViewModelConversion.ToString(modelValue),
				"brand.name" => ViewModelConversion.ToString(modelValue),
				"category.codcategory" => ViewModelConversion.ToString(modelValue),
				"category.name" => ViewModelConversion.ToString(modelValue),
				"subcategory.codsubcategory" => ViewModelConversion.ToString(modelValue),
				"subcategory.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FORM_ITEM]/

		#endregion
	}
}
