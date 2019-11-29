using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Domain;

namespace Desafio.Repository
{
    public interface IFileManager
    {
        void ManageFile(string fileName);
        Task<bool> WriteData(string data);
        Valores[] GetValores();
        Valores GetValoresByDatalog (DateTime dataLog);
        Registros[] GetDados();
        Registros GetDadosById(string identificacao);

    }
}