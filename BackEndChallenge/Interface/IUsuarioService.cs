using BackEndChallenge.Model;

namespace BackEndChallenge.Interface
{
    public interface IUsuarioService
    {
        UsuarioResponse ValidarSenha(string senha);
    }
}
