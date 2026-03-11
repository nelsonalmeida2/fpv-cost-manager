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
using GenioMVC.ViewModels.Photoalbum;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL FPV INCLUDE_CONTROLLER PHOTOALBUM]/

namespace GenioMVC.Controllers
{
	public partial class PhotoalbumController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_CANCEL = new("PHOTO_ALBUM45574", "Form_photo_album_Cancel", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_SHOW = new("PHOTO_ALBUM45574", "Form_photo_album_Show", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_NEW = new("PHOTO_ALBUM45574", "Form_photo_album_New", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_EDIT = new("PHOTO_ALBUM45574", "Form_photo_album_Edit", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_DUPLICATE = new("PHOTO_ALBUM45574", "Form_photo_album_Duplicate", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FORM_PHOTO_ALBUM_DELETE = new("PHOTO_ALBUM45574", "Form_photo_album_Delete", "Photoalbum") { vueRouteName = "form-FORM_PHOTO_ALBUM", mode = "DELETE" };

		#endregion

		#region Form_photo_album private

		private void FormHistoryLimits_Form_photo_album()
		{

		}

		#endregion

		#region Form_photo_album_Show

// USE /[MANUAL FPV CONTROLLER_SHOW FORM_PHOTO_ALBUM]/

		[HttpPost]
		public ActionResult Form_photo_album_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Show_GET",
				AreaName = "photoalbum",
				Location = ACTION_FORM_PHOTO_ALBUM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_photo_album();
// USE /[MANUAL FPV BEFORE_LOAD_SHOW FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_SHOW FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Form_photo_album_New

// USE /[MANUAL FPV CONTROLLER_NEW_GET FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Form_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_New_GET",
				AreaName = "photoalbum",
				FormName = "FORM_PHOTO_ALBUM",
				Location = ACTION_FORM_PHOTO_ALBUM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Form_photo_album();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Photoalbum/Form_photo_album_New
// USE /[MANUAL FPV CONTROLLER_NEW_POST FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_New([FromBody]Form_photo_album_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_New",
				ViewName = "Form_photo_album",
				AreaName = "photoalbum",
				Location = ACTION_FORM_PHOTO_ALBUM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_NEW FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_NEW FORM_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_NEW_EX FORM_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_NEW_EX FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Form_photo_album_Edit

// USE /[MANUAL FPV CONTROLLER_EDIT_GET FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Edit_GET",
				AreaName = "photoalbum",
				FormName = "FORM_PHOTO_ALBUM",
				Location = ACTION_FORM_PHOTO_ALBUM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_photo_album();
// USE /[MANUAL FPV BEFORE_LOAD_EDIT FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Photoalbum/Form_photo_album_Edit
// USE /[MANUAL FPV CONTROLLER_EDIT_POST FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_Edit([FromBody]Form_photo_album_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Edit",
				ViewName = "Form_photo_album",
				AreaName = "photoalbum",
				Location = ACTION_FORM_PHOTO_ALBUM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_EDIT FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_EDIT FORM_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_EDIT_EX FORM_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_EDIT_EX FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Form_photo_album_Delete

// USE /[MANUAL FPV CONTROLLER_DELETE_GET FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Delete_GET",
				AreaName = "photoalbum",
				FormName = "FORM_PHOTO_ALBUM",
				Location = ACTION_FORM_PHOTO_ALBUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Form_photo_album();
// USE /[MANUAL FPV BEFORE_LOAD_DELETE FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DELETE FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Photoalbum/Form_photo_album_Delete
// USE /[MANUAL FPV CONTROLLER_DELETE_POST FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Form_photo_album_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Delete",
				ViewName = "Form_photo_album",
				AreaName = "photoalbum",
				Location = ACTION_FORM_PHOTO_ALBUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_DESTROY_DELETE FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_DESTROY_DELETE FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Form_photo_album_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FORM_PHOTO_ALBUM");
		}

		#endregion

		#region Form_photo_album_Duplicate

// USE /[MANUAL FPV CONTROLLER_DUPLICATE_GET FORM_PHOTO_ALBUM]/

		[HttpPost]
		public ActionResult Form_photo_album_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Form_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Duplicate_GET",
				AreaName = "photoalbum",
				FormName = "FORM_PHOTO_ALBUM",
				Location = ACTION_FORM_PHOTO_ALBUM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Photoalbum/Form_photo_album_Duplicate
// USE /[MANUAL FPV CONTROLLER_DUPLICATE_POST FORM_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult Form_photo_album_Duplicate([FromBody]Form_photo_album_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_Duplicate",
				ViewName = "Form_photo_album",
				AreaName = "photoalbum",
				Location = ACTION_FORM_PHOTO_ALBUM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_SAVE_DUPLICATE FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_SAVE_DUPLICATE FORM_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_LOAD_DUPLICATE_EX FORM_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_LOAD_DUPLICATE_EX FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Form_photo_album_Cancel

		//
		// GET: /Photoalbum/Form_photo_album_Cancel
// USE /[MANUAL FPV CONTROLLER_CANCEL_GET FORM_PHOTO_ALBUM]/
		public ActionResult Form_photo_album_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Photoalbum model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("photoalbum");

// USE /[MANUAL FPV BEFORE_CANCEL FORM_PHOTO_ALBUM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL FPV AFTER_CANCEL FORM_PHOTO_ALBUM]/

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

				Navigation.SetValue("ForcePrimaryRead_photoalbum", "true", true);
			}

			Navigation.ClearValue("photoalbum");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Form_photo_album_ItemValNameModel : RequestLookupModel
		{
			public Form_photo_album_ViewModel Model { get; set; }
		}

		//
		// GET: /Photoalbum/Form_photo_album_ItemValName
		// POST: /Photoalbum/Form_photo_album_ItemValName
		[ActionName("Form_photo_album_ItemValName")]
		public ActionResult Form_photo_album_ItemValName([FromBody] Form_photo_album_ItemValNameModel requestModel)
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

			IsStateReadonly = true;

			Models.Photoalbum parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Form_photo_album_ItemValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Photoalbum/Form_photo_album_SaveEdit
		[HttpPost]
		public ActionResult Form_photo_album_SaveEdit([FromBody] Form_photo_album_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Form_photo_album_SaveEdit",
				ViewName = "Form_photo_album",
				AreaName = "photoalbum",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL FPV BEFORE_APPLY_EDIT FORM_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL FPV AFTER_APPLY_EDIT FORM_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Form_photo_albumDocumValidateTickets : RequestDocumValidateTickets
		{
			public Form_photo_album_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsForm_photo_album([FromBody] Form_photo_albumDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
