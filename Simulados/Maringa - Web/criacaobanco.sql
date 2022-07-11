CREATE TABLE tbDepartamento(
	id int identity primary key,
	nome VARCHAR(100),
);

CREATE TABLE tbUsuarios(
	id int identity primary key,
	nome VARCHAR(MAX),
	id_departamento int REFERENCES tbDepartamento(id),
	cpf VARCHAR(MAX),
	tipo int,
	CNH VARCHAR(MAX),
	val_CNH DATETIME,
	telefone VARCHAR(MAX),
	senha VARCHAR(MAX)
);

CREATE TABLE tbVeiculos(
	id INT IDENTITY PRIMARY KEY,
	modelo VARCHAR(MAX),
	placa VARCHAR(MAX),
	id_usuario int REFERENCES tbUsuarios(id),
);

CREATE TABLE tbReservas(
	id INT IDENTITY PRIMARY KEY,
	id_veiculo INT REFERENCES tbVeiculos(id),
	data_saida DATETIME,
	data_retorno DATETIME,
	destino VARCHAR(MAX),
	condutor VARCHAR(MAX),
	id_departamento int REFERENCES tbDepartamento(id),
	motivo VARCHAR(MAX)
);