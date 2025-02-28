# Criação de API para gerenciamento de cursos

### Criar uma API para gerenciar Cursos, Alunos e Matrícula de uma faculdade.

A API deve gerenciar três entidades diferentes: **Alunos**, **Cursos** e **Matrícula,** em um banco que deve se chamar FaculdadeDB.

Todos os scripts utilizados para o banco de dados devem ser postos na pasta Scripts

As entidades devem seguir a seguinte estrutura:

- **Alunos**:
    - AlunoID
    - Nome
    - Idade
    - E-mail
    - DataMatricula
- **Cursos:**
    - CursoID
    - Nome
    - Descricao
    - CargaHoraria
- **Matrículas:**
    - MatriculaID
    - AlunoID
    - CursoID
    - DataMatricula

📌 **Regras:**

✅ Um aluno pode estar matriculado em vários cursos.

✅ Um curso pode ter vários alunos matriculados.

✅ O email do aluno deve ser único.

📌 **Padrão de Rotas**

| Entidade | Método | Rota | Descrição |
| --- | --- | --- | --- |
| **Alunos** | `GET` | `/api/alunos` | Lista todos alunos com seus cursos |
|  | `GET` | `/api/alunos/{id}` | Retorna um aluno pelo ID com os cursos que ele está matriculado |
|  | `GET` | `/api/alunos/{pagina}/{quantidade}` | Retorna todos os alunos paginados com seus cursos |
|  | `POST` | `/api/alunos` | Cria um aluno |
|  | `PUT` | `/api/alunos/{id}` | Atualiza um aluno |
|  | `DELETE` | `/api/alunos/{id}` | Remove um aluno |
| **Cursos** | `GET` | `/api/cursos` | Lista cursos |
|  | `GET` | `/api/cursos/{id}` | Retorna um curso pelo ID  |
|  | `POST` | `/api/cursos` | Cria um curso |
|  | `PUT` | `/api/cursos/{id}` | Atualiza um curso |
|  | `DELETE` | `/api/cursos/{id}` | Remove um curso |
| **Matrículas** | `POST` | `/api/matriculas` | Matricula um aluno em um curso |
|  | `GET` | `/api/matriculas` | Lista todas as matrículas com paginação |
|  | `DELETE` | `/api/matriculas/{id}` | Cancela uma matrícula |

### Observações:

✅ Criar **Interfaces e Repositórios** (`IAlunoRepository`, `ICursoRepository`, etc.) para encapsular a lógica de banco de dados.

✅ Criar **Interfaces e Serviços** (IAlunoRepository, ICursoRepository, etc.) para encapsular o fluxo da aplicação.

✅ Implementar **injeção de dependência** (`services.AddScoped<IAlunoRepository, AlunoRepository>();`).

✅ Criar **Models** para representar os dados (`Aluno`, `Curso`, `Matricula`).

✅ Criar **DTOs** para controlar os dados enviados e recebidos (`AlunoDTO`, `CursoDTO`).

✅ Validar os dados que são utilizados para cadastrar um novo item (a validação pode ser feita por meio de DTOs).

✅ Criar **métodos assíncronos** (`Task<IEnumerable<Aluno>> BuscarAlunosAsync(...)`).

✅ Retornar **status HTTP apropriados** nos endpoints (`200 OK`, `400 Bad Request`, `404 Not Found`).

### Podem utilizar os projetos criados anteriormente como base para configuração do projeto atual, e como base para criação da API.