using fly_API.Models;
using Fly_Api_MongoDB.Configurations;
using MongoDB.Driver;
using System.Collections.Generic;

namespace fly_API.Services
{
    public class FlyService
    {
        private IMongoCollection<Fly> _flys;

        public FlyService(IFlySettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.DataBase);
            _flys = database.GetCollection<Fly>(settings.Collection);
        }

        public List<Fly> Get()
        {
            return _flys.Find(v => true).ToList();

        }

        public Fly GetId(string id)
        {
            var filter = Builders<Fly>.Filter.Eq(v => v.Id, id);
            var vuelo = _flys.Find(filter).FirstOrDefault();
            return vuelo;
        }

        public Fly Create(Fly vuelo)
        {
            _flys.InsertOne(vuelo);
            return vuelo;
        }

        public void Edit(string id, Fly vuelo)
        {
            _flys.ReplaceOne(v => v.Id == id, vuelo);
        }
        public void Delete(string id)
        {
            _flys.DeleteOne(v => v.Id == id);

        }
    }
}
