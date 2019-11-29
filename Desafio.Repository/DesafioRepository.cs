using System.Text;
using Desafio.Domain;

namespace Desafio.Repository
{
    public class DesafioRepository : IDesafioRepository
    {
        public Valores CalcularResultado(Valores valores){

            switch (valores.Operacao)
            {
                case "Adição":
                    valores.Resultado = valores.Valor1 + valores.Valor2;
                    break;
                case "Subtração":
                    valores.Resultado = valores.Valor1 - valores.Valor2;
                    break;
                case "Multiplicação":
                    valores.Resultado = valores.Valor1 * valores.Valor2;
                    break;
                case "Divisão":
                    valores.Resultado = valores.Valor1 / valores.Valor2;
                    break;
            }

            return valores;
        }
        public string FormataIdentificacao (string identificacao) {

            StringBuilder sb = new StringBuilder ();
            foreach (char c in identificacao) {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                    sb.Append (c);
                }
            }
            return sb.ToString ();
        }
    }
}