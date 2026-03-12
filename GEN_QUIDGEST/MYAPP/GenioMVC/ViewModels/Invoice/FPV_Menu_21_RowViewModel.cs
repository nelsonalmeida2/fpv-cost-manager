using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Invoice;

public class FPV_Menu_21_RowViewModel : Models.Invoice
{
	#region Constructors

	public FPV_Menu_21_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public FPV_Menu_21_RowViewModel(UserContext userContext, CSGenioAinvoice val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	#endregion

	#region Private methods

	private void InitRowProperties()
	{
		SetColumns();
		SetCustomActions();
	}

	private void SetColumns()
	{
		Columns ??= [
			new ListColumn()
			{
				Order = 1,
				Area = "INVOICE",
				Field = "CODINVOICESTORE",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "INVOICE",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "STORE",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "INVOICE",
				Field = "PRICE",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "INVOICE",
				Field = "TAXES",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "INVOICE",
				Field = "SHIPPINGCOST",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "INVOICE",
				Field = "TOTALPRICE",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "INVOICE",
				Field = "NUMBEROFITEMS",
			},
		];
	}

	private void SetButtonPermissions()
	{
		if (BtnPermission != null)
			return;

		bool canView = true;
		bool canEdit = true;
		bool canDelete = true;
		bool canDuplicate = true;
		bool canInsert = true;

		using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport))
		{
		}

		BtnPermission = new TableRowCrudButtonPermissions()
		{
			ViewBtnDisabled = !canView,
			EditBtnDisabled = !canEdit,
			DeleteBtnDisabled = !canDelete,
			DuplicateBtnDisabled = !canDuplicate,
			InsertBtnDisabled = !canInsert
		};
	}

	private void SetCustomActions()
	{
		CustomActions ??= new()
		{
		};
	}

	#endregion

	/// <summary>
	/// The state of the row (it's an internal value, therefore it shouldn't be sent to the client-side)
	/// </summary>
	[JsonIgnore]
	public override int ValZzstate => base.ValZzstate;

	/// <summary>
	/// Whether the row is in a valid state
	/// </summary>
	[JsonPropertyName("isValid")]
	public bool IsValid => ValZzstate == 0;

	/// <summary>
	/// The list columns
	/// </summary>
	[JsonPropertyName("columns")]
	public List<ListColumn> Columns { get; private set; }

	/// <summary>
	/// The button permissions
	/// </summary>
	[JsonPropertyName("btnPermission")]
	public TableRowCrudButtonPermissions BtnPermission { get; private set; }

	/// <summary>
	/// The custom action buttons
	/// </summary>
	[JsonPropertyName("customActions")]
	public Dictionary<string, ListCustomAction> CustomActions { get; private set; }

	/// <summary>
	/// The foreground color
	/// </summary>
	[JsonPropertyName("foregroundColor")]
	public string ForegroundColor => "";

	/// <summary>
	/// The background color
	/// Formula: iif([INVOICE->TOTALPRICE] > 100, HEXCOLOUR("FFD5D5"), iif([INVOICE->TOTALPRICE] > 50, HEXCOLOUR("FFF3CD"), HEXCOLOUR("FFFFFF")))
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	public string BackgroundColor => ((((decimal)this.ValTotalprice)>100)?("#"+"FFD5D5"):(((((decimal)this.ValTotalprice)>50)?("#"+"FFF3CD"):("#"+"FFFFFF"))));

	/// <summary>
	/// Runs init logic that depends on row data.
	/// </summary>
	public void InitRowData()
	{
		SetButtonPermissions();
	}
}
