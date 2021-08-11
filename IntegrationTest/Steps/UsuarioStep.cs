using BackEndChallenge;
using BackEndChallenge.Model;
using BoDi;
using RestSharp;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace IntegratedTest
{
    [Binding]
    public class UsuarioStep
    {
        protected IRestClient _restClient;
        protected IRestRequest _restRequest;
        protected IRestResponse _restResponse;
        protected IObjectContainer _objectContainer;
        protected Uri _baseHost = new Uri("https://localhost:5001/");
        private Uri _host;
        private string _senha;

        public UsuarioStep(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _restClient = new RestClient();
            _restRequest = new RestRequest();
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restClient);
            _objectContainer.RegisterInstanceAs(_restRequest);
            _objectContainer.RegisterInstanceAs(_restResponse);
        }

        [Given(@"que o host é '(.*)'")]
        public void InserirHost(string uri) => _host = new Uri(uri);

        [Given(@"que o endpoint é '(.*)'")]
        public void DadoQueAUrlDoEndpointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"o método http é '(.*)'")]
        public void DadoOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;
        }

        [Given(@"a senha seja '(.*)'")]
        public void DadoASenhaSeja(string senha)
        {
            this._senha = senha;
        }

        [When(@"validar a senha")]
        public void QuandoValidarASenha() => ValidarSenha();


        [Then(@"a resposta será (.*)")]
        public void EntaoARespostaSera(string valido)
        {
            UsuarioResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<UsuarioResponse>(_restResponse.Content);

            Assert.Equal(valido.Trim(), (response.IsValid == true ? "'sim'" : "'não'"));
        }


        private void ValidarSenha()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_host == null)
                _restClient.BaseUrl = _baseHost;
            else
                _restClient.BaseUrl = _host;

            if (_senha != "" && _senha != null)
                _restRequest.AddParameter("senha", _senha);

            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}