namespace Adopet.Excepitions;

public class PetEmProcessoDeAdocaoException : AdocaoException
{
    public PetEmProcessoDeAdocaoException(string? mensagem) 
        : base(mensagem) { }

    public PetEmProcessoDeAdocaoException(string? mensagem, Exception? excecaoInterna)
    : base(mensagem, excecaoInterna) { }
}
