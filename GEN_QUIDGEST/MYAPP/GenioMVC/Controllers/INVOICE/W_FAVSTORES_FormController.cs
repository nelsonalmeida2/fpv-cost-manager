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
using GenioMVC.ViewModels.Invoice;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER INVOICE]/

namespace GenioMVC.Controllers
{
	public partial class InvoiceController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_W_FAVSTORES_CANCEL = new("CANCELAR49513", "W_favstores_Cancel", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_W_FAVSTORES_SHOW = new("CONSULTA40695", "W_favstores_Show", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_W_FAVSTORES_NEW = new("INSERIR43365", "W_favstores_New", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_W_FAVSTORES_EDIT = new("EDITAR11616", "W_favstores_Edit", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_W_FAVSTORES_DUPLICATE = new("DUPLICAR09748", "W_favstores_Duplicate", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_W_FAVSTORES_DELETE = new("APAGAR04097", "W_favstores_Delete", "Invoice") { vueRouteName = "form-W_FAVSTORES", mode = "DELETE" };

		#endregion

		#region W_favstores private

		private void FormHistoryLimits_W_favstores()
		{

		}

		#endregion

		#region W_favstores_Show

// USE /[MANUAL FPV CONTROLLER_SHOW W_FAVSTORES]/

		[HttpPost]
		public ActionResult W_favstores_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			W_favstores_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Show_GET",
				AreaName = "invoice",
				Location = ACTION_W_FAVSTORES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_W_favstores();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW W_FAVSTORES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region W_favstores_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			W_favstores_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_New_GET",
				AreaName = "invoice",
				FormName = "W_FAVSTORES",
				Location = ACTION_W_FAVSTORES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_W_favstores();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW W_FAVSTORES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Invoice/W_favstores_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_New([FromBody]W_favstores_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_New",
				ViewName = "W_favstores",
				AreaName = "invoice",
				Location = ACTION_W_FAVSTORES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW W_FAVSTORES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX W_FAVSTORES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX W_FAVSTORES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region W_favstores_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			W_favstores_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Edit_GET",
				AreaName = "invoice",
				FormName = "W_FAVSTORES",
				Location = ACTION_W_FAVSTORES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_W_favstores();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT W_FAVSTORES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Invoice/W_favstores_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_Edit([FromBody]W_favstores_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Edit",
				ViewName = "W_favstores",
				AreaName = "invoice",
				Location = ACTION_W_FAVSTORES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT W_FAVSTORES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX W_FAVSTORES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX W_FAVSTORES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region W_favstores_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			W_favstores_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Delete_GET",
				AreaName = "invoice",
				FormName = "W_FAVSTORES",
				Location = ACTION_W_FAVSTORES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_W_favstores();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE W_FAVSTORES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Invoice/W_favstores_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			W_favstores_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Delete",
				ViewName = "W_favstores",
				AreaName = "invoice",
				Location = ACTION_W_FAVSTORES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE W_FAVSTORES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult W_favstores_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("W_FAVSTORES");
		}

		#endregion

		#region W_favstores_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET W_FAVSTORES]/

		[HttpPost]
		public ActionResult W_favstores_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			W_favstores_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Duplicate_GET",
				AreaName = "invoice",
				FormName = "W_FAVSTORES",
				Location = ACTION_W_FAVSTORES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE W_FAVSTORES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Invoice/W_favstores_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST W_FAVSTORES]/
		[HttpPost]
		public ActionResult W_favstores_Duplicate([FromBody]W_favstores_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_Duplicate",
				ViewName = "W_favstores",
				AreaName = "invoice",
				Location = ACTION_W_FAVSTORES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE W_FAVSTORES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX W_FAVSTORES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX W_FAVSTORES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region W_favstores_Cancel

		//
		// GET: /Invoice/W_favstores_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET W_FAVSTORES]/
		public ActionResult W_favstores_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Invoice model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("invoice");

// USE /[MANUAL FPV BEFORE_CANCEL W_FAVSTORES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL W_FAVSTORES]/

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

				Navigation.SetValue("ForcePrimaryRead_invoice", "true", true);
			}

			Navigation.ClearValue("invoice");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class W_favstores_ValField001Model : RequestLookupModel
		{
			public W_favstores_ViewModel Model { get; set; }
		}

		//
		// GET: /Invoice/W_favstores_ValField001
		// POST: /Invoice/W_favstores_ValField001
		[ActionName("W_favstores_ValField001")]
		public ActionResult W_favstores_ValField001([FromBody] W_favstores_ValField001Model requestModel)
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

			Models.Invoice parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			W_favstores_ValField001_ViewModel model = new(m_userContext, parentCtx);

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

		public class W_favstores_ValField002Model : RequestLookupModel
		{
			public W_favstores_ViewModel Model { get; set; }
		}

		//
		// GET: /Invoice/W_favstores_ValField002
		// POST: /Invoice/W_favstores_ValField002
		[ActionName("W_favstores_ValField002")]
		public ActionResult W_favstores_ValField002([FromBody] W_favstores_ValField002Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_store")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_store");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Invoice parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			W_favstores_ValField002_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Invoice/W_favstores_SaveEdit
		[HttpPost]
		public ActionResult W_favstores_SaveEdit([FromBody] W_favstores_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "W_favstores_SaveEdit",
				ViewName = "W_favstores",
				AreaName = "invoice",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT W_FAVSTORES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT W_FAVSTORES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class W_favstoresDocumValidateTickets : RequestDocumValidateTickets
		{
			public W_favstores_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsW_favstores([FromBody] W_favstoresDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
