using CadastroAluno.Models;
using Xunit;

namespace CadastroAlunoTest
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("Juninho", "3")]
        [InlineData("", "")]
        [InlineData("Marcelo ", " 2")]
        [InlineData("Antonio", "4")]
        [InlineData("Victor", "11")]
        [InlineData(" ", " ")]
        [InlineData("", "")]
        public void AtualizarDados(string nome, string turma)
        {

            Aluno aluno = new Aluno();
            aluno.AtualizarDados(nome, turma);
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]

        public void VerificarAprovacao_MediaMaior(int n1)
        {
            Aluno aluno = new Aluno();
            aluno.Media = n1;
            var media = aluno.VerificaAprovacao();
            Assert.True(media);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void AtualizarDados_Media(double novaMedia)
        {

            Aluno aluno = new Aluno();
            aluno.AtualizaMedia(novaMedia);
            Assert.Equal(aluno.Media, novaMedia);
        }
    }
}