using DominoesApi.Data;
using DominoesApi.Dtos;
using DominoesApi.Models;

namespace DominoesApi.Business
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async  Task<UserResponseDto> Login(User user)
        {
            return await userRepository.Login(user);
        }
    }
}
