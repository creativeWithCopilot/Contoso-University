using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    // Service class for managing Student-related API calls.
    // Wraps HttpClient to interact with the backend StudentsController endpoints.
    // Provides methods for CRUD operations on students, which can be injected into Blazor components.
    public class StudentService
    {
        // Constructor that injects HttpClient.
        private readonly HttpClient _httpClient;
        // HttpClient is configured in Program.cs with the backend API base address.
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //  GET: api/Students
        // Retrieves all students from the backend as a list of StudentDto objects.
        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StudentDto>>("api/Students");
        }

        // GET: api/Students/{id}
        // Retrieves a single student by ID as a StudentDto. Returns null if the student does not exist.
        public async Task<StudentDto?> GetStudentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StudentDto>($"api/Students/{id}");
        }

        // POST: api/Students
        // Creates a new student using StudentCreateDto. Throws an exception if the request fails.
        public async Task AddStudentAsync(StudentCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Students", dto);
            response.EnsureSuccessStatusCode();
        }

        // PUT: api/Students/{id}
        // Updates an existing student using StudentUpdateDto. Throws an exception if the request fails.
        public async Task UpdateStudentAsync(StudentUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Students/{dto.StudentID}", dto);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/Students/{id}
        // Deletes a student by ID. Throws an exception if the request fails.
        public async Task DeleteStudentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Students/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
