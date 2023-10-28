using IdentityModel.Client;

namespace UI.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);

    }
}
