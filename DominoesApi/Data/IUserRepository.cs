using DominoesApi.Dtos;
using DominoesApi.Models;

namespace DominoesApi.Data
{
    public interface IUserRepository
    {
        Task<UserResponseDto> Login(User request);
    }
}
