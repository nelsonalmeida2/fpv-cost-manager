
 
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
	/// Item
	/// </summary>
	public class CSGenioAitem : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAitem(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL FPV CONSTRUTOR ITEM]/
		}

		public CSGenioAitem(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "coditem", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  255;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NAME31974";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantity", FieldType.NUMERIC);
			Qfield.FieldDescription = "Quantity";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "QUANTITY06415";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "unitprice", FieldType.CURRENCY);
			Qfield.FieldDescription = "Unit Price";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "UNIT_PRICE24898";

            Qfield.NotNull = true;
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

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"unitprice","quantity"}, new int[] {0,1}, "item", "coditem"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])!=0&&((decimal)args[1])!=0;
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"quantity","unitprice"}, new int[] {0,1}, "item", "coditem"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])*((decimal)args[1]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "brand", FieldType.KEY_INT);
			Qfield.FieldDescription = "Brand";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BRAND05002";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "category", FieldType.KEY_INT);
			Qfield.FieldDescription = "Category";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CATEGORY18978";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "subcategory", FieldType.KEY_INT);
			Qfield.FieldDescription = "Sub-Category";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SUB_CATEGORY39956";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"category"}, new int[] {0}, "item", "coditem"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return !(((string)args[0]) == "");
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "invoice", FieldType.KEY_INT);
			Qfield.FieldDescription = "Invoice";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "INVOICE63068";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_at", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Updated At";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_AT46891";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_by", FieldType.TEXT);
			Qfield.FieldDescription = "Updated by";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_BY17808";

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
			Qfield = new Field(info.Alias, "codperson", FieldType.KEY_INT);
			Qfield.FieldDescription = "CODPERSON";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CODPERSON27649";

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
			info.ChildTable[0]= new ChildRelation("photoalbum", new String[] {"item"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("brand", new Relation("FPV", "fpvitem", "item", "coditem", "brand", "FPV", "fpvbrand", "brand", "codbrand", "codbrand"));
			info.ParentTables.Add("category", new Relation("FPV", "fpvitem", "item", "coditem", "category", "FPV", "fpvcategory", "category", "codcategory", "codcategory"));
			info.ParentTables.Add("invoice", new Relation("FPV", "fpvitem", "item", "coditem", "invoice", "FPV", "fpvinvoice", "invoice", "codinvoice", "codinvoice"));
			info.ParentTables.Add("person", new Relation("FPV", "fpvitem", "item", "coditem", "codperson", "FPV", "fpvperson", "person", "codperson", "codperson"));
			info.ParentTables.Add("subcategory", new Relation("FPV", "fpvitem", "item", "coditem", "subcategory", "FPV", "fpvsubcategory", "subcategory", "codsubcategory", "codsubcategory"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(7);
			info.Pathways.Add("category","category");
			info.Pathways.Add("person","person");
			info.Pathways.Add("subcategory","subcategory");
			info.Pathways.Add("brand","brand");
			info.Pathways.Add("invoice","invoice");
			info.Pathways.Add("country","brand");
			info.Pathways.Add("store","invoice");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("item", "brand", "totalspending", "totalprice", '+', true));
			info.RelatedSumArgs.Add( new RelatedSumArgument("item", "invoice", "numberofitems", "1", '+', false));
			info.RelatedSumArgs.Add( new RelatedSumArgument("item", "invoice", "price", "totalprice", '+', true));



			info.InternalOperationFields = new string[] {
			 "totalprice"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAitem()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="FPV";
			info.TableName="fpvitem";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coditem";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="item";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Item";
			info.AreaPluralDesignation="Items";
			info.DescriptionCav="ITEM40802";

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

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();
			EPHField[] camposEPH;
						camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("PERSONEPH", "person", "codperson", "=", false);
			info.Ephs.Add(new Par("FPV", "5"), camposEPH);

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
		public static FieldRef FldCoditem { get { return m_fldCoditem; } }
		private static FieldRef m_fldCoditem = new FieldRef("item", "coditem");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoditem
		{
			get { return (string)returnValueField(FldCoditem); }
			set { insertNameValueField(FldCoditem, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("item", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantity { get { return m_fldQuantity; } }
		private static FieldRef m_fldQuantity = new FieldRef("item", "quantity");

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantity
		{
			get { return (decimal)returnValueField(FldQuantity); }
			set { insertNameValueField(FldQuantity, value); }
		}

		/// <summary>Field : "Unit Price" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldUnitprice { get { return m_fldUnitprice; } }
		private static FieldRef m_fldUnitprice = new FieldRef("item", "unitprice");

		/// <summary>Field : "Unit Price" Tipo: "$" Formula:  ""</summary>
		public decimal ValUnitprice
		{
			get { return (decimal)returnValueField(FldUnitprice); }
			set { insertNameValueField(FldUnitprice, value); }
		}

		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[ITEM->QUANTITY] * [ITEM->UNITPRICE]"</summary>
		public static FieldRef FldTotalprice { get { return m_fldTotalprice; } }
		private static FieldRef m_fldTotalprice = new FieldRef("item", "totalprice");

		/// <summary>Field : "Total Price" Tipo: "$" Formula: + "[ITEM->QUANTITY] * [ITEM->UNITPRICE]"</summary>
		public decimal ValTotalprice
		{
			get { return (decimal)returnValueField(FldTotalprice); }
			set { insertNameValueField(FldTotalprice, value); }
		}

		/// <summary>Field : "Brand" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldBrand { get { return m_fldBrand; } }
		private static FieldRef m_fldBrand = new FieldRef("item", "brand");

		/// <summary>Field : "Brand" Tipo: "CE" Formula:  ""</summary>
		public string ValBrand
		{
			get { return (string)returnValueField(FldBrand); }
			set { insertNameValueField(FldBrand, value); }
		}

		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCategory { get { return m_fldCategory; } }
		private static FieldRef m_fldCategory = new FieldRef("item", "category");

		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		public string ValCategory
		{
			get { return (string)returnValueField(FldCategory); }
			set { insertNameValueField(FldCategory, value); }
		}

		/// <summary>Field : "Sub-Category" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldSubcategory { get { return m_fldSubcategory; } }
		private static FieldRef m_fldSubcategory = new FieldRef("item", "subcategory");

		/// <summary>Field : "Sub-Category" Tipo: "CE" Formula:  ""</summary>
		public string ValSubcategory
		{
			get { return (string)returnValueField(FldSubcategory); }
			set { insertNameValueField(FldSubcategory, value); }
		}

		/// <summary>Field : "Invoice" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldInvoice { get { return m_fldInvoice; } }
		private static FieldRef m_fldInvoice = new FieldRef("item", "invoice");

		/// <summary>Field : "Invoice" Tipo: "CE" Formula:  ""</summary>
		public string ValInvoice
		{
			get { return (string)returnValueField(FldInvoice); }
			set { insertNameValueField(FldInvoice, value); }
		}

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldUpdated_at { get { return m_fldUpdated_at; } }
		private static FieldRef m_fldUpdated_at = new FieldRef("item", "updated_at");

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValUpdated_at
		{
			get { return (DateTime)returnValueField(FldUpdated_at); }
			set { insertNameValueField(FldUpdated_at, value); }
		}

		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldUpdated_by { get { return m_fldUpdated_by; } }
		private static FieldRef m_fldUpdated_by = new FieldRef("item", "updated_by");

		/// <summary>Field : "Updated by" Tipo: "EN" Formula:  ""</summary>
		public string ValUpdated_by
		{
			get { return (string)returnValueField(FldUpdated_by); }
			set { insertNameValueField(FldUpdated_by, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreated_by { get { return m_fldCreated_by; } }
		private static FieldRef m_fldCreated_by = new FieldRef("item", "created_by");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreated_by
		{
			get { return (string)returnValueField(FldCreated_by); }
			set { insertNameValueField(FldCreated_by, value); }
		}

		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreated_at { get { return m_fldCreated_at; } }
		private static FieldRef m_fldCreated_at = new FieldRef("item", "created_at");

		/// <summary>Field : "Created at" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreated_at
		{
			get { return (DateTime)returnValueField(FldCreated_at); }
			set { insertNameValueField(FldCreated_at, value); }
		}

		/// <summary>Field : "CODPERSON" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodperson { get { return m_fldCodperson; } }
		private static FieldRef m_fldCodperson = new FieldRef("item", "codperson");

		/// <summary>Field : "CODPERSON" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperson
		{
			get { return (string)returnValueField(FldCodperson); }
			set { insertNameValueField(FldCodperson, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("item", "zzstate");



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
        public static CSGenioAitem search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAitem area = new CSGenioAitem(user, user.CurrentModule);

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
        public static List<CSGenioAitem> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAitem>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAitem> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAitem>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL FPV TABAUX ITEM]/

 
               

	}
}
