using System.Data;
using System.Data.SqlClient;
using MongoDB.Driver;
using rfe.dotnet.grpc.core.Interfaces.Models;

namespace rfe.dotnet.grpc.core.Models.Shared
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private IMongoClient _mongoClient;
        /// <summary>
        /// Client
        /// </summary>
        /// <value></value>
        public IMongoClient Client
        {
            get
            {
                return _mongoClient;
            }            
        }       

        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _mongoClient = new MongoClient();
        }

        public UnitOfWork(string mongoConnectionUrl)
        {
            var settings = MongoClientSettings.FromConnectionString(mongoConnectionUrl);
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };
            _mongoClient = new MongoClient(settings);
        }

        #endregion

        #region Public methods

        #endregion

    }
}