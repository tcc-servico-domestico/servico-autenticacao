using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Services;
using ServicoAutenticacao.Domain.Interfaces.Repositories;
using ServicoAutenticacao.Domain.Services.Base;
using ServicoAutenticacao.Domain.Interfaces;
using ServicoAutenticacao.Domain.Interfaces.Mensageria;
using Newtonsoft.Json;

namespace ServicoAutenticacao.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        //private readonly ICriptografica _criptografica;
        private readonly IEventProducer _eventProducer;

        public UsuarioService(
            IUsuarioRepository repository, 
            IEventProducer eventProducer) 
            : base(repository) 
        {
            //_criptografica = criptografica;
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
            //Adiciona usuário
            var usuarioAdd = await base.AdicionarAsync(usuario);
            
            //Envia email
            await _eventProducer.ProduceAsync(
                "adicionar-notificacao",
                JsonConvert.SerializeObject(new Notificacao
                {
                    PessoaId = usuarioAdd.Id,
                    CanalId = new Guid("06972b6e-b170-401c-a07f-686becf4bf6a"),
                    TemplateId = new Guid("ba83654b-3e0e-4376-925b-c5c9883b502e"),
                    Titulo = "Confirmação de E-mail - HTML",
                    Mensagem = "Confirmação de Email - HTML",
                    DataAgendamento = DateTime.UtcNow,
                    MaxTentativas = 3
                }));
            
            return usuarioAdd;
        }
    }
}