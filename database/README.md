# Database

Este diretório contém todos os arquivos relacionados ao banco de dados **PostgreSQL** para o serviço de autenticação.

---

## Conteúdo

- `schema.sql`: Script SQL para criação das tabelas e estrutura do banco.
- `seed.sql`: Script SQL para popular o banco com dados iniciais.
- `.env.example`: Exemplo de arquivo com variáveis de ambiente para configurar o banco.

---

## Como subir o banco de dados

> O banco de dados é iniciado junto com a aplicação através do `docker-compose.yml` que está na raiz do projeto, orquestrando ambos os serviços e criando uma network compartilhada.

1. **Copie o arquivo `.env.example` para `.env` na raiz do projeto:**

```bash
cp .env.example .env
```

2. **Ajuste as variáveis de ambiente no arquivo .env conforme seu ambiente.**

3. **Na raiz do projeto, suba os containers com Docker Compose:**

```bash
docker-compose up -d
```

4. **O banco PostgreSQL estará disponível na porta configurada (padrão: 5432) e a aplicação estará conectada a ele automaticamente via network Docker.**

## Observações importantes

* **Os scripts SQL serão executados automaticamente na primeira inicialização do container do banco, criando a estrutura do banco e populando os dados iniciais.**
* **Para reiniciar o banco do zero, remova o volume Docker antes de subir novamente:**

```bash
docker-compose down
docker volume rm pgdata
docker-compose up -d
```

* **Para visualizar os logs do container do banco, utilize:**

```bash
docker logs postgres_db
```

