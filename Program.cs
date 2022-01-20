var builder = WebApplication.CreateBuilder(args);

// Configurar Logger personalizado
builder.Logging.ClearProviders(); // remover loggers padrão
builder.Logging.AddProvider(new mvc_test.Loggers.MyLoggerProvider());

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

//app.MapControllerRoute(
//	  name: "default",
//	  pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
