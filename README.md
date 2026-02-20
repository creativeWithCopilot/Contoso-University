Contoso University is a sample application that demonstrates how to use Entity Framework Core in an ASP.NET Core Controller-Based web API and Blazor UI.
I developed the backend for an ASP.NET Core Controller-Based Web API and called this API using Blazor.

## 🚀 Features

### Students
- View all students in a table.
- Add new students via a form.
- Edit existing student details.
- Delete students with confirmation.
- **Search options:**
  - By **StudentID**
  - By **LastName**
  - By **EnrollmentDate range** (between two dates)

### Courses
- View all courses in a table.
- Add new courses via a form.
- Edit existing course details.
- Delete courses.
- **Search options:**
  - By **CourseID**
  - By **Title**

### Enrollments
- View all enrollments in a table.
- Add new enrollments via a form.
- Edit existing enrollment details.
- Delete enrollments.
- **Search options:**
  - By **StudentID**
  - By **CourseID**

---

## 🛠️ Tech Stack

- **Blazor WebAssembly** – frontend framework
- **ASP.NET Core Web API** – backend service (expected)
- **DTOs (Data Transfer Objects)** – for clean separation of models
- **HttpClient** – for API communication
- **Bootstrap** – for styling and responsive layout

---
## ▶️ Running the Project

1. Clone the repository:
2. Restore dependencies: dotnet restore
3. Build the API and UI: dotnet build
4. Run the project: dotnet run --launch-profile https
5. Click on run the UI address
