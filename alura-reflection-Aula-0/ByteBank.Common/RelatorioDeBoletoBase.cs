using System.Reflection;

namespace ByteBank.Common;

public abstract class RelatorioDeBoletoBase : IRelatorio<Boleto>
{
    protected readonly string nomeArquivoSaida;
    protected readonly DateTime dataRelatorio = DateTime.Now;

    public RelatorioDeBoletoBase(string nomeArquivoSaida, DateTime dataRelatorio)
    {
        this.nomeArquivoSaida = nomeArquivoSaida;
        this.dataRelatorio = dataRelatorio;
    }

    public RelatorioDeBoletoBase(DateTime dataRelatorio)
    {
        this.dataRelatorio = dataRelatorio;
    }

    public RelatorioDeBoletoBase(string nomeArquivoSaida)
    {
        this.nomeArquivoSaida = nomeArquivoSaida;
    }

    public RelatorioDeBoletoBase()
    {

    }

    public void Processar(List<Boleto> boletos)
    {
        var atributoNomeRelatorio = this.GetType().GetCustomAttribute<NomeRelatorioAttribute>();
        Console.WriteLine("========================================================");
        Console.WriteLine($"Nome: {atributoNomeRelatorio!.Nome}");
        Console.WriteLine("========================================================");

        var boletosPorCedente = PegaBoletosAgrupados(boletos);
        //Console.WriteLine(JsonConvert.SerializeObject(boletosPorCedente));
        GravarArquivo(boletosPorCedente);
    }

    private List<BoletosPorCedente> PegaBoletosAgrupados(List<Boleto> boletos)
    {
        // Agrupar boletos por cedente
        var boletosAgrupados = boletos.GroupBy(b => new
        {
            b.CedenteNome,
            b.CedenteCpfCnpj,
            b.CedenteAgencia,
            b.CedenteConta
        });

        // Lista para armazenar instâncias de BoletosPorCedente
        List<BoletosPorCedente> boletosPorCedenteList = new List<BoletosPorCedente>();

        // Iterar sobre os grupos de boletos por cedente
        foreach (var grupo in boletosAgrupados)
        {
            // Criar instância de BoletosPorCedente
            BoletosPorCedente boletosPorCedente = new BoletosPorCedente
            {
                CedenteNome = grupo.Key.CedenteNome,
                CedenteCpfCnpj = grupo.Key.CedenteCpfCnpj,
                CedenteAgencia = grupo.Key.CedenteAgencia,
                CedenteConta = grupo.Key.CedenteConta,
                Valor = grupo.Sum(b => b.Valor),
                Quantidade = grupo.Count()
            };

            // Adicionar à lista
            boletosPorCedenteList.Add(boletosPorCedente);
        }

        return boletosPorCedenteList;
    }

    protected abstract void GravarArquivo(List<BoletosPorCedente> grupos);
}
