using Microsoft.AspNetCore.Mvc;
using Rapid.SmartReport.Core;
using Rapid.SmartReport.Examples.Models;

namespace Rapid.SmartReport.Examples.ViewComponents;

public class SmartReportViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Report<SalesData> reportData)
    {
        return View(reportData);
    }
}
