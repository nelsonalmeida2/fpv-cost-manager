using System.Collections.Generic;
using System.Text.Json.Serialization;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// FPV_Menu_41 Dashboard Viewmodel
	/// </summary>
	public class FPV_Menu_41_ViewModel : DashboardViewModel
	{
		[JsonPropertyName("uuid")]
		public override string Uuid => "06f2259d-8efb-4823-8c4a-e3927400fff1";

		public FPV_Menu_41_ViewModel(UserContext userContext): base(userContext)
		{
			RoleToShow = CSGenio.framework.Role.ROLE_5;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
			};

			WidgetProviders =
			[
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "LASTINVOICE",
					Order = 2,
					Width = 2,
					Height = 2,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.LAST_INVOICES43184,
					Group = "_GRAPHS",
					Form = "W_LASTINVOICE",
					Component = "QFormWLastinvoice",
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.CSGenioAinvoice>
{
					Id = "FAVSTORES",
					Order = 1,
					Width = 10,
					Height = 10,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.FAVORITE_STORES13289,
					Group = "_GRAPHS",
					Form = "W_FAVSTORES",
					Component = "QFormWFavstores",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAinvoice>,
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
			];
		}


	}
}
