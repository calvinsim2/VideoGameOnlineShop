﻿using System.Net;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Helpers.Developer;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopDomain.Services
{
    public class DeveloperService : IDeveloperService
    {
        public readonly IGameRepository _gameRepository;
        public readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IGameRepository gameRepository,
                                IDeveloperRepository developerRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<DeveloperDataModel>> GetAllExistingDevelopersAsync()
        {
            IEnumerable<Developer> developers = await _developerRepository.GetAllDevelopersAsync(false);

            IEnumerable<DeveloperDataModel> developerDataModels = MapMultipleGameRecordToGameDataModel(developers);

            return developerDataModels;
        }
        public async Task<DeveloperDataModel> GetExplicitDeveloperAsync(Guid id)
        {
            Developer? developer = await _developerRepository.GetByIdAsync(id, false) ?? throw new HttpRequestException("Developer not found", null, HttpStatusCode.NotFound);

            DeveloperDataModel developerDataModel = DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developer);
            return developerDataModel;
        }
        public async Task AddDeveloperAsync(DeveloperDataModel developerDataModel)
        {
            Developer developer = DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developerDataModel);

            await _developerRepository.AddAsync(developer);
            await _developerRepository.SaveChangesAsync();
        }

        public async Task UpdateSelectedDeveloperAsync(DeveloperDataModel developerDataModel)
        {
            Developer? developer = await _developerRepository.GetByIdAsync(developerDataModel.Id, false) 
                                    ?? throw new HttpRequestException("Developer not found", null, HttpStatusCode.NotFound);

            MapDataToNewDeveloperForUpdate(developerDataModel, developer);

            _developerRepository.Update(developer);
            await _developerRepository.SaveChangesAsync();
        }

        public async Task DeleteSelectedDeveloperAsync(Guid id)
        {
            var existingDeveloper = await _developerRepository.GetByIdAsync(id, true);
            if (existingDeveloper is null)
            {
                throw new HttpRequestException("Developer not found", null, HttpStatusCode.NotFound);
            }

            _developerRepository.Remove(existingDeveloper);
            await _developerRepository.SaveChangesAsync();
        }

        #region Common Non Repository calls functions
        public static void MapDataToNewDeveloperForUpdate(DeveloperDataModel incomingDeveloperDataModel, Developer existingDeveloper)
        {
            existingDeveloper.Name = incomingDeveloperDataModel.Name;
            existingDeveloper.Slogan = incomingDeveloperDataModel.Slogan;
            existingDeveloper.Logo = incomingDeveloperDataModel.Logo;
            existingDeveloper.DateTimeUpdated = DateTimeOffset.Now;
        }

        public IEnumerable<DeveloperDataModel> MapMultipleGameRecordToGameDataModel(IEnumerable<Developer> developers)
        {
            if (developers is null || !developers.Any())
            {
                return new List<DeveloperDataModel>();
            }

            List<DeveloperDataModel> newDeveloperSubmissionDataModels = new List<DeveloperDataModel>();

            foreach (var developer in developers)
            {
                newDeveloperSubmissionDataModels.Add(DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developer));
            }

            return newDeveloperSubmissionDataModels;

        }

        #endregion
    }
}
