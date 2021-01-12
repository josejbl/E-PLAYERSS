using System.Collections.Generic;
using EPLAYERS_ASPNETCORE.Models;

namespace EPLAYERS_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
        //Método de CRUD - contrato
        void Create(Equipe e);
        List<Equipe> ReadAll();
        void Update(Equipe e);
        void Delete(int id);
        


    }
}