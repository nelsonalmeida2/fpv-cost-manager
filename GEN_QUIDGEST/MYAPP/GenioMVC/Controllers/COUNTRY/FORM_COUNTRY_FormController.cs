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
using GenioMVC.ViewModels.Country;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER COUNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CountryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_COUNTRY_CANCEL = new("COUNTRY64133", "Form_country_Cancel", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_COUNTRY_SHOW = new("COUNTRY64133", "Form_country_Show", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_COUNTRY_NEW = new("COUNTRY64133", "Form_country_New", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_COUNTRY_EDIT = new("COUNTRY64133", "Form_country_Edit", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_COUNTRY_DUPLICATE = new("COUNTRY64133", "Form_country_Duplicate", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_COUNTRY_DELETE = new("COUNTRY64133", "Form_country_Delete", "Country") { vueRouteName = "form-FORM_COUNTRY", mode = "DELETE" };

		#endregion

		#region Form_country private

		private void FormHistoryLimits_Form_country()
		{

		}

		#endregion

		#region Form_country_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_COUNTRY]/

		[HttpPost]
		public ActionResult Form_country_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Show_GET",
				AreaName = "country",
				Location = ACTION_FORM_COUNTRY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_country();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_COUNTRY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_country_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_country_New_GET",
				AreaName = "country",
				FormName = "FORM_COUNTRY",
				Location = ACTION_FORM_COUNTRY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_country();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_COUNTRY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Country/Form_country_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_New([FromBody]Form_country_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_country_New",
				ViewName = "Form_country",
				AreaName = "country",
				Location = ACTION_FORM_COUNTRY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_COUNTRY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_country_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Edit_GET",
				AreaName = "country",
				FormName = "FORM_COUNTRY",
				Location = ACTION_FORM_COUNTRY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_country();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_COUNTRY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Country/Form_country_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_Edit([FromBody]Form_country_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Edit",
				ViewName = "Form_country",
				AreaName = "country",
				Location = ACTION_FORM_COUNTRY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_COUNTRY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_country_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Delete_GET",
				AreaName = "country",
				FormName = "FORM_COUNTRY",
				Location = ACTION_FORM_COUNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_country();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_COUNTRY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Country/Form_country_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_country_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_country_Delete",
				ViewName = "Form_country",
				AreaName = "country",
				Location = ACTION_FORM_COUNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_COUNTRY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_country_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_COUNTRY");
		}

		#endregion

		#region Form_country_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_COUNTRY]/

		[HttpPost]
		public ActionResult Form_country_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Duplicate_GET",
				AreaName = "country",
				FormName = "FORM_COUNTRY",
				Location = ACTION_FORM_COUNTRY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_COUNTRY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Country/Form_country_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_COUNTRY]/
		[HttpPost]
		public ActionResult Form_country_Duplicate([FromBody]Form_country_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_country_Duplicate",
				ViewName = "Form_country",
				AreaName = "country",
				Location = ACTION_FORM_COUNTRY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_COUNTRY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_country_Cancel

		//
		// GET: /Country/Form_country_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_COUNTRY]/
		public ActionResult Form_country_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Country model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("country");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_COUNTRY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_COUNTRY]/

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

				Navigation.SetValue("ForcePrimaryRead_country", "true", true);
			}

			Navigation.ClearValue("country");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Country/Form_country_SaveEdit
		[HttpPost]
		public ActionResult Form_country_SaveEdit([FromBody] Form_country_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_country_SaveEdit",
				ViewName = "Form_country",
				AreaName = "country",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_COUNTRY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_countryDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_country_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_country([FromBody] Form_countryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
