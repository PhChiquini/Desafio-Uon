using Desafio.Domain;

namespace Desafio.Repository
{
    public interface IDesafioRepository
    {
        Valores CalcularResultado(Valores valores);
        string FormataIdentificacao (string identificacao);
    }
}