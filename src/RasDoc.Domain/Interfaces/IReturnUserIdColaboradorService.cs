namespace RasDoc.Domain.Interfaces
{
    public interface IReturnUserIdColaboradorService
    {
        Task<bool> HasUserColaborador(Guid id);
    }
}
