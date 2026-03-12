using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_storeForm : Form
{
	/// <summary>
	/// Store Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_STORE__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Logotype
	/// </summary>
	public BaseInputControl StoreLogotype => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__LOGOTYPE", "#FORM_STORE__STORE__LOGOTYPE");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl StoreName => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__NAME", "#FORM_STORE__STORE__NAME");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl StoreDescription => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__DESCRIPTION", "#FORM_STORE__STORE__DESCRIPTION");

	/// <summary>
	/// Website
	/// </summary>
	public BaseInputControl StoreSite => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__SITE", "#FORM_STORE__STORE__SITE");

	/// <summary>
	/// Currency
	/// </summary>
	public EnumControl StoreCurrency => new EnumControl(driver, ContainerLocator, "container-FORM_STORE__STORE__CURRENCY");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CountryName => new LookupControl(driver, ContainerLocator, "container-FORM_STORE__COUNTRY__NAME");
	public SeeMorePage CountryNameSeeMorePage => new SeeMorePage(driver, "FORM_STORE", "FORM_STORE__COUNTRY__NAME");

	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_STORE__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl StoreCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__CREATED_BY", "#FORM_STORE__STORE__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl StoreCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__CREATED_AT", "#FORM_STORE__STORE__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl StoreUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__UPDATED_BY", "#FORM_STORE__STORE__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl StoreUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_STORE__STORE__UPDATED_AT", "#FORM_STORE__STORE__UPDATED_AT");

	/// <summary>
	/// Assigned to
	/// </summary>
	public IWebElement PersonName => throw new NotImplementedException();

	public Form_storeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_STORE", containerLocator: containerLocator) { }
}
