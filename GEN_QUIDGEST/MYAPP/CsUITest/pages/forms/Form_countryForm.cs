using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_countryForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_COUNTRY__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl CountryCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_COUNTRY__COUNTRY__CREATED_BY", "#FORM_COUNTRY__COUNTRY__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl CountryCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_COUNTRY__COUNTRY__CREATED_AT", "#FORM_COUNTRY__COUNTRY__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl CountryUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_COUNTRY__COUNTRY__UPDATED_BY", "#FORM_COUNTRY__COUNTRY__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl CountryUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_COUNTRY__COUNTRY__UPDATED_AT", "#FORM_COUNTRY__COUNTRY__UPDATED_AT");

	/// <summary>
	/// Country Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_COUNTRY__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl CountryName => new BaseInputControl(driver, ContainerLocator, "container-FORM_COUNTRY__COUNTRY__NAME", "#FORM_COUNTRY__COUNTRY__NAME");

	public Form_countryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_COUNTRY", containerLocator: containerLocator) { }
}
