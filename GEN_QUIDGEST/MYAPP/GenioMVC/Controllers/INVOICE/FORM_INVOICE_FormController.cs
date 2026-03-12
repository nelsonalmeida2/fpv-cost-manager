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

		private static readonly NavigationLocation ACTION_FORM_INVOICE_CANCEL = new("INVOICE63068", "Form_invoice_Cancel", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_INVOICE_SHOW = new("INVOICE63068", "Form_invoice_Show", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_INVOICE_NEW = new("INVOICE63068", "Form_invoice_New", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_INVOICE_EDIT = new("INVOICE63068", "Form_invoice_Edit", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_INVOICE_DUPLICATE = new("INVOICE63068", "Form_invoice_Duplicate", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_INVOICE_DELETE = new("INVOICE63068", "Form_invoice_Delete", "Invoice") { vueRouteName = "form-FORM_INVOICE", mode = "DELETE" };

		#endregion

		#region Form_invoice private

		private void FormHistoryLimits_Form_invoice()
		{

		}

		#endregion

		#region Form_invoice_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_INVOICE]/

		[HttpPost]
		public ActionResult Form_invoice_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_invoice_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Show_GET",
				AreaName = "invoice",
				Location = ACTION_FORM_INVOICE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_invoice();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_INVOICE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_invoice_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_invoice_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_New_GET",
				AreaName = "invoice",
				FormName = "FORM_INVOICE",
				Location = ACTION_FORM_INVOICE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_invoice();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_INVOICE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Invoice/Form_invoice_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_New([FromBody]Form_invoice_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_New",
				ViewName = "Form_invoice",
				AreaName = "invoice",
				Location = ACTION_FORM_INVOICE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_INVOICE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_INVOICE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_INVOICE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_invoice_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_invoice_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Edit_GET",
				AreaName = "invoice",
				FormName = "FORM_INVOICE",
				Location = ACTION_FORM_INVOICE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_invoice();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_INVOICE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Invoice/Form_invoice_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_Edit([FromBody]Form_invoice_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Edit",
				ViewName = "Form_invoice",
				AreaName = "invoice",
				Location = ACTION_FORM_INVOICE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_INVOICE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_INVOICE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_INVOICE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_invoice_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_invoice_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Delete_GET",
				AreaName = "invoice",
				FormName = "FORM_INVOICE",
				Location = ACTION_FORM_INVOICE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_invoice();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_INVOICE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Invoice/Form_invoice_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_invoice_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Delete",
				ViewName = "Form_invoice",
				AreaName = "invoice",
				Location = ACTION_FORM_INVOICE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_INVOICE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_invoice_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_INVOICE");
		}

		#endregion

		#region Form_invoice_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_INVOICE]/

		[HttpPost]
		public ActionResult Form_invoice_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_invoice_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Duplicate_GET",
				AreaName = "invoice",
				FormName = "FORM_INVOICE",
				Location = ACTION_FORM_INVOICE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_INVOICE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Invoice/Form_invoice_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_INVOICE]/
		[HttpPost]
		public ActionResult Form_invoice_Duplicate([FromBody]Form_invoice_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_Duplicate",
				ViewName = "Form_invoice",
				AreaName = "invoice",
				Location = ACTION_FORM_INVOICE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_INVOICE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_INVOICE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_INVOICE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_invoice_Cancel

		//
		// GET: /Invoice/Form_invoice_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_INVOICE]/
		public ActionResult Form_invoice_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Invoice model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("invoice");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_INVOICE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_INVOICE]/

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


		public class Form_invoice_ValField001Model : RequestLookupModel
		{
			public Form_invoice_ViewModel Model { get; set; }
		}

		//
		// GET: /Invoice/Form_invoice_ValField001
		// POST: /Invoice/Form_invoice_ValField001
		[ActionName("Form_invoice_ValField001")]
		public ActionResult Form_invoice_ValField001([FromBody] Form_invoice_ValField001Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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
			Form_invoice_ValField001_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Invoice/Form_invoice_SaveEdit
		[HttpPost]
		public ActionResult Form_invoice_SaveEdit([FromBody] Form_invoice_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_invoice_SaveEdit",
				ViewName = "Form_invoice",
				AreaName = "invoice",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_INVOICE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_INVOICE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_invoiceDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_invoice_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_invoice([FromBody] Form_invoiceDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field RECEIPT
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileForm_invoiceReceipt([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
