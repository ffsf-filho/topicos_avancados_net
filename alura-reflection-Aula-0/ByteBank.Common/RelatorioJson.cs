using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Common;
[NomeRelatorio("Relatório de boletos agrupados por cedentes")]
public class RelatorioJson : RelatorioDeBoletoBase
{
    protected readonly new string nomeArquivoSaida = "BoletosPorCedente.json";

    public RelatorioJson()
    {
    }

    public RelatorioJson(DateTime dataRelatorio) : base(dataRelatorio)
    {
    }

    public RelatorioJson(string nomeArquivoSaida) : base(nomeArquivoSaida)
    {
    }

    public RelatorioJson(string nomeArquivoSaida, DateTime dataRelatorio) : base(nomeArquivoSaida, dataRelatorio)
    {
    }

    protected override void GravarArquivo(List<BoletosPorCedente> grupos)
    {
        File.WriteAllText(nomeArquivoSaida, JsonConvert.SerializeObject(grupos));
        Console.WriteLine($"Arquivo '{nomeArquivoSaida}' criado com sucesso!");
    }
}
