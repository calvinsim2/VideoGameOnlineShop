using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopApplication.Controllers
{
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }


    }
}
