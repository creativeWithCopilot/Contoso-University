using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    // Service class for managing Enrollment-related API calls.
    // Wraps HttpClient to interact with the backend EnrollmentsController endpoints.
    // Provides methods for CRUD operations on enrollments, which can be injected into Blazor components.
    public class EnrollmentService
    {
        // Constructor that injects HttpClient.
        private readonly HttpClient _httpClient;
        // HttpClient is configured in Program.cs with the backend API base address.
        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: api/Enrollments
        // Retrieves all enrollments from the backend as a list of EnrollmentDto objects.
        // Includes related Student and Course information.
        public async Task<List<EnrollmentDto>> GetEnrollmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EnrollmentDto>>("api/Enrollments");
        }

        // GET: api/Enrollments/{id}
        // Retrieves a single enrollment by ID as an EnrollmentDto. Returns null if the enrollment does
        public async Task<EnrollmentDto?> GetEnrollmentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EnrollmentDto>($"api/Enrollments/{id}");
        }

        // POST: api/Enrollments
        // Creates a new enrollment using EnrollmentCreateDto. Throws an exception if the request fails.
        // Allows specifying StudentID, CourseID, and Grade for the new enrollment.
        public async Task AddEnrollmentAsync(EnrollmentCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Enrollments", dto);
            response.EnsureSuccessStatusCode();
        }

        // PUT: api/Enrollments/{id}
        // Updates an existing enrollment using EnrollmentUpdateDto. Throws an exception if the request fails.
        // Allows updating StudentID, CourseID, and Grade.
        public async Task UpdateEnrollmentAsync(EnrollmentUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Enrollments/{dto.EnrollmentID}", dto);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Enrollments/{id}
        // Deletes an enrollment by ID. Throws an exception if the request fails.
        public async Task DeleteEnrollmentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Enrollments/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
