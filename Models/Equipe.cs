using System;
using System.Collections.Generic;
using System.IO;
using EPLAYERS_ASPNETCORE.Interfaces;

namespace EPLAYERS_ASPNETCORE.Models
{
    public class Equipe : EplayerBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        //Criamos o método prara preparar a linha do CSV

        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";

        }

        public void Create(Equipe e)
        {
            //Preparamos um array de string para o mátodo AppendAllLines
            string[] linhas = {Prepare(e) };
            //Acrescentamos a nova linha
            File.AppendAllLines(PATH, linhas );
        }

        public void Delete(int id)
        {
            

           List<string> linhas = ReadAllLinesCSV(PATH);

           //2;SNK.Jpg
           //Removemos as linhas com o código comparado
           linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());


        
           //Reescrever o CSV com a lista a Alteradas

           RewriteCSV(PATH, linhas);

        }
        public List<Equipe> ReadA11()

        {
           List<Equipe> equipes = new List<Equipe>();

           //Lemos todas as linhas do CSV
           string[] linhas = File.ReadAllLines(PATH);

           foreach (var item in linhas)
           {
               //1;VivoKed;vivo;Jpg
               //[0] = 1
               //[0] = VivoKeyd
               //[2] = vivo.Jpg
               string[] linha = item.Split(";");

               Equipe novaEquipe = new Equipe();
               novaEquipe.IdEquipe = Int32.Parse( linha[0] );
               novaEquipe.Nome = linha[1];
               novaEquipe.Imagem = linha[2];

               equipes.Add(novaEquipe);

           }
            return equipes;
        }

        public void Update(Equipe e)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);

           //2;SNK.Jpg
           //Removemos as linhas com o código comparado
           linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());


           //Adicionamos na lista a equip altera
           linhas.Add( Prepare(e));

           //Reescrever o CSV com a lista a Alteradas

           RewriteCSV(PATH, linhas);



        }

        public void Creat(Equipe e)
        {
            throw new System.NotImplementedException();
        }
    }
}











            