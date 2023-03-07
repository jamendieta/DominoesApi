using DominoesApi.Data;
using DominoesApi.Dtos;
using DominoesApi.Models;

namespace DominoesApi.Business
{
    public interface IUserLogic
    {
        Task<UserResponseDto> Login(User user);
    }
}
