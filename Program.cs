using Rapid.SmartReport.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Configure Rapid.SmartReport
builder.Services.Configure<ReportConfiguration>(options =>
{
    options.DefaultTemplatePath = "Templates/Default.html";
    options.DefaultStylePath = "Templates/Style.css";
    options.Theme = ReportTheme.Modern;
    options.PageSize = PaperSize.A4;
    options.Orientation = Orientation.Portrait;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
