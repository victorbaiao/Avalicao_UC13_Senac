# Atividade

## A atividade de testes será dividida em X etapas.

#### Etapa 1 - Preparação da Aplicação
- Página Home deve ser o Index (lista) de Alunos
- A comunicação com o repositório deverá ser feita atráves de Injeção de Dependência

#### Etapa 2 - Escrita de testes
- Escreva testes para a model Aluno
  - O método AtualizarDados() deve alterar as propriedades Nome e Turma com sucesso, independente dos dados passados.
  - O método VerificaAprovacao() deve retornar VERDADEIRO se, e somente se a média for maior ou igual a 5.
  - O método AtualizaMedia() deve atualizar a propriedade Media com o novo valor recebido.
  - Anote quais as inconsistências encontradas na model Aluno, mas não a corrija ainda.
- Escreva testes para a controller AlunosController
  - O método Index() deve retornar um OkResult, contendo ou não registros no banco.
  - O método Index() deve retornar chamar o repositório apenas uma vez.
  - O método Details() deve retornar uma BadRequest() para um id nulo, um NotFound() para um um id válido, mas aluno não encontrado no banco e uma ViewResult para um aluno encontrado.
   - O método Details() deve chamar o repositório apenas uma vez.
  - O método Create() deve sempre retornar uma View.
  - O método [HttpPost] Create() deve validar as propriedades da model Aluno, conforme suas regras. Caso válidas, deve chamar uma única vez o repositório e retornar a o RedirectToAction. Caso inválidas, retornar uma View.
  
