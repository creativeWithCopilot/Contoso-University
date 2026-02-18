using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StudentDto>>("api/Students");
        }

        public async Task<StudentDto?> GetStudentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StudentDto>($"api/Students/{id}");
        }

        public async Task AddStudentAsync(StudentCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Students", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStudentAsync(StudentUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Students/{dto.StudentID}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Students/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
