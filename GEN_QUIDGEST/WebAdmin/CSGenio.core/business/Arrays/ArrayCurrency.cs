using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array CURRENCY (Currency)
	/// </summary>
	public class ArrayCurrency : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayCurrency _instance = new ArrayCurrency();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayCurrency Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Euro
		/// </summary>
		public const string E_EUR_1 = "EUR";
		/// <summary>
		/// Dollar
		/// </summary>
		public const string E_USD_2 = "USD";
		/// <summary>
		/// Ruble
		/// </summary>
		public const string E_RUB_3 = "RUB";
		/// <summary>
		/// Real
		/// </summary>
		public const string E_BRL_4 = "BRL";
		/// <summary>
		/// Kwanza
		/// </summary>
		public const string E_AOA_5 = "AOA";
		/// <summary>
		/// Yuan
		/// </summary>
		public const string E_CNY_6 = "CNY";
		/// <summary>
		/// Local Currency
		/// </summary>
		public const string E_LOC_7 = "LOC";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayCurrency"/> class from being created.
		/// </summary>
		private ArrayCurrency() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_EUR_1, new ArrayElement() { ResourceId = "EURO46226", HelpId = "", Group = "" } },
				{ E_USD_2, new ArrayElement() { ResourceId = "DOLLAR33324", HelpId = "", Group = "" } },
				{ E_RUB_3, new ArrayElement() { ResourceId = "RUBLE07990", HelpId = "", Group = "" } },
				{ E_BRL_4, new ArrayElement() { ResourceId = "REAL43894", HelpId = "", Group = "" } },
				{ E_AOA_5, new ArrayElement() { ResourceId = "KWANZA16977", HelpId = "", Group = "" } },
				{ E_CNY_6, new ArrayElement() { ResourceId = "YUAN27097", HelpId = "", Group = "" } },
				{ E_LOC_7, new ArrayElement() { ResourceId = "LOCAL_CURRENCY16850", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
