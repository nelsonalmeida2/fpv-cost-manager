using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_invoiceForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_INVOICE__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl InvoiceCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__CREATED_BY", "#FORM_INVOICE__INVOICE__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl InvoiceCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__CREATED_AT", "#FORM_INVOICE__INVOICE__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl InvoiceUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__UPDATED_BY", "#FORM_INVOICE__INVOICE__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl InvoiceUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__UPDATED_AT", "#FORM_INVOICE__INVOICE__UPDATED_AT");

	/// <summary>
	/// Purchase Details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_INVOICE__PSEUD__NEWGRP02-container");

	/// <summary>
	/// CODINVOICESTORE
	/// </summary>
	public BaseInputControl InvoiceCodinvoicestore => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__CODINVOICESTORE", "#FORM_INVOICE__INVOICE__CODINVOICESTORE");

	/// <summary>
	/// Receipt
	/// </summary>
	public DocumentControl InvoiceReceipt => new DocumentControl(driver, ContainerLocator, "FORM_INVOICE__INVOICE__RECEIPT-container");

	/// <summary>
	/// Store
	/// </summary>
	public LookupControl StoreName => new LookupControl(driver, ContainerLocator, "container-FORM_INVOICE__STORE__NAME");
	public SeeMorePage StoreNameSeeMorePage => new SeeMorePage(driver, "FORM_INVOICE", "FORM_INVOICE__STORE__NAME");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl InvoiceDate => new DateInputControl(driver, ContainerLocator, "#FORM_INVOICE__INVOICE__DATE");

	/// <summary>
	/// Cost Breakdown
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_INVOICE__PSEUD__NEWGRP03-container");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl InvoicePrice => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__PRICE", "#FORM_INVOICE__INVOICE__PRICE");

	/// <summary>
	/// Shipping Cost
	/// </summary>
	public BaseInputControl InvoiceShippingcost => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__SHIPPINGCOST", "#FORM_INVOICE__INVOICE__SHIPPINGCOST");

	/// <summary>
	/// Taxes
	/// </summary>
	public BaseInputControl InvoiceTaxes => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__TAXES", "#FORM_INVOICE__INVOICE__TAXES");

	/// <summary>
	/// Number of Items
	/// </summary>
	public BaseInputControl InvoiceNumberofitems => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__NUMBEROFITEMS", "#FORM_INVOICE__INVOICE__NUMBEROFITEMS");

	/// <summary>
	/// Total Price
	/// </summary>
	public BaseInputControl InvoiceTotalprice => new BaseInputControl(driver, ContainerLocator, "container-FORM_INVOICE__INVOICE__TOTALPRICE", "#FORM_INVOICE__INVOICE__TOTALPRICE");

	/// <summary>
	/// Items
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp04 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_INVOICE__PSEUD__NEWGRP04-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#FORM_INVOICE__PSEUD__FIELD001");

	public Form_invoiceForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_INVOICE", containerLocator: containerLocator) { }
}
