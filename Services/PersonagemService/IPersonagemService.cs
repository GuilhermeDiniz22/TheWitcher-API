namespace rpgapi.Services.PersonagemService
{
    public interface IPersonagemService //Task é um método asíncrono.
    {
        Task<ServiceResposta<List<GetPersonagemDto>>> PegarTodosPersonagens();

        Task<ServiceResposta<GetPersonagemDto>> GetPersonagemPorId(int id);

        Task<ServiceResposta<List<GetPersonagemDto>>> AddPersonagem(AddPersonagemDto NovoPersonagem);

        Task<ServiceResposta<GetPersonagemDto>> AtualizarPersonagem(AtualizarPersonagemDto PersonagemAtualizado);

        Task<ServiceResposta<List<GetPersonagemDto>>> DeletarPersonagem(int id);

    }
}
