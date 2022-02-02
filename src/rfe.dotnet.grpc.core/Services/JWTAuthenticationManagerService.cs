using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using rfe.dotnet.grpc.core.Interfaces.Services;

namespace rfe.dotnet.grpc.core.Services
{
    public class JWTAuthenticationManagerService : IJWTAuthenticationManagerService
    {
        private readonly IDictionary<string, string> user = new Dictionary<string, string>(){{"grpc-user@common-auth.com","grpc"}, {"admin@common-auth.com","admin"}};
        
        public Task<string> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> AuthenticateUsingId(Guid TokenId)
        {
            throw new NotImplementedException();
        }
    }
}