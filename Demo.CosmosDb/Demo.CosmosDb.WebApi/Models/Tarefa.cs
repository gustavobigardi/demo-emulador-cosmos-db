using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.CosmosDb.WebApi.Models
{
    public class Tarefa
    {
        public ObjectId _id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
