using System;
using System.Collections.Generic;
using System.IO;
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
           
            //Upload Início

            //Verificamos se o usuário selecionou um arqiuvo
            if (form.Files.Count >0)
            {
                //Recebemos o arquivo que o usuário enviou e armazenamos na variável file
                var file   = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                //Verificamos se o diretorio (patejá existe)
                //De não a, criamos 
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                                         //Localhost:5001                               Equipes imagem.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/",folder,file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;

            }
            else
            {
                novaEquipe.Imagem ="Logo.png";
            }



            //Upload Final

            //Chamamos o Método Create para salvar a nova equipe no CSV
            equipeModel.Create(novaEquipe);
            //Atualiza a lista de equipes na View
            ViewBag.Equipe = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/listar");

        }

        [Route("{id}")]
        public IActionResult Escluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/listar");
            
        }



    }
}