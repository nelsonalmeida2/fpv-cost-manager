using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_ITEM_CANCEL = new("ITEM40802", "Form_item_Cancel", "Item") { vueRouteName = "form-FORM_ITEM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_ITEM_SHOW = new("ITEM40802", "Form_item_Show", "Item") { vueRouteName = "form-FORM_ITEM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_ITEM_NEW = new("ITEM40802", "Form_item_New", "Item") { vueRouteName = "form-FORM_ITEM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_ITEM_EDIT = new("ITEM40802", "Form_item_Edit", "Item") { vueRouteName = "form-FORM_ITEM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_ITEM_DUPLICATE = new("ITEM40802", "Form_item_Duplicate", "Item") { vueRouteName = "form-FORM_ITEM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_ITEM_DELETE = new("ITEM40802", "Form_item_Delete", "Item") { vueRouteName = "form-FORM_ITEM", mode = "DELETE" };

		#endregion

		#region Form_item private

		private void FormHistoryLimits_Form_item()
		{

		}

		#endregion

		#region Form_item_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_ITEM]/

		[HttpPost]
		public ActionResult Form_item_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Show_GET",
				AreaName = "item",
				Location = ACTION_FORM_ITEM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_item();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_ITEM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_item_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_item_New_GET",
				AreaName = "item",
				FormName = "FORM_ITEM",
				Location = ACTION_FORM_ITEM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_item();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_ITEM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Form_item_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_New([FromBody]Form_item_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_item_New",
				ViewName = "Form_item",
				AreaName = "item",
				Location = ACTION_FORM_ITEM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_ITEM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_item_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Edit_GET",
				AreaName = "item",
				FormName = "FORM_ITEM",
				Location = ACTION_FORM_ITEM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_item();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_ITEM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Form_item_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_Edit([FromBody]Form_item_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Edit",
				ViewName = "Form_item",
				AreaName = "item",
				Location = ACTION_FORM_ITEM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_ITEM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_item_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Delete_GET",
				AreaName = "item",
				FormName = "FORM_ITEM",
				Location = ACTION_FORM_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_item();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_ITEM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Form_item_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_item_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_item_Delete",
				ViewName = "Form_item",
				AreaName = "item",
				Location = ACTION_FORM_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_ITEM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_item_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_ITEM");
		}

		#endregion

		#region Form_item_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_ITEM]/

		[HttpPost]
		public ActionResult Form_item_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Duplicate_GET",
				AreaName = "item",
				FormName = "FORM_ITEM",
				Location = ACTION_FORM_ITEM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_ITEM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Form_item_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_ITEM]/
		[HttpPost]
		public ActionResult Form_item_Duplicate([FromBody]Form_item_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_item_Duplicate",
				ViewName = "Form_item",
				AreaName = "item",
				Location = ACTION_FORM_ITEM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_ITEM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_item_Cancel

		//
		// GET: /Item/Form_item_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_ITEM]/
		public ActionResult Form_item_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Item model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_ITEM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_ITEM]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_item", "true", true);
			}

			Navigation.ClearValue("item");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_item_BrandValNameModel : RequestLookupModel
		{
			public Form_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Form_item_BrandValName
		// POST: /Item/Form_item_BrandValName
		[ActionName("Form_item_BrandValName")]
		public ActionResult Form_item_BrandValName([FromBody] Form_item_BrandValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_brand")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_brand");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_item_BrandValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Form_item_CategoryValNameModel : RequestLookupModel
		{
			public Form_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Form_item_CategoryValName
		// POST: /Item/Form_item_CategoryValName
		[ActionName("Form_item_CategoryValName")]
		public ActionResult Form_item_CategoryValName([FromBody] Form_item_CategoryValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_category")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_category");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_item_CategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Form_item_SubcategoryValNameModel : RequestLookupModel
		{
			public Form_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Form_item_SubcategoryValName
		// POST: /Item/Form_item_SubcategoryValName
		[ActionName("Form_item_SubcategoryValName")]
		public ActionResult Form_item_SubcategoryValName([FromBody] Form_item_SubcategoryValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_subcategory")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_subcategory");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_item_SubcategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Form_item_InvoiceValCodinvoicestoreModel : RequestLookupModel
		{
			public Form_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Form_item_InvoiceValCodinvoicestore
		// POST: /Item/Form_item_InvoiceValCodinvoicestore
		[ActionName("Form_item_InvoiceValCodinvoicestore")]
		public ActionResult Form_item_InvoiceValCodinvoicestore([FromBody] Form_item_InvoiceValCodinvoicestoreModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_invoice")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_invoice");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_item_InvoiceValCodinvoicestore_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Form_item_ValField001Model : RequestLookupModel
		{
			public Form_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Form_item_ValField001
		// POST: /Item/Form_item_ValField001
		[ActionName("Form_item_ValField001")]
		public ActionResult Form_item_ValField001([FromBody] Form_item_ValField001Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_photoalbum")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_photoalbum");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_item_ValField001_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Item/Form_item_SaveEdit
		[HttpPost]
		public ActionResult Form_item_SaveEdit([FromBody] Form_item_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_item_SaveEdit",
				ViewName = "Form_item",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_ITEM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_itemDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_item_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_item([FromBody] Form_itemDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
