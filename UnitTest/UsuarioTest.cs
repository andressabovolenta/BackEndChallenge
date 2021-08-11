using BackEndChallenge.Interface;
using BackEndChallenge.Service;
using Xunit;

namespace UnitTest
{
    public class UsuarioTest
    {
        IUsuarioService _service = new UsuarioService();

        [Fact]
        public async void Usuario_ValidaSenha_Sucesso()
        {
            var response = await _service.ValidarSenha("AbTp9!fok");
            Assert.True(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste1()
        {
            var response = await _service.ValidarSenha("");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste2()
        {
            var response = await  _service.ValidarSenha("aa");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste3()
        {
            var response = await _service.ValidarSenha("ab");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste4()
        {
            var response = await _service.ValidarSenha("AAAbbbCc");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste5()
        {
            var response = await _service.ValidarSenha("AbTp9!foo");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste6()
        {
            var response = await _service.ValidarSenha("AbTp9!foA");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_Teste7()
        {
            var response = await _service.ValidarSenha("AbTp9 fok");
            Assert.False(response.IsValid);
        }
    }
}
