# Scripts da criação do banco

CREATE DATABASE FaculdadeDB;

CREATE TABLE Alunos (
    AlunoID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Idade INT,
    Email VARCHAR(255) NOT NULL UNIQUE,
    DataMatricula DATETIME NOT NULL
);

CREATE TABLE Cursos (
    CursoID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(500),
    CargaHoraria INT NOT NULL
);


CREATE TABLE Matriculas (
    MatriculaID INT IDENTITY(1,1) PRIMARY KEY,
    AlunoID INT NOT NULL,
    CursoID INT NOT NULL,
    DataMatricula DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (AlunoID) REFERENCES Alunos(AlunoID),
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID),
    UNIQUE (AlunoID, CursoID)
);
