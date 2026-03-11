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

namespace GenioMVC.ViewModels.Personpsw
{
	public class Form_personpsw_ViewModel : FormViewModel<Models.Personpsw>, IPreparableForSerialization
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
		/// Title: "Name Person" | Type: "CE"
		/// </summary>
		public string ValCodperson { get; set; }
		/// <summary>
		/// Title: "Name PSW" | Type: "CE"
		/// </summary>
		public string ValCodpsw { get; set; }

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
		/// Title: "Name PSW" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Psw> TablePswNome { get; set; }
		/// <summary>
		/// Title: "Name Person" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Person> TablePersonName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpersonpsw { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Form_personpsw_ViewModel() : base(null!) { }

		public Form_personpsw_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFORM_PERSONPSW", nestedForm) { }

		public Form_personpsw_ViewModel(UserContext userContext, Models.Personpsw row, bool nestedForm = false) : base(userContext, "FFORM_PERSONPSW", row, nestedForm) { }

		public Form_personpsw_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("personpsw", id);
			Model = Models.Personpsw.Find(id, userContext, "FFORM_PERSONPSW", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ADMINISTRATION;
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
			Models.Personpsw model = new Models.Personpsw(userContext) { Identifier = "FFORM_PERSONPSW" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFORM_PERSONPSW");
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
		public override void MapFromModel(Models.Personpsw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Personpsw) to ViewModel (Form_personpsw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodperson = ViewModelConversion.ToString(m.ValCodperson);
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValCodpersonpsw = ViewModelConversion.ToString(m.ValCodpersonpsw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Personpsw) to ViewModel (Form_personpsw) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Personpsw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Form_personpsw) to Model (Personpsw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodperson = ViewModelConversion.ToString(ValCodperson);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodpersonpsw = ViewModelConversion.ToString(ValCodpersonpsw);

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
				CSGenio.framework.Log.Error($"Map ViewModel (Form_personpsw) to Model (Personpsw) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "personpsw.codperson":
						this.ValCodperson = ViewModelConversion.ToString(_value);
						break;
					case "personpsw.codpsw":
						this.ValCodpsw = ViewModelConversion.ToString(_value);
						break;
					case "personpsw.codpersonpsw":
						this.ValCodpersonpsw = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Form_personpsw) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Form_personpsw)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Personpsw.Find(id ?? Navigation.GetStrValue("personpsw"), m_userContext, "FFORM_PERSONPSW"); }
			finally { Model ??= new Models.Personpsw(m_userContext) { Identifier = "FFORM_PERSONPSW" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Personpsw.Find(Navigation.GetStrValue("personpsw"), m_userContext, "FFORM_PERSONPSW");
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

			Model.Identifier = "FFORM_PERSONPSW";
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
		
		protected override void LoadDocumentsProperties(Models.Personpsw row)
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
				Model = Models.Personpsw.Find(Navigation.GetStrValue("personpsw"), m_userContext, "FFORM_PERSONPSW");
				if (Model == null)
				{
					Model = new Models.Personpsw(m_userContext) { Identifier = "FFORM_PERSONPSW" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("personpsw");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Form_personpsw__psw__nome(qs, lazyLoad);
			Load_Form_personpsw__person__name(qs, lazyLoad);

// USE /[MANUAL FPV VIEWMODEL_LOADPARTIAL FORM_PERSONPSW]/
		}

// USE /[MANUAL FPV VIEWMODEL_NEW FORM_PERSONPSW]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCodperson", Resources.Resources.NAME_PERSON43394, ViewModelConversion.ToString(ValCodperson), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCodpsw", Resources.Resources.NAME_PSW24858, ViewModelConversion.ToString(ValCodpsw), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCreated_by", Resources.Resources.CREATED_BY12292, ViewModelConversion.ToString(ValCreated_by), FieldType.TEXT.GetFormatting());

			validator.Required("ValCreated_at", Resources.Resources.CREATED_AT29089, ViewModelConversion.ToDateTime(ValCreated_at), FieldType.DATETIMESECONDS.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL FPV VIEWMODEL_SAVE FORM_PERSONPSW]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL FPV VIEWMODEL_APPLY FORM_PERSONPSW]/

// USE /[MANUAL FPV VIEWMODEL_DUPLICATE FORM_PERSONPSW]/

// USE /[MANUAL FPV VIEWMODEL_DESTROY FORM_PERSONPSW]/
		public override void Destroy(string id)
		{
			Model = Models.Personpsw.Find(id, m_userContext, "FFORM_PERSONPSW");
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
		/// TablePswNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_personpsw__psw__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_personpsw__psw__nomeDoLoad = true;
			CriteriaSet form_personpsw__psw__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("psw", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_personpsw__psw__nomeConds.Equal(CSGenioApsw.FldCodpsw, hValue);
					this.ValCodpsw = DBConversion.ToString(hValue);
				}
			}

			TablePswNome = new TableDBEdit<Models.Psw>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
				FillDependant_Form_personpswTablePswNome(lazyLoad);
				return;
			}

			if (form_personpsw__psw__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
					TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
				else
					TablePswNome.TableFilters = false;

				query = qs["qTablePswNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
				}
				form_personpsw__psw__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_PERSONPSW_PSWNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
					form_personpsw__psw__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApsw.FldZzstate, 0)
						.Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
				else
					form_personpsw__psw__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, form_personpsw__psw__nomeConds, fields, offset, numberItems, sorts, "LED_FORM_PERSONPSW__PSW__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePswNome.Query = query;
				TablePswNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Psw(m_userContext, r, true, _fieldsToSerialize_FORM_PERSONPSW__PSW__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
				FillDependant_Form_personpswTablePswNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Psw</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_personpswTablePswNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome];

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

			CSGenioApsw tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_personpswTablePswNome(bool lazyLoad = false)
		{
			var row = GetDependant_Form_personpswTablePswNome(this.ValCodpsw);
			try
			{

				// Fill List fields
				this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
				TablePswNome.Value = (string)row["psw.nome"];
				if (GenFunctions.emptyG(this.ValCodpsw) == 1)
				{
					this.ValCodpsw = "";
					TablePswNome.Value = "";
					Navigation.ClearValue("psw");
				}
				else if (lazyLoad)
				{
					TablePswNome.SetPagination(1, 0, false, false, 1);
					TablePswNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpsw),
							Text = Convert.ToString(TablePswNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpsw);
				}

				TablePswNome.Selected = this.ValCodpsw;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_PERSONPSW__PSW__NOME = ["Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome"];

		/// <summary>
		/// TablePersonName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_personpsw__person__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_personpsw__person__nameDoLoad = true;
			CriteriaSet form_personpsw__person__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("person", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_personpsw__person__nameConds.Equal(CSGenioAperson.FldCodperson, hValue);
					this.ValCodperson = DBConversion.ToString(hValue);
				}
			}

			TablePersonName = new TableDBEdit<Models.Person>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_person") != null)
				{
					this.ValCodperson = Navigation.GetStrValue("RETURN_person");
					Navigation.CurrentLevel.SetEntry("RETURN_person", null);
				}
				FillDependant_Form_personpswTablePersonName(lazyLoad);
				return;
			}

			if (form_personpsw__person__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePersonName, "sTablePersonName", "dTablePersonName", qs, "person");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePersonName_tableFilters"]))
					TablePersonName.TableFilters = bool.Parse(qs["TablePersonName_tableFilters"]);
				else
					TablePersonName.TableFilters = false;

				query = qs["qTablePersonName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAperson.FldName, query + "%");
				}
				form_personpsw__person__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePersonName"] != null ? qs["pTablePersonName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAperson.FldCodperson, CSGenioAperson.FldName, CSGenioAperson.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_PERSONPSW_PERSONNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("person", FormMode.New) || Navigation.checkFormMode("person", FormMode.Duplicate))
					form_personpsw__person__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAperson.FldZzstate, 0)
						.Equal(CSGenioAperson.FldCodperson, Navigation.GetStrValue("person")));
				else
					form_personpsw__person__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperson.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("person", "name");
				ListingMVC<CSGenioAperson> listing = Models.ModelBase.Where<CSGenioAperson>(m_userContext, false, form_personpsw__person__nameConds, fields, offset, numberItems, sorts, "LED_FORM_PERSONPSW__PERSON__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePersonName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePersonName.Query = query;
				TablePersonName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Person(m_userContext, r, true, _fieldsToSerialize_FORM_PERSONPSW__PERSON__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_person") != null)
				{
					this.ValCodperson = Navigation.GetStrValue("RETURN_person");
					Navigation.CurrentLevel.SetEntry("RETURN_person", null);
				}

				TablePersonName.List = new SelectList(TablePersonName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperson,  x => x.ValCodperson == this.ValCodperson), "Value", "Text", this.ValCodperson);
				FillDependant_Form_personpswTablePersonName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePersonName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Person</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_personpswTablePersonName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAperson.FldCodperson, CSGenioAperson.FldName];

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

			CSGenioAperson tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAperson.FldCodperson, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePersonName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_personpswTablePersonName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_personpswTablePersonName(this.ValCodperson);
			try
			{

				// Fill List fields
				this.ValCodperson = ViewModelConversion.ToString(row["person.codperson"]);
				TablePersonName.Value = (string)row["person.name"];
				if (GenFunctions.emptyG(this.ValCodperson) == 1)
				{
					this.ValCodperson = "";
					TablePersonName.Value = "";
					Navigation.ClearValue("person");
				}
				else if (lazyLoad)
				{
					TablePersonName.SetPagination(1, 0, false, false, 1);
					TablePersonName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodperson),
							Text = Convert.ToString(TablePersonName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodperson);
				}

				TablePersonName.Selected = this.ValCodperson;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersonName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_PERSONPSW__PERSON__NAME = ["Person", "Person.ValCodperson", "Person.ValZzstate", "Person.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"personpsw.codperson" => ViewModelConversion.ToString(modelValue),
				"personpsw.codpsw" => ViewModelConversion.ToString(modelValue),
				"personpsw.created_by" => ViewModelConversion.ToString(modelValue),
				"personpsw.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"personpsw.updated_by" => ViewModelConversion.ToString(modelValue),
				"personpsw.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"personpsw.codpersonpsw" => ViewModelConversion.ToString(modelValue),
				"psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"psw.nome" => ViewModelConversion.ToString(modelValue),
				"person.codperson" => ViewModelConversion.ToString(modelValue),
				"person.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FORM_PERSONPSW]/

		#endregion
	}
}
