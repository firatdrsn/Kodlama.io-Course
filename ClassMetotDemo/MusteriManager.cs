using System;
using System.Collections.Generic;

public class MusteriManager
{    
    public List<Musteri> MusteriListesi = new List<Musteri>();
    public void MusteriEkle(Musteri musteri)
    {
        MusteriListesi.Add(musteri);
    }
    public void MusteriSil(int Id)
    {
        foreach(Musteri musteri in MusteriListesi)
        {
            if(musteri.Id==Id)
            {
                MusteriListesi.Remove(musteri);
                break;
            }
        }
    }
    public void MusteriListele()
    {
        foreach(Musteri musteri in MusteriListesi)
        {
            Console.WriteLine("Müşterinin Idsi : "+musteri.Id+" - Adı : "+musteri.Ad+" - Soyadı : "+musteri.Soyad+" - Doğum Tarihi : "+musteri.DogumTarihi.ToShortDateString());
        }
    } 

}