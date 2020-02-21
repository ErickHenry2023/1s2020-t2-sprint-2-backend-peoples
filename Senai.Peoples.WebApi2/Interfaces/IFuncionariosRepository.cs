using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
  
    interface IFuncionariosRepository
    {
        List<FuncionariosDomain> Listar();
        void Cadastrar(FuncionariosDomain novoFuncionario);
        FuncionariosDomain BuscarPorId(int id);
        void AtualizarIdUrl(int id, FuncionariosDomain funcionario);
        void Deletar(int id);
    }
}
