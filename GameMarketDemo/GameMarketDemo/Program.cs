using System;

namespace GameMarketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Giriş yapmak için : 1'e basın \nKayıt olmak için : 2'ye basın \nÇıkış yapmak için : 0'a basın");
            int secim = int.Parse(Console.ReadLine());
            switch(secim)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 0:
                    break;
            }
        }
    }
}
