namespace rpgapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personagem, GetPersonagemDto>();
            CreateMap<AddPersonagemDto, Personagem>();
            ;
        }
    }
}
