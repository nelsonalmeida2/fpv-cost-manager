using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array DELIVERYTYPE (Delivery Type)
	/// </summary>
	public class ArrayDeliverytype : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayDeliverytype _instance = new ArrayDeliverytype();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayDeliverytype Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Pickup
		/// </summary>
		public const string E_P_1 = "P";
		/// <summary>
		/// Delivery
		/// </summary>
		public const string E_D_2 = "D";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayDeliverytype"/> class from being created.
		/// </summary>
		private ArrayDeliverytype() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_P_1, new ArrayElement() { ResourceId = "PICKUP49098", HelpId = "", Group = "" } },
				{ E_D_2, new ArrayElement() { ResourceId = "DELIVERY50566", HelpId = "", Group = "" } },
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
