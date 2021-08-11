using BackEndChallenge.Interface;
using BackEndChallenge.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackEndChallenge.Service
{
    public class UsuarioService : IUsuarioService
    {
        public async Task<UsuarioResponse> ValidarSenha(string senha)
        {
            var retornoFalso = new UsuarioResponse()
            {
                Menssagem = "Senha inválida",
                StatusCode = StatusCodes.Status400BadRequest,
                IsValid = false
            };


            if (senha == null || senha == string.Empty)
                return retornoFalso;

            if (senha.Length < 9)
                return retornoFalso;

            if (senha.Contains(" ") == true)
                return retornoFalso;

            bool existeCaracterEspecial = Regex.IsMatch(senha, (@"[!@#$%^&*()\-+]"));

            if (!existeCaracterEspecial)
                return retornoFalso;

            bool temMaiusculo = false;
            bool temMinusculo = false;
            bool temDigito = false;

            char[] caracteres = new char[senha.Length];
            int i = 0;

            foreach (char c in senha)
            {
                temMaiusculo = Regex.IsMatch(senha, @"[A-Z]+") ? true : false;
                temMinusculo = Regex.IsMatch(senha, @"[a-z]+") ? true : false;
                temDigito = Regex.IsMatch(senha, @"[0-9]+") ? true : false;
                caracteres[i] = c;
                i++;
            }

            if (!temMaiusculo || !temMinusculo)
                return retornoFalso;

            if (!temDigito)
                return retornoFalso;


            bool existeRepeticaoDeCaracter = false;
            i = 0;

            foreach (char c in senha)
            {
                foreach (char a in caracteres)
                {
                    if (c == a)
                    {
                        if (Array.IndexOf(caracteres, a) != i)
                        {
                            existeRepeticaoDeCaracter = true;
                        }
                    }
                }

                i++;
            }

            if (existeRepeticaoDeCaracter)
                return retornoFalso;

            return new UsuarioResponse()
            {
                Menssagem = "Senha válida.",
                StatusCode = StatusCodes.Status200OK,
                IsValid = true
            };
        }
    }
}
