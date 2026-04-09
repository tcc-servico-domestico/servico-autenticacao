using Newtonsoft.Json;
using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Mensageria;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Domain.Interfaces.Services;
using ServicoAutenticacao.Domain.Services.Base;

namespace ServicoAutenticacao.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IEventProducer _eventProducer;

        public UsuarioService(
            IUsuarioRepository repository,
            IEventProducer eventProducer)
            : base(repository)
        {
            _eventProducer = eventProducer;
        }

        public async Task ConfirmarEmailAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) return;

            var usuarioNaoVerificado = (await _repository.BuscarAsync(x => x.Email == token)).FirstOrDefault();
            if (usuarioNaoVerificado is null) return;

            usuarioNaoVerificado.DefinirEmailVerificado();
            await _repository.AtualizarAsync(usuarioNaoVerificado);
        }

        public override async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            var usuarioExistente = (await _repository.BuscarAsync(x => x.Email == usuario.Email)).FirstOrDefault();
            if (usuarioExistente is not null)
                throw new Exception("Usuário já existe!");

            var usuarioAdd = await base.AdicionarAsync(usuario);

            await _eventProducer.ProduceAsync(
                "adicionar-notificacao",
                JsonConvert.SerializeObject(new Notificacao
                {
                    PessoaId = usuarioAdd.Id,
                    CanalId = new Guid("06972b6e-b170-401c-a07f-686becf4bf6a"),
                    TemplateId = new Guid("77a20167-0cb4-4415-8b41-92cf4c227637"),
                    Titulo = "Confirmação de E-mail - HTML",
                    Mensagem = "Confirmação de Email - HTML",
                    DataAgendamento = DateTime.UtcNow,
                    MaxTentativas = 3,
                    Enderecos = new List<NotificacaoEndereco>
                    {
                        new NotificacaoEndereco
                        {
                            Endereco = new Endereco()
                            {
                                Valor = usuarioAdd.Email,
                                TipoId = new Guid("ecd4aea4-abdb-4f24-b5ef-21c462d5d09a")
                            }
                        }
                    }
                }));

            return usuarioAdd;
        }
    }
}
