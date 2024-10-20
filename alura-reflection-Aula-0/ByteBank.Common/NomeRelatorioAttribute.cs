namespace ByteBank.Common;

[AttributeUsage(AttributeTargets.Class)]
public class NomeRelatorioAttribute : Attribute
{
    public NomeRelatorioAttribute(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }


}
