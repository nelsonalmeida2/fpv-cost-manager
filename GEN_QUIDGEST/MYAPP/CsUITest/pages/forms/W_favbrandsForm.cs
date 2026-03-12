using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class W_favbrandsForm : Form
{
	/// <summary>
	/// Favorite Brands
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#W_FAVBRANDS__PSEUD__FIELD001");

	public W_favbrandsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "W_FAVBRANDS", containerLocator: containerLocator) { }
}
