using DominoesApi.Dtos;
using DominoesApi.Models;
using DominoesApi.Token;

namespace DominoesApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IJwtGenerator jwtGenerator;
        public UserRepository(IJwtGenerator jwtGenerator)
        {
            this.jwtGenerator = jwtGenerator;
        }
        public async Task<UserResponseDto?> Login(User request)
        {
            if (request.Email == "mendietajimmy7@gmail.com")
            {
                UserResponseDto response = new()
                {
                    Email = "mendietajimmy7@gmail.com",
                    UserName = "Jimmy Mendieta",
                    Token = jwtGenerator.CreateToken(request)
                };
                return response;
            }
            return default;
        }
    }
}
