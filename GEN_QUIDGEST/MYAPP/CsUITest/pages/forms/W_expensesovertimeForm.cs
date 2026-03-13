using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class W_expensesovertimeForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#W_EXPENSESOVERTIME__PSEUD__FIELD001");

	public W_expensesovertimeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "W_EXPENSESOVERTIME", containerLocator: containerLocator) { }
}
