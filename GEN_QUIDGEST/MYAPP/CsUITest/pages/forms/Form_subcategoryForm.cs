using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_subcategoryForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_SUBCATEGORY__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl SubcategoryCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__CREATED_BY", "#FORM_SUBCATEGORY__SUBCATEGORY__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl SubcategoryCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__CREATED_AT", "#FORM_SUBCATEGORY__SUBCATEGORY__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl SubcategoryUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__UPDATED_BY", "#FORM_SUBCATEGORY__SUBCATEGORY__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl SubcategoryUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__UPDATED_AT", "#FORM_SUBCATEGORY__SUBCATEGORY__UPDATED_AT");

	/// <summary>
	/// SUB-CATEGORY INFO
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_SUBCATEGORY__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl SubcategoryName => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__NAME", "#FORM_SUBCATEGORY__SUBCATEGORY__NAME");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl SubcategoryDescription => new BaseInputControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__SUBCATEGORY__DESCRIPTION", "#FORM_SUBCATEGORY__SUBCATEGORY__DESCRIPTION");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategoryName => new LookupControl(driver, ContainerLocator, "container-FORM_SUBCATEGORY__CATEGORY__NAME");
	public SeeMorePage CategoryNameSeeMorePage => new SeeMorePage(driver, "FORM_SUBCATEGORY", "FORM_SUBCATEGORY__CATEGORY__NAME");

	public Form_subcategoryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_SUBCATEGORY", containerLocator: containerLocator) { }
}
