using Smarti.Entites;
using Smarti.Services.Interfaces;

namespace Smarti.Services
{
    public class D2Service:ID2Service
    {
        
            public async Task<PersonEntity> GetPersonData(int Id)
            {
                //in real world take data from DB by use DB CONTEXT
                var person = new PersonEntity() { tz = 20202020, name = "chani nafcha D2", age = 20, address = new AddressEntity() { city = "bb", region = "aaa" } };
                return person;

            }

        
    }
}
