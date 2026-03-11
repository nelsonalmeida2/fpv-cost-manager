using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_categoryForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_CATEGORY__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl CategoryCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__CREATED_BY", "#FORM_CATEGORY__CATEGORY__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl CategoryCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__CREATED_AT", "#FORM_CATEGORY__CATEGORY__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl CategoryUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__UPDATED_BY", "#FORM_CATEGORY__CATEGORY__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl CategoryUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__UPDATED_AT", "#FORM_CATEGORY__CATEGORY__UPDATED_AT");

	/// <summary>
	/// Category INFO
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_CATEGORY__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl CategoryName => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__NAME", "#FORM_CATEGORY__CATEGORY__NAME");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CategoryDescription => new BaseInputControl(driver, ContainerLocator, "container-FORM_CATEGORY__CATEGORY__DESCRIPTION", "#FORM_CATEGORY__CATEGORY__DESCRIPTION");

	public Form_categoryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_CATEGORY", containerLocator: containerLocator) { }
}
