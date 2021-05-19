using System;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ExtracaoTermos
{
    public class TratarPDF
    {

        public static string ExtrairTexto(string arquivo)
        {

            StringBuilder Sb = new StringBuilder();
            string Texto;

            string arquivoString = @arquivo;

            using (PdfReader Leitor = new PdfReader(arquivoString))
            {
                for (int Pagina = 1; Pagina <= Leitor.NumberOfPages; Pagina++)
                {
                    Texto = (PdfTextExtractor.GetTextFromPage(Leitor, Pagina));

                    Sb.AppendLine(Texto);
                }
            }

            Texto = Sb.ToString();
            return Texto;
        }

        public static string RetirarPontuacoes(string texto)
        {
            texto = texto.ToString().ToUpper();
            texto = texto.Replace("Á", "A");
            texto = texto.Replace("À", "A");
            texto = texto.Replace("Â", "A");
            texto = texto.Replace("Ã", "A");
            texto = texto.Replace("É", "E");
            texto = texto.Replace("È", "E");
            texto = texto.Replace("Ê", "E");
            texto = texto.Replace("Í", "I");
            texto = texto.Replace("Ï", "I");
            texto = texto.Replace("Ó", "O");
            texto = texto.Replace("Ô", "O");
            texto = texto.Replace("Õ", "O");
            texto = texto.Replace("Ö", "O");
            texto = texto.Replace("Ú", "U");
            texto = texto.Replace("Ç", "C");
            texto = texto.Replace("Ñ", "N");

            return texto;
        }

        public static string TratarTexto(string texto)
        {
            texto = Regex.Replace(texto, @"\s{2,}", " ");
            texto = texto.Replace(Environment.NewLine, " ");
            texto = Regex.Replace(texto, @"\r\n", " ");
            texto = Regex.Replace(texto, @"\r", " ");
            texto = Regex.Replace(texto, @"\t", " ");
            texto = Regex.Replace(texto, @"\n", " ");

            return texto;
        }

    }
}