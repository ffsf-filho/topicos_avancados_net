using System.Diagnostics;

namespace UsuarioLib;

public class Usuario
{

    public Usuario(string nome, string email, List<string> telefone)
    {
        Nome = nome;
        Email = email;
        Telefones = telefone;
        ChavesDeAcessoList = new(new Guid[10]);
        ChavesDeAcessoLinkedList = new();

        Stopwatch stopwatchList = new();
        stopwatchList.Start();

        for (int i = 0; i < 1000000; i++)
        {
            ChavesDeAcessoList.Add(Guid.NewGuid());
        }

        stopwatchList.Stop();
        Console.WriteLine($"Tempo total em ms: List {stopwatchList.Elapsed.TotalMilliseconds}");

        Stopwatch stopwatchLikedList = new();
        stopwatchLikedList.Start();
        ChavesDeAcessoLinkedList.AddFirst(Guid.NewGuid());

        for (int i = 0; i < 100000; i++) 
        {
            ChavesDeAcessoLinkedList.AddBefore(ChavesDeAcessoLinkedList.First!,Guid.NewGuid());
        }
        stopwatchLikedList.Stop();

        Console.WriteLine($"Tempo total em ms: LikedList {stopwatchLikedList.Elapsed.TotalMilliseconds}");
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<string> Telefones { get; set; }
    public List<Guid> ChavesDeAcessoList { get; set; }
    public LinkedList<Guid> ChavesDeAcessoLinkedList { get; set; }

    public void PadronizaTelefones()
    {
        Telefones = Telefones.Select(telefone =>
            telefone.Length == 8 ?
            telefone = "9" + telefone :
            telefone
        ).ToList();
    }

    public void ExibeTelefones()
    {
        Telefones.ForEach(telefone => Console.WriteLine(telefone));
    }
}