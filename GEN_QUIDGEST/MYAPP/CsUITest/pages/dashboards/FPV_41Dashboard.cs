[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FPV_41Dashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetMenuControl NEWSTORE => new WidgetMenuControl(driver, By.Id("w-Menu_B"), ".q-widget");
    public WidgetMenuControl NEWBRAND => new WidgetMenuControl(driver, By.Id("w-Menu_C"), ".q-widget");
    public IWebElement LASTINVOICE => throw new NotImplementedException();
    public WidgetMenuControl NEWINVOICE => new WidgetMenuControl(driver, By.Id("w-Menu_6"), ".q-widget");
    public IWebElement FAVSTORES => throw new NotImplementedException();
}
