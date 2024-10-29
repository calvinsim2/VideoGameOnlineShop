using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Helpers.User;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthorizationUtilityMethods _authorizationUtilityMethods;
        private readonly ICommonUtilityMethods _commonUtilityMethods;
        private readonly IUserRepository _userRepository;
        public UserService(IAuthorizationUtilityMethods authorizationUtilityMethods, 
                           ICommonUtilityMethods commonUtilityMethods, IUserRepository userRepository) 
        {
            _authorizationUtilityMethods = authorizationUtilityMethods;
            _commonUtilityMethods = commonUtilityMethods;
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(RegisterUserDataModel registerUserDataModel)
        {
            bool userNameTaken = await CheckIfUsernameAlreadyExistAsync(registerUserDataModel.Username);

            if (userNameTaken)
            {
                throw new BadRequestException("Username already exists");
            }

            User newUser = UserDomainMapper.MapRegisterUserDataModelToUser(registerUserDataModel);

            _authorizationUtilityMethods.CreatePasswordHash(registerUserDataModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<UserDataModel> LoginUserAsync(LoginRequestDataModel loginRequestDataModel)
        {
            User? existingUser = await _userRepository.GetUserByUsername(loginRequestDataModel.Username, false);

            if (existingUser is null) 
            {
                throw new NotFoundException("No Account with username found.");
            }

            bool passwordMatches =
                _authorizationUtilityMethods.VerifyPasswordHash(loginRequestDataModel.Password, existingUser.PasswordHash, existingUser.PasswordSalt);

            if (!passwordMatches)
            {
                throw new BadRequestException("Incorrect password provided.");
            }

            UserDataModel existingUserDataModel = UserDomainMapper.MapUserToUserDataModel(existingUser);

            return existingUserDataModel;
        }

        public async Task<bool> CheckIfUsernameAlreadyExistAsync(string name)
        {
            List<User> users = (await _userRepository.GetAllUsersAsync(false)).ToList();

            foreach (User user in users)
            {
                string existingUsername = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(user.Username);
                string inputUsername = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(name);

                if (existingUsername == inputUsername)
                {
                    return true;
                }
            }

            return false;
        }

        
    }
}
