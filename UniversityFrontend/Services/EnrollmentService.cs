using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    public class EnrollmentService
    {
        private readonly HttpClient _httpClient;

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EnrollmentDto>> GetEnrollmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EnrollmentDto>>("api/Enrollments");
        }

        public async Task<EnrollmentDto?> GetEnrollmentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EnrollmentDto>($"api/Enrollments/{id}");
        }

        public async Task AddEnrollmentAsync(EnrollmentCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Enrollments", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEnrollmentAsync(EnrollmentUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Enrollments/{dto.EnrollmentID}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Enrollments/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
