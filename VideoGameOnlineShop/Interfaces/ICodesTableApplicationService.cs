﻿using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface ICodesTableApplicationService
    {
        Task<IEnumerable<CodesTableViewModel>> GetAllCodeMatureRatingAsync();
        Task<CodesTableViewModel> GetCodeMatureRatingByCodeAsync(string code);
        Task AddCodeMatureRatingAsync(CodesTableDto codesTableDto);
    }
}