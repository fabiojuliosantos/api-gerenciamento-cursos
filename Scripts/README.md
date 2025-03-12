# Scripts da criação do banco

CREATE DATABASE CursoAPI_DB;

USE CursoAPI_DB;

CREATE TABLE Alunos 
(
	AlunoID INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR (100) NOT NULL,
	Idade INT NOT NULL,
	Email VARCHAR (50) NOT NULL UNIQUE,
	DataMatricula DATETIME NOT NULL
);

CREATE TABLE Cursos 
(
	CursoID INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR (100) NOT NULL,
	Descricao VARCHAR (500),
	CargaHoraria INT NOT NULL
);

CREATE TABLE Matriculas 
(
	MatriculaID INT PRIMARY KEY IDENTITY (1,1),
	AlunoID INT NOT NULL,
	FOREIGN KEY (AlunoID) REFERENCES Alunos(AlunoID),
	CursoID INT NOT NULL,
	FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID),
	DataMatricula DATETIME NOT NULL
);

# Inserção no Banco

# Alunos : 

INSERT INTO Alunos (Nome, Idade, Email, DataMatricula)
VALUES
('João Silva', 20, 'joao.silva@example.com', GETDATE()),
('Maria Oliveira', 22, 'maria.oliveira@example.com', GETDATE()),
('Carlos Souza', 19, 'carlos.souza@example.com', GETDATE()),
('Ana Costa', 21, 'ana.costa@example.com', GETDATE()),
('Pedro Santos', 23, 'pedro.santos@example.com', GETDATE()),
('Luiza Fernandes', 20, 'luiza.fernandes@example.com', GETDATE()),
('Rafael Lima', 24, 'rafael.lima@example.com', GETDATE()),
('Fernanda Alves', 22, 'fernanda.alves@example.com', GETDATE()),
('Bruno Pereira', 21, 'bruno.pereira@example.com', GETDATE()),
('Juliana Ribeiro', 19, 'juliana.ribeiro@example.com', GETDATE()),
('Lucas Martins', 20, 'lucas.martins@example.com', GETDATE()),
('Mariana Rocha', 22, 'mariana.rocha@example.com', GETDATE()),
('Gustavo Henrique', 19, 'gustavo.henrique@example.com', GETDATE()),
('Patrícia Gomes', 21, 'patricia.gomes@example.com', GETDATE()),
('Ricardo Nunes', 23, 'ricardo.nunes@example.com', GETDATE()),
('Camila Castro', 20, 'camila.castro@example.com', GETDATE()),
('Diego Almeida', 24, 'diego.almeida@example.com', GETDATE()),
('Amanda Dias', 22, 'amanda.dias@example.com', GETDATE()),
('Roberto Junior', 21, 'roberto.junior@example.com', GETDATE()),
('Tatiane Souza', 19, 'tatiane.souza@example.com', GETDATE()),
('Felipe Costa', 20, 'felipe.costa@example.com', GETDATE()),
('Vanessa Lima', 22, 'vanessa.lima@example.com', GETDATE()),
('Leonardo Oliveira', 19, 'leonardo.oliveira@example.com', GETDATE()),
('Cristina Santos', 21, 'cristina.santos@example.com', GETDATE()),
('Marcos Ribeiro', 23, 'marcos.ribeiro@example.com', GETDATE()),
('Isabela Fernandes', 20, 'isabela.fernandes@example.com', GETDATE()),
('Thiago Alves', 24, 'thiago.alves@example.com', GETDATE()),
('Larissa Pereira', 22, 'larissa.pereira@example.com', GETDATE()),
('Eduardo Gomes', 21, 'eduardo.gomes@example.com', GETDATE()),
('Renata Castro', 19, 'renata.castro@example.com', GETDATE()),
('Gabriel Nunes', 20, 'gabriel.nunes@example.com', GETDATE()),
('Beatriz Rocha', 22, 'beatriz.rocha@example.com', GETDATE()),
('Rodrigo Martins', 19, 'rodrigo.martins@example.com', GETDATE()),
('Sandra Dias', 21, 'sandra.dias@example.com', GETDATE()),
('Alexandre Junior', 23, 'alexandre.junior@example.com', GETDATE()),
('Cláudia Lima', 20, 'claudia.lima@example.com', GETDATE()),
('André Oliveira', 24, 'andre.oliveira@example.com', GETDATE()),
('Daniela Costa', 22, 'daniela.costa@example.com', GETDATE()),
('Marcelo Souza', 21, 'marcelo.souza@example.com', GETDATE()),
('Tânia Ribeiro', 19, 'tania.ribeiro@example.com', GETDATE()),
('Paulo Fernandes', 20, 'paulo.fernandes@example.com', GETDATE()),
('Helena Alves', 22, 'helena.alves@example.com', GETDATE()),
('Márcio Pereira', 19, 'marcio.pereira@example.com', GETDATE()),
('Lúcia Gomes', 21, 'lucia.gomes@example.com', GETDATE()),
('Fábio Castro', 23, 'fabio.castro@example.com', GETDATE()),
('Simone Nunes', 20, 'simone.nunes@example.com', GETDATE()),
('Vinícius Rocha', 24, 'vinicius.rocha@example.com', GETDATE()),
('Elaine Martins', 22, 'elaine.martins@example.com', GETDATE()),
('César Dias', 21, 'cesar.dias@example.com', GETDATE()),
('Regina Junior', 19, 'regina.junior@example.com', GETDATE());

# Cursos : 

INSERT INTO Cursos (Nome, Descricao, CargaHoraria)
VALUES
('Programação em Python', 'Aprenda Python do básico ao avançado.', 80),
('Banco de Dados SQL', 'Domine SQL e modelagem de bancos de dados.', 60),
('Desenvolvimento Web', 'Crie sites com HTML, CSS e JavaScript.', 100),
('Machine Learning', 'Introdução à inteligência artificial.', 120),
('DevOps', 'Aprenda CI/CD, Docker e Kubernetes.', 90),
('Segurança da Informação', 'Proteja sistemas e redes contra ataques.', 70),
('Cloud Computing', 'Aprenda AWS, Azure e Google Cloud.', 85);

# Matriculas

INSERT INTO Matriculas (AlunoID, CursoID, DataMatricula)
VALUES
(1, 1, GETDATE()),  -- João Silva no curso de Python
(2, 2, GETDATE()),  -- Maria Oliveira no curso de SQL
(3, 3, GETDATE()),  -- Carlos Souza no curso de Desenvolvimento Web
(4, 4, GETDATE()),  -- Ana Costa no curso de Machine Learning
(5, 5, GETDATE()),  -- Pedro Santos no curso de DevOps
(6, 6, GETDATE()),  -- Luiza Fernandes no curso de Segurança da Informação
(7, 7, GETDATE()),  -- Rafael Lima no curso de Cloud Computing
(8, 1, GETDATE()),  -- Fernanda Alves no curso de Python
(9, 2, GETDATE()),  -- Bruno Pereira no curso de SQL
(10, 3, GETDATE()), -- Juliana Ribeiro no curso de Desenvolvimento Web
(11, 4, GETDATE()), -- Lucas Martins no curso de Machine Learning
(12, 5, GETDATE()), -- Mariana Rocha no curso de DevOps
(13, 6, GETDATE()), -- Gustavo Henrique no curso de Segurança da Informação
(14, 7, GETDATE()), -- Patrícia Gomes no curso de Cloud Computing
(15, 1, GETDATE()), -- Ricardo Nunes no curso de Python
(16, 2, GETDATE()), -- Camila Castro no curso de SQL
(17, 3, GETDATE()), -- Diego Almeida no curso de Desenvolvimento Web
(18, 4, GETDATE()), -- Amanda Dias no curso de Machine Learning
(19, 5, GETDATE()), -- Roberto Junior no curso de DevOps
(20, 6, GETDATE()), -- Tatiane Souza no curso de Segurança da Informação
(21, 7, GETDATE()), -- Felipe Costa no curso de Cloud Computing
(22, 1, GETDATE()), -- Vanessa Lima no curso de Python
(23, 2, GETDATE()), -- Leonardo Oliveira no curso de SQL
(24, 3, GETDATE()), -- Cristina Santos no curso de Desenvolvimento Web
(25, 4, GETDATE()), -- Marcos Ribeiro no curso de Machine Learning
(26, 5, GETDATE()), -- Isabela Fernandes no curso de DevOps
(27, 6, GETDATE()), -- Thiago Alves no curso de Segurança da Informação
(28, 7, GETDATE()), -- Larissa Pereira no curso de Cloud Computing
(29, 1, GETDATE()), -- Eduardo Gomes no curso de Python
(30, 2, GETDATE()), -- Renata Castro no curso de SQL
(31, 3, GETDATE()), -- Gabriel Nunes no curso de Desenvolvimento Web
(32, 4, GETDATE()), -- Beatriz Rocha no curso de Machine Learning
(33, 5, GETDATE()), -- Rodrigo Martins no curso de DevOps
(34, 6, GETDATE()), -- Sandra Dias no curso de Segurança da Informação
(35, 7, GETDATE()), -- Alexandre Junior no curso de Cloud Computing
(36, 1, GETDATE()), -- Cláudia Lima no curso de Python
(37, 2, GETDATE()), -- André Oliveira no curso de SQL
(38, 3, GETDATE()), -- Daniela Costa no curso de Desenvolvimento Web
(39, 4, GETDATE()), -- Marcelo Souza no curso de Machine Learning
(40, 5, GETDATE()); -- Tânia Ribeiro no curso de DevOps