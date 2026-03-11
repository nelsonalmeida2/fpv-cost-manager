
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Invoice
	/// </summary>
	public class CSGenioAinvoice : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAinvoice(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL FPV CONSTRUTOR INVOICE]/
		}

		public CSGenioAinvoice(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codinvoice", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "price", FieldType.CURRENCY);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PRICE06900";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shippingcost", FieldType.CURRENCY);
			Qfield.FieldDescription = "Shipping Cost";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SHIPPING_COST12785";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "taxes", FieldType.CURRENCY);
			Qfield.FieldDescription = "Taxes";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "TAXES34617";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "totalprice", FieldType.CURRENCY);
			Qfield.FieldDescription = "Total Price";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "TOTAL_PRICE46894";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"totalprice","shippingcost","taxes"}, new int[] {0,1,2}, "invoice", "codinvoice"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 3, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])+((decimal)args[1])+((decimal)args[2]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "numberofitems", FieldType.NUMERIC);
			Qfield.FieldDescription = "Number of Items";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "NUMBER_OF_ITEMS22472";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "store", FieldType.KEY_INT);
			Qfield.FieldDescription = "Store";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STORE16493";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATE);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getToday);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "receipt", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Receipt";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RECEIPT15218";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			Qfield = new Field(info.Alias, "receiptfk", FieldType.KEY_INT);
			Qfield.FieldSize = 8;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_at", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Updated At";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_AT46891";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_by", FieldType.TEXT);
			Qfield.FieldDescription = "Updated by";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_BY17808";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "created_by", FieldType.TEXT);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_BY12292";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "created_at", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Created at";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREA43898";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("item", new String[] {"invoice"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("store", new Relation("FPV", "fpvinvoice", "invoice", "codinvoice", "store", "FPV", "fpvstore", "store", "codstore", "codstore"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("store","store");
			info.Pathways.Add("country","store");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "totalprice"
			};

			info.DefaultValues = new string[] {
			 "date"
			};


			info.RelatedSumFields = new string[] {
			 "price","numberofitems"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAinvoice()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="FPV";
			info.TableName="fpvinvoice";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codinvoice";
			info.HumanKeyName="";
			info.Alias="invoice";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Invoice";
			info.AreaPluralDesignation="Invoices";
			info.DescriptionCav="INVOICE63068";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------
			info.StampFieldsIns = new string[] {
                "created_by","created_at"
			};

			info.StampFieldsAlt = new string[] {
                "updated_by","updated_at"
			};
            // Documents in DB
            //------------------------------
			info.DocumsForeignKeys = new List<String> {
			 "receiptfk"
			};
			info.HasVersionManagment = true; //a true por omissão, quando o Qfield no genio tiver criado preencher por esse Qvalue

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodinvoice { get { return m_fldCodinvoice; } }
		private static FieldRef m_fldCodinvoice = new FieldRef("invoice", "codinvoice");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodinvoice
		{
			get { return (string)returnValueField(FldCodinvoice); }
			set { insertNameValueField(FldCodinvoice, value); }
		}

		/// <summary>Field : "Price" Tipo: "$" Formula: SR "[ITEM->TOTALPRICE]"</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("invoice", "price");

		/// <summary>Field : "Price" Tipo: "$" Formula: SR "[ITEM->TOTALPRICE]"</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "Shipping Cost" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldShippingcost { get { return m_fldShippingcost; } }
		private static FieldRef m_fldShippingcost = new FieldRef("invoice", "shippingcost");

		/// <summary>Field : "Shipping Cost" Tipo: "$" Formula:  ""</summary>
		public decimal ValShippingcost
		{
			get { return (decimal)returnValueField(FldShippingcost); }
			set { insertNameValueField(FldShippingcost, value); }
		}

		/// <summary>Field : "Taxes" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldTaxes { get { return m_fldTaxes; } }
		private static FieldRef m_fldTaxes = new FieldRef("invoice", "taxes");

		/// <summary>Field : "Taxes" Tipo: "$" Formula:  ""</summary>
		public decimal ValTaxes
		{
			get { return (decimal)returnValueField(FldTaxes); }
			set { insertNameValueField(FldTaxes, value); }
		}

		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[INVOICE->TOTALPRICE] + [INVOICE->SHIPPINGCOST] + [INVOICE->TAXES]"</summary>
		public static FieldRef FldTotalprice { get { return m_fldTotalprice; } }
		private static FieldRef m_fldTotalprice = new FieldRef("invoice", "totalprice");

		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[INVOICE->TOTALPRICE] + [INVOICE->SHIPPINGCOST] + [INVOICE->TAXES]"</summary>
		public decimal ValTotalprice
		{
			get { return (decimal)returnValueField(FldTotalprice); }
			set { insertNameValueField(FldTotalprice, value); }
		}

		/// <summary>Field : "Number of Items" Tipo: "N" Formula: SR "[ITEM->1]"</summary>
		public static FieldRef FldNumberofitems { get { return m_fldNumberofitems; } }
		private static FieldRef m_fldNumberofitems = new FieldRef("invoice", "numberofitems");

		/// <summary>Field : "Number of Items" Tipo: "N" Formula: SR "[ITEM->1]"</summary>
		public decimal ValNumberofitems
		{
			get { return (decimal)returnValueField(FldNumberofitems); }
			set { insertNameValueField(FldNumberofitems, value); }
		}

		/// <summary>Field : "Store" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldStore { get { return m_fldStore; } }
		private static FieldRef m_fldStore = new FieldRef("invoice", "store");

		/// <summary>Field : "Store" Tipo: "CE" Formula:  ""</summary>
		public string ValStore
		{
			get { return (string)returnValueField(FldStore); }
			set { insertNameValueField(FldStore, value); }
		}

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("invoice", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Receipt" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldReceipt { get { return m_fldReceipt; } }
		private static FieldRef m_fldReceipt = new FieldRef("invoice", "receipt");

		/// <summary>Field : "Receipt" Tipo: "IB" Formula:  ""</summary>
		public string ValReceipt
		{
			get { return (string)returnValueField(FldReceipt); }
			set { insertNameValueField(FldReceipt, value); }
		}

		/// <summary>Field : "Receipt FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldReceiptfk { get { return m_fldReceiptfk; } }
		private static FieldRef m_fldReceiptfk = new FieldRef("invoice", "receiptfk");

		/// <summary>Field : "Receipt FK" Tipo: "CE" Formula:  ""</summary>
		public string ValReceiptfk
		{
			get { return (string)returnValueField(FldReceiptfk); }
			set { insertNameValueField(FldReceiptfk, value); }
		}

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldUpdated_at { get { return m_fldUpdated_at; } }
		private static FieldRef m_fldUpdated_at = new FieldRef("invoice", "updated_at");

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValUpdated_at
		{
			get { return (DateTime)returnValueField(FldUpdated_at); }
			set { insertNameValueField(FldUpdated_at, value); }
		}

		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldUpdated_by { get { return m_fldUpdated_by; } }
		private static FieldRef m_fldUpdated_by = new FieldRef("invoice", "updated_by");

		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		public string ValUpdated_by
		{
			get { return (string)returnValueField(FldUpdated_by); }
			set { insertNameValueField(FldUpdated_by, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreated_by { get { return m_fldCreated_by; } }
		private static FieldRef m_fldCreated_by = new FieldRef("invoice", "created_by");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreated_by
		{
			get { return (string)returnValueField(FldCreated_by); }
			set { insertNameValueField(FldCreated_by, value); }
		}

		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreated_at { get { return m_fldCreated_at; } }
		private static FieldRef m_fldCreated_at = new FieldRef("invoice", "created_at");

		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreated_at
		{
			get { return (DateTime)returnValueField(FldCreated_at); }
			set { insertNameValueField(FldCreated_at, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("invoice", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAinvoice search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAinvoice area = new CSGenioAinvoice(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAinvoice> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAinvoice>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAinvoice> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAinvoice>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL FPV TABAUX INVOICE]/

 
              

	}
}
