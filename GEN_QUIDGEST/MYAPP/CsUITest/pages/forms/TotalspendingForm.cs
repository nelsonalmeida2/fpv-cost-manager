using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TotalspendingForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#TOTALSPENDING__PSEUD__FIELD001");

	public TotalspendingForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TOTALSPENDING", containerLocator: containerLocator) { }
}
