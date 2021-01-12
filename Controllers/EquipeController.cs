using System;
using EPLAYERS_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPLAYERS_ASPNETCORE.Controllers
{
    [Route("Equipe")]
    //http://localhost:5000/Equipe
    public class EquipeController : Controller
    {
        //Criamos uma intância de equipeModeu
        Equipe equipeModel = new Equipe();
        
        [Route("Listar")]
        public IActionResult Index()
        {
            //Listamos todas as equipes e inviamos para a View,através da ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            //Chamamos o Método Create para salvar a nova equipe no CSV
            equipeModel.Create(novaEquipe);
            //Atualiza a lista de equipes na View
            ViewBag.Equipe = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/listar");

        }



    }
}