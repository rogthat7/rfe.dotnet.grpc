using System;
using System.Threading.Tasks;

namespace rfe.dotnet.grpc.core.Interfaces.Services
{
    public interface IJWTAuthenticationManagerService
    {
         Task<string> AuthenticateUsingId(Guid TokenId);
         Task<string> Authenticate(string userName, string password);
    }
}