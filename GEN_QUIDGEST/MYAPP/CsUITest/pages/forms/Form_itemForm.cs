using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_itemForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_ITEM__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl ItemCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__CREATED_BY", "#FORM_ITEM__ITEM__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl ItemCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__CREATED_AT", "#FORM_ITEM__ITEM__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl ItemUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__UPDATED_BY", "#FORM_ITEM__ITEM__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl ItemUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__UPDATED_AT", "#FORM_ITEM__ITEM__UPDATED_AT");

	/// <summary>
	/// ITEM INFO
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_ITEM__PSEUD__NEWGRP03-container");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl ItemName => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__NAME", "#FORM_ITEM__ITEM__NAME");

	/// <summary>
	/// Quantity
	/// </summary>
	public BaseInputControl ItemQuantity => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__QUANTITY", "#FORM_ITEM__ITEM__QUANTITY");

	/// <summary>
	/// Unit Price
	/// </summary>
	public BaseInputControl ItemUnitprice => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__UNITPRICE", "#FORM_ITEM__ITEM__UNITPRICE");

	/// <summary>
	/// Total Price
	/// </summary>
	public BaseInputControl ItemTotalprice => new BaseInputControl(driver, ContainerLocator, "container-FORM_ITEM__ITEM__TOTALPRICE", "#FORM_ITEM__ITEM__TOTALPRICE");

	/// <summary>
	/// Catalog Details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_ITEM__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Brand
	/// </summary>
	public LookupControl BrandName => new LookupControl(driver, ContainerLocator, "container-FORM_ITEM__BRAND__NAME");
	public SeeMorePage BrandNameSeeMorePage => new SeeMorePage(driver, "FORM_ITEM", "FORM_ITEM__BRAND__NAME");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategoryName => new LookupControl(driver, ContainerLocator, "container-FORM_ITEM__CATEGORY__NAME");
	public SeeMorePage CategoryNameSeeMorePage => new SeeMorePage(driver, "FORM_ITEM", "FORM_ITEM__CATEGORY__NAME");

	/// <summary>
	/// Sub-Category
	/// </summary>
	public LookupControl SubcategoryName => new LookupControl(driver, ContainerLocator, "container-FORM_ITEM__SUBCATEGORY__NAME");
	public SeeMorePage SubcategoryNameSeeMorePage => new SeeMorePage(driver, "FORM_ITEM", "FORM_ITEM__SUBCATEGORY__NAME");

	/// <summary>
	/// Invoice
	/// </summary>
	public LookupControl InvoiceCodinvoicestore => new LookupControl(driver, ContainerLocator, "container-FORM_ITEM__INVOICE__CODINVOICESTORE");
	public SeeMorePage InvoiceCodinvoicestoreSeeMorePage => new SeeMorePage(driver, "FORM_ITEM", "FORM_ITEM__INVOICE__CODINVOICESTORE");

	/// <summary>
	/// Photos
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp04 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_ITEM__PSEUD__NEWGRP04-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#FORM_ITEM__PSEUD__FIELD001");

	public Form_itemForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_ITEM", containerLocator: containerLocator) { }
}
