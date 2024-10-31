using Microsoft.AspNetCore.Mvc;

namespace ExampleApp;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController: ControllerBase
{
    private readonly IYearMonthService YearMonthService;

    public HomeController(IYearMonthService yearMonthservice)
    {
        YearMonthService = yearMonthservice;
    }

    [HttpGet]
    public string Test([ModelBinder(BinderType = typeof(YearMonthBiner))] TestFilter date)
    {
        try
        {
            return YearMonthService.EchoYearMonth(date) ?? YearMonthService.EchoDefaultYearMonth();
        }
        catch (Exception ex) 
        {
            /*Log the error*/
            return YearMonthService.EchoDefaultYearMonth();
        }
    }

}