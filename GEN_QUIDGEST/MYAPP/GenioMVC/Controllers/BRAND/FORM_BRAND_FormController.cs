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
using GenioMVC.ViewModels.Brand;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER BRAND]/

namespace GenioMVC.Controllers
{
	public partial class BrandController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_BRAND_CANCEL = new("BRAND05002", "Form_brand_Cancel", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_BRAND_SHOW = new("BRAND05002", "Form_brand_Show", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_BRAND_NEW = new("BRAND05002", "Form_brand_New", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_BRAND_EDIT = new("BRAND05002", "Form_brand_Edit", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_BRAND_DUPLICATE = new("BRAND05002", "Form_brand_Duplicate", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_BRAND_DELETE = new("BRAND05002", "Form_brand_Delete", "Brand") { vueRouteName = "form-FORM_BRAND", mode = "DELETE" };

		#endregion

		#region Form_brand private

		private void FormHistoryLimits_Form_brand()
		{

		}

		#endregion

		#region Form_brand_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_BRAND]/

		[HttpPost]
		public ActionResult Form_brand_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_brand_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Show_GET",
				AreaName = "brand",
				Location = ACTION_FORM_BRAND_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_brand();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_BRAND]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_brand_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_brand_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_New_GET",
				AreaName = "brand",
				FormName = "FORM_BRAND",
				Location = ACTION_FORM_BRAND_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_brand();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_BRAND]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Brand/Form_brand_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_New([FromBody]Form_brand_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_New",
				ViewName = "Form_brand",
				AreaName = "brand",
				Location = ACTION_FORM_BRAND_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_BRAND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_BRAND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_BRAND]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_brand_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_brand_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Edit_GET",
				AreaName = "brand",
				FormName = "FORM_BRAND",
				Location = ACTION_FORM_BRAND_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_brand();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_BRAND]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Brand/Form_brand_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_Edit([FromBody]Form_brand_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Edit",
				ViewName = "Form_brand",
				AreaName = "brand",
				Location = ACTION_FORM_BRAND_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_BRAND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_BRAND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_BRAND]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_brand_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_brand_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Delete_GET",
				AreaName = "brand",
				FormName = "FORM_BRAND",
				Location = ACTION_FORM_BRAND_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_brand();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_BRAND]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Brand/Form_brand_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_brand_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Delete",
				ViewName = "Form_brand",
				AreaName = "brand",
				Location = ACTION_FORM_BRAND_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_BRAND]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_brand_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_BRAND");
		}

		#endregion

		#region Form_brand_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_BRAND]/

		[HttpPost]
		public ActionResult Form_brand_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_brand_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Duplicate_GET",
				AreaName = "brand",
				FormName = "FORM_BRAND",
				Location = ACTION_FORM_BRAND_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_BRAND]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Brand/Form_brand_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_BRAND]/
		[HttpPost]
		public ActionResult Form_brand_Duplicate([FromBody]Form_brand_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_Duplicate",
				ViewName = "Form_brand",
				AreaName = "brand",
				Location = ACTION_FORM_BRAND_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_BRAND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_BRAND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_BRAND]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_brand_Cancel

		//
		// GET: /Brand/Form_brand_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_BRAND]/
		public ActionResult Form_brand_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Brand model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("brand");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_BRAND]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_BRAND]/

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

				Navigation.SetValue("ForcePrimaryRead_brand", "true", true);
			}

			Navigation.ClearValue("brand");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_brand_CountryValNameModel : RequestLookupModel
		{
			public Form_brand_ViewModel Model { get; set; }
		}

		//
		// GET: /Brand/Form_brand_CountryValName
		// POST: /Brand/Form_brand_CountryValName
		[ActionName("Form_brand_CountryValName")]
		public ActionResult Form_brand_CountryValName([FromBody] Form_brand_CountryValNameModel requestModel)
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

			Models.Brand parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_brand_CountryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Brand/Form_brand_SaveEdit
		[HttpPost]
		public ActionResult Form_brand_SaveEdit([FromBody] Form_brand_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_brand_SaveEdit",
				ViewName = "Form_brand",
				AreaName = "brand",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_BRAND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_BRAND]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_brandDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_brand_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_brand([FromBody] Form_brandDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
