# Scripts da criação do banco

-- CREATES

create table alunos(
ALUNOID INT PRIMARY KEY IDENTITY(1,1),
NOME VARCHAR(50) NOT NULL,
IDADE INT NOT NULL,	
EMAIL VARCHAR(150) NOT NULL,
DATAMATRICULA DATETIME NOT NULL

);

CREATE TABLE CURSOS(
CURSOID INT PRIMARY KEY IDENTITY(1,1),
NOME VARCHAR(50) NOT NULL,
DESCRICAO VARCHAR(200),
CARGAHORARIA INT NOT NULL

);


CREATE TABLE MATRICULAS(
MATRICULAID INT PRIMARY KEY IDENTITY(1,1),
ALUNOID INT FOREIGN KEY REFERENCES ALUNOS(ALUNOID),
CURSOID INT FOREIGN KEY REFERENCES CURSOS(CURSOID),
DATAMATRICULA DATETIME NOT NULL
);


-- INSERTS

INSERT INTO MATRICULAS (ALUNOID, CURSOID, DATAMATRICULA)  
VALUES  
(1, 3, '2024-03-12 10:30:00'),  
(2, 1, '2024-03-11 09:15:00'),  
(3, 5, '2024-03-10 14:45:00'),  
(4, 2, '2024-03-09 08:20:00'),  
(5, 4, '2024-03-08 16:10:00');  


INSERT INTO CURSOS (NOME, DESCRICAO, CARGAHORARIA)  
VALUES  
('Análise de Dados', 'Curso voltado para análise e interpretação de dados.', 120),  
('Desenvolvimento Web', 'Curso completo sobre desenvolvimento de sites e aplicações web.', 200),  
('Segurança da Informação', 'Aprenda sobre cibersegurança e proteção de dados.', 180),  
('Banco de Dados', 'Curso sobre modelagem, administração e otimização de bancos de dados.', 150),  
('Inteligência Artificial', 'Introdução a IA e aprendizado de máquina.', 160);  



INSERT INTO alunos (NOME, IDADE, EMAIL, DATAMATRICULA)  
VALUES  
('Lucas Silva', 22, 'lucas.silva@email.com', '2024-03-12 10:30:00'),  
('Mariana Souza', 25, 'mariana.souza@email.com', '2024-03-11 09:15:00'),  
('Carlos Mendes', 20, 'carlos.mendes@email.com', '2024-03-10 14:45:00'),  
('Fernanda Lima', 23, 'fernanda.lima@email.com', '2024-03-09 08:20:00'),  
('João Pereira', 21, 'joao.pereira@email.com', '2024-03-08 16:10:00');  


