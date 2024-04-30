using Smarti.Entites;
using Smarti.Services.Interfaces;

namespace Smarti.Services
{
    public class WebIntService:IWebIntService
    {
      

            public async Task<PersonEntity> GetPersonData(int Id)
            {
                //in real world take data from DB by use DB CONTEXT
                var person = new PersonEntity() { tz = 20202020, name = "chani nafcha WebInt", age = 30, address = new AddressEntity() { city = "WebInt city", region = "aaa" } };
                return person;

            }


        
    }
}
