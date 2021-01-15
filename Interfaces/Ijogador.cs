using System.Collections.Generic;
using EPLAYERS_ASPNETCORE.Models;

namespace E_PLAYERSS.Interfaces
{
    public interface Ijogador
    {
         //Criar
        void Create(Jogador j);
        //Ler
        List<Jogador> ReadAll();
        //Alterar
        void Update(Jogador j);
        //Excluir
        void Delete(int id);  
    }
}