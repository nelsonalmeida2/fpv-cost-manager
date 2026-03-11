using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Form_personpswForm : Form
{
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
