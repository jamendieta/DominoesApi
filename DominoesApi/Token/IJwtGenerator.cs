using DominoesApi.Models;


namespace DominoesApi.Token;

public interface IJwtGenerator {
    string CreateToken(User user);
}