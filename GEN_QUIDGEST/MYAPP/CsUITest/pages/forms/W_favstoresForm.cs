using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class W_favstoresForm : Form
{
	/// <summary>
	/// Favorite stores
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#W_FAVSTORES__PSEUD__FIELD001");

	public W_favstoresForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "W_FAVSTORES", containerLocator: containerLocator) { }
}
