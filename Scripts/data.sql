USE API_CURSOS;

-- Inserindo 50 alunos
INSERT INTO ALUNOS (NOME, IDADE, EMAIL, DATAMATRICULA)
VALUES
    ('João Silva', 25, 'joao.silva@example.com', '2023-10-01 10:00:00'),
    ('Maria Oliveira', 30, 'maria.oliveira@example.com', '2023-10-02 11:30:00'),
    ('Carlos Souza', 22, 'carlos.souza@example.com', '2023-10-03 09:15:00'),
    ('Ana Costa', 28, 'ana.costa@example.com', '2023-10-04 14:20:00'),
    ('Pedro Rocha', 35, 'pedro.rocha@example.com', '2023-10-05 08:45:00'),
    ('Laura Mendes', 27, 'laura.mendes@example.com', '2023-10-06 12:00:00'),
    ('Fernando Lima', 32, 'fernando.lima@example.com', '2023-10-07 10:30:00'),
    ('Juliana Santos', 29, 'juliana.santos@example.com', '2023-10-08 15:00:00'),
    ('Ricardo Almeida', 26, 'ricardo.almeida@example.com', '2023-10-09 09:00:00'),
    ('Patrícia Gomes', 31, 'patricia.gomes@example.com', '2023-10-10 11:00:00'),
    ('Lucas Pereira', 24, 'lucas.pereira@example.com', '2023-10-11 14:00:00'),
    ('Camila Ribeiro', 33, 'camila.ribeiro@example.com', '2023-10-12 16:00:00'),
    ('Marcos Ferreira', 28, 'marcos.ferreira@example.com', '2023-10-13 08:00:00'),
    ('Isabela Martins', 29, 'isabela.martins@example.com', '2023-10-14 10:00:00'),
    ('Gustavo Henrique', 27, 'gustavo.henrique@example.com', '2023-10-15 12:00:00'),
    ('Amanda Dias', 30, 'amanda.dias@example.com', '2023-10-16 14:00:00'),
    ('Roberto Nunes', 34, 'roberto.nunes@example.com', '2023-10-17 16:00:00'),
    ('Tatiane Castro', 26, 'tatiane.castro@example.com', '2023-10-18 09:00:00'),
    ('Bruno Carvalho', 31, 'bruno.carvalho@example.com', '2023-10-19 11:00:00'),
    ('Vanessa Lopes', 29, 'vanessa.lopes@example.com', '2023-10-20 13:00:00'),
    ('Diego Oliveira', 28, 'diego.oliveira@example.com', '2023-10-21 15:00:00'),
    ('Cristina Souza', 32, 'cristina.souza@example.com', '2023-10-22 08:00:00'),
    ('Rafael Mendonça', 27, 'rafael.mendonca@example.com', '2023-10-23 10:00:00'),
    ('Larissa Costa', 30, 'larissa.costa@example.com', '2023-10-24 12:00:00'),
    ('Felipe Rocha', 29, 'felipe.rocha@example.com', '2023-10-25 14:00:00'),
    ('Mariana Lima', 26, 'mariana.lima@example.com', '2023-10-26 16:00:00'),
    ('Thiago Santos', 31, 'thiago.santos@example.com', '2023-10-27 09:00:00'),
    ('Daniela Almeida', 28, 'daniela.almeida@example.com', '2023-10-28 11:00:00'),
    ('Rodrigo Gomes', 33, 'rodrigo.gomes@example.com', '2023-10-29 13:00:00'),
    ('Beatriz Pereira', 27, 'beatriz.pereira@example.com', '2023-10-30 15:00:00'),
    ('Eduardo Ribeiro', 30, 'eduardo.ribeiro@example.com', '2023-10-31 08:00:00'),
    ('Sandra Ferreira', 29, 'sandra.ferreira@example.com', '2023-11-01 10:00:00'),
    ('Alexandre Martins', 32, 'alexandre.martins@example.com', '2023-11-02 12:00:00'),
    ('Cláudia Henrique', 28, 'claudia.henrique@example.com', '2023-11-03 14:00:00'),
    ('Marcelo Dias', 31, 'marcelo.dias@example.com', '2023-11-04 16:00:00'),
    ('Luciana Nunes', 27, 'luciana.nunes@example.com', '2023-11-05 09:00:00'),
    ('André Castro', 30, 'andre.castro@example.com', '2023-11-06 11:00:00'),
    ('Simone Carvalho', 29, 'simone.carvalho@example.com', '2023-11-07 13:00:00'),
    ('Paulo Lopes', 33, 'paulo.lopes@example.com', '2023-11-08 15:00:00'),
    ('Renata Oliveira', 28, 'renata.oliveira@example.com', '2023-11-09 08:00:00'),
    ('José Souza', 31, 'jose.souza@example.com', '2023-11-10 10:00:00'),
    ('Aline Mendonça', 27, 'aline.mendonca@example.com', '2023-11-11 12:00:00'),
    ('Vitor Costa', 30, 'vitor.costa@example.com', '2023-11-12 14:00:00'),
    ('Helena Rocha', 29, 'helena.rocha@example.com', '2023-11-13 16:00:00'),
    ('Márcio Lima', 32, 'marcio.lima@example.com', '2023-11-14 09:00:00'),
    ('Tânia Santos', 28, 'tania.santos@example.com', '2023-11-15 11:00:00'),
    ('César Almeida', 31, 'cesar.almeida@example.com', '2023-11-16 13:00:00'),
    ('Regina Gomes', 27, 'regina.gomes@example.com', '2023-11-17 15:00:00');

-- Inserindo 15 cursos
INSERT INTO CURSOS (NOME, DESCRICAO, CARGAHORARIA)
VALUES
    ('Introdução ao SQL', 'Curso básico de SQL para iniciantes', 20),
    ('Desenvolvimento Web', 'Curso de desenvolvimento web com HTML, CSS e JavaScript', 40),
    ('Data Science', 'Curso introdutório de Data Science com Python', 60),
    ('Machine Learning', 'Curso avançado de Machine Learning', 80),
    ('Programação em Java', 'Curso de programação em Java para iniciantes', 50),
    ('Banco de Dados Avançado', 'Curso avançado de banco de dados relacionais', 70),
    ('Desenvolvimento Mobile', 'Curso de desenvolvimento de aplicativos móveis', 60),
    ('UX/UI Design', 'Curso de design de interfaces e experiência do usuário', 30),
    ('Cloud Computing', 'Curso de computação em nuvem com AWS e Azure', 50),
    ('Segurança da Informação', 'Curso de fundamentos de segurança da informação', 40),
    ('DevOps', 'Curso de práticas de integração e entrega contínua', 60),
    ('Inteligência Artificial', 'Curso introdutório de IA e algoritmos', 70),
    ('Big Data', 'Curso de análise e processamento de grandes volumes de dados', 80),
    ('Gestão de Projetos', 'Curso de metodologias ágeis e gestão de projetos', 30),
    ('Marketing Digital', 'Curso de estratégias de marketing digital', 40);

-- Inserindo matrículas
-- Agora, garantimos que os ALUNOID e CURSOID existem antes de inserir as matrículas
INSERT INTO MATRICULAS (ALUNOID, CURSOID, DATAMATRICULA)
VALUES
    (1, 1, '2023-10-05 08:00:00'),  -- João Silva em Introdução ao SQL
    (1, 2, '2023-10-06 09:00:00'),  -- João Silva em Desenvolvimento Web
    (2, 3, '2023-10-07 10:00:00'),  -- Maria Oliveira em Data Science
    (3, 4, '2023-10-08 11:00:00'),  -- Carlos Souza em Machine Learning
    (4, 5, '2023-10-09 12:00:00'),  -- Ana Costa em Programação em Java
    (5, 6, '2023-10-10 13:00:00'),  -- Pedro Rocha em Banco de Dados Avançado
    (6, 7, '2023-10-11 14:00:00'),  -- Laura Mendes em Desenvolvimento Mobile
    (7, 8, '2023-10-12 15:00:00'),  -- Fernando Lima em UX/UI Design
    (8, 9, '2023-10-13 16:00:00'),  -- Juliana Santos em Cloud Computing
    (9, 10, '2023-10-14 08:00:00'), -- Ricardo Almeida em Segurança da Informação
    (10, 11, '2023-10-15 09:00:00'),-- Patrícia Gomes em DevOps
    (11, 12, '2023-10-16 10:00:00'),-- Lucas Pereira em Inteligência Artificial
    (12, 13, '2023-10-17 11:00:00'),-- Camila Ribeiro em Big Data
    (13, 14, '2023-10-18 12:00:00'),-- Marcos Ferreira em Gestão de Projetos
    (14, 15, '2023-10-19 13:00:00'),-- Isabela Martins em Marketing Digital
    (15, 1, '2023-10-20 14:00:00'), -- Gustavo Henrique em Introdução ao SQL
    (16, 2, '2023-10-21 15:00:00'), -- Amanda Dias em Desenvolvimento Web
    (17, 3, '2023-10-22 08:00:00'), -- Roberto Nunes em Data Science
    (18, 4, '2023-10-23 09:00:00'), -- Tatiane Castro em Machine Learning
    (19, 5, '2023-10-24 10:00:00'), -- Bruno Carvalho em Programação em Java
    (20, 6, '2023-10-25 11:00:00'), -- Vanessa Lopes em Banco de Dados Avançado
    (21, 7, '2023-10-26 12:00:00'), -- Diego Oliveira em Desenvolvimento Mobile
    (22, 8, '2023-10-27 13:00:00'), -- Cristina Souza em UX/UI Design
    (23, 9, '2023-10-28 14:00:00'), -- Rafael Mendonça em Cloud Computing
    (24, 10, '2023-10-29 15:00:00'),-- Larissa Costa em Segurança da Informação
    (25, 11, '2023-10-30 08:00:00'),-- Felipe Rocha em DevOps
    (26, 12, '2023-10-31 09:00:00'),-- Mariana Lima em Inteligência Artificial
    (27, 13, '2023-11-01 10:00:00'),-- Thiago Santos em Big Data
    (28, 14, '2023-11-02 11:00:00'),-- Daniela Almeida em Gestão de Projetos
    (29, 15, '2023-11-03 12:00:00'),-- Rodrigo Gomes em Marketing Digital
    (30, 1, '2023-11-04 13:00:00'), -- Beatriz Pereira em Introdução ao SQL
    (31, 2, '2023-11-05 14:00:00'), -- Eduardo Ribeiro em Desenvolvimento Web
    (32, 3, '2023-11-06 15:00:00'), -- Sandra Ferreira em Data Science
    (33, 4, '2023-11-07 08:00:00'), -- Alexandre Martins em Machine Learning
    (34, 5, '2023-11-08 09:00:00'), -- Cláudia Henrique em Programação em Java
    (35, 6, '2023-11-09 10:00:00'), -- Marcelo Dias em Banco de Dados Avançado
    (36, 7, '2023-11-10 11:00:00'), -- Luciana Nunes em Desenvolvimento Mobile
    (37, 8, '2023-11-11 12:00:00'), -- André Castro em UX/UI Design
    (38, 9, '2023-11-12 13:00:00'), -- Simone Carvalho em Cloud Computing
    (39, 10, '2023-11-13 14:00:00'),-- Paulo Lopes em Segurança da Informação
    (40, 11, '2023-11-14 15:00:00'),-- Renata Oliveira em DevOps
    (41, 12, '2023-11-15 08:00:00'),-- José Souza em Inteligência Artificial
    (42, 13, '2023-11-16 09:00:00'),-- Aline Mendonça em Big Data
    (43, 14, '2023-11-17 10:00:00'),-- Vitor Costa em Gestão de Projetos
    (44, 15, '2023-11-18 11:00:00'),-- Helena Rocha em Marketing Digital
    (45, 1, '2023-11-19 12:00:00'),-- Márcio Lima em Introdução ao SQL
    (46, 2, '2023-11-20 13:00:00'),-- Tânia Santos em Desenvolvimento Web
    (47, 3, '2023-11-21 14:00:00'),-- César Almeida em Data Science
    (48, 4, '2023-11-22 15:00:00'),-- Regina Gomes em Machine Learning
    (48, 5, '2023-11-23 08:00:00'),-- Regina Gomes em Programação em Java
    (48, 6, '2023-11-24 09:00:00'); -- Regina Gomes em Banco de Dados Avançado