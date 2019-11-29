using Desafio.Domain;

namespace Desafio.API.Models
{
    public class RequestModel
    {
        public string fileName { get; set; }
        public Valores Valores { get; set; }
        public Registros Registros { get; set; }
    }
}