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

namespace GenioMVC.ViewModels.Subcategory
{
	public class Form_subcategory_ViewModel : FormViewModel<Models.Subcategory>, IPreparableForSerialization
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
		/// Title: "Category" | Type: "CE"
		/// </summary>
		public string ValCategory { get; set; }

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
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescription { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Category> TableCategoryName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodsubcategory { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Form_subcategory_ViewModel() : base(null!) { }

		public Form_subcategory_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFORM_SUBCATEGORY", nestedForm) { }

		public Form_subcategory_ViewModel(UserContext userContext, Models.Subcategory row, bool nestedForm = false) : base(userContext, "FFORM_SUBCATEGORY", row, nestedForm) { }

		public Form_subcategory_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("subcategory", id);
			Model = Models.Subcategory.Find(id, userContext, "FFORM_SUBCATEGORY", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_5;
			this.RoleToEdit = CSGenio.framework.Role.ADMINISTRATION;
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
			Models.Subcategory model = new Models.Subcategory(userContext) { Identifier = "FFORM_SUBCATEGORY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFORM_SUBCATEGORY");
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
		public override void MapFromModel(Models.Subcategory m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Subcategory) to ViewModel (Form_subcategory) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCategory = ViewModelConversion.ToString(m.ValCategory);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDescription = ViewModelConversion.ToString(m.ValDescription);
				ValCodsubcategory = ViewModelConversion.ToString(m.ValCodsubcategory);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Subcategory) to ViewModel (Form_subcategory) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Subcategory m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Form_subcategory) to Model (Subcategory) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDescription = ViewModelConversion.ToString(ValDescription);
				m.ValCodsubcategory = ViewModelConversion.ToString(ValCodsubcategory);

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
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Form_subcategory) to Model (Subcategory) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "subcategory.category":
						this.ValCategory = ViewModelConversion.ToString(_value);
						break;
					case "subcategory.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "subcategory.description":
						this.ValDescription = ViewModelConversion.ToString(_value);
						break;
					case "subcategory.codsubcategory":
						this.ValCodsubcategory = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Form_subcategory) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Form_subcategory)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Subcategory.Find(id ?? Navigation.GetStrValue("subcategory"), m_userContext, "FFORM_SUBCATEGORY"); }
			finally { Model ??= new Models.Subcategory(m_userContext) { Identifier = "FFORM_SUBCATEGORY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Subcategory.Find(Navigation.GetStrValue("subcategory"), m_userContext, "FFORM_SUBCATEGORY");
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

			Model.Identifier = "FFORM_SUBCATEGORY";
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
		
		protected override void LoadDocumentsProperties(Models.Subcategory row)
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
				Model = Models.Subcategory.Find(Navigation.GetStrValue("subcategory"), m_userContext, "FFORM_SUBCATEGORY");
				if (Model == null)
				{
					Model = new Models.Subcategory(m_userContext) { Identifier = "FFORM_SUBCATEGORY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("subcategory");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Form_subcategory__category__name(qs, lazyLoad);

// USE /[MANUAL FPV VIEWMODEL_LOADPARTIAL FORM_SUBCATEGORY]/
		}

// USE /[MANUAL FPV VIEWMODEL_NEW FORM_SUBCATEGORY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCategory", Resources.Resources.CATEGORY18978, ViewModelConversion.ToString(ValCategory), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCreated_by", Resources.Resources.CREATED_BY12292, ViewModelConversion.ToString(ValCreated_by), FieldType.TEXT.GetFormatting());

			validator.Required("ValCreated_at", Resources.Resources.CREATED_AT29089, ViewModelConversion.ToDateTime(ValCreated_at), FieldType.DATETIMESECONDS.GetFormatting());
			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);

			validator.Required("ValName", Resources.Resources.NAME31974, ViewModelConversion.ToString(ValName), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValDescription", Resources.Resources.DESCRIPTION07383, ValDescription, 255);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL FPV VIEWMODEL_SAVE FORM_SUBCATEGORY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL FPV VIEWMODEL_APPLY FORM_SUBCATEGORY]/

// USE /[MANUAL FPV VIEWMODEL_DUPLICATE FORM_SUBCATEGORY]/

// USE /[MANUAL FPV VIEWMODEL_DESTROY FORM_SUBCATEGORY]/
		public override void Destroy(string id)
		{
			Model = Models.Subcategory.Find(id, m_userContext, "FFORM_SUBCATEGORY");
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
		/// TableCategoryName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_subcategory__category__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_subcategory__category__nameDoLoad = true;
			CriteriaSet form_subcategory__category__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("category", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_subcategory__category__nameConds.Equal(CSGenioAcategory.FldCodcategory, hValue);
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
				FillDependant_Form_subcategoryTableCategoryName(lazyLoad);
				return;
			}

			if (form_subcategory__category__nameDoLoad)
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
				form_subcategory__category__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategoryName"] != null ? qs["pTableCategoryName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName, CSGenioAcategory.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_SUBCATEGORY_CATEGORYNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("category", FormMode.New) || Navigation.checkFormMode("category", FormMode.Duplicate))
					form_subcategory__category__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcategory.FldZzstate, 0)
						.Equal(CSGenioAcategory.FldCodcategory, Navigation.GetStrValue("category")));
				else
					form_subcategory__category__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcategory.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("category", "name");
				ListingMVC<CSGenioAcategory> listing = Models.ModelBase.Where<CSGenioAcategory>(m_userContext, false, form_subcategory__category__nameConds, fields, offset, numberItems, sorts, "LED_FORM_SUBCATEGORY__CATEGORY__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategoryName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategoryName.Query = query;
				TableCategoryName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Category(m_userContext, r, true, _fieldsToSerialize_FORM_SUBCATEGORY__CATEGORY__NAME));

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
				FillDependant_Form_subcategoryTableCategoryName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategoryName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Category</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_subcategoryTableCategoryName(string PKey)
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
		public void FillDependant_Form_subcategoryTableCategoryName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_subcategoryTableCategoryName(this.ValCategory);
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

		private readonly string[] _fieldsToSerialize_FORM_SUBCATEGORY__CATEGORY__NAME = ["Category", "Category.ValCodcategory", "Category.ValZzstate", "Category.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"subcategory.category" => ViewModelConversion.ToString(modelValue),
				"subcategory.created_by" => ViewModelConversion.ToString(modelValue),
				"subcategory.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"subcategory.updated_by" => ViewModelConversion.ToString(modelValue),
				"subcategory.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"subcategory.name" => ViewModelConversion.ToString(modelValue),
				"subcategory.description" => ViewModelConversion.ToString(modelValue),
				"subcategory.codsubcategory" => ViewModelConversion.ToString(modelValue),
				"category.codcategory" => ViewModelConversion.ToString(modelValue),
				"category.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FORM_SUBCATEGORY]/

		#endregion
	}
}
