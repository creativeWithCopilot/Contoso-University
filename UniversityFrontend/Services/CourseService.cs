using System.Net.Http;
using System.Net.Http.Json;
using UniversityFrontend.DTOs;

namespace UniversityFrontend.Services
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>("api/Courses");
        }

        public async Task<CourseDto?> GetCourseAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CourseDto>($"api/Courses/{id}");
        }

        public async Task AddCourseAsync(CourseCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Courses", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCourseAsync(CourseUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Courses/{dto.CourseID}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Courses/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
