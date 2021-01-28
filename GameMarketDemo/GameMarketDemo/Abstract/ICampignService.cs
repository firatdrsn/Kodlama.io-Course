using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Abstract
{
    public interface ICampaignService
    {
        Campaign CampaignControl(DateTime date);
        void GetCurrentListWrite();
    }
}
