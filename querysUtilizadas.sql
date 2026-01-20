--Script para criar tabela Job
CREATE TABLE Job (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    location VARCHAR(100) NOT NULL,
    salary MONEY NOT NULL
);

--Script para criar tabela Users
CREATE TABLE Users (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    full_name NVARCHAR(150) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    birth_date DATE NOT NULL,
    created_at DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    active BIT NOT NULL DEFAULT 1,
    [password] NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) NOT NULL
);

--Script para consultar dados na tabela job
SELECT * FROM job

--Script para consultar dados na tabela users