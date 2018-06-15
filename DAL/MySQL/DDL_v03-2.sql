CREATE DATABASE SGA;
USE SGA;

CREATE TABLE Usuario (
Id INT AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(255),
Login VARCHAR(20),
Senha VARCHAR(255)
);

CREATE TABLE Administrador (
Id INT AUTO_INCREMENT PRIMARY KEY,
Id_Usuario INT,
FOREIGN KEY(Id_Usuario) REFERENCES Usuario (Id)
);

CREATE TABLE Professor (
Id INT AUTO_INCREMENT PRIMARY KEY,
Id_Usuario INT,
FOREIGN KEY(Id_Usuario) REFERENCES Usuario (Id)
);

CREATE TABLE Disciplina (
Id INT AUTO_INCREMENT PRIMARY KEY,
Periodo INT,
Nome VARCHAR(255),
Id_Professor INT,
FOREIGN KEY(Id_Professor) REFERENCES Professor (Id)
);

CREATE TABLE Aptidao (
Id INT AUTO_INCREMENT PRIMARY KEY,
Id_Disciplina INT,
Id_Professor INT,
FOREIGN KEY(Id_Disciplina) REFERENCES Disciplina (Id),
FOREIGN KEY(Id_Professor) REFERENCES Professor (Id)
);

CREATE TABLE Horario (
Id INT AUTO_INCREMENT PRIMARY KEY,
HoraInicio TIME,
HoraTermino TIME,
DiaSemana INT
);

CREATE TABLE Alocacao (
Id INT AUTO_INCREMENT PRIMARY KEY,
Id_Disciplina INT,
Id_Horario INT,
FOREIGN KEY(Id_Disciplina) REFERENCES Disciplina (Id),
FOREIGN KEY(Id_Horario) REFERENCES Horario (Id)
);

CREATE TABLE Log (
Id INT PRIMARY KEY,
Hora DATETIME,
Operacao VARCHAR(255),
Id_Usuario INT,
Id_Alocacao INT,
FOREIGN KEY(Id_Usuario) REFERENCES Usuario (Id),
FOREIGN KEY(Id_Alocacao) REFERENCES Alocacao (Id)
);

insert into usuario values (null, 'daniel', 'daniel', '1234');
insert into usuario values (null, 'italo', 'italo', '1234');
insert into usuario values (null, 'pedro', 'pedro', '1234');
insert into usuario values (null, 'michelle', 'michelle', '1234');

insert into administrador values (null, 1);
insert into administrador values (null, 2);
insert into administrador values (null, 3);
insert into professor values (null, 4);

insert into horario values (null, '19:00:00', '20:30:00', 2);
insert into horario values (null, '20:50:00', '22:30:00', 2);
insert into horario values (null, '19:00:00', '20:30:00', 3);
insert into horario values (null, '20:50:00', '22:30:00', 3);
insert into horario values (null, '19:00:00', '20:30:00', 4);
insert into horario values (null, '20:50:00', '22:30:00', 4);
insert into horario values (null, '19:00:00', '20:30:00', 5);
insert into horario values (null, '20:50:00', '22:30:00', 5);
insert into horario values (null, '19:00:00', '20:30:00', 6);
insert into horario values (null, '20:50:00', '22:30:00', 6);