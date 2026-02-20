using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    // Service class for managing Course-related API calls.
    // Wraps HttpClient to interact with the backend CoursesController endpoints.
    // Provides methods for CRUD operations on courses, which can be injected into Blazor components.
    public class CourseService
    {
        // Constructor that injects HttpClient.
        private readonly HttpClient _httpClient;
        // HttpClient is configured in Program.cs with the base address of the backend API.
        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: api/Courses
        // Retrieves all courses from the backend as a list of CourseDto objects.
        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>("api/Courses");
        }

        // GET: api/Courses/{id}
        // Retrieves a single course by ID as a CourseDto. Returns null if the course does not exist.
        public async Task<CourseDto?> GetCourseAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CourseDto>($"api/Courses/{id}");
        }

        // POST: api/Courses
        // Creates a new course using CourseCreateDto. Throws an exception if the request fails.
        public async Task AddCourseAsync(CourseCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Courses", dto);
            response.EnsureSuccessStatusCode();
        }

        // PUT: api/Courses/{id}
        // Updates an existing course using CourseUpdateDto. Throws an exception if the request fails.
        public async Task UpdateCourseAsync(CourseUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Courses/{dto.CourseID}", dto);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Courses/{id}
        // Deletes a course by ID. Throws an exception if the request fails.
        public async Task DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Courses/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
