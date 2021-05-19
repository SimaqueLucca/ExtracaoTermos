using System;
using System.IO;
using System.Text;

namespace ExtracaoTermos
{
    public class TratarTermos
    {
        public static string[] GerarTermos(string caminhoTermos)
        {
            string Texto = File.ReadAllText(@caminhoTermos, Encoding.UTF8);
            Texto = TratarPDF.RetirarPontuacoes(Texto);
            string[] Termos = Texto.Split(Environment.NewLine);

            return Termos;
        }
    }
}