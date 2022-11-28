using CtcontrolAPIService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CtcontrolAPIService.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<ClientDataModel> _clientDataCollection;
        private readonly IMongoCollection<StatusDataModel> _statusDataCollection;
        public bool _issuccess { get; private set; } = false;

        public MongoDBService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DataBaseName);
            _clientDataCollection = database.GetCollection<ClientDataModel>(mongoDbSettings.Value.ClientCollectionName);
            _statusDataCollection = database.GetCollection<StatusDataModel>(mongoDbSettings.Value.StatusCollectionName);
        }

        #region ClientArea
        public async Task<List<ClientDataModel>> ClientGetAsync() 
        {
            return await _clientDataCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<ClientDataModel> ClientGetAsync(string id)
        {
            return await _clientDataCollection.Find(cd => cd.Id == id).FirstOrDefaultAsync();
        }

        public async Task ClientCreateAsync(ClientDataModel clientDataModel)
        {
            try
            {
                string? id = _clientDataCollection.Find(cd => cd.Id == clientDataModel.Id).FirstOrDefault().Id;
            }
            catch
            {
                await _clientDataCollection.InsertOneAsync(clientDataModel);
                _issuccess = true;
                return;
            }
            _issuccess= false;
            return;
        }

        public async Task ClientUpdateAsync(string id, ClientDataModel clientDataModel)
        {
            //Replace NOT UPDATE
            //TODO UPDATE
            //FilterDefinition<ClientDataModel> filter = Builders<ClientDataModel>.Filter.Eq("Id", id);
            //UpdateDefinition<ClientDataModel> update = Builders<ClientDataModel>.Update.Set<ClientDataModel>("clientdata", clientDataModel);
            //await _clientDataCollection.UpdateOneAsync(filter, new BsonDocument(new BsonDocument(), new BsonDocument());
            await _clientDataCollection.FindOneAndReplaceAsync(cd => cd.Id == id, clientDataModel);
            return;
        }

        public async Task ClientDeleteAsync(string id)
        {
            FilterDefinition<ClientDataModel> filter = Builders<ClientDataModel>.Filter.Eq("Id", id);
            await _clientDataCollection.DeleteOneAsync(filter);
            return;
        }
        #endregion

        #region StatusArea
        public async Task<List<StatusDataModel>> StatusGetAsync()
        {
            return await _statusDataCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<StatusDataModel> StatusGetAsync(string id)
        {
            return await _statusDataCollection.Find(cd => cd.Id == id).FirstOrDefaultAsync();
        }

        public async Task StatusCreateAsync(StatusDataModel statusDataModel)
        {
            try
            {
                string? id = _statusDataCollection.Find(cd => cd.Id == statusDataModel.Id).FirstOrDefault().Id;
            }
            catch
            {
                await _statusDataCollection.InsertOneAsync(statusDataModel);
                _issuccess = true;
                return;
            }
            _issuccess = false;
            return;
        }

        public async Task StatusUpdateAsync(string id, StatusDataModel statusDataModel)
        {
            await _statusDataCollection.FindOneAndReplaceAsync(cd => cd.Id == id, statusDataModel);
            return;
        }

        public async Task StatusDeleteAsync(string id)
        {
            FilterDefinition<StatusDataModel> filter = Builders<StatusDataModel>.Filter.Eq("Id", id);
            await _statusDataCollection.DeleteOneAsync(filter);
            return;
        }
        #endregion
    }
}
