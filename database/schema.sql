CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Tabela PESSOA
CREATE TABLE PESSOA (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    data_nascimento DATE,
    cpf VARCHAR(11),
    nome VARCHAR(100),
    bio TEXT,
    data_criacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    data_atualizacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
);

-- Tabela TELEFONE
CREATE TABLE TELEFONE (
    telefone_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    pessoa_id UUID NOT NULL,
    ddd VARCHAR(2),
    numero VARCHAR(9),
    CONSTRAINT fk_telefone_pessoa FOREIGN KEY (pessoa_id) REFERENCES pessoa(id) ON DELETE CASCADE
);

-- Tabela TRABALHADOR_DOMESTICO
CREATE TABLE TRABALHADOR_DOMESTICO (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    pessoa_id UUID NOT NULL UNIQUE, -- assume relação 1:1
    valor_hora NUMERIC(18,4),
    experiencia TEXT,
    data_criacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    data_atualizacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    CONSTRAINT fk_trabalhador_pessoa FOREIGN KEY (pessoa_id) REFERENCES pessoa(id) ON DELETE CASCADE
);

-- Tabela USUARIO
CREATE TABLE USUARIO (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    pessoa_id UUID NOT NULL UNIQUE,
    username VARCHAR(50) UNIQUE NOT NULL,
    senha VARCHAR(100) NOT NULL,
    data_criacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    CONSTRAINT fk_usuario_pessoa FOREIGN KEY (pessoa_id) REFERENCES pessoa(id) ON DELETE CASCADE
);

-- Tabela PERMISSAO
CREATE TABLE PERMISSAO (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    nome VARCHAR(30) NOT NULL,
    descricao VARCHAR(100)
);

-- Tabela POSSUI (associação N:N entre USUARIO e PERMISSAO)
CREATE TABLE POSSUI (
    usuario_id UUID NOT NULL,
    permissao_id UUID NOT NULL,
    PRIMARY KEY (usuario_id, permissao_id),
    CONSTRAINT fk_possui_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id) ON DELETE RESTRICT,
    CONSTRAINT fk_possui_permissao FOREIGN KEY (permissao_id) REFERENCES permissao(id) ON DELETE RESTRICT
);

-- Tabela LOG_ACESSO
CREATE TABLE LOG_ACESSO (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    usuario_id UUID NOT NULL,
    ip INET,
    user_agent TEXT,
    data_login TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    sucesso BOOLEAN NOT NULL,
    CONSTRAINT fk_log_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id) ON DELETE RESTRICT
);

-- Tabela TOKEN
CREATE TABLE TOKEN (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    usuario_id UUID NOT NULL,
    token VARCHAR(300) NOT NULL,
    expira_em BIGINT,
    revogado BOOLEAN DEFAULT FALSE,
    data_criacao TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    CONSTRAINT fk_token_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id) ON DELETE RESTRICT
);
