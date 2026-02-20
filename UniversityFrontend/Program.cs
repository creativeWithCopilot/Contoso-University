using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniversityFrontend;
using UniversityFrontend.Services;

// Entry point for the Blazor WebAssembly frontend application.
// Configures root components and registers services for dependency injection.
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the root App component, which is rendered inside the #app element in index.html.
builder.RootComponents.Add<App>("#app");

// Register HeadOutlet, which allows dynamic content (like meta tags, title) to be injected into the <head>.
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with the base address of the backend API for making HTTP requests.
// BaseAddress should point to the backend API URL.
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7192/") // Replace with your backend API URL
});

// Register application services for dependency injection.
// These services wrap HttpClient calls to the backend API.
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<EnrollmentService>();

// Build and run the Blazor WebAssembly application.
await builder.Build().RunAsync();
