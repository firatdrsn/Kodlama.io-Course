using GameMarketDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Entities
{
    public class Campaign
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
