using BackEndChallenge.Model;
using System.Threading.Tasks;

namespace BackEndChallenge.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> ValidarSenha(string senha);
    }
}
