using GameMarketDemo.Abstract;
using GameMarketDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public class CampaignManager :BaseManager<Campaign>,ICampaignService
    {
        public override void Update(Campaign campaign)
        {
            string oldCampaignName = campaign.CampaignName;
            Console.WriteLine("Güncel kampanya ismini giriniz : ");
            campaign.CampaignName= Console.ReadLine();
            Console.WriteLine("Güncel indirim değerini giriniz : ");
            campaign.Discount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Güncel kampanya başlangıç tarihini giriniz : ");
            campaign.StartDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Güncel kampanya bitiş tarihini giriniz : ");
            campaign.EndDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(oldCampaignName + " isimli kampanya "+campaign.CampaignName+" diye güncellendi");
        }
        public override void GetListWrite()
        {
            Console.WriteLine("KAMPANYALAR LİSTESİ");
            foreach (var campaign in GetList())
            {
                Console.WriteLine("Id : {0} - Kampanyanın Adı : {1} - İndirim Oranı : %{2} - Başlangıç Tarihi {3} - Bitiş Tarihi {4}", campaign.Id, campaign.CampaignName, campaign.Discount, campaign.StartDate.ToShortDateString(), campaign.EndDate.ToShortDateString());
            }
            Console.WriteLine("");
        }
        public void GetCurrentListWrite()
        {
            Console.WriteLine("MEVCUT KAMPANYALAR");
            foreach (var campaign in GetList())
            {
                if (DateTime.Now <=  campaign.EndDate)
                {
                    Console.WriteLine("Kampanyanın Adı : {0} - İndirim Oranı : %{1} - Başlangıç Tarihi {2} - Bitiş Tarihi {3}",campaign.CampaignName, campaign.Discount, campaign.StartDate.ToShortDateString(), campaign.EndDate.ToShortDateString());
                }
            }
            Console.WriteLine("");
        }
        public Campaign CampaignControl(DateTime date)
        {
            Campaign oldCampaing = new Campaign();
            oldCampaing = null;
            foreach (var campaign in GetList())
            {
                if(campaign.StartDate<=date && campaign.EndDate>=date)
                {
                    oldCampaing = campaign;
                    if(oldCampaing.Discount<=campaign.Discount)
                    {
                        oldCampaing = campaign;
                    }
                }
            }
            return oldCampaing;
        }
    }
}
