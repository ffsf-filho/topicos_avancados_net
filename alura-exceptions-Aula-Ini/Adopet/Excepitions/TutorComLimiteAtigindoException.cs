using System.Security.Cryptography;

namespace Adopet.Excepitions;

public class TutorComLimiteAtigindoException : AdocaoException
{
    public TutorComLimiteAtigindoException(string? mensagem) 
        : base(mensagem) { }

    public TutorComLimiteAtigindoException(string? mensagem, Exception? excecaoInterna)
    : base(mensagem, excecaoInterna) { }

}
