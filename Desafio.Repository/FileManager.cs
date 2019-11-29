using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain;

namespace Desafio.Repository {
    public class FileManager : IFileManager {
        private string _fileName;
        private string filePath;
        private string headerValores = "datahora,valor1,valor2,resultado,operacao";
        private string headerRegistro = "Nome,Morada,DataNascimento,NumeroTelemovel,NumeroFiscal";

        public void ManageFile (string fileName) {

            string path = @"C:\Log\";

            _fileName = fileName;

            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            filePath = $@"C:\Log\{fileName}.csv";

            if (!File.Exists (filePath)) {
                if (fileName == "TestRegis") {
                    CreateFile (headerRegistro);
                } else if (fileName == "TestLog") {
                    CreateFile (headerValores);
                }

            }
        }

        private void CreateFile (string header) {

            header += Environment.NewLine;

            File.Create (filePath).Dispose ();
            File.WriteAllText (filePath, header);
        }

        private bool ValidarRegistro (string id) {
            var dados = GetDadosById (id);

            if (dados != null) {
                return true;
            }

            return false;
        }

        public async Task<bool> WriteData (string data) {

            string dataLog = String.Empty;

            if (_fileName == "TestRegis") {
                var registro = data.Split (';');
                if (ValidarRegistro (registro[2])) {
                    return false;
                }
            } else {

                dataLog = DateTime.Now.ToString ("dd/MM/yyyy HH:mm:ss") + ";";

            }

            string dataToWrite = dataLog + data;

            using (StreamWriter writer = new StreamWriter (filePath, true)) {
                await writer.WriteLineAsync (dataToWrite);
            }

            return true;

        }

        public Valores[] GetValores () {
            List<Valores> valList = new List<Valores> ();

            var linhasCsv = File.ReadAllLines (filePath).Skip (1);

            var query = from linhaCsv in linhasCsv
            let data = linhaCsv.Split (';')
            select new Valores {
                DataLog = Convert.ToDateTime (data[0]),
                    Valor1 = Convert.ToDouble (data[1]),
                    Valor2 = Convert.ToDouble (data[2]),
                    Resultado = Convert.ToDouble (data[3]),
                    Operacao = data[4]
            };

            foreach (var item in query) {
                valList.Add (item);
            }

            return valList.OrderByDescending (v => v.DataLog).ToArray ();
        }

        public Valores GetValoresByDatalog (DateTime dataLog) {

            var linhasCsv = File.ReadAllLines (filePath).Skip (1);

            var query = from linhaCsv in linhasCsv
            let data = linhaCsv.Split (';')
            where data[0] == dataLog.ToString ()
            select new Valores {
                DataLog = Convert.ToDateTime (data[0]),
                Valor1 = Convert.ToDouble (data[1]),
                Valor2 = Convert.ToDouble (data[2]),
                Resultado = Convert.ToDouble (data[3]),
                Operacao = data[4],
            };

            return query.FirstOrDefault (x => x.DataLog == dataLog);
        }

        public Registros[] GetDados () {

            var linhasCsv = File.ReadAllLines (filePath).Skip (1);

            var query = from linhaCsv in linhasCsv
            let data = linhaCsv.Split (';')
            select new Registros {
                    Nome = data[0],
                    Endereco = data[1],
                    DataNascimento = Convert.ToDateTime (data[2]),
                    Telefone = data[3],
                    Identificacao = data[4],
            };

            return query.ToArray ();
        }

        public Registros GetDadosById (string Identificacao) {

            var linhasCsv = File.ReadAllLines (filePath).Skip (1);

            var query = from linhaCsv in linhasCsv
            let data = linhaCsv.Split (';')
            where data[2] == Identificacao
            select new Registros {
                Nome = data[0],
                Endereco = data[1],
                DataNascimento = Convert.ToDateTime (data[2]),
                Telefone = data[3],
                Identificacao = data[4],
            };

            return query.FirstOrDefault (x => x.Identificacao == Identificacao);
        }
    }
}