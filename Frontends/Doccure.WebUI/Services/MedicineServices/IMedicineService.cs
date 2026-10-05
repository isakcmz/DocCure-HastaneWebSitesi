using Doccure.WebUI.Dtos.MedicineDtos;

namespace Doccure.WebUI.Services.MedicineServices
{
    public interface IMedicineService
    {
        Task<List<ResultMedicineDto>> GetAllMedicinesAsync();
        Task<GetMedicineByIdDto> GetMedicineByIdAsync(int id);
        Task CreateMedicineAsync(CreateMedicineDto createMedicineDto);
        Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto);
        Task DeleteMedicineAsync(int id);
    }
}
