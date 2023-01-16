using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using reestAPI.Models;

namespace reestAPI.Services
{
	public class ReestrService
	{
        private readonly IMongoCollection<reestr> _reestrs;

        public ReestrService(IReestrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _reestrs = database.GetCollection<reestr>(settings.ReestrCollectionName);
        }

        public List<reestr> Get() =>
            _reestrs.Find(reestr => true).ToList();

        public reestr Get(string id) =>
            _reestrs.Find<reestr>(reestr => reestr.Id == id).FirstOrDefault();

        public reestr Create(reestr reestr)
        {
            _reestrs.InsertOne(reestr);
            return reestr;
        }

        public void Update(string id, reestr reestrIn) =>
            _reestrs.ReplaceOne(reestr => reestr.Id == id, reestrIn);

        public void Remove(reestr reestrIn) =>
            _reestrs.DeleteOne(reestr => reestr.Id == reestrIn.Id);

        public void Remove(string id) =>
            _reestrs.DeleteOne(reestr => reestr.Id == id);
    }
}

