using Microsoft.AspNetCore.Mvc;
using Rapid.SmartReport.Examples.Models;
using Rapid.SmartReport.Core;
using Rapid.SmartReport.Core.Components.Tables;
using Rapid.SmartReport.Core.Components.Charts;
using Rapid.SmartReport.Core.Configuration;

namespace Rapid.SmartReport.Examples.Controllers;

public class ReportsController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public ReportsController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SimpleTable()
    {
        var data = SampleData.GetSampleSalesData();
        return View(data);
    }

    public IActionResult ChartExample()
    {
        var data = SampleData.GetSampleSalesData();
        return View(data);
    }

    public IActionResult ComplexReport()
    {
        var data = SampleData.GetSampleSalesData();
        return View(data);
    }

    public async Task<IActionResult> ExportSimpleTableHtml()
    {
        var data = SampleData.GetSampleSalesData();
        
        var report = new Report<SalesData>();
        report.WithTitle("Sales Report");
        report.WithData(data);
        report.WithConfiguration(new ReportConfiguration
        {
            DefaultTemplatePath = Path.Combine(_environment.WebRootPath, "Templates", "Default.html"),
            DefaultStylePath = Path.Combine(_environment.WebRootPath, "Templates", "Style.css"),
            Theme = ReportTheme.Modern
        });

        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Date, options => {
            options.Header = "Date";
            options.Format = "d";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Product, options => {
            options.Header = "Product";
            options.Width = "150px";
        });
        table.AddColumn(x => x.Amount, options => {
            options.Header = "Amount";
            options.Format = "C2";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Region, options => {
            options.Header = "Region";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Quantity, options => {
            options.Header = "Quantity";
            options.Width = "80px";
        });

        report.AddTable(table);

        var htmlBytes = await report.ExportToHtmlAsync();
        return File(htmlBytes, "text/html", "SalesReport.html");
    }

    public async Task<IActionResult> ExportChartHtml()
    {
        var data = SampleData.GetSampleSalesData();
        
        var report = new Report<SalesData>();
        report.WithTitle("Sales by Product");
        report.WithData(data);
        report.WithConfiguration(new ReportConfiguration
        {
            DefaultTemplatePath = Path.Combine(_environment.WebRootPath, "Templates", "Default.html"),
            DefaultStylePath = Path.Combine(_environment.WebRootPath, "Templates", "Style.css"),
            Theme = ReportTheme.Modern
        });

        var chart = new ChartComponent<SalesData>(
            x => x.Product,
            x => (double)x.Amount,
            options => {
                options.Title = "Sales Distribution";
                options.Type = ChartType.Bar;
                options.ShowLegend = true;
                options.Colors = new[] { "#36A2EB", "#FF6384", "#FFCE56", "#4BC0C0", "#9966FF" };
            });

        report.AddChart(chart);

        var htmlBytes = await report.ExportToHtmlAsync();
        return File(htmlBytes, "text/html", "SalesChart.html");
    }

    public async Task<IActionResult> ExportComplexReportHtml()
    {
        var data = SampleData.GetSampleSalesData();
        
        var report = new Report<SalesData>();
        report.WithTitle("Comprehensive Sales Analysis");
        report.WithData(data);
        report.WithConfiguration(new ReportConfiguration
        {
            DefaultTemplatePath = Path.Combine(_environment.WebRootPath, "Templates", "Default.html"),
            DefaultStylePath = Path.Combine(_environment.WebRootPath, "Templates", "Style.css"),
            Theme = ReportTheme.Modern
        });

        // Add Table
        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Date, options => {
            options.Header = "Date";
            options.Format = "d";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Product, options => {
            options.Header = "Product";
            options.Width = "150px";
        });
        table.AddColumn(x => x.Amount, options => {
            options.Header = "Amount";
            options.Format = "C2";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Region, options => {
            options.Header = "Region";
            options.Width = "100px";
        });
        table.AddColumn(x => x.Quantity, options => {
            options.Header = "Quantity";
            options.Width = "80px";
        });
        report.AddTable(table);

        // Add Product Chart
        var productChart = new ChartComponent<SalesData>(
            x => x.Product,
            x => (double)x.Amount,
            options => {
                options.Title = "Sales by Product";
                options.Type = ChartType.Bar;
                options.ShowLegend = true;
                options.Colors = new[] { "#36A2EB", "#FF6384", "#FFCE56", "#4BC0C0", "#9966FF" };
            });
        report.AddChart(productChart);

        // Add Region Chart
        var regionChart = new ChartComponent<SalesData>(
            x => x.Region,
            x => (double)x.Amount,
            options => {
                options.Title = "Regional Distribution";
                options.Type = ChartType.Pie;
                options.ShowLegend = true;
                options.Colors = new[] { "#FF6384", "#36A2EB", "#FFCE56", "#4BC0C0", "#9966FF" };
            });
        report.AddChart(regionChart);

        var htmlBytes = await report.ExportToHtmlAsync();
        return File(htmlBytes, "text/html", "ComplexReport.html");
    }
}
