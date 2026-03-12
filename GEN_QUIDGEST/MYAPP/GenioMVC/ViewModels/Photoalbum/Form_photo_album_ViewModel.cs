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

namespace GenioMVC.ViewModels.Photoalbum
{
	public class Form_photo_album_ViewModel : FormViewModel<Models.Photoalbum>, IPreparableForSerialization
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
		/// Title: "Item" | Type: "CE"
		/// </summary>
		public string ValItem { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodperson { get; set; }

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
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Item" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodphotoalbum { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Form_photo_album_ViewModel() : base(null!) { }

		public Form_photo_album_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFORM_PHOTO_ALBUM", nestedForm) { }

		public Form_photo_album_ViewModel(UserContext userContext, Models.Photoalbum row, bool nestedForm = false) : base(userContext, "FFORM_PHOTO_ALBUM", row, nestedForm) { }

		public Form_photo_album_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("photoalbum", id);
			Model = Models.Photoalbum.Find(id, userContext, "FFORM_PHOTO_ALBUM", fieldsToQuery: fieldsToLoad);
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
			Models.Photoalbum model = new Models.Photoalbum(userContext) { Identifier = "FFORM_PHOTO_ALBUM" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFORM_PHOTO_ALBUM");
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
		public override void MapFromModel(Models.Photoalbum m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Photoalbum) to ViewModel (Form_photo_album) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValItem = ViewModelConversion.ToString(m.ValItem);
				ValCodperson = ViewModelConversion.ToString(m.ValCodperson);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValCodphotoalbum = ViewModelConversion.ToString(m.ValCodphotoalbum);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Photoalbum) to ViewModel (Form_photo_album) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Photoalbum m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Form_photo_album) to Model (Photoalbum) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValItem = ViewModelConversion.ToString(ValItem);
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValCodphotoalbum = ViewModelConversion.ToString(ValCodphotoalbum);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodperson = ViewModelConversion.ToString(ValCodperson);
				m.ValCreated_by = ViewModelConversion.ToString(ValCreated_by);
				m.ValCreated_at = ViewModelConversion.ToDateTime(ValCreated_at);
				m.ValUpdated_by = ViewModelConversion.ToString(ValUpdated_by);
				m.ValUpdated_at = ViewModelConversion.ToDateTime(ValUpdated_at);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Form_photo_album) to Model (Photoalbum) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "photoalbum.item":
						this.ValItem = ViewModelConversion.ToString(_value);
						break;
					case "photoalbum.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "photoalbum.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "photoalbum.codphotoalbum":
						this.ValCodphotoalbum = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Form_photo_album) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Form_photo_album)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Photoalbum.Find(id ?? Navigation.GetStrValue("photoalbum"), m_userContext, "FFORM_PHOTO_ALBUM"); }
			finally { Model ??= new Models.Photoalbum(m_userContext) { Identifier = "FFORM_PHOTO_ALBUM" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Photoalbum.Find(Navigation.GetStrValue("photoalbum"), m_userContext, "FFORM_PHOTO_ALBUM");
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

			Model.Identifier = "FFORM_PHOTO_ALBUM";
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
		
		protected override void LoadDocumentsProperties(Models.Photoalbum row)
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
				Model = Models.Photoalbum.Find(Navigation.GetStrValue("photoalbum"), m_userContext, "FFORM_PHOTO_ALBUM");
				if (Model == null)
				{
					Model = new Models.Photoalbum(m_userContext) { Identifier = "FFORM_PHOTO_ALBUM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("photoalbum");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Form_photo_album__item__name(qs, lazyLoad);

// USE /[MANUAL FPV VIEWMODEL_LOADPARTIAL FORM_PHOTO_ALBUM]/
		}

// USE /[MANUAL FPV VIEWMODEL_NEW FORM_PHOTO_ALBUM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValItem", Resources.Resources.ITEM40802, ViewModelConversion.ToString(ValItem), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValCreated_by", Resources.Resources.CREATED_BY12292, ViewModelConversion.ToString(ValCreated_by), FieldType.TEXT.GetFormatting());

			validator.Required("ValCreated_at", Resources.Resources.CREATED_AT29089, ViewModelConversion.ToDateTime(ValCreated_at), FieldType.DATETIMESECONDS.GetFormatting());

			validator.Required("ValPhoto", Resources.Resources.PHOTO51874, ViewModelConversion.ToImage(ValPhoto), FieldType.IMAGE.GetFormatting());
			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);

			validator.Required("ValTitle", Resources.Resources.TITLE21885, ViewModelConversion.ToString(ValTitle), FieldType.TEXT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL FPV VIEWMODEL_SAVE FORM_PHOTO_ALBUM]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL FPV VIEWMODEL_APPLY FORM_PHOTO_ALBUM]/

// USE /[MANUAL FPV VIEWMODEL_DUPLICATE FORM_PHOTO_ALBUM]/

// USE /[MANUAL FPV VIEWMODEL_DESTROY FORM_PHOTO_ALBUM]/
		public override void Destroy(string id)
		{
			Model = Models.Photoalbum.Find(id, m_userContext, "FFORM_PHOTO_ALBUM");
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
		/// TableItemName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Form_photo_album__item__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool form_photo_album__item__nameDoLoad = true;
			CriteriaSet form_photo_album__item__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("item", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					form_photo_album__item__nameConds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValItem = DBConversion.ToString(hValue);
				}
			}

			TableItemName = new TableDBEdit<Models.Item>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValItem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
				FillDependant_Form_photo_albumTableItemName(lazyLoad);
				return;
			}

			if (form_photo_album__item__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableItemName, "sTableItemName", "dTableItemName", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableItemName_tableFilters"]))
					TableItemName.TableFilters = bool.Parse(qs["TableItemName_tableFilters"]);
				else
					TableItemName.TableFilters = false;

				query = qs["qTableItemName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAitem.FldName, query + "%");
				}
				form_photo_album__item__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemName"] != null ? qs["pTableItemName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldName, CSGenioAitem.FldZzstate];

// USE /[MANUAL FPV OVERRQ FORM_PHOTO_ALBUM_ITEMNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					form_photo_album__item__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					form_photo_album__item__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "name");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, form_photo_album__item__nameConds, fields, offset, numberItems, sorts, "LED_FORM_PHOTO_ALBUM__ITEM__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemName.Query = query;
				TableItemName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_FORM_PHOTO_ALBUM__ITEM__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValItem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemName.List = new SelectList(TableItemName.Elements.ToSelectList(x => x.ValName, x => x.ValCoditem,  x => x.ValCoditem == this.ValItem), "Value", "Text", this.ValItem);
				//Seleciona se só um
				if (TableItemName.List != null && TableItemName.List.Count() == 1)
				{
					this.ValItem = TableItemName.List.First().Value;
					Navigation.SetValue("item", this.ValItem);
				}
				FillDependant_Form_photo_albumTableItemName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_Form_photo_albumTableItemName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldName];

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

			CSGenioAitem tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableItemName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Form_photo_albumTableItemName(bool lazyLoad = false)
		{
			var row = GetDependant_Form_photo_albumTableItemName(this.ValItem);
			try
			{

				// Fill List fields
				this.ValItem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemName.Value = (string)row["item.name"];
				if (GenFunctions.emptyG(this.ValItem) == 1)
				{
					this.ValItem = "";
					TableItemName.Value = "";
					Navigation.ClearValue("item");
				}
				else if (lazyLoad)
				{
					TableItemName.SetPagination(1, 0, false, false, 1);
					TableItemName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValItem),
							Text = Convert.ToString(TableItemName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValItem);
				}

				TableItemName.Selected = this.ValItem;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FORM_PHOTO_ALBUM__ITEM__NAME = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"photoalbum.item" => ViewModelConversion.ToString(modelValue),
				"photoalbum.codperson" => ViewModelConversion.ToString(modelValue),
				"photoalbum.created_by" => ViewModelConversion.ToString(modelValue),
				"photoalbum.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"photoalbum.updated_by" => ViewModelConversion.ToString(modelValue),
				"photoalbum.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"photoalbum.photo" => ViewModelConversion.ToImage(modelValue),
				"photoalbum.title" => ViewModelConversion.ToString(modelValue),
				"photoalbum.codphotoalbum" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"item.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPHOTOALBUM, CSGenioAphotoalbum.FldPhoto.Field, null, ValCodphotoalbum);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL FPV VIEWMODEL_CUSTOM FORM_PHOTO_ALBUM]/

		#endregion
	}
}
