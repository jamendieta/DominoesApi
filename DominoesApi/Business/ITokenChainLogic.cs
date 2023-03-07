using DominoesApi.Dtos;

namespace DominoesApi.Business
{
    public interface ITokenChainLogic
    {
        IEnumerable<string> CalculateAll(IEnumerable<DominoesApi.Dtos.Token> tokens);
        string FirstCalculated(IEnumerable<DominoesApi.Dtos.Token> tokens);

    }
}
