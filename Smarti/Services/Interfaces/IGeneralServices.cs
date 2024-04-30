using Smarti.Entites;


namespace Smarti.Services.Interfaces
{
    public interface IGeneralServices
    {
        Task<PersonEntity> SetProperties<T>();
    }
}
