using System.Diagnostics;
using UsuarioLib;

//Usuario usuario = 
//    new Usuario(
//        "Daniel", 
//        "daniel@email.com",
//        new List<string>() {"12345678"});

//Usuario usuario2 =
//    new Usuario(
//        "Luis",
//        "luis@email.com",
//        new List<string>() { "87654321" });


//12345678
//usuario.ExibeTelefones();

//efetuar a padronização
//usuario.PadronizaTelefones();

//912345678
//usuario.ExibeTelefones();

//Stopwatch sw = Stopwatch.StartNew();

//for (int i = 0; i < 1000000000; i++)
//{
//    Coordenada coordenada = new(123.456, -123.456);
//    var latitude = coordenada.Latitude;
//    var longitude = coordenada.Longitude;
//}

//sw.Stop();

//Console.WriteLine(sw.Elapsed.TotalMilliseconds);

//FormularioDto dto1 = new("Daniel", "11111111111", "Programador")
//{
//    Idade = 100
//};

//FormularioDto dto2 = new("Daniel", "11111111111", "Programador")
//{
//    Idade = 100
//};

//Console.WriteLine(dto1 == dto2);

//UsuarioDto dto3 = new()
//{
//    Nome = "Daniel",
//    Email = "daniel@gmail.com",
//    Telefones = null
//};

//UsuarioDto dto4 = new()
//{
//    Nome = "Daniel",
//    Email = "daniel@gmail.com",
//    Telefones = null
//};

//Console.WriteLine(dto3 == dto4);

Stopwatch sw1 = Stopwatch.StartNew();

for (int i = 0; i < 1000000000; i++)
{
    Coordenada coordenada = new(123.456, -123.456);
    var latitude = coordenada.Latitude;
    var longitude = coordenada.Longitude;
}

sw1.Stop();

Console.WriteLine(sw1.Elapsed.TotalMilliseconds);

sw1.Start();

for (int i = 0; i < 1000000000; i++)
{
    //UsuarioDto dto5 = new()
    //{
    //    Nome = "Daniel",
    //    Email = "daniel@gmail.com",
    //    Telefones = null
    //};

    FormularioDto dto2 = new("Daniel", "11111111111", "Programador", 100);
    var idade = dto2.Idade;
    var nome = dto2.Nome;
}

sw1.Stop();
Console.WriteLine(sw1.Elapsed.TotalMilliseconds);