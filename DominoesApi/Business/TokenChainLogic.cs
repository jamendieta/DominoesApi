using DominoesApi.Dtos;
using DominoesApi.Utilities;

namespace DominoesApi.Business
{
    public class TokenChainLogic : ITokenChainLogic
    {
        private List<DominoesApi.Dtos.Token> finalTokens;

        public IEnumerable<string> CalculateAll(IEnumerable<DominoesApi.Dtos.Token> tokens)
        {
            IEnumerable<IEnumerable<DominoesApi.Dtos.Token>> permutations = PermutationsExtension.GetPermutations(tokens, tokens.Count());
            List<string> result = new List<string>();
            foreach (IEnumerable<DominoesApi.Dtos.Token> permutation in permutations)
            {
                finalTokens = new();
                FindStrings(permutation.ToList(), 0, permutation.Count());
                if (finalTokens.Count == tokens.Count())
                {
                    if (finalTokens[0].Left == finalTokens[^1].Right)
                    {
                        string chain = string.Empty;
                        finalTokens.ForEach(t => chain += $"[{t.Left}|{t.Right}] ");
                        result.Add(chain.Trim());
                    }
                }
            }
            return result;
        }

        public string FirstCalculated(IEnumerable<DominoesApi.Dtos.Token> tokens)
        {
            IEnumerable<string> strings = CalculateAll(tokens);
            int size = strings.Count();
            if (size == 0)
                return string.Empty;
            Random random = new();
            int randomNumber = random.Next(1, size + 1);
            return strings.ToArray()[randomNumber - 1];
        }
        private DominoesApi.Dtos.Token RotateToken(DominoesApi.Dtos.Token token)
        {
            (token.Right, token.Left) = (token.Left, token.Right);
            token.RotatedToken = true;
            return token;
        }
        private void FindStrings(List<DominoesApi.Dtos.Token> listToken, int current, int size)
        {
            if (current < size - 1)
            {
                if (listToken[current].Left == listToken[current + 1].Left && !listToken[current].RotatedToken)
                {
                    listToken[current] = RotateToken(listToken[current]);
                    finalTokens.Add(listToken[current]);
                    if (current == size - 2)
                        finalTokens.Add(listToken[current + 1]);
                }
                else if (listToken[current].Left == listToken[current + 1].Right && !listToken[current].RotatedToken)
                {
                    listToken[current] = RotateToken(listToken[current]);
                    listToken[current + 1] = RotateToken(listToken[current + 1]);
                    finalTokens.Add(listToken[current]);
                    if (current == size - 2)
                        finalTokens.Add(listToken[current + 1]);
                }
                else if (listToken[current].Right == listToken[current + 1].Left)
                {
                    finalTokens.Add(listToken[current]);
                    if (current == size - 2)
                        finalTokens.Add(listToken[current + 1]);
                }
                else if (listToken[current].Right == listToken[current + 1].Right && (!listToken[current].RotatedToken || current == size - 2))
                {
                    listToken[current + 1] = RotateToken(listToken[current + 1]);
                    finalTokens.Add(listToken[current]);
                    if (current == size - 2)
                        finalTokens.Add(listToken[current + 1]);
                }
                FindStrings(listToken, current + 1, size);
            }
        }
    }
}
