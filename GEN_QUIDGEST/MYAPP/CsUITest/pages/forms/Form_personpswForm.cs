using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_personpswForm : Form
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PERSONPSW__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PersonpswCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PERSONPSW__CREATED_BY", "#FORM_PERSONPSW__PERSONPSW__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl PersonpswCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PERSONPSW__CREATED_AT", "#FORM_PERSONPSW__PERSONPSW__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl PersonpswUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PERSONPSW__UPDATED_BY", "#FORM_PERSONPSW__PERSONPSW__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl PersonpswUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PERSONPSW__UPDATED_AT", "#FORM_PERSONPSW__PERSONPSW__UPDATED_AT");

	/// <summary>
	/// Relation
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PERSONPSW__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Name PSW
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PSW__NOME");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "FORM_PERSONPSW", "FORM_PERSONPSW__PSW__NOME");

	/// <summary>
	/// Name Person
	/// </summary>
	public LookupControl PersonName => new LookupControl(driver, ContainerLocator, "container-FORM_PERSONPSW__PERSON__NAME");
	public SeeMorePage PersonNameSeeMorePage => new SeeMorePage(driver, "FORM_PERSONPSW", "FORM_PERSONPSW__PERSON__NAME");

	public Form_personpswForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_PERSONPSW", containerLocator: containerLocator) { }
}
