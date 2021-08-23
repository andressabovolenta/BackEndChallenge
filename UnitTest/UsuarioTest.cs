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
            var response = await _service.ValidarSenha("AbCd1!EfG");
            Assert.True(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_SenhaNula()
        {
            var response = await _service.ValidarSenha("");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_MenosQueNoveCaracteres()
        {
            var response = await  _service.ValidarSenha("AbCd1!Ef");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_SemLetraMinuscula()
        {
            var response = await _service.ValidarSenha("ABCD1!EFG");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_SemLetraMaiuscula()
        {
            var response = await _service.ValidarSenha("abcd1!egf");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_SemDigitoDecimal()
        {
            var response = await _service.ValidarSenha("AbCd!EfGh");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_EspacoEmBranco()
        {
            var response = await _service.ValidarSenha("AbCd 1!EfG");
            Assert.False(response.IsValid);
        }

        [Fact]
        public async void Usuario_ValidaSenha_Erro_CaractereRepetido()
        {
            var response = await _service.ValidarSenha("AbCd1!EfA");
            Assert.False(response.IsValid);
        }
    }
}
