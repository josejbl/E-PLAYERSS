using System.Collections.Generic;
using System.IO;

namespace EPLAYERS_ASPNETCORE.Models
{
    public class EplayerBase
    {
        public void CreateFolderAndFile(string _path)
        { 
    
        //Datebase/Equipe.cvs
        string folder = _path.Split("/")[0];

        //string file   = _path.Split("/")[1];
        if(!Directory.Exists(_path))
        {
            Directory.CreateDirectory(folder);
        }

        if(!File.Exists(_path))
        {
            File.Create(_path);
        }


        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string>linhas = new List<string>();

            //Using - > responsável por abrir e fechar arquivos automaticamente

            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                //Percorrer as linhas comum laço While

                while((linha = file.ReadLine())!=null)
                {
                    linhas.Add(linha);
                }

            }

            return linhas;
        }

           public void RewriteCSV(string path, List<string> Linhas)
           {
               //StreamWrite -> Escrever dados em um arquivo
               using (StreamWriter output = new StreamWriter(path))
               {
                   foreach( var item in Linhas)
                   {

                   output.Write(item + '\n');
                   }

               }


           }











    }

   
}