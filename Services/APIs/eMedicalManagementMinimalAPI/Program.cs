// Get WebApplication instance
using eMedicalManagementMinimalAPI.APIs;
using eMedicalManagementMinimalAPI.APIs.Medicals;
using eMedicalManagementMinimalAPI.Bootstrapper;

var app = AppBuilder.GetApp(args);
app.Logger.LogInformation("application instance created");

// Configure Request Pipeline
RequestPipelineBuilder.Configure(app);
app.Logger.LogInformation("request pipeline has been configured");

// Configure APIs 
//StudentsApi.RegisterApis(app);
//WeatherApi.RegisterApis(app);
//ProductsApi.RegisterApis(app);

ProvincesApi.RegisterApis(app);
UsersApi.RegisterApis(app);
InstitutionsApi.RegisterApis(app);
RolesApi.RegisterApis(app);
app.Logger.LogInformation("Apis have been registered");

// Start the app
app.Run();