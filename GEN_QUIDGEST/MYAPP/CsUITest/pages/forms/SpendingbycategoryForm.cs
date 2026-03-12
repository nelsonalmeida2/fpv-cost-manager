using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SpendingbycategoryForm : Form
{
	/// <summary>
	/// Spending By Category
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#SPENDINGBYCATEGORY__PSEUD__FIELD001");

	public SpendingbycategoryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "SPENDINGBYCATEGORY", containerLocator: containerLocator) { }
}
