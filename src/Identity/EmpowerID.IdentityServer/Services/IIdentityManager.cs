using EmpowerID.IdentityServer.API.Controllers.Requests;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;

namespace EmpowerID.IdentityServer.Services;

public interface IIdentityManager
{
    Task<TokenResponse> AuthUserByCredentials(LoginRequest request);
    Task<IdentityResult> RegisterNewUser(RegisterUserRequest request);
}
