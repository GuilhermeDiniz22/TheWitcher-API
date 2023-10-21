namespace rpgapi.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResposta<int>> Registrar(Usuario usuario, string senha);

        Task<ServiceResposta<string>> Login(string username, string senha);

        Task<bool> UsuarioExiste(string username);

    }
}
