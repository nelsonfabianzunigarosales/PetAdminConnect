using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetAdminConnect.Backend.Helpers;
using PetAdminConnect.Backend.Intertfaces.Repositories;
using PetAdminConnect.Backend.Intertfaces.UnitOfWork;
using PetAdminConnect.Backend.Repositories;
using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;
using Sales.Backend.Helpers;

namespace PetAdminConnect.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetsController : GenericController<Vet>
    {
        private readonly IVetsUnitOfWork _vetsUnitOfWork;
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly IFileStorage _fileStorage;
        private readonly IMailHelper _mailHelper;
        private readonly IUsersRepository _usersRepository;
        private readonly string _container;

        public VetsController(
            IGenericUnitOfWork<Vet> unitOfWork, 
            IVetsUnitOfWork vetsUnitOfWork,
            IUserHelper userHelper,
            IConfiguration configuration,
            IFileStorage fileStorage,
            IMailHelper mailHelper,
            IUsersRepository usersRepository) 
            : base(unitOfWork)
        {
            _vetsUnitOfWork = vetsUnitOfWork;
            _userHelper = userHelper;
            _configuration = configuration;
            _fileStorage = fileStorage;
            _mailHelper = mailHelper;
            _usersRepository = usersRepository;
            _container = "users";
        }

        [HttpGet("GetVet/{userId}")]
        public async Task<IActionResult> GetClient(string userId)
        {
            var response = await _vetsUnitOfWork.GetAsync(userId);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpPost("CreateVet")]
        public async Task<ActionResult> CreateVetAsync([FromBody] VetDTO model)
        {
            User user = model;

            if (!string.IsNullOrEmpty(model.Photo))
            {
                var photoUser = Convert.FromBase64String(model.Photo);
                model.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
            }

            var result = await _userHelper.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());

                
                var userProfile = await _vetsUnitOfWork.AddAsync(model);

                if (userProfile.WasSuccess)
                {
                    var response = await SendConfirmationEmailAsync(user);
                    if (response.WasSuccess)
                    {
                        return NoContent();
                    }
                    return BadRequest(response.Message);
                }
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }

        private async Task<Response<string>> SendConfirmationEmailAsync(User user)
        {
            var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
            var tokenLink = Url.Action("ConfirmEmail", "accounts", new
            {
                userid = user.Id,
                token = myToken
            }, HttpContext.Request.Scheme, _configuration["Url Frontend"]);

            return _mailHelper.SendMail(user.FullName, user.Email!,
                $"Sales - Confirmación de cuenta",
                $"<h1>Sales - Confirmación de cuenta</h1>" +
                $"<p>Para habilitar el usuario, por favor hacer clic 'Confirmar Email':</p>" +
                $"<b><a href ={tokenLink}>Confirmar Email</a></b>");
        }
    }
}
