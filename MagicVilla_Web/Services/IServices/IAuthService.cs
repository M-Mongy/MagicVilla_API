using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> loginAsync<T>(loginRequesetDTO objToCreate);
        Task<T> registerAsync<T>(RegistrationRequestDTO objToCreate);
    }
}
