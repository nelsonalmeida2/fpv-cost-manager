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
					Id = "FAVSTORES",
					Order = 6,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.FAVORITE_STORES13289,
					Group = "_GRAPHS",
					Form = "W_FAVSTORES",
					Component = "QFormWFavstores",
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "FAVBRANDS",
					Order = 5,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.FAVORITE_BRANDS21837,
					Group = "_GRAPHS",
					Form = "W_FAVBRANDS",
					Component = "QFormWFavbrands",
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "EXPENSESOVERT",
					Order = 8,
					Width = 6,
					Height = 6,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.EXPENSES_OVER_TIME29607,
					Group = "_GRAPHS",
					Form = "W_EXPENSESOVERTIME",
					Component = "QFormWExpensesovertime",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "LASTINVOICE",
					Order = 1,
					Width = 6,
					Height = 6,
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
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "TOTALSPENDING",
					Order = 9,
					Width = 2,
					Height = 2,
					BorderStyle = "",
					Required = false,
					Visible = true,
					Role = CSGenio.framework.Role.ROLE_5,
					Module = "FPV",
					Title = Resources.Resources.TOTAL_SPENDING49047,
					Group = "_GRAPHS",
					Form = "TOTALSPENDING",
					Component = "QFormTotalspending",
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
				new MenuWidget
				{
					Id = "Menu_B",
					Order = 3,
					Width = 2,
					Height = 2,
					Style = "",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_STORE64351,
					Group = "_GRAPHS",
					Module = "FPV",
					Path = "FPV" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("FPV", "B")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("FPV", "B")
				},
				new MenuWidget
				{
					Id = "Menu_C",
					Order = 4,
					Width = 2,
					Height = 2,
					Style = "",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_BRAND53740,
					Group = "_GRAPHS",
					Module = "FPV",
					Path = "FPV" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("FPV", "C")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("FPV", "C")
				},
				new MenuWidget
				{
					Id = "Menu_6",
					Order = 2,
					Width = 2,
					Height = 2,
					Style = "",
					BorderStyle = "",
					RenderSubmenus = false,
					Required = false,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_INVOICE29126,
					Group = "_GRAPHS",
					Module = "FPV",
					Path = "FPV" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("FPV", "6")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("FPV", "6")
				},
			];
		}


	}
}
