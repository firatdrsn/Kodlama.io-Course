using GameMarketDemo.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public class PersonValidationManager : IUserValidationService
    {
        public bool TrueValidate(Person person)
        {
            return true;
        }

        public bool Validate(Person person)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(person.NationalityId, person.FirstName.ToUpper(), person.LastName, person.DateOfBirth.Year).Result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
