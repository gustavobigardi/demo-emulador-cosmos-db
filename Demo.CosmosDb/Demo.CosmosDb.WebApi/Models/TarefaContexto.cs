using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.CosmosDb.WebApi.Models
{
    public class TarefaContexto
    {
        private readonly IConfiguration _configuration;

        public TarefaContexto(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T ObterIarefa<T>(string codigo)
        {
            MongoClient client = new MongoClient(
                _configuration.GetConnectionString("Default"));
            IMongoDatabase db = client.GetDatabase("DBTarefas");

            var filter = Builders<T>.Filter.Eq("Codigo", codigo);

            return db.GetCollection<T>("Tarefas")
                .Find(filter).FirstOrDefault();
        }

        public IEnumerable<T> ListarTarefas<T>()
        {
            MongoClient client = new MongoClient(
                _configuration.GetConnectionString("Default"));
            IMongoDatabase db = client.GetDatabase("DBTarefas");

            return db.GetCollection<T>("Tarefas").Find(_ => true).ToList();
        }

        public void AdicionarTarefa<T>(T tarefa)
        {
            MongoClient client = new MongoClient(
               _configuration.GetConnectionString("Default"));
            IMongoDatabase db = client.GetDatabase("DBTarefas");

            db.GetCollection<T>("Tarefas").InsertOne(tarefa);
        }
    }
}
