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
using GenioMVC.ViewModels.Subcategory;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER SUBCATEGORY]/

namespace GenioMVC.Controllers
{
	public partial class SubcategoryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_CANCEL = new("SUB_CATEGORY39956", "Form_subcategory_Cancel", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_SHOW = new("SUB_CATEGORY39956", "Form_subcategory_Show", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_NEW = new("SUB_CATEGORY39956", "Form_subcategory_New", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_EDIT = new("SUB_CATEGORY39956", "Form_subcategory_Edit", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_DUPLICATE = new("SUB_CATEGORY39956", "Form_subcategory_Duplicate", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_SUBCATEGORY_DELETE = new("SUB_CATEGORY39956", "Form_subcategory_Delete", "Subcategory") { vueRouteName = "form-FORM_SUBCATEGORY", mode = "DELETE" };

		#endregion

		#region Form_subcategory private

		private void FormHistoryLimits_Form_subcategory()
		{

		}

		#endregion

		#region Form_subcategory_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_SUBCATEGORY]/

		[HttpPost]
		public ActionResult Form_subcategory_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_subcategory_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Show_GET",
				AreaName = "subcategory",
				Location = ACTION_FORM_SUBCATEGORY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_subcategory();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_SUBCATEGORY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_subcategory_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_subcategory_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_New_GET",
				AreaName = "subcategory",
				FormName = "FORM_SUBCATEGORY",
				Location = ACTION_FORM_SUBCATEGORY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_subcategory();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_SUBCATEGORY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Subcategory/Form_subcategory_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_New([FromBody]Form_subcategory_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_New",
				ViewName = "Form_subcategory",
				AreaName = "subcategory",
				Location = ACTION_FORM_SUBCATEGORY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_SUBCATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_SUBCATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_SUBCATEGORY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_subcategory_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_subcategory_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Edit_GET",
				AreaName = "subcategory",
				FormName = "FORM_SUBCATEGORY",
				Location = ACTION_FORM_SUBCATEGORY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_subcategory();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_SUBCATEGORY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Subcategory/Form_subcategory_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_Edit([FromBody]Form_subcategory_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Edit",
				ViewName = "Form_subcategory",
				AreaName = "subcategory",
				Location = ACTION_FORM_SUBCATEGORY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_SUBCATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_SUBCATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_SUBCATEGORY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_subcategory_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_subcategory_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Delete_GET",
				AreaName = "subcategory",
				FormName = "FORM_SUBCATEGORY",
				Location = ACTION_FORM_SUBCATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_subcategory();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_SUBCATEGORY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Subcategory/Form_subcategory_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_subcategory_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Delete",
				ViewName = "Form_subcategory",
				AreaName = "subcategory",
				Location = ACTION_FORM_SUBCATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_SUBCATEGORY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_subcategory_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_SUBCATEGORY");
		}

		#endregion

		#region Form_subcategory_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_SUBCATEGORY]/

		[HttpPost]
		public ActionResult Form_subcategory_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_subcategory_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Duplicate_GET",
				AreaName = "subcategory",
				FormName = "FORM_SUBCATEGORY",
				Location = ACTION_FORM_SUBCATEGORY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_SUBCATEGORY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Subcategory/Form_subcategory_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_SUBCATEGORY]/
		[HttpPost]
		public ActionResult Form_subcategory_Duplicate([FromBody]Form_subcategory_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_Duplicate",
				ViewName = "Form_subcategory",
				AreaName = "subcategory",
				Location = ACTION_FORM_SUBCATEGORY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_SUBCATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_SUBCATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_SUBCATEGORY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_subcategory_Cancel

		//
		// GET: /Subcategory/Form_subcategory_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_SUBCATEGORY]/
		public ActionResult Form_subcategory_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Subcategory model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("subcategory");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_SUBCATEGORY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_SUBCATEGORY]/

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

				Navigation.SetValue("ForcePrimaryRead_subcategory", "true", true);
			}

			Navigation.ClearValue("subcategory");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_subcategory_CategoryValNameModel : RequestLookupModel
		{
			public Form_subcategory_ViewModel Model { get; set; }
		}

		//
		// GET: /Subcategory/Form_subcategory_CategoryValName
		// POST: /Subcategory/Form_subcategory_CategoryValName
		[ActionName("Form_subcategory_CategoryValName")]
		public ActionResult Form_subcategory_CategoryValName([FromBody] Form_subcategory_CategoryValNameModel requestModel)
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

			Models.Subcategory parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_subcategory_CategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Subcategory/Form_subcategory_SaveEdit
		[HttpPost]
		public ActionResult Form_subcategory_SaveEdit([FromBody] Form_subcategory_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_subcategory_SaveEdit",
				ViewName = "Form_subcategory",
				AreaName = "subcategory",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_SUBCATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_SUBCATEGORY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_subcategoryDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_subcategory_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_subcategory([FromBody] Form_subcategoryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
