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
using GenioMVC.ViewModels.Person;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER PERSON]/

namespace GenioMVC.Controllers
{
	public partial class PersonController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_PERSON_CANCEL = new("PERSON10446", "Form_person_Cancel", "Person") { vueRouteName = "form-FORM_PERSON", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_PERSON_SHOW = new("PERSON10446", "Form_person_Show", "Person") { vueRouteName = "form-FORM_PERSON", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_PERSON_NEW = new("PERSON10446", "Form_person_New", "Person") { vueRouteName = "form-FORM_PERSON", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_PERSON_EDIT = new("PERSON10446", "Form_person_Edit", "Person") { vueRouteName = "form-FORM_PERSON", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_PERSON_DUPLICATE = new("PERSON10446", "Form_person_Duplicate", "Person") { vueRouteName = "form-FORM_PERSON", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_PERSON_DELETE = new("PERSON10446", "Form_person_Delete", "Person") { vueRouteName = "form-FORM_PERSON", mode = "DELETE" };

		#endregion

		#region Form_person private

		private void FormHistoryLimits_Form_person()
		{

		}

		#endregion

		#region Form_person_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_PERSON]/

		[HttpPost]
		public ActionResult Form_person_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_person_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Show_GET",
				AreaName = "person",
				Location = ACTION_FORM_PERSON_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_person();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_PERSON]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_person_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_person_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_person_New_GET",
				AreaName = "person",
				FormName = "FORM_PERSON",
				Location = ACTION_FORM_PERSON_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_person();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_PERSON]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Person/Form_person_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_New([FromBody]Form_person_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_person_New",
				ViewName = "Form_person",
				AreaName = "person",
				Location = ACTION_FORM_PERSON_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_PERSON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_PERSON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_PERSON]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_person_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_person_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Edit_GET",
				AreaName = "person",
				FormName = "FORM_PERSON",
				Location = ACTION_FORM_PERSON_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_person();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_PERSON]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Person/Form_person_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_Edit([FromBody]Form_person_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Edit",
				ViewName = "Form_person",
				AreaName = "person",
				Location = ACTION_FORM_PERSON_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_PERSON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_PERSON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_PERSON]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_person_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_person_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Delete_GET",
				AreaName = "person",
				FormName = "FORM_PERSON",
				Location = ACTION_FORM_PERSON_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_person();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_PERSON]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Person/Form_person_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_person_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_person_Delete",
				ViewName = "Form_person",
				AreaName = "person",
				Location = ACTION_FORM_PERSON_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_PERSON]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_person_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_PERSON");
		}

		#endregion

		#region Form_person_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_PERSON]/

		[HttpPost]
		public ActionResult Form_person_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_person_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Duplicate_GET",
				AreaName = "person",
				FormName = "FORM_PERSON",
				Location = ACTION_FORM_PERSON_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_PERSON]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Person/Form_person_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_PERSON]/
		[HttpPost]
		public ActionResult Form_person_Duplicate([FromBody]Form_person_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_person_Duplicate",
				ViewName = "Form_person",
				AreaName = "person",
				Location = ACTION_FORM_PERSON_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_PERSON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_PERSON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_PERSON]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_person_Cancel

		//
		// GET: /Person/Form_person_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_PERSON]/
		public ActionResult Form_person_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Person model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("person");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_PERSON]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_PERSON]/

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

				Navigation.SetValue("ForcePrimaryRead_person", "true", true);
			}

			Navigation.ClearValue("person");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Person/Form_person_SaveEdit
		[HttpPost]
		public ActionResult Form_person_SaveEdit([FromBody] Form_person_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_person_SaveEdit",
				ViewName = "Form_person",
				AreaName = "person",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_PERSON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_PERSON]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_personDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_person_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_person([FromBody] Form_personDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
