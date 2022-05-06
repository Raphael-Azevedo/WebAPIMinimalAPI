using ApiCatalgo.Models;

namespace ApiCatalgo.Services;

public interface ITokenService
{
    string GerarToken(string key, string issuer, string audience, UserModel user);
}
