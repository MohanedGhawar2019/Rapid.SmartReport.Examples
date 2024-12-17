# Rapid.SmartReport.Examples

This project demonstrates the usage of Rapid.SmartReport library for creating dynamic, interactive reports in ASP.NET Core applications.

## Getting Started

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or any compatible IDE
- Basic knowledge of ASP.NET Core MVC

### Installation

1. Clone the repository:
```bash
git clone [repository-url]
```

2. Navigate to the project directory:
```bash
cd Rapid.SmartReport.Examples
```

3. Restore NuGet packages:
```bash
dotnet restore
```

4. Run the application:
```bash
dotnet run
```

## Features Overview

### 1. Basic Table Report
- Simple table generation with static data
- Basic column configuration
- Example: `/AdvancedTableExample/BasicReport`

### 2. Filtered Report
- Pre-filtered data display
- Custom filter conditions
- Example: `/AdvancedTableExample/FilteredReport`

### 3. Smart Report with Advanced Features
- Dynamic sorting by columns
- Real-time search/filtering
- Pagination
- Example: `/AdvancedTableExample/SmartReport`

## Implementation Guide

### 1. Creating a Basic Report

```csharp
public IActionResult BasicReport()
{
    var report = new SmartReport<YourDataModel>()
        .AddData(yourDataList)
        .AddColumn(m => m.Property1, "Column Title 1")
        .AddColumn(m => m.Property2, "Column Title 2");

    return View(report);
}
```

### 2. Adding Filtering

```csharp
public IActionResult FilteredReport()
{
    var report = new SmartReport<YourDataModel>()
        .AddData(yourDataList)
        .AddFilter(m => m.Property1 == "value");

    return View(report);
}
```

### 3. Implementing Smart Features

#### Controller Setup
```csharp
public IActionResult SmartReport(string sort = "", string sortDir = "asc", string search = "", int page = 1)
{
    var report = new SmartReport<YourDataModel>()
        .AddData(yourDataList)
        .ConfigurePaging(page, pageSize: 10)
        .ConfigureSort(sort, sortDir)
        .ConfigureSearch(search);

    return View(report);
}
```

#### View Implementation
```cshtml
@model SmartReport<YourDataModel>

<div class="smart-report">
    <!-- Search Box -->
    <div class="search-box">
        <input type="text" id="searchInput" value="@Model.SearchTerm" />
        <button onclick="clearSearch()">Clear</button>
    </div>

    <!-- Table with Sortable Headers -->
    <table>
        <thead>
            <tr>
                @foreach (var column in Model.Columns)
                {
                    <th>
                        <a href="@column.GetSortUrl()">
                            @column.Title
                            @if (Model.IsSortedBy(column))
                            {
                                <span>@(Model.SortDirection == "asc" ? "↑" : "↓")</span>
                            }
                        </a>
                    </th>
                }
            </tr>
        </thead>
        <tbody>
            @foreach (var row in Model.GetRows())
            {
                <tr>
                    @foreach (var cell in row.Cells)
                    {
                        <td>@cell.Value</td>
                    }
                </tr>
            }
        </tbody>
    </table>

    <!-- Pagination -->
    @await Component.InvokeAsync("Pagination", new { 
        currentPage = Model.CurrentPage, 
        totalPages = Model.TotalPages 
    })
</div>
```

## Advanced Customization

### Custom Column Formatting
```csharp
.AddColumn(m => m.Date, "Date", format: "{0:dd/MM/yyyy}")
```

### Custom Styling
```csharp
.AddColumn(m => m.Status, "Status")
.AddColumnClass(m => m.Status == "Active" ? "status-active" : "status-inactive")
```

### Custom Filtering Logic
```csharp
.AddFilter(m => m.Category.Contains(searchTerm) || m.Description.Contains(searchTerm))
```

## Best Practices

1. **Performance Optimization**
   - Use appropriate page sizes
   - Implement server-side sorting and filtering for large datasets
   - Consider caching for static data

2. **User Experience**
   - Maintain state across page refreshes
   - Provide clear visual feedback for sorting and filtering
   - Implement responsive design for mobile compatibility

3. **Error Handling**
   - Validate user inputs
   - Provide meaningful error messages
   - Handle edge cases gracefully

## Troubleshooting

### Common Issues and Solutions

1. **Sorting Not Working**
   - Verify column property names match exactly
   - Check sort parameter in URL
   - Ensure sort direction is either "asc" or "desc"

2. **Search Not Functioning**
   - Confirm search term is being passed correctly
   - Check case sensitivity settings
   - Verify search logic in controller

3. **Pagination Issues**
   - Validate page number is within range
   - Check page size configuration
   - Ensure total count calculation is correct

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
