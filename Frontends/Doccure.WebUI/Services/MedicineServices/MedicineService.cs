using Doccure.WebUI.Dtos.MedicineDtos;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.MedicineServices
{
    public class MedicineService : IMedicineService
    {
        private readonly HttpClient _httpClient;

        public MedicineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMedicineAsync(CreateMedicineDto createMedicineDto)
        {
            var jsonData = JsonConvert.SerializeObject(createMedicineDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7165/api/Medicines", stringContent);     // localhost:7165
        }

        public async Task DeleteMedicineAsync(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:7165/api/Medicines?id={id}");
        }

        public async Task<List<ResultMedicineDto>> GetAllMedicinesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7165/api/Medicines");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMedicineDto>>(jsonData);
            return values;
        }

        public async Task<GetMedicineByIdDto> GetMedicineByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7165/api/Medicines/GetMedicine?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetMedicineByIdDto>(jsonData);
            return values;
        }

        public async Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateMedicineDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:7165/api/Medicines", stringContent);
        }


    }
}
