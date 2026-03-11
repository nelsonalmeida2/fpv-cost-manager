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
using GenioMVC.ViewModels.Personpsw;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER PERSONPSW]/

namespace GenioMVC.Controllers
{
	public partial class PersonpswController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_CANCEL = new("PERSON_PSW33377", "Form_personpsw_Cancel", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_SHOW = new("PERSON_PSW33377", "Form_personpsw_Show", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_NEW = new("PERSON_PSW33377", "Form_personpsw_New", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_EDIT = new("PERSON_PSW33377", "Form_personpsw_Edit", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_DUPLICATE = new("PERSON_PSW33377", "Form_personpsw_Duplicate", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_PERSONPSW_DELETE = new("PERSON_PSW33377", "Form_personpsw_Delete", "Personpsw") { vueRouteName = "form-FORM_PERSONPSW", mode = "DELETE" };

		#endregion

		#region Form_personpsw private

		private void FormHistoryLimits_Form_personpsw()
		{

		}

		#endregion

		#region Form_personpsw_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_PERSONPSW]/

		[HttpPost]
		public ActionResult Form_personpsw_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_personpsw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Show_GET",
				AreaName = "personpsw",
				Location = ACTION_FORM_PERSONPSW_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_personpsw();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_PERSONPSW]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_personpsw_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_personpsw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_New_GET",
				AreaName = "personpsw",
				FormName = "FORM_PERSONPSW",
				Location = ACTION_FORM_PERSONPSW_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_personpsw();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_PERSONPSW]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Personpsw/Form_personpsw_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_New([FromBody]Form_personpsw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_New",
				ViewName = "Form_personpsw",
				AreaName = "personpsw",
				Location = ACTION_FORM_PERSONPSW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_PERSONPSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_PERSONPSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_PERSONPSW]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_personpsw_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_personpsw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Edit_GET",
				AreaName = "personpsw",
				FormName = "FORM_PERSONPSW",
				Location = ACTION_FORM_PERSONPSW_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_personpsw();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_PERSONPSW]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Personpsw/Form_personpsw_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_Edit([FromBody]Form_personpsw_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Edit",
				ViewName = "Form_personpsw",
				AreaName = "personpsw",
				Location = ACTION_FORM_PERSONPSW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_PERSONPSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_PERSONPSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_PERSONPSW]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_personpsw_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_personpsw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Delete_GET",
				AreaName = "personpsw",
				FormName = "FORM_PERSONPSW",
				Location = ACTION_FORM_PERSONPSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_personpsw();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_PERSONPSW]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Personpsw/Form_personpsw_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_personpsw_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Delete",
				ViewName = "Form_personpsw",
				AreaName = "personpsw",
				Location = ACTION_FORM_PERSONPSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_PERSONPSW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_personpsw_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_PERSONPSW");
		}

		#endregion

		#region Form_personpsw_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_PERSONPSW]/

		[HttpPost]
		public ActionResult Form_personpsw_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_personpsw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Duplicate_GET",
				AreaName = "personpsw",
				FormName = "FORM_PERSONPSW",
				Location = ACTION_FORM_PERSONPSW_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_PERSONPSW]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Personpsw/Form_personpsw_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_PERSONPSW]/
		[HttpPost]
		public ActionResult Form_personpsw_Duplicate([FromBody]Form_personpsw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_Duplicate",
				ViewName = "Form_personpsw",
				AreaName = "personpsw",
				Location = ACTION_FORM_PERSONPSW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_PERSONPSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_PERSONPSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_PERSONPSW]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_personpsw_Cancel

		//
		// GET: /Personpsw/Form_personpsw_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_PERSONPSW]/
		public ActionResult Form_personpsw_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Personpsw model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("personpsw");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_PERSONPSW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_PERSONPSW]/

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

				Navigation.SetValue("ForcePrimaryRead_personpsw", "true", true);
			}

			Navigation.ClearValue("personpsw");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_personpsw_PswValNomeModel : RequestLookupModel
		{
			public Form_personpsw_ViewModel Model { get; set; }
		}

		//
		// GET: /Personpsw/Form_personpsw_PswValNome
		// POST: /Personpsw/Form_personpsw_PswValNome
		[ActionName("Form_personpsw_PswValNome")]
		public ActionResult Form_personpsw_PswValNome([FromBody] Form_personpsw_PswValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
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

			Models.Personpsw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_personpsw_PswValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Form_personpsw_PersonValNameModel : RequestLookupModel
		{
			public Form_personpsw_ViewModel Model { get; set; }
		}

		//
		// GET: /Personpsw/Form_personpsw_PersonValName
		// POST: /Personpsw/Form_personpsw_PersonValName
		[ActionName("Form_personpsw_PersonValName")]
		public ActionResult Form_personpsw_PersonValName([FromBody] Form_personpsw_PersonValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_person")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_person");
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

			Models.Personpsw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_personpsw_PersonValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Personpsw/Form_personpsw_SaveEdit
		[HttpPost]
		public ActionResult Form_personpsw_SaveEdit([FromBody] Form_personpsw_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_personpsw_SaveEdit",
				ViewName = "Form_personpsw",
				AreaName = "personpsw",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_PERSONPSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_PERSONPSW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_personpswDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_personpsw_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_personpsw([FromBody] Form_personpswDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
