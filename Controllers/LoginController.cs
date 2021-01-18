using System.Collections.Generic;
using EPLAYERS_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_PLAYERSS.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        
        

        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        {

            return View();
        }

        [Route("Logar")]
        public ActionResult Logar(IFormCollection form)
        {
            // Lemos todos os arquivos do CSV
            List<string> csv = jogadorModel.ReadAllLinesCSV(jogadorModel.PATH);

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && 
                x.Split(";")[3] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                //Criamos uma sessão com os dados do usuásrio
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }
        [Route("Logolt")]
        public ActionResult Logolt()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}