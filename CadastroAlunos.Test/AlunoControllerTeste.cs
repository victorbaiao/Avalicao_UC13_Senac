using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTeste
{
    public class AlunoControllerTeste
    {
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;

        public AlunoControllerTeste()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public void IndexOkResult()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexRepository()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            controller.Create(alunoValido);
            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
        }

        [Fact]
        public void DetailsNotFound()
        {

        }

        [Fact]
        public void DetailsRepository()
        {

        }

        [Fact]
        public void CreateView()
        {

        }

        [Fact]
        public void HttpPostView()
        {

        }
    }
}