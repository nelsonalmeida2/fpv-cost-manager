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
using GenioMVC.ViewModels.Category;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER CATEGORY]/

namespace GenioMVC.Controllers
{
	public partial class CategoryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_CATEGORY_CANCEL = new("CATEGORY18978", "Form_category_Cancel", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_CATEGORY_SHOW = new("CATEGORY18978", "Form_category_Show", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_CATEGORY_NEW = new("CATEGORY18978", "Form_category_New", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_CATEGORY_EDIT = new("CATEGORY18978", "Form_category_Edit", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_CATEGORY_DUPLICATE = new("CATEGORY18978", "Form_category_Duplicate", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_CATEGORY_DELETE = new("CATEGORY18978", "Form_category_Delete", "Category") { vueRouteName = "form-FORM_CATEGORY", mode = "DELETE" };

		#endregion

		#region Form_category private

		private void FormHistoryLimits_Form_category()
		{

		}

		#endregion

		#region Form_category_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_CATEGORY]/

		[HttpPost]
		public ActionResult Form_category_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Show_GET",
				AreaName = "category",
				Location = ACTION_FORM_CATEGORY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_category();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_CATEGORY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_category_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_category_New_GET",
				AreaName = "category",
				FormName = "FORM_CATEGORY",
				Location = ACTION_FORM_CATEGORY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_category();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_CATEGORY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Category/Form_category_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_New([FromBody]Form_category_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_category_New",
				ViewName = "Form_category",
				AreaName = "category",
				Location = ACTION_FORM_CATEGORY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_CATEGORY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_category_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Edit_GET",
				AreaName = "category",
				FormName = "FORM_CATEGORY",
				Location = ACTION_FORM_CATEGORY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_category();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_CATEGORY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Category/Form_category_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_Edit([FromBody]Form_category_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Edit",
				ViewName = "Form_category",
				AreaName = "category",
				Location = ACTION_FORM_CATEGORY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_CATEGORY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_category_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Delete_GET",
				AreaName = "category",
				FormName = "FORM_CATEGORY",
				Location = ACTION_FORM_CATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_category();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_CATEGORY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Category/Form_category_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_category_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_category_Delete",
				ViewName = "Form_category",
				AreaName = "category",
				Location = ACTION_FORM_CATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_CATEGORY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_category_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_CATEGORY");
		}

		#endregion

		#region Form_category_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_CATEGORY]/

		[HttpPost]
		public ActionResult Form_category_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Duplicate_GET",
				AreaName = "category",
				FormName = "FORM_CATEGORY",
				Location = ACTION_FORM_CATEGORY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_CATEGORY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Category/Form_category_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_CATEGORY]/
		[HttpPost]
		public ActionResult Form_category_Duplicate([FromBody]Form_category_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_category_Duplicate",
				ViewName = "Form_category",
				AreaName = "category",
				Location = ACTION_FORM_CATEGORY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_CATEGORY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_category_Cancel

		//
		// GET: /Category/Form_category_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_CATEGORY]/
		public ActionResult Form_category_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Category model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("category");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_CATEGORY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_CATEGORY]/

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

				Navigation.SetValue("ForcePrimaryRead_category", "true", true);
			}

			Navigation.ClearValue("category");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Category/Form_category_SaveEdit
		[HttpPost]
		public ActionResult Form_category_SaveEdit([FromBody] Form_category_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_category_SaveEdit",
				ViewName = "Form_category",
				AreaName = "category",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_CATEGORY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_categoryDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_category_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_category([FromBody] Form_categoryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
