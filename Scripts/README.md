# Scripts da criação do banco

CREATE DATABASE FaculdadeDB;

USE FaculdadeDB;

CREATE TABLE Alunos (
    AlunoID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Idade INT NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DataMatricula DATE NOT NULL
);

CREATE TABLE Cursos (
    CursoID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255),
    CargaHoraria INT NOT NULL
);

CREATE TABLE Matriculas (
    MatriculaID INT IDENTITY(1,1) PRIMARY KEY,
    AlunoID INT NOT NULL,
    CursoID INT NOT NULL,
    DataMatricula DATE NOT NULL,
    FOREIGN KEY (AlunoID) REFERENCES Alunos(AlunoID) ON DELETE CASCADE,
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID) ON DELETE CASCADE
);

ALTER TABLE Alunos 
ALTER COLUMN DataMatricula DATETIME;

ALTER TABLE Matriculas 
ALTER COLUMN DataMatricula DATETIME;

INSERT INTO Alunos (Nome, Idade, Email, DataMatricula)
VALUES 
('João Silva', 20, 'joao.silva@email.com', CONVERT(DATE, '2024-01-10')),
('Maria Oliveira', 22, 'maria.oliveira@email.com', CONVERT(DATE, '2024-01-15')),
('Carlos Santos', 19, 'carlos.santos@email.com', CONVERT(DATE, '2024-02-01')),
('Ana Souza', 21, 'ana.souza@email.com', CONVERT(DATE, '2024-02-05')),
('Pedro Almeida', 23, 'pedro.almeida@email.com', CONVERT(DATE, '2024-02-10')),
('Fernanda Costa', 20, 'fernanda.costa@email.com', CONVERT(DATE, '2024-03-01')),
('Lucas Rocha', 22, 'lucas.rocha@email.com', CONVERT(DATE, '2024-03-05')),
('Beatriz Lima', 19, 'beatriz.lima@email.com', CONVERT(DATE, '2024-03-10')),
('Ricardo Mendes', 24, 'ricardo.mendes@email.com', CONVERT(DATE, '2024-04-01')),
('Juliana Pereira', 21, 'juliana.pereira@email.com', CONVERT(DATE, '2024-04-05')),
('Bruno Martins', 22, 'bruno.martins@email.com', CONVERT(DATE, '2024-04-10')),
('Gabriela Nogueira', 20, 'gabriela.nogueira@email.com', CONVERT(DATE, '2024-04-15')),
('Thiago Barbosa', 23, 'thiago.barbosa@email.com', CONVERT(DATE, '2024-05-01')),
('Larissa Fernandes', 19, 'larissa.fernandes@email.com', CONVERT(DATE, '2024-05-05')),
('Eduardo Ramos', 21, 'eduardo.ramos@email.com', CONVERT(DATE, '2024-05-10')),
('Camila Teixeira', 22, 'camila.teixeira@email.com', CONVERT(DATE, '2024-06-01')),
('Gustavo Ribeiro', 20, 'gustavo.ribeiro@email.com', CONVERT(DATE, '2024-06-05')),
('Vanessa Souza', 24, 'vanessa.souza@email.com', CONVERT(DATE, '2024-06-10')),
('Fábio Cardoso', 23, 'fabio.cardoso@email.com', CONVERT(DATE, '2024-07-01')),
('Isabela Duarte', 21, 'isabela.duarte@email.com', CONVERT(DATE, '2024-07-05')),
('Rodrigo Moreira', 19, 'rodrigo.moreira@email.com', CONVERT(DATE, '2024-07-10')),
('Tatiane Lopes', 22, 'tatiane.lopes@email.com', CONVERT(DATE, '2024-08-01'));

INSERT INTO Cursos (Nome, Descricao, CargaHoraria)
VALUES 
('Engenharia de Software', 'Curso voltado para o desenvolvimento de software', 360),
('Banco de Dados', 'Ensino sobre modelagem e administração de BD', 280),
('Redes de Computadores', 'Infraestrutura e segurança de redes', 300),
('Inteligência Artificial', 'Aplicações e fundamentos de IA', 320),
('Segurança da Informação', 'Proteção e criptografia de dados', 270),
('Ciência de Dados', 'Análise e interpretação de dados', 350),
('Desenvolvimento Web', 'Criação de aplicações web', 400),
('DevOps', 'Integração e entrega contínua de software', 290),
('Gestão de Projetos de TI', 'Gerenciamento de equipes e projetos', 310),
('Computação em Nuvem', 'Armazenamento e processamento em nuvem', 330);

INSERT INTO Matriculas (AlunoID, CursoID, DataMatricula)
SELECT 
    AlunoID, 
    (SELECT TOP 1 CursoID FROM Cursos ORDER BY NEWID()), 
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
FROM Alunos
WHERE AlunoID BETWEEN 3 AND 24;

UPDATE Matriculas
SET CursoID = 1,  -- Atribuindo curso 1
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 3;

UPDATE Matriculas
SET CursoID = 2,  -- Atribuindo curso 2
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 4;

UPDATE Matriculas
SET CursoID = 3,  -- Atribuindo curso 3
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 5;

UPDATE Matriculas
SET CursoID = 4,  -- Atribuindo curso 4
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 6;

UPDATE Matriculas
SET CursoID = 5,  -- Atribuindo curso 5
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 7;

UPDATE Matriculas
SET CursoID = 6,  -- Atribuindo curso 6
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 8;

UPDATE Matriculas
SET CursoID = 7,  -- Atribuindo curso 7
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 9;

UPDATE Matriculas
SET CursoID = 8,  -- Atribuindo curso 8
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 10;

UPDATE Matriculas
SET CursoID = 9,  -- Atribuindo curso 9
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 11;

UPDATE Matriculas
SET CursoID = 10,  -- Atribuindo curso 10
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 12;

UPDATE Matriculas
SET CursoID = 2,  -- Atribuindo curso 2
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 14;

UPDATE Matriculas
SET CursoID = 3,  -- Atribuindo curso 3
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 15;

UPDATE Matriculas
SET CursoID = 4,  -- Atribuindo curso 4
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 16;

UPDATE Matriculas
SET CursoID = 5,  -- Atribuindo curso 5
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 17;

UPDATE Matriculas
SET CursoID = 6,  -- Atribuindo curso 6
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 18;

UPDATE Matriculas
SET CursoID = 7,  -- Atribuindo curso 7
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 19;

UPDATE Matriculas
SET CursoID = 8,  -- Atribuindo curso 8
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 20;

UPDATE Matriculas
SET CursoID = 9,  -- Atribuindo curso 9
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 21;

UPDATE Matriculas
SET CursoID = 10,  -- Atribuindo curso 10
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 22;

UPDATE Matriculas
SET CursoID = 1,  -- Atribuindo curso 1
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 23;

UPDATE Matriculas
SET CursoID = 2,  -- Atribuindo curso 2
    DataMatricula = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2024-01-01')
WHERE AlunoID = 24;