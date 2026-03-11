using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_personForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PersonName => new BaseInputControl(driver, ContainerLocator, "container-FORM_PERSON__PERSON__NAME", "#FORM_PERSON__PERSON__NAME");

	public Form_personForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FORM_PERSON", containerLocator: containerLocator) { }
}
