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
using GenioMVC.ViewModels.Store;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER STORE]/

namespace GenioMVC.Controllers
{
	public partial class StoreController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_STORE_CANCEL = new("STORE16493", "Form_store_Cancel", "Store") { vueRouteName = "form-FORM_STORE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_STORE_SHOW = new("STORE16493", "Form_store_Show", "Store") { vueRouteName = "form-FORM_STORE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_STORE_NEW = new("STORE16493", "Form_store_New", "Store") { vueRouteName = "form-FORM_STORE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_STORE_EDIT = new("STORE16493", "Form_store_Edit", "Store") { vueRouteName = "form-FORM_STORE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_STORE_DUPLICATE = new("STORE16493", "Form_store_Duplicate", "Store") { vueRouteName = "form-FORM_STORE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_STORE_DELETE = new("STORE16493", "Form_store_Delete", "Store") { vueRouteName = "form-FORM_STORE", mode = "DELETE" };

		#endregion

		#region Form_store private

		private void FormHistoryLimits_Form_store()
		{

		}

		#endregion

		#region Form_store_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_STORE]/

		[HttpPost]
		public ActionResult Form_store_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_store_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Show_GET",
				AreaName = "store",
				Location = ACTION_FORM_STORE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_store();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_STORE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_store_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_store_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_store_New_GET",
				AreaName = "store",
				FormName = "FORM_STORE",
				Location = ACTION_FORM_STORE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_store();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_STORE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Store/Form_store_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_New([FromBody]Form_store_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_store_New",
				ViewName = "Form_store",
				AreaName = "store",
				Location = ACTION_FORM_STORE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_STORE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_STORE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_STORE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_store_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_store_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Edit_GET",
				AreaName = "store",
				FormName = "FORM_STORE",
				Location = ACTION_FORM_STORE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_store();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_STORE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Store/Form_store_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_Edit([FromBody]Form_store_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Edit",
				ViewName = "Form_store",
				AreaName = "store",
				Location = ACTION_FORM_STORE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_STORE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_STORE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_STORE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_store_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_store_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Delete_GET",
				AreaName = "store",
				FormName = "FORM_STORE",
				Location = ACTION_FORM_STORE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_store();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_STORE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Store/Form_store_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_store_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_store_Delete",
				ViewName = "Form_store",
				AreaName = "store",
				Location = ACTION_FORM_STORE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_STORE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_store_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_STORE");
		}

		#endregion

		#region Form_store_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_STORE]/

		[HttpPost]
		public ActionResult Form_store_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_store_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Duplicate_GET",
				AreaName = "store",
				FormName = "FORM_STORE",
				Location = ACTION_FORM_STORE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_STORE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Store/Form_store_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_STORE]/
		[HttpPost]
		public ActionResult Form_store_Duplicate([FromBody]Form_store_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_store_Duplicate",
				ViewName = "Form_store",
				AreaName = "store",
				Location = ACTION_FORM_STORE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_STORE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_STORE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_STORE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_store_Cancel

		//
		// GET: /Store/Form_store_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_STORE]/
		public ActionResult Form_store_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Store model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("store");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_STORE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_STORE]/

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

				Navigation.SetValue("ForcePrimaryRead_store", "true", true);
			}

			Navigation.ClearValue("store");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_store_CountryValNameModel : RequestLookupModel
		{
			public Form_store_ViewModel Model { get; set; }
		}

		//
		// GET: /Store/Form_store_CountryValName
		// POST: /Store/Form_store_CountryValName
		[ActionName("Form_store_CountryValName")]
		public ActionResult Form_store_CountryValName([FromBody] Form_store_CountryValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_country")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_country");
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

			Models.Store parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_store_CountryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Store/Form_store_SaveEdit
		[HttpPost]
		public ActionResult Form_store_SaveEdit([FromBody] Form_store_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_store_SaveEdit",
				ViewName = "Form_store",
				AreaName = "store",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_STORE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_STORE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_storeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_store_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_store([FromBody] Form_storeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
