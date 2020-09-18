using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface IMovementApiService
    {
        Task<List<MovementDto>> GetAllAsync();
        Task AddAsync(MovementAddModel model, string newName);
        Task UpdateAsync(MovementUpdateModel model, string newName);
        Task DeleteAsync(int id);
        Task<MovementDto> DetailsAsync(int id);
        Task<MovementDto> GetByIdAsync(int id);

        Task<List<MovementListModel>> GetAllMovementNameAsync();

        /// ÇOKA ÇOK TABLOLAR
        Task<List<MovementListModel>> GetAreaMovementsAsync(int sportListId);
        Task AddToAreaMovementAsync(AreaMovementModel model);
        Task DeleteToAreaMovementAsync(AreaMovementModel model);
        Task<List<AreaMovementsDto>> SportListDetailsAsync(int id);
        Task<List<MovementListModel>> SportistAreaMovementDetailsAsync(int sportListId, int areaId);

    }
}
