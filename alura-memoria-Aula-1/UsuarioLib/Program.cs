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

FormularioDto dto1 = new("Daniel", "11111111111", "Programador")
{
    Idade = 100
};

FormularioDto dto2 = new("Daniel", "11111111111", "Programador")
{
    Idade = 100
};

Console.WriteLine(dto1 == dto2);

UsuarioDto dto3 = new()
{
    Nome = "Daniel",
    Email = "daniel@gmail.com",
    Telefones = null
};

UsuarioDto dto4 = new()
{
    Nome = "Daniel",
    Email = "daniel@gmail.com",
    Telefones = null
};

Console.WriteLine(dto3 == dto4);