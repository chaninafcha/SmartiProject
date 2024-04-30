using Smarti.Entites;

namespace Smarti.Services.Interfaces
{
    public interface IWebIntService
    {
        Task<PersonEntity> GetPersonData(int Id);

    }
}
