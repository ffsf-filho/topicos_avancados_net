using ByteBank.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaXPTO.Plugins;

public class RelatorioJson : IRelatorio<Boleto>
{
    private const string PastaDestino = @"C:\Plugins";

    public RelatorioJson()
    {
        
    }

    public void Processar(List<Boleto> boletos)
    {
        var boletosPorCedenteList = PegaBoletosAgrupados(boletos);

        GravarArquivo(boletosPorCedenteList);
    }

    private void GravarArquivo(List<BoletosPorCedente> grupos)
    {
        string nomeArquivoSaida = Path.Combine(PastaDestino, $"{typeof(BoletosPorCedente).Name}.json");
        File.WriteAllText(nomeArquivoSaida, JsonConvert.SerializeObject(grupos));
        Console.WriteLine($"Arquivo '{nomeArquivoSaida}' criado com sucesso!");
    }

    private List<BoletosPorCedente> PegaBoletosAgrupados(List<Boleto> boletos)
    {
        List<BoletosPorCedente> boletosPorCedentes = boletos
                                                        .GroupBy(b => new { b.CedenteNome, b.CedenteCpfCnpj, b.CedenteAgencia, b.CedenteConta })
                                                        .Select(g => new BoletosPorCedente
                                                        {
                                                            CedenteNome = g.Key.CedenteNome,
                                                            CedenteCpfCnpj = g.Key.CedenteCpfCnpj,
                                                            CedenteAgencia = g.First().CedenteAgencia,
                                                            CedenteConta = g.First().CedenteConta,
                                                            Valor = g.Sum(b => b.Valor),
                                                            Quantidade = g.Count()
                                                        })
                                                        .ToList();


        return boletosPorCedentes;
    }
}
