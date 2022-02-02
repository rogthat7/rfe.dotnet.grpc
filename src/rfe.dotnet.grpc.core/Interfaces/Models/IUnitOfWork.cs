using System;
using System.Data;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace rfe.dotnet.grpc.core.Interfaces.Models
{
    public interface IUnitOfWork  
    {
        IMongoClient Client {get;}
    }
}