using System;

namespace ClassMetotDemo
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            MusteriManager musteriManager = new MusteriManager();
            Musteri musteri;
            int secim=1;
            int sayac=1,Id;
            while(secim!=0)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Müşteri eklemek için 1'e basın");
                Console.WriteLine("Müşteri silmek için 2'ye basın");
                Console.WriteLine("Müşterileri listelemek için 3'e basın");
                Console.WriteLine("Çıkış yapmak için 0'a basın");
                secim=Convert.ToInt32(Console.ReadLine());
                switch(secim)
                {
                case 1:
                    musteri = new Musteri();
                    musteri.Id=sayac;
                    Console.WriteLine("Müşterinin Adı");
                    musteri.Ad=Console.ReadLine();
                    Console.WriteLine("Müşterinin Soyadı");
                    musteri.Soyad=Console.ReadLine();
                    Console.WriteLine("Müşterinin Doğum Tarihi");
                    musteri.DogumTarihi=Convert.ToDateTime(Console.ReadLine());
                    sayac++;
                    musteriManager.MusteriEkle(musteri);
                    break;
                case 2:
                    if(musteriManager.MusteriListesi.Count<=0)
                    {
                        Console.WriteLine("Hiç müşteri kaydı yok");
                    }
                    else
                    {
                        musteriManager.MusteriListele();
                        Console.WriteLine("Silinecek Müşterinin Idsini giriniz");
                        Id=Convert.ToInt32(Console.ReadLine());
                        musteriManager.MusteriSil(Id);
                    }
                    break;
                case 3:
                    Console.WriteLine("MÜŞTERİLER");
                    musteriManager.MusteriListele();
                    break;
                case 0:
                    Console.WriteLine("Sistemden Çıkış yapılıyor");
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız");
                    break;
                    }
            }
        }
    }
}
