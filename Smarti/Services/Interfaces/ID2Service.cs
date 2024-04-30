using Smarti.Entites;

namespace Smarti.Services.Interfaces
{
    public interface ID2Service
    {
        Task<PersonEntity> GetPersonData(int Id);

    }
}
