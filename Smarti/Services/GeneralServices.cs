using Microsoft.Extensions.Caching.Memory;
using Smarti.Entites;
using Smarti.Services.Interfaces;
using System.Collections;
using System.Reflection;
using static Smarti.Models.JsonModel;

namespace Smarti.Services;

public class GeneralServices : IGeneralServices
{
    //const property
    public const string webInt = "webint";
    public const string D2 = "D2";

    //injectable property
    private readonly IMemoryCache _cache;
    private ID2Service d2Service;
    private IWebIntService webIntService;
    public GeneralServices(ID2Service _d2Service,
            IWebIntService _webIntService, IMemoryCache memoryCache)
    {
        d2Service = _d2Service;
        webIntService = _webIntService;
        _cache = memoryCache;

    }
    


    public async Task<PersonEntity> SetProperties<T>()
    {
        JsonData priorites;

        //get data from cache
        if (_cache.TryGetValue("Priorities", out JsonData cachedData))
        {
             priorites= cachedData;
        }
        else
        {
            return null;
        }

        PersonEntity newPerson = new PersonEntity();

        // Get all properties of the model
        PropertyInfo[] properties = typeof(PersonEntity).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            // get the value for each property from Priorities json
            var propertyValue = (priorites.priorities.GetType().GetProperty(property.Name).GetValue(priorites.priorities));
            string[] stringArray = null;


            if (propertyValue != null)
            {            
                // Convert the property value to a string array
                if (propertyValue is IEnumerable enumerableValue)
                {
                    // If the property value is an IEnumerable, convert it to an array of strings
                    stringArray = enumerableValue.Cast<object>()
                                                  .Select(x => x.ToString())
                                                  .ToArray();

                     FillDataForSimpleProperty(stringArray, property.Name, newPerson);
                }
                else if(propertyValue is Address addressData)
                {
                    
                    newPerson.address =await FillDataForNestedProperty(addressData);
                }

            }




                       
           
        }
        return newPerson;


    }

    private async void FillDataForSimpleProperty(string[] stringArray,string filedName, PersonEntity newPerson)
    {
        object value = null;
        PersonEntity D2Entity = null;
        PersonEntity webIntEntity = null;
        if (stringArray != null && stringArray[0] == webInt)
         {
             if (webIntEntity == null)
             {
                 webIntEntity = await webIntService.GetPersonData(0);
             }
           value = webIntEntity.GetType().GetProperty(filedName)?.GetValue(webIntEntity);

         }   
         else if (stringArray != null && stringArray[0] == D2)
         {
                if (D2Entity == null)
                 {
                  D2Entity = await d2Service.GetPersonData(0);
                 }
                value = D2Entity.GetType().GetProperty(filedName)?.GetValue(D2Entity);

         }

        if (value != null)
        {
            newPerson.GetType().GetProperty(filedName).SetValue(newPerson, value);
        }
     
    }

    private async Task<AddressEntity> FillDataForNestedProperty(Address addressData)
    {

        PersonEntity D2Entity = null;
        PersonEntity webIntEntity = null;
        AddressEntity address = new AddressEntity();
        if (addressData.city[0] == webInt)
        {
            if (webIntEntity == null)
            {
                webIntEntity = await webIntService.GetPersonData(0);
            }
            address.city = webIntEntity.address.city;
        }
        else if (addressData.city[0] == D2)
        {

            if (D2Entity == null)
            {
                D2Entity = await d2Service.GetPersonData(0);
            }
            address.city = D2Entity.address.city;

        }

        if (addressData.region[0] == webInt)
        {
            if (webIntEntity == null)
            {
                webIntEntity = await webIntService.GetPersonData(0);
            }
            address.region = webIntEntity.address.region;
        }
        else if (addressData.region[0] == D2)
        {

            if (D2Entity == null)
            {
                D2Entity = await d2Service.GetPersonData(0);
            }
            address.region = D2Entity.address.region;

        }
        return address;

    }

}



