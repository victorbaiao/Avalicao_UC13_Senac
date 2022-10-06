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
            alunoValido = new Aluno()
            {
                Id = 1,
                Nome = "Victor",
                Media = 1,
                Turma = "1"
            };
        }

        [Fact]
        public void ReturnOkResult_da_Index()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ChamandoAIndexRepositorio()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);

            controller.Create(alunoValido);

            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
        }
        [Fact]
        public void SemAlunoRetornaNotFound()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);

            var consulta = controller.Create();

            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact]
        public void RetornaUmBadRequestSeAlunoNaoExistir()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var consulta = controller.Create();

            Assert.IsType<BadRequestResult>(consulta);
        }
        [Fact]
        public void ModelChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1));

            controller.Create();

            _repository.Verify(repo => repo.Details(1), Times.Once);
        }
        [Fact]
        public void ExecutaEDaCerto()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);

            var result = controller.Create();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ChamaAViewResukt()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);

            var result = controller.Create(alunoValido);

            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void HttpPost()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);

            var result = controller.Create(alunoValido);

            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void RevieWDeDados()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);

            var result = controller.Create(alunoValido);

            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);

            Assert.IsType<ViewResult>(result);
        }
    }
}