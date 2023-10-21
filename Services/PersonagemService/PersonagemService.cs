global using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using rpgapi.Data;

namespace rpgapi.Services.PersonagemService
{
    public class PersonagemService : IPersonagemService
    {

        private readonly IMapper _mapper;
        private readonly TheWitcherContext _context;

        public PersonagemService(IMapper mapper, TheWitcherContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResposta<List<GetPersonagemDto>>> AddPersonagem(AddPersonagemDto NovoPersonagem)
        {
            var serviceResposta = new ServiceResposta<List<GetPersonagemDto>>();

            var personagem = _mapper.Map<Personagem>(NovoPersonagem);
            _context.Personagems.Add(personagem);
            await _context.SaveChangesAsync();
            serviceResposta.Dados = await _context.Personagems.Select(p => _mapper.Map<GetPersonagemDto>(p)).ToListAsync();
            return serviceResposta;

            /* Após adicionar um novo personagem a função select 
             * retorna um IEnumerable 
            * que depois é jogado em uma lista */
        }


        public async Task<ServiceResposta<List<GetPersonagemDto>>> PegarTodosPersonagens()
        {
            var serviceResposta = new ServiceResposta<List<GetPersonagemDto>>();
            var DbPersonagens = await _context.Personagems.ToListAsync();
            serviceResposta.Dados = DbPersonagens.Select(p => _mapper.Map<GetPersonagemDto>(p)).ToList();
            return serviceResposta;
        }

        public async Task<ServiceResposta<GetPersonagemDto>> GetPersonagemPorId(int id)
        {
            var serviceResposta = new ServiceResposta<GetPersonagemDto>();

            var personagem = await _context.Personagems.FirstOrDefaultAsync(p => p.Id == id);

            serviceResposta.Dados = _mapper.Map<GetPersonagemDto>(personagem);

            return serviceResposta;


        }

        public async Task<ServiceResposta<GetPersonagemDto>> AtualizarPersonagem(AtualizarPersonagemDto PersonagemAtualizado)
        {
            var serviceResposta = new ServiceResposta<GetPersonagemDto>();

            try
            {


                var personagem = await _context.Personagems.FirstOrDefaultAsync(p => p.Id == PersonagemAtualizado.Id);

                if (personagem is null)
                {
                    throw new Exception($"Personagem com Id '{PersonagemAtualizado.Id}' não encontrado!");
                }

                personagem.Nome = PersonagemAtualizado.Nome;
                personagem.PontosdeVida = PersonagemAtualizado.PontosdeVida;
                personagem.PontosdeMana = PersonagemAtualizado.PontosdeMana;
                personagem.Força = PersonagemAtualizado.Força;
                personagem.Defesa = PersonagemAtualizado.Defesa;
                personagem.Inteligencia = PersonagemAtualizado.Inteligencia;
                personagem.Classe = PersonagemAtualizado.Classe;

                await _context.SaveChangesAsync();
                serviceResposta.Dados = _mapper.Map<GetPersonagemDto>(personagem);
            }

            catch (Exception ex)
            {
                serviceResposta.Sucesso = false;
                serviceResposta.Mensagem = ex.Message;
            }

            return serviceResposta;

        }

        public async Task<ServiceResposta<List<GetPersonagemDto>>> DeletarPersonagem(int id)
        {
            var serviceResposta = new ServiceResposta<List<GetPersonagemDto>>();

            try
            {


                var personagem = await _context.Personagems.FirstOrDefaultAsync(p => p.Id == id);

                if (personagem is null)
                {
                    throw new Exception($"Personagem com Id '{id}' não encontrado!");
                }

                _context.Personagems.Remove(personagem);

                await _context.SaveChangesAsync();

                serviceResposta.Dados = await _context.Personagems.Select(p => _mapper.Map<GetPersonagemDto>(p)).ToListAsync();
            }

            catch (Exception ex)
            {
                serviceResposta.Sucesso = false;
                serviceResposta.Mensagem = ex.Message;
            }

            return serviceResposta;
        }
    }
}
