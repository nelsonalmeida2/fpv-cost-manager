using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_brandForm : Form
{
	/// <summary>
	/// metadata
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_BRAND__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl BrandCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__CREATED_BY", "#FORM_BRAND__BRAND__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl BrandCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__CREATED_AT", "#FORM_BRAND__BRAND__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl BrandUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__UPDATED_BY", "#FORM_BRAND__BRAND__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl BrandUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__UPDATED_AT", "#FORM_BRAND__BRAND__UPDATED_AT");

	/// <summary>
	/// BRAND INFO
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_BRAND__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Logotype
	/// </summary>
	public BaseInputControl BrandLogotype => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__LOGOTYPE", "#FORM_BRAND__BRAND__LOGOTYPE");

	/// <summary>
	/// Brand Name
	/// </summary>
	public BaseInputControl BrandName => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__NAME", "#FORM_BRAND__BRAND__NAME");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl BrandDescription => new BaseInputControl(driver, ContainerLocator, "container-FORM_BRAND__BRAND__DESCRIPTION", "#FORM_BRAND__BRAND__DESCRIPTION");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CountryName => new LookupControl(driver, ContainerLocator, "container-FORM_BRAND__COUNTRY__NAME");
	public SeeMorePage CountryNameSeeMorePage => new SeeMorePage(driver, "FORM_BRAND", "FORM_BRAND__COUNTRY__NAME");

	public Form_brandForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_BRAND", containerLocator: containerLocator) { }
}
