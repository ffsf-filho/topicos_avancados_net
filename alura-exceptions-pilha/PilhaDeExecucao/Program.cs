public class PilhaDeExecucao
{
    public static void Metodo1()
    {
        Console.WriteLine("[Inicio] - Metodo1");
        try
        {
            Metodo2();
        }
        catch (Exception ex)
        {
            Console.WriteLine ($"Erro ao chamar método 2!\n{ex.ToString()}");
        }
       
        Console.WriteLine("[Fim] - Metodo1");
    }

    public static void Metodo2()
    {
        Console.WriteLine("[Inicio] - Metodo2");

        Usuario usuario = null;

        try
        {
            Console.WriteLine(usuario.Nome);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Usuário foi instanciado de forma nula!\n{ex.Message}");
        }

        Console.WriteLine("[Fim] - Metodo2");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("[Inicio] - Main");
        try
        {
            Metodo1();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Falha ao chamar método 1" + ex.Message);  
        }

        Console.WriteLine("[Fim] - Main");
    }
}

public class Usuario
{
    public string Nome { get; set; }

    public Usuario(string nome)
    {
        Nome = nome;
    }
}
