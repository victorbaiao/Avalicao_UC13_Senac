using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace CadastroAlunoTest
{
    public class AlunoControllerTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;
        Aluno alunoValido2;
        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
            alunoValido = new Aluno()
            {
                Id = 1,
                Nome = "Nome",
                Media = 8,
                Turma = "Turma 1"
            };
            alunoValido2 = new Aluno()
            {
                Id = -2,
                Nome = "",
                Media = 11,
                Turma = ""
            };
        }
        [Fact]
        public void ChamaAlunos()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Index  Chama Repo 1 Vez")]
        public void ModelStateValida_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            controller.Index();
            //assert
            _repository.Verify(repo => repo.Index(), Times.Once);
        }
        [Fact(DisplayName = "ALuno Inexistente NotFound")]
        public void AlunoInexistente()
        {

            AlunosController controller = new AlunosController(_repository.Object);
            //
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);

            var consulta = controller.Details(2);

            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact(DisplayName = "Aluno Inexistente BadRequest")]
        public void AlunoInexistente_RetornBadRequest()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var consulta = controller.Details(-1);
            //assert
            Assert.IsType<BadRequestResult>(consulta);
        }
	
        public void Dados()
        {   ////Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            controller.ModelState.AddModelError("", "");
            //Action

            var result = controller.Create(alunoValido);
            // Assert
            _repository.Verify(repo => repo.Create(alunoValido2), Times.Never);
            Assert.IsType<ViewResult>(result);
        }

    }
}