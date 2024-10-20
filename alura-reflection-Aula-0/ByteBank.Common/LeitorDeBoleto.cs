using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Common
{
    public class LeitorDeBoleto
    {
        public List<Boleto> LerBoletos(string caminhoArquivo)
        {
            // montar lista de boletos
            var boletos = new List<Boleto>();

            // ler arquivo de boletos
            using (var reader = new StreamReader(caminhoArquivo))
            {
                // ler cabeçalho do arquivo CSV
                string linha = reader.ReadLine();
                string[] cabecalho = linha.Split(',');

                // para cada linha do arquivo CSV
                while (!reader.EndOfStream)
                {
                    // ler dados
                    linha = reader.ReadLine();
                    string[] dados = linha.Split(',');

                    // carregar objeto Boleto
                    //Boleto boleto = MapearTextoParaBoleto(cabecalho, dados);
                    Boleto boleto = MapearTextoParaObjeto<Boleto>(cabecalho, dados);

                    // adicionar boleto à lista
                    boletos.Add(boleto);
                }
            }

            // retornar lista de boletos
            return boletos;
        }

        private Boleto MapearTextoParaBoleto(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            Boleto instancia = new Boleto();
            instancia.CedenteNome = valoresPropriedades[0];
            instancia.CedenteCpfCnpj = valoresPropriedades[1];
            instancia.CedenteAgencia = valoresPropriedades[2];
            instancia.CedenteConta = valoresPropriedades[3];
            instancia.SacadoNome = valoresPropriedades[4];
            instancia.SacadoCpfCnpj = valoresPropriedades[5];
            instancia.SacadoEndereco = valoresPropriedades[6];
            instancia.Valor = Convert.ToDecimal(valoresPropriedades[7]);
            instancia.DataVencimento = Convert.ToDateTime(valoresPropriedades[8]);
            instancia.NumeroDocumento = valoresPropriedades[9];
            instancia.NossoNumero = valoresPropriedades[10];
            instancia.CodigoBarras = valoresPropriedades[11];
            instancia.LinhaDigitavel = valoresPropriedades[12];
            return instancia;
        }

        private T MapearTextoParaObjeto<T>(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            T instancia = Activator.CreateInstance<T>();
            //Percorrer os nomes de propriedades
            for (int i = 0; i < nomesPropriedades.Length; i++)
            {
                //Obtém a propriedade atual através do nome.
                string namePropriedade = nomesPropriedades[i];
                PropertyInfo propertyInfo = instancia!.GetType().GetProperty(namePropriedade)!;

                //Veririfca se a propriedade foi encontrada
                if(propertyInfo != null)
                {
                    //obtém o tipo da propriedade
                    Type propertyType = propertyInfo.PropertyType;

                    //obtém o valor da propriedade
                    string valor = valoresPropriedades[i].ToString();

                    //Converte o valor da propriedade para o tipo correto
                    Object valorConvertido = Convert.ChangeType(valor, propertyType);

                    //Guarda o valor convertido na propriedade
                    propertyInfo.SetValue(instancia, valorConvertido);
                }
            }

            return instancia;
        }
    }
}
