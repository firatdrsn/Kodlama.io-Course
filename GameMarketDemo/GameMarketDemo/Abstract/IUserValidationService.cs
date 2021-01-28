using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public interface IUserValidationService
    {
        bool Validate(Person person);
        bool TrueValidate(Person person);//Test
    }
}
