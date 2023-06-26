using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTests.WebPages.WebApplications.Root.Pages
{
    public static class TouchVPNExtension
    {

        public static void SelectLocation(VPNLocation location)
        {
            //Browser.Navigate("chrome-extension://jjpionfnfhfmmnbojmaadghajpodhimo/panel/index.html");
            //WaitHelper.SpinWait(() => new WebElement().ByXPath("//*[@class='location']/span").IsVisible(), TimeSpan.FromSeconds(35), TimeSpan.FromSeconds(2));
            //new WebElement().ByXPath("//*[@class='location']/span").ClickAt();
            //WaitHelper.SpinWait(() => new WebElement().ByXPath("//*[@class='list']").Last().IsPresent(), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));
            //new WebElement().ByXPath($"//*[@class='list']//*[@class='row' and text()='{location.ToString().Replace("_", " ")}']").ClickAt();
            //WaitHelper.SpinWait(() => new WebElement().ByXPath("//*[@class='list']").Last().IsNotVisible(), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));
            //new WebElement().ByXPath("//*[@id='ConnectionButton']").ClickAt();
            //WaitHelper.SpinWait(() => new WebElement().ByXPath("//*[@class='browsingFromText']").IsPresent(), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));
        }
    }

    public enum VPNLocation
    {
        [Description("Best Choice")]
        Best_Choice,
        [Description("United States")]
        United_States,
        [Description("Canada")]
        Canada,
        [Description("Russian Federation")]
        Russian_Federation,
        [Description("Germany")]
        Germany,
        [Description("Netherlands")]
        Netherlands,
        [Description("United Kingdom")]
        United_Kingdom
    }

}
