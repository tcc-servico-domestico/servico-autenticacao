-- Insere na tabela de PESSOA
INSERT INTO PESSOA (data_nascimento, cpf, nome, bio) VALUES
('1985-06-15', '12345678901', 'Nathan Serra', 'Desenvolvedor de software.'),
('1990-12-30', '98765432100', 'Marcos Silva', 'Profissional de limpeza.');

-- Insere na tabela de TELEFONE
INSERT INTO TELEFONE (pessoa_id, ddd, numero) VALUES
((SELECT id FROM PESSOA WHERE cpf = '12345678901'), '31', '999999999'),
((SELECT id FROM PESSOA WHERE cpf = '98765432100'), '31', '988888888');

-- Insere na tabela de TRABALHADOR_DOMESTICO
INSERT INTO TRABALHADOR_DOMESTICO (pessoa_id, valor_hora, experiencia) VALUES
((SELECT id FROM PESSOA WHERE cpf = '98765432100'), 25.50, '5 anos de experiência em limpeza residencial.');

-- Insere na tabela de USUARIO
INSERT INTO USUARIO (pessoa_id, username, senha) VALUES
((SELECT id FROM PESSOA WHERE cpf = '12345678901'), 'nathan.serra', 'hash_senha_exemplo');

-- Insere na tabela de PERMISSAO
INSERT INTO PERMISSAO (nome, descricao) VALUES
('admin', 'Permissão de administrador'),
('usuario', 'Permissão de usuário comum');

-- Insere na tabela de POSSUI
INSERT INTO POSSUI (usuario_id, permissao_id) VALUES
((SELECT id FROM USUARIO WHERE username = 'nathan.serra'), (SELECT id FROM permissao WHERE nome = 'admin'));

-- Insere na tabela de LOG_ACESSO
INSERT INTO LOG_ACESSO (usuario_id, ip, user_agent, sucesso) VALUES
((SELECT id FROM USUARIO WHERE username = 'nathan.serra'), '192.168.0.10', 'Mozilla/5.0', true);

-- Insere na tabela de TOKEN
INSERT INTO TOKEN (usuario_id, token, expira_em, revogado, data_criacao) VALUES
((SELECT id FROM USUARIO WHERE username = 'nathan.serra'), 'token_exemplo_12345', 1700000000, false, now());
