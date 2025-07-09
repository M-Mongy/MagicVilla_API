using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> login(loginRequesetDTO loginRequesetDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);

    }
}
