namespace ByteBank.Common;

public class BoletosPorCedente
{
    // Informações do Cedente (Beneficiário)
    [NomeColuna("Nome")]
    public string CedenteNome { get; set; }

    [NomeColuna("CpfCnpj")]
    public string CedenteCpfCnpj { get; set; }

    [NomeColuna("Agencia")]
    public string CedenteAgencia { get; set; }

    [NomeColuna("Conta")]
    public string CedenteConta { get; set; }

    [NomeColuna("Total")]
    public decimal Valor { get; set; }

    [NomeColuna("Qtde")]
    public int Quantidade { get; set; } 
}
