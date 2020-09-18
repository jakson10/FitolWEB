using FitOl.WebUI.Models;
using FitOl.WebUI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.ApiServices.Interfaces
{
    public interface ISportListApiService
    {
        Task<List<SportListDto>> GetAllAsync();
        Task AddAsync(SportListDto sportListDto);
        Task DeleteAsync(int id);
        Task<SportListDto> DetailsAsync(int id);

        Task<int> AddMovementForAreaAsync(int bolgeGun, int sportListId);

        Task<SelectMovementAndAreaModel> MovementsAsync(int id);
        Task<List<AreaMovementsDto>> SportListViewAsync(int id);
        Task MovementsPostAsync(SelectMovementAndAreaModel model);

        Task QuestionsResultAsync(string userName, QuestionSportModel model);
    }
}














