CREATE DATABASE FaculdadeDB;

-- alunos
CREATE TABLE Alunos (
    alunoID INT PRIMARY KEY IDENTITY(1,1), 
    matriculaID INT,                       
    nome VARCHAR(255) NOT NULL,             
    idade INT,                             
    email VARCHAR(255) UNIQUE NOT NULL,     
    dataMatricula DATE NOT NULL,           
   
);

-- cursos
CREATE TABLE Cursos (
    cursoID INT PRIMARY KEY IDENTITY(1,1),
	matriculaID INT,                        
    nome VARCHAR(255) NOT NULL,             
    descricao TEXT,                         
    cargaHoraria INT NOT NULL,              
    
);


--  matrículas (relacionamento entre alunos e cursos)
CREATE TABLE Matriculas (
    matriculaID INT PRIMARY KEY IDENTITY(1,1), 
    alunoID INT,                                
    cursoID INT,                                
    dataMatricula DATE NOT NULL,                
    FOREIGN KEY (alunoID) REFERENCES alunos(alunoID) ON DELETE CASCADE,  
    FOREIGN KEY (cursoID) REFERENCES cursos(cursoID) ON DELETE CASCADE,  
    CONSTRAINT uq_aluno_curso UNIQUE (alunoID, cursoID)  
);

--Cadastro Alunos
INSERT INTO Alunos (Nome, Idade, Email, DataMatricula)
VALUES
('João Silva', 20, 'joao.silva@email.com', '2023-08-01'),
('Maria Oliveira', 22, 'maria.oliveira@email.com', '2023-07-15'),
('Pedro Souza', 21, 'pedro.souza@email.com', '2023-09-10'),
('Ana Santos', 19, 'ana.santos@email.com', '2023-06-25'),
('Lucas Pereira', 23, 'lucas.pereira@email.com', '2023-05-30'),
('Beatriz Costa', 20, 'beatriz.costa@email.com', '2023-04-20'),
('Carlos Lima', 24, 'carlos.lima@email.com', '2023-03-05'),
('Juliana Almeida', 21, 'juliana.almeida@email.com', '2023-02-15'),
('Gabriel Rocha', 22, 'gabriel.rocha@email.com', '2023-01-10'),
('Larissa Martins', 19, 'larissa.martins@email.com', '2022-12-22'),
('Marcos Fernandes', 23, 'marcos.fernandes@email.com', '2022-11-12'),
('Fernanda Ribeiro', 22, 'fernanda.ribeiro@email.com', '2022-10-08'),
('Vinícius Silva', 21, 'vinicius.silva@email.com', '2022-09-19'),
('Roberta Alves', 20, 'roberta.alves@email.com', '2022-08-05'),
('Rafael Oliveira', 22, 'rafael.oliveira@email.com', '2022-07-22'),
('Carolina Souza', 23, 'carolina.souza@email.com', '2022-06-17'),
('Fabiano Pinto', 24, 'fabiano.pinto@email.com', '2022-05-05'),
('Camila Martins', 20, 'camila.martins@email.com', '2022-04-10'),
('Eduardo Costa', 21, 'eduardo.costa@email.com', '2022-03-22'),
('Gustavo Santos', 22, 'gustavo.santos@email.com', '2022-02-12'),
('Tatiane Lima', 19, 'tatiane.lima@email.com', '2022-01-18'),
('Felipe Rocha', 20, 'felipe.rocha@email.com', '2021-12-15'),
('Jéssica Silva', 23, 'jessica.silva@email.com', '2021-11-10'),
('Ricardo Almeida', 21, 'ricardo.almeida@email.com', '2021-10-05'),
('Juliana Rocha', 22, 'juliana.rocha@email.com', '2021-09-14'),
('Bruno Lima', 24, 'bruno.lima@email.com', '2021-08-22'),
('Aline Pereira', 19, 'aline.pereira@email.com', '2021-07-09'),
('Eduarda Costa', 21, 'eduarda.costa@email.com', '2021-06-03'),
('Felipe Almeida', 23, 'felipe.almeida@email.com', '2021-05-19'),
('Cláudia Souza', 22, 'claudia.souza@email.com', '2021-04-10'),
('Vitor Oliveira', 24, 'vitor.oliveira@email.com', '2021-03-15'),
('Gabriela Fernandes', 19, 'gabriela.fernandes@email.com', '2021-02-20'),
('Mariana Pinto', 22, 'mariana.pinto@email.com', '2021-01-14'),
('Leandro Rocha', 21, 'leandro.rocha@email.com', '2020-12-05'),
('Simone Lima', 23, 'simone.lima@email.com', '2020-11-19'),
('Amanda Almeida', 20, 'amanda.almeida@email.com', '2020-10-10'),
('Fabiana Costa', 24, 'fabiana.costa@email.com', '2020-09-15'),
('Vinícius Pereira', 22, 'vinicius.pereira@email.com', '2020-08-03'),
('Robson Souza', 21, 'robson.souza@email.com', '2020-07-08'),
('Tatiane Almeida', 23, 'tatiane.almeida@email.com', '2020-06-14'),
('Luciana Rocha', 24, 'luciana.rocha@email.com', '2020-05-05'),
('César Lima', 22, 'cesar.lima@email.com', '2020-04-19'),
('Douglas Souza', 21, 'douglas.souza@email.com', '2020-03-10'),
('Cristiane Fernandes', 19, 'cristiane.fernandes@email.com', '2020-02-20'),
('Ana Lima', 23, 'ana.lima@email.com', '2020-01-10'),
('Sabrina Almeida', 21, 'sabrina.almeida@email.com', '2019-12-15'),
('Paulo Pereira', 22, 'paulo.pereira@email.com', '2019-11-05'),
('Monique Silva', 23, 'monique.silva@email.com', '2019-10-18'),
('Denise Rocha', 24, 'denise.rocha@email.com', '2019-09-30'),
('Tatiane Santos', 19, 'tatiane.santos@email.com', '2019-08-25');


--Cadastro Cursos
INSERT INTO Cursos (Nome, Descricao, CargaHoraria)
VALUES
('Engenharia de Software', 'Curso de Engenharia de Software focado em desenvolvimento de sistemas.', 360),
('Administração', 'Curso de Administração com ênfase em gestão de negócios e recursos.', 320),
('Medicina', 'Curso de Medicina com formação para médicos clínicos gerais.', 500),
('Direito', 'Curso de Direito com foco em advocacia e legislação brasileira.', 400),
('Arquitetura', 'Curso de Arquitetura com ênfase em projetos e urbanismo.', 380),
('Design Gráfico', 'Curso de Design Gráfico focado em criação visual e publicidade.', 300),
('Psicologia', 'Curso de Psicologia com formação para psicólogos clínicos.', 380),
('Fisioterapia', 'Curso de Fisioterapia com ênfase em tratamentos e reabilitação.', 350),
('Engenharia Civil', 'Curso de Engenharia Civil focado na construção de obras e infraestrutura.', 420),
('Ciências da Computação', 'Curso de Ciência das Computação com foco em desenvolvimento de software.', 500),
('Biomedicina', 'Curso de Biomedicina com foco em análises clínicas e pesquisa.', 350),
('Veterinária', 'Curso de Veterinária com ênfase no cuidado de animais e saúde animal.', 500),
('Arqueologia', 'Curso de Arqueologia com ênfase na preservação do patrimonio cultural, bioarquologia e etnicidade.', 500),
('Análise e Desenvolvimento de Sistemas', 'Curso de Análise e Desenvolvimento de Sistema com foco em análise e desenvolvimento de software.', 500);

-- Matriculas
INSERT INTO Matriculas (AlunoID, CursoID, DataMatricula)
VALUES
(1, 1, '2023-08-01'),
(2, 2, '2023-07-15'),
(3, 3, '2023-09-10'),
(4, 4, '2023-06-25'),
(5, 5, '2023-05-30'),
(6, 6, '2023-04-20'),
(7, 7, '2023-03-05'),
(8, 8, '2023-02-15'),
(9, 9, '2023-01-10'),
(10, 10, '2022-12-22'),
(11, 11, '2022-11-12'),
(12, 12, '2022-10-08'),
(13, 13, '2022-09-19'),
(14, 14, '2022-08-05'),
(15, 1, '2023-08-01'),
(16, 2, '2023-07-15'),
(17, 3, '2023-09-10'),
(18, 4, '2023-06-25'),
(19, 5, '2023-05-30'),
(20, 6, '2023-04-20'),
(21, 7, '2023-03-05'),
(22, 8, '2023-02-15'),
(23, 9, '2023-01-10'),
(24, 10, '2022-12-22'),
(25, 11, '2022-11-12'),
(26, 12, '2022-10-08'),
(27, 13, '2022-09-19'),
(28, 14, '2022-08-05'),
(29, 1, '2023-08-01'),
(30, 2, '2023-07-15'),
(31, 3, '2023-09-10'),
(32, 4, '2023-06-25'),
(33, 5, '2023-05-30'),
(34, 6, '2023-04-20'),
(35, 7, '2023-03-05'),
(36, 8, '2023-02-15'),
(37, 9, '2023-01-10'),
(38, 10, '2022-12-22'),
(39, 11, '2022-11-12'),
(40, 12, '2022-10-08'),
(41, 13, '2022-09-19'),
(42, 14, '2022-08-05'),
(43, 1, '2023-08-01'),
(44, 2, '2023-07-15'),
(45, 3, '2023-09-10'),
(46, 4, '2023-06-25'),
(47, 5, '2023-05-30'),
(48, 6, '2023-04-20'),
(49, 6, '2023-04-20'),
(50, 6, '2023-04-20');



SELECT * FROM Alunos;

SELECT * FROM Cursos;

SELECT * FROM Matriculas;