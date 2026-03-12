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
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
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
		/// Title: "Assigned to" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string PersonValName
		{
			get
			{
				return funcPersonValName != null ? funcPersonValName() : _auxPersonValName;
			}
			set { funcPersonValName = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPersonValName { get; set; }

		private string _auxPersonValName { get; set; }
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
		public string ItemValName
		{
			get
			{
				return funcItemValName != null ? funcItemValName() : _auxItemValName;
			}
			set { funcItemValName = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcItemValName { get; set; }

		private string _auxItemValName { get; set; }

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
				funcPersonValName = () => ViewModelConversion.ToString(m.Person.ValName);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				funcItemValName = () => ViewModelConversion.ToString(m.Item.ValName);
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

				m.ValItem = ViewModelConversion.ToString(ValItem);
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


			validator.Required("ValCreated_by", Resources.Resources.CREATED_BY12292, ViewModelConversion.ToString(ValCreated_by), FieldType.TEXT.GetFormatting());

			validator.Required("ValCreated_at", Resources.Resources.CREATED_AT29089, ViewModelConversion.ToDateTime(ValCreated_at), FieldType.DATETIMESECONDS.GetFormatting());
			validator.StringLength("PersonValName", Resources.Resources.ASSIGNED_TO26333, PersonValName, 50);

			validator.Required("ValPhoto", Resources.Resources.PHOTO51874, ViewModelConversion.ToImage(ValPhoto), FieldType.IMAGE.GetFormatting());
			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);

			validator.Required("ValTitle", Resources.Resources.TITLE21885, ViewModelConversion.ToString(ValTitle), FieldType.TEXT.GetFormatting());
			validator.StringLength("ItemValName", Resources.Resources.ITEM40802, ItemValName, 255);


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
				"person.name" => ViewModelConversion.ToString(modelValue),
				"photoalbum.photo" => ViewModelConversion.ToImage(modelValue),
				"photoalbum.title" => ViewModelConversion.ToString(modelValue),
				"item.name" => ViewModelConversion.ToString(modelValue),
				"photoalbum.codphotoalbum" => ViewModelConversion.ToString(modelValue),
				"person.codperson" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
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
