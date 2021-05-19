using System;
using System.Collections.Generic;
using System.IO;

namespace ExtracaoTermos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Arquivos = File.ReadAllText(@"\\192.168.254.108\Desenvolvimento\Luca\ARQUIVOS.txt").Split(Environment.NewLine);

            String NomeCSV = "Extração " + DateTime.Now.ToString("ddMMyyyy hh mm") + ".CSV";
            File.WriteAllText(@"Resultado\" + NomeCSV, "Nome Arquivo; Caminho Arquivos; Termos Extraidos" + Environment.NewLine);

            foreach (var URL in Arquivos)
            {
                string URLArquivo = @URL;
                string URLTermos = @"Termos\TodosTermos.txt";
                string NomeArquivo = Path.GetFileNameWithoutExtension(@URLArquivo);

                string Texto = TratarPDF.ExtrairTexto(@URLArquivo);
                Texto = TratarPDF.RetirarPontuacoes(Texto);
                Texto = TratarPDF.TratarTexto(Texto);

                string[] Termos = TratarTermos.GerarTermos(@URLTermos);

                List<string> TermosLocalizados = new List<string>();

                foreach (var item in Termos)
                {
                    if (Texto.Contains(item) && item != "")
                    {
                        TermosLocalizados.Add(item);
                    }
                }

                if (TermosLocalizados.Count > 0)
                {
                    string linhaTermos = "";

                    foreach (var item in TermosLocalizados)
                    {
                        linhaTermos += item + ", ";
                    }

                    File.AppendAllText(@"Resultado\" + NomeCSV, NomeArquivo + ";" + URLArquivo + "; " + linhaTermos + Environment.NewLine);
                }

                else
                {
                    File.AppendAllText(@"resultado\" + NomeCSV, NomeArquivo + ";" + URLArquivo + "; " + "Sem termos localizados" + Environment.NewLine);
                }
            }
        }
    }
}
