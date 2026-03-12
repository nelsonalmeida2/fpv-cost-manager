using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class W_lastinvoiceForm : Form
{
	/// <summary>
	/// Last Invoices
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#W_LASTINVOICE__PSEUD__FIELD001");

	public W_lastinvoiceForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "W_LASTINVOICE", containerLocator: containerLocator) { }
}
