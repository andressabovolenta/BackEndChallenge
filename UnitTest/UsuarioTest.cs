using BackEndChallenge.Interface;
using BackEndChallenge.Service;
using Xunit;

namespace UnitTest
{
    public class UsuarioTest
    {
        IUsuarioService _service = new UsuarioService();

        [Fact]
        public void Usuario_ValidaSenha_Sucesso()
        {
            var response = _service.ValidarSenha("AbTp9!fok");
            Assert.True(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_Vazio()
        {
            var response = _service.ValidarSenha("");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_MinimoCaracteres()
        {
            var response = _service.ValidarSenha("abcdefgh");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_()
        {
            var response = _service.ValidarSenha("ab");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_Teste4()
        {
            var response = _service.ValidarSenha("AAAbbbCc");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_Teste5()
        {
            var response = _service.ValidarSenha("AbTp9!foo");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_Teste6()
        {
            var response = _service.ValidarSenha("AbTp9!foA");
            Assert.False(response.IsValid);
        }

        [Fact]
        public void Usuario_ValidaSenha_Erro_Teste7()
        {
            var response = _service.ValidarSenha("AbTp9 fok");
            Assert.False(response.IsValid);
        }
    }
}
