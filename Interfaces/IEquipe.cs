using System.Collections.Generic;
using EPLAYERS_ASPNETCORE.Models;

namespace EPLAYERS_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
        //Método de CRUD - contrato
        void Creat(Equipe e);
        List<Equipe> ReadA11();
        void Update(Equipe e);
        void Delete(int id);
        


    }
}