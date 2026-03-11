using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_photo_albumForm : PopupForm
{
	/// <summary>
	/// METADATA
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PHOTO_ALBUM__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl PhotoalbumCreated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__CREATED_BY", "#FORM_PHOTO_ALBUM__PHOTOALBUM__CREATED_BY");

	/// <summary>
	/// Created at
	/// </summary>
	public BaseInputControl PhotoalbumCreated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__CREATED_AT", "#FORM_PHOTO_ALBUM__PHOTOALBUM__CREATED_AT");

	/// <summary>
	/// Updated by
	/// </summary>
	public BaseInputControl PhotoalbumUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__UPDATED_BY", "#FORM_PHOTO_ALBUM__PHOTOALBUM__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl PhotoalbumUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__UPDATED_AT", "#FORM_PHOTO_ALBUM__PHOTOALBUM__UPDATED_AT");

	/// <summary>
	/// PHOTO DETAILS
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#FORM_PHOTO_ALBUM__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PhotoalbumPhoto => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__PHOTO", "#FORM_PHOTO_ALBUM__PHOTOALBUM__PHOTO");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PhotoalbumTitle => new BaseInputControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__PHOTOALBUM__TITLE", "#FORM_PHOTO_ALBUM__PHOTOALBUM__TITLE");

	/// <summary>
	/// Item
	/// </summary>
	public LookupControl ItemName => new LookupControl(driver, ContainerLocator, "container-FORM_PHOTO_ALBUM__ITEM__NAME");
	public SeeMorePage ItemNameSeeMorePage => new SeeMorePage(driver, "FORM_PHOTO_ALBUM", "FORM_PHOTO_ALBUM__ITEM__NAME");

	public Form_photo_albumForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_PHOTO_ALBUM") { }
}
