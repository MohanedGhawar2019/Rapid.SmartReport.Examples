using Microsoft.AspNetCore.Mvc;
using Rapid.SmartReport.Core;
using Rapid.SmartReport.Core.Components;
using Rapid.SmartReport.Core.Components.Tables;
using Rapid.SmartReport.Examples.Models;
using System.Linq.Expressions;

namespace Rapid.SmartReport.Examples.Controllers;

[Route("[controller]")]
public class AdvancedTableExampleController : Controller
{
    [HttpGet("basic")]
    public IActionResult GenerateBasicTableReport(
        [FromQuery] int page = 1,
        [FromQuery] string sort = "Amount",
        [FromQuery] string sortDir = "desc",
        [FromQuery] string search = "")
    {
        var salesData = SampleData.GetSampleSalesData();
        var report = Report<SalesData>.Create()
            .WithTitle("Basic Sales Report with Sorting");

        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Date, options =>
        {
            options.Header = "Date";
            options.Format = "d";
        });
        table.AddColumn(x => x.Product, options =>
        {
            options.Header = "Product";
        });
        table.AddColumn(x => x.Amount, options =>
        {
            options.Header = "Amount";
            options.Format = "C2";
        });

        table.ConfigureOptions(options =>
        {
            // Configure sorting based on the column header
            Expression<Func<SalesData, object>> sortExpression = sort switch
            {
                "Date" => x => x.Date,
                "Product" => x => x.Product,
                "Amount" => x => x.Amount,
                _ => x => x.Amount
            };

            options.Sort = new SortOptions<SalesData>
            {
                PropertyName = sort,
                IsAscending = sortDir != "desc",
                SortExpression = sortExpression
            };

            // Configure search if provided
            if (!string.IsNullOrEmpty(search))
            {
                options.Filter = new FilterOptions<SalesData>
                {
                    SearchTerm = search
                };
            }

            options.Pagination = new PaginationOptions
            {
                PageSize = 5,
                CurrentPage = page
            };
        });

        report.AddTable(table);
        report.WithData(salesData);

        return View("BasicTableReport", report);
    }

    [HttpGet("advanced")]
    public IActionResult GenerateAdvancedTableReport(
        [FromQuery] int page = 1,
        [FromQuery] string sort = "Amount",
        [FromQuery] string sortDir = "desc",
        [FromQuery] string search = "")
    {
        var salesData = SampleData.GetSampleSalesData();
        var report = Report<SalesData>.Create()
            .WithTitle("Advanced Sales Report");

        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Date, options =>
        {
            options.Header = "Date";
            options.Format = "d";
        });
        table.AddColumn(x => x.Product, options =>
        {
            options.Header = "Product";
        });
        table.AddColumn(x => x.Amount, options =>
        {
            options.Header = "Amount";
            options.Format = "C2";
        });
        table.AddColumn(x => x.Region, options =>
        {
            options.Header = "Region";
        });
        table.AddColumn(x => x.Quantity, options =>
        {
            options.Header = "Quantity";
        });

        table.ConfigureOptions(options =>
        {
            // Configure sorting based on the column header
            Expression<Func<SalesData, object>> sortExpression = sort switch
            {
                "Date" => x => x.Date,
                "Product" => x => x.Product,
                "Amount" => x => x.Amount,
                "Region" => x => x.Region,
                "Quantity" => x => x.Quantity,
                _ => x => x.Amount
            };

            options.Sort = new SortOptions<SalesData>
            {
                PropertyName = sort,
                IsAscending = sortDir != "desc",
                SortExpression = sortExpression
            };

            // Configure search if provided
            if (!string.IsNullOrEmpty(search))
            {
                options.Filter = new FilterOptions<SalesData>
                {
                    SearchTerm = search
                };
            }

            options.Pagination = new PaginationOptions
            {
                PageSize = 3,
                CurrentPage = page
            };
        });

        report.AddTable(table);
        report.WithData(salesData);

        return View("AdvancedTableReport", report);
    }

    [HttpGet("multi-sort")]
    public IActionResult GenerateMultiSortTableReport(
        [FromQuery] int page = 1,
        [FromQuery] string sort = "Region",
        [FromQuery] string sortDir = "asc",
        [FromQuery] string search = "")
    {
        var salesData = SampleData.GetSampleSalesData();
        var report = Report<SalesData>.Create()
            .WithTitle("Multi-Sorted Sales Report");

        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Region, options =>
        {
            options.Header = "Region";
        });
        table.AddColumn(x => x.Product, options =>
        {
            options.Header = "Product";
        });
        table.AddColumn(x => x.Amount, options =>
        {
            options.Header = "Amount";
            options.Format = "C2";
        });
        table.AddColumn(x => x.Quantity, options =>
        {
            options.Header = "Quantity";
        });

        table.ConfigureOptions(options =>
        {
            // Configure sorting based on the column header
            Expression<Func<SalesData, object>> sortExpression = sort switch
            {
                "Region" => x => x.Region,
                "Product" => x => x.Product,
                "Amount" => x => x.Amount,
                "Quantity" => x => x.Quantity,
                _ => x => x.Region
            };

            options.Sort = new SortOptions<SalesData>
            {
                PropertyName = sort,
                IsAscending = sortDir != "desc",
                SortExpression = sortExpression
            };

            // Configure search if provided
            if (!string.IsNullOrEmpty(search))
            {
                options.Filter = new FilterOptions<SalesData>
                {
                    SearchTerm = search
                };
            }

            options.Pagination = new PaginationOptions
            {
                PageSize = 5,
                CurrentPage = page
            };
        });

        report.AddTable(table);
        report.WithData(salesData);

        return View("MultiSortTableReport", report);
    }

    [HttpGet("filtered")]
    public IActionResult GenerateFilteredTableReport(
        [FromQuery] int page = 1,
        [FromQuery] string sort = "Amount",
        [FromQuery] string sortDir = "desc",
        [FromQuery] string search = "",
        [FromQuery] string region = "North")
    {
        var salesData = SampleData.GetSampleSalesData();
        var report = Report<SalesData>.Create()
            .WithTitle("Filtered Sales Report");

        var table = new TableComponent<SalesData>();
        table.AddColumn(x => x.Date, options =>
        {
            options.Header = "Date";
            options.Format = "d";
        });
        table.AddColumn(x => x.Product, options =>
        {
            options.Header = "Product";
        });
        table.AddColumn(x => x.Amount, options =>
        {
            options.Header = "Amount";
            options.Format = "C2";
        });
        table.AddColumn(x => x.Region, options =>
        {
            options.Header = "Region";
        });
        table.AddColumn(x => x.Quantity, options =>
        {
            options.Header = "Quantity";
        });

        table.ConfigureOptions(options =>
        {
            // Configure sorting based on the column header
            Expression<Func<SalesData, object>> sortExpression = sort switch
            {
                "Date" => x => x.Date,
                "Product" => x => x.Product,
                "Amount" => x => x.Amount,
                "Region" => x => x.Region,
                "Quantity" => x => x.Quantity,
                _ => x => x.Amount
            };

            options.Sort = new SortOptions<SalesData>
            {
                PropertyName = sort,
                IsAscending = sortDir != "desc",
                SortExpression = sortExpression
            };

            // Configure combined filtering
            options.Filter = new FilterOptions<SalesData>
            {
                FilterExpression = x => x.Region == region && x.Amount > 1000 &&
                    (string.IsNullOrEmpty(search) || 
                     x.Product.Contains(search, StringComparison.OrdinalIgnoreCase))
            };

            options.Pagination = new PaginationOptions
            {
                PageSize = 5,
                CurrentPage = page
            };
        });

        report.AddTable(table);
        report.WithData(salesData);

        return View("FilteredTableReport", report);
    }
}
