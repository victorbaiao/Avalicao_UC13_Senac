using CadastroAluno.Models;
using System.Collections.Generic;

namespace CadastroAluno.Contracts
{
    public interface IAlunoRepository
    {
        List<Aluno> Index();
        Aluno Details(int? id);
        Aluno Create(Aluno cliente);
        Aluno Edit(int? id, Aluno cliente);
        int Delete(int id);
    }
}