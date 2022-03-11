using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace api_caminhoneiro.Controllers
{
    [RoutePrefix("api")]
    public class CaminhoneiroController : ApiController
    {
        
        private static List<Caminhoneiro> listCaminhoneiros = new List<Caminhoneiro>();
        private static List<Caminhao> listCaminhoes = new List<Caminhao>();

        #region Caminhoneiro

        [AcceptVerbs("POST")]
        [Route("caminhoneiro")]
        public string CadastrarCaminhoneiro(Caminhoneiro caminhoneiro)
        {

            listCaminhoneiros.Add(caminhoneiro);

            return "Caminhoneiro cadastrado com sucesso!";
        }
        
        [AcceptVerbs("GET")]
        [Route("caminhoneiro")]
        public List<Caminhoneiro> ConsultarCaminhoneiros()
        {
            return listCaminhoneiros;
        }

        [AcceptVerbs("GET")]
        [Route("caminhoneiro/{codigo}")]
        public Caminhoneiro ConsultarCaminhoneiro(int codigo)
        {
            Caminhoneiro caminhoneiro = listCaminhoneiros.Where(n => n.Codigo == codigo)
                                               .Select(n => n)
                                               .First();

            return caminhoneiro;
        }
        
        [AcceptVerbs("GET")]
        [Route("orderby_nome_caminhoneiro")]
        public List<Caminhoneiro> NomeCaminhoneiroOrdemAlfabetica()
        {
            var list = listCaminhoneiros.OrderBy(x => x.Nome).ToList();

            return list;
        }

        [AcceptVerbs("GET")]
        [Route("orderby_sobrenome_caminhoneiro")]
        public List<Caminhoneiro> SobrenomeCaminhoneiroOrdemAlfabetica()
        {
            var list = listCaminhoneiros.OrderBy(x => x.UltimoNome).ToList();

            return list;
        }

        [AcceptVerbs("PUT")]
        [Route("caminhoneiro/{codigo}")]
        public string AlterarCaminhoneiro(Caminhoneiro caminhoneiro)
        {

            listCaminhoneiros.Where(n => n.Codigo == caminhoneiro.Codigo)
                         .Select(s =>
                         {
                             s.Nome = caminhoneiro.Nome;
                             s.UltimoNome = caminhoneiro.UltimoNome;
                             s.Endereco = caminhoneiro.Endereco;

                             return s;

                         }).ToList();



            return "Caminhoneiro alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("caminhoneiro/{codigo}")]
        public string ExcluirCaminhoneiro(int codigo)
        {

            Caminhoneiro caminhoneiro = listCaminhoneiros.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listCaminhoneiros.Remove(caminhoneiro);

            return "Caminhoneiro excluido com sucesso!";
        }

        #endregion

        #region Caminhao

        [AcceptVerbs("POST")]
        [Route("caminhao")]
        public string CadastrarCaminhao(Caminhao caminhao)
        {

            listCaminhoes.Add(caminhao);

            return "Caminhão cadastrado com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("caminhao")]
        public List<Caminhao> ConsultarCaminhoes()
        {
            return listCaminhoes;
        }

        [AcceptVerbs("GET")]
        [Route("caminhao/{codigo}")]
        public Caminhao ConsultarCaminhao(int codigo)
        {
            Caminhao caminhao = listCaminhoes.Where(n => n.Codigo == codigo)
                                               .Select(n => n)
                                               .First();

            return caminhao;
        }

        [AcceptVerbs("GET")]
        [Route("caminhaoproprietario/{codigo}")]
        public List<Caminhao> ConsultarCaminhaoPorCodigoCaminhoneiro(int codigo)
        {
             listCaminhoes.Where(n => n.CodigoProprietario == codigo)
                                               .Select(n => n)
                                               .First();

            return listCaminhoes;
        }
        
        [AcceptVerbs("PUT")]
        [Route("caminhao")]
        public string AlterarCaminhao(Caminhao caminhao)
        {

            listCaminhoes.Where(n => n.Codigo == caminhao.Codigo)
                         .Select(s =>
                         {

                             {

                                 s.CodigoProprietario = caminhao.CodigoProprietario;
                                 s.Marca = caminhao.Marca;
                                 s.Modelo = caminhao.Modelo;
                                 s.Placa = caminhao.Placa;
                                 s.Eixos = caminhao.Eixos;
                             }


                             return s;

                         }).ToList();



            return "Caminhão alterado com sucesso!";
        }
        
        [AcceptVerbs("DELETE")]
        [Route("caminhao/{codigo}")]
        public string ExcluirCaminhao(int codigo)
        {

            Caminhao caminhao = listCaminhoes.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listCaminhoes.Remove(caminhao);

            return "Caminhão excluido com sucesso!";
        }

        #endregion
    }
}
