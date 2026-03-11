using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_personForm : Form
{
	/// <summary>
	/// MetaData
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PERSON__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PersonCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__CREATED_BY", "#FORM_PERSON__PERSON__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl PersonCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__CREATED_AT", "#FORM_PERSON__PERSON__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl PersonUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__UPDATED_BY", "#FORM_PERSON__PERSON__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl PersonUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__UPDATED_AT", "#FORM_PERSON__PERSON__UPDATED_AT");

	/// <summary>
	/// Person Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PERSON__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PersonPhoto => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__PHOTO", "#FORM_PERSON__PERSON__PHOTO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PersonName => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__NAME", "#FORM_PERSON__PERSON__NAME");

	/// <summary>
	/// Birthday
	/// </summary>
	public DateInputControl PersonBirthday => new DateInputControl(driver, ContainerLocator, "#FORM_PERSON__PERSON__BIRTHDAY");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PersonGender => new EnumControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__GENDER");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl PersonEmail => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__EMAIL", "#FORM_PERSON__PERSON__EMAIL");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PersonTelephone => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__TELEPHONE", "#FORM_PERSON__PERSON__TELEPHONE");

	public Form_personForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_PERSON", containerLocator: containerLocator) { }
}
