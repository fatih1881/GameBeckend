using System;
using System.Collections.Generic;

namespace GameBeckend
{
    class Program
    {
        static void Main(string[] args)
        {

            Oyuncu oyuncu1 = new EskiOyuncu()
            {
                OyuncuAdi = "Fatih",
                OyuncuSoyadi = "KORKMAZ",
                DogumYılı = 2000,
                TcNo = "123123",
                UyelikYılı = 2
            };

            OyunManager oyunManager = new OyunManager();
            oyunManager.Add(new Oyun() { OyunAdı = "Counter Strike 1.6 ", OyunTuru = "Aksiyon", OyunFiyati = 15, OyunuYapan = "Duygu Pahli" });
            oyunManager.Add(new Oyun() { OyunAdı = "League Of Legends ", OyunTuru = "Aksiyon", OyunFiyati = 5, OyunuYapan = "Duygu Pahli" });

            while (true)
            {
                Console.WriteLine("---------MENU----------");
                Console.WriteLine("1- OYuncu Ekle" + " " + "2- Oyuncu Sil" + "  " + "3- Kullancıları Listele" + "  " + "4- Kampanyaları Listele" + "  " + "5-Oyun Ekle" + "  " + "6-Oyun Sil" + "  " + "7-Çıkış");
                Console.WriteLine("-----------------------");
                int seçim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (seçim == 1)
                {
                    Console.WriteLine("Eklemek istedğiniz kullanıcıları girin");
                    Console.WriteLine("Tc No");
                    string TcNo = Console.ReadLine();
                    Console.WriteLine("Ad:");
                    string oyuncuadi = Console.ReadLine();
                    string oyuncusoyadi = Console.ReadLine();
                    Console.WriteLine("Dogum Yılı");
                    int dogumyili = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("kaç yıl sözleşme istersiniz ?");
                    int sozlemeyili = Convert.ToInt32(Console.ReadLine());
                    oyunManager.Add(new YeniOyuncu() { TcNo = TcNo, OyuncuSoyadi = oyuncusoyadi, OyuncuAdi = oyuncuadi, DogumYılı = dogumyili, SozlesmeYılı = sozlemeyili });

                }
                else if (seçim == 2)
                {
                    Console.WriteLine("Silmek İstediğin Oyuncunun Tc Numarası");
                    oyunManager.Sil(Console.ReadLine());



                }
                else if (seçim == 3)
                {

                    oyunManager.OyunListesi();


                }
                else if (seçim == 4)
                {
                    Console.WriteLine("Eklemek istediğiniz oyunun bilgilerini giriniz");
                    Console.WriteLine("Oyun Adı:");
                    string OyunAdi = Console.ReadLine();
                    Console.WriteLine("Oyunun Türü:");
                    string OyunTuru = Console.ReadLine();
                    Console.WriteLine("Oyunun Fiyatı:");
                    double OyunFiyati = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Oyunun İnceleme Puanı:");
                    oyunManager.Add(new Oyun() { OyunAdı = OyunAdi, OyunFiyati = OyunFiyati, OyunTuru = OyunTuru });



                }

                else if (seçim == 5)
                {
                    Console.WriteLine("Silmek istediğiniz oyuncunun Adını giriniz:");
                    oyunManager.Sil(Console.ReadLine());
                }
                else if (seçim == 6)
                {
                    oyunManager.OyunListesi();
                }
                else if (seçim == 7)
                {
                    Console.WriteLine("**********KAMPANYALAR**********");
                    Console.WriteLine("1- Duygu Kampanyası" + "  " + "2-Fatih Kampanası" + "  " + "3-Ana Menüye Dön");
                    Console.WriteLine("*******************************");
                    int secim2 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (secim2 == 1)
                    {
                        oyunManager.OyunListesi();
                        Console.WriteLine("Yukarıdaki oyunlardan öğrencisi kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                        string isim = Console.ReadLine();
                        Console.Clear();
                        IKampanyaHizmetleri kampanya = new DuyguKampanyası();
                        oyunManager.OyunAl(isim, kampanya);
                    }
                    else if (secim2 == 2)
                    {
                        oyunManager.OyunListesi();
                        Console.WriteLine("Yukarıdaki oyunlardan kara cuma kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                        string isim = Console.ReadLine();
                        Console.Clear();
                        IKampanyaHizmetleri kampanya = new FatihKampanyası();
                        oyunManager.OyunAl(isim, kampanya);
                    }
                    else
                    {
                        break;
                    }
                } 
                else
                {
                    Console.WriteLine("Programdan çıkış yaptınız.İyi günler...");
                    break;
                }
                    }











            }
            
        }

        class Oyun
        {
            public string OyunAdı { get; set; }
            public double OyunFiyati { get; set; }
            public string OyunTuru { get; set; }
            public string OyunuYapan { get; set; }
        }
        class Oyuncu
        { // Burda hocanın dediği sisteme kayıt olması için gereken bilgileri ekledim
            public string OyuncuAdi { get; set; }
            public string OyuncuSoyadi { get; set; }
            public string TcNo { get; set; }
            public int DogumYılı { get; set; }
        }
        class YeniOyuncu : Oyuncu
        {
            public int SozlesmeYılı { get; set; }

        }
        class EskiOyuncu : Oyuncu
        {
            public int UyelikYılı { get; set; }

        }

        interface IKampanyaHizmetleri
        {
            void SatısıHesapla(Oyun oyun);
            void SatısBilgisi(Oyun oyun);
        }
        class DuyguKampanyası : IKampanyaHizmetleri
        {
            public void SatısBilgisi(Oyun oyun)
            {
                Console.WriteLine("{0} isimli oyuna duygu kampanyası uygulandı.\nYeni Fiyat:{1} TL\n", oyun.OyunAdı, oyun.OyunFiyati);
            }

            public void SatısıHesapla(Oyun oyun)
            {
                oyun.OyunFiyati -= oyun.OyunFiyati * (0.20);
            }
        }
        class FatihKampanyası : IKampanyaHizmetleri
        {
            public void SatısBilgisi(Oyun oyun)
            {
                Console.WriteLine("{0} isimli oyuna fatih kampanyası uygulandı.\nYeni Fiyat:{1} TL\n", oyun.OyunAdı, oyun.OyunFiyati);
            }

            public void SatısıHesapla(Oyun oyun)
            {
                oyun.OyunFiyati -= oyun.OyunFiyati * (0.15);
            }
        }
        class OyunManager
        {
            List<Oyun> oyunlar = new List<Oyun>() { };

            public void Add(Oyun oyun)
            {
                oyunlar.Add(oyun);
                Console.WriteLine("{0} isimli oyun eklendi", oyun.OyunAdı);
            }
            public void Sil(string OyunAdi)
            {
                foreach (var oyun in oyunlar)
                {
                    if (oyun.OyunAdı == OyunAdi)
                    {
                        oyunlar.Remove(oyun);
                        Console.WriteLine("{0} adında oyuncu oyundan silindi", oyun.OyunAdı);
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            public void OyunListesi()
            {
                int x = 1;
                foreach (var oyun in oyunlar)
                {

                    Console.WriteLine("{0}. Oyunun Adı : {1} Oyunun Yazarı + {2} Oyunun Türü + {3} Oyunun Fiyati", oyun.OyunAdı, oyun.OyunuYapan, oyun.OyunTuru, oyun.OyunFiyati);
                    x += 1;
                }


            }
            public void OyunAl(string OyunAdi, IKampanyaHizmetleri kampanya)
            {
                foreach (var oyun in oyunlar)
                {
                    if (oyun.OyunAdı == oyun.OyunAdı)
                    {
                        kampanya.SatısBilgisi(oyun);
                        kampanya.SatısıHesapla(oyun);

                    }
                    else
                    {
                        continue;
                    }
                }
            }

        internal void Add(YeniOyuncu yeniOyuncu)
        {
            throw new NotImplementedException();
        }

        class OyuncuManager
            {
                List<Oyuncu> oyuncular = new List<Oyuncu>() { };
                public void Add(Oyuncu oyuncu)
                {
                    oyuncular.Add(oyuncu);
                    Console.WriteLine(" {0} {1} , adlı oyuncu sisteme eklendi", oyuncu.OyuncuAdi, oyuncu.OyuncuSoyadi);
                }
                public void Sil(string TcNo)
                {
                    foreach (var oyuncu in oyuncular)
                    {
                        if (oyuncu.TcNo == TcNo)
                        {
                            oyuncular.Remove(oyuncu);
                            Console.WriteLine("{0} {1} , adlı oyuncu oyundan silindi", oyuncu.OyuncuAdi, oyuncu.OyuncuSoyadi);
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                public void OyuncuBilgileriListele()
                {

                    int x = 1;
                    foreach (var oyuncu in oyuncular)
                    {
                        Console.WriteLine("{0}. Oyuncunun Adı + {1} Oyuncunun Soyadı + {2} Oyuncunun Doğum Yılı, {3} Oyuncunun Tc No'su", oyuncu.OyuncuAdi, oyuncu.OyuncuSoyadi, oyuncu.DogumYılı, oyuncu.TcNo);
                        x += 1;
                    }
                }
            }
        }
    }

    

 
    

