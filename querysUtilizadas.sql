--Script para criar tabela Job
CREATE TABLE Job(
	id INT NOT NULL PRIMARY KEY,
	title VARCHAR(100) NOT NULL,
	description VARCHAR(100) NOT NULL,
	location VARCHAR(100) NOT NULL,
	salary MONEY NOT NULL
);

--Script para consultar dados na tabela job
SELECT * FROM job