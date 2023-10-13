using System;
using System.Collections.Generic;

class Program
{
    static double para = 90000;
    static Dictionary<string, List<string>> urunListeleri = new Dictionary<string, List<string>>()
    {
        { "meyve", new List<string> { "elma", "armut", "karpuz" } },
        { "sebze", new List<string> { "domates", "biber", "soğan" } }
    };

    // Ürün stokları
    static Dictionary<string, int> urunStoklari = new Dictionary<string, int>()
    {
        { "elma", 100 },
        { "armut", 50 },
        { "karpuz", 30 },
        { "domates", 80 },
        { "biber", 60 },
        { "soğan", 90 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Ana Menü");
            Console.WriteLine("1- Hal Bölümü");
            Console.WriteLine("2- Manav Bölümü");
            Console.WriteLine("3- Müşteri Bölümü");
            Console.WriteLine("9- Ana Menüye Dön");
            Console.WriteLine("0- Programı Kapat");

            Console.Write("Lütfen bir seçenek girin: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    HalBolumu();
                    break;
                case "2":
                    ManavBolumu();
                    break;
                case "3":
                    MusteriBolumu();
                    break;
                case "9":
                    continue; // Ana menüye dön
                case "0":
                    return; // Programı kapat
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen geçerli bir seçenek girin.");
                    break;
            }
        }
    }

    static void HalBolumu()
    {
        while (true)
        {
            Console.WriteLine("Hal Bölümü");
            Console.WriteLine("Meyve mi istiyorsunuz yoksa sebzemi?");
            string secim1 = Console.ReadLine();

            if (secim1.ToLower() == "meyve" || secim1.ToLower() == "sebze")
            {
                List<string> urunler = urunListeleri[secim1.ToLower()];

                for (int i = 0; i < urunler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{urunler[i]}");
                }

                Console.Write($"Kaç numaralı ürünü almak istersiniz? (1-{urunler.Count}): ");
                int secilenUrunIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                if (secilenUrunIndex >= 0 && secilenUrunIndex < urunler.Count)
                {
                    string secilenUrun = urunler[secilenUrunIndex];

                    Console.Write($"Kaç kilo {secilenUrun} almak istiyorsunuz: ");
                    int kilo = Convert.ToInt32(Console.ReadLine());

                    double fiyat = kilo * (secim1.ToLower() == "meyve" ? 5 : 3); // Kilogram başı fiyat
                    if (para >= fiyat)
                    {
                        para -= fiyat;
                        urunStoklari[secilenUrun] += kilo; // Stok miktarını güncelle
                        Console.WriteLine($"{kilo} kilo {secilenUrun} aldınız. Kalan para: ${para}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye. Daha az kilo seçin veya başka bir ürün seçin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün numarası.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen meyve veya sebze girin.");
            }

            Console.Write("Başka bir ürün almak ister misiniz? (Evet/Hayır): ");
            string devamSecim = Console.ReadLine();

            if (devamSecim.ToLower() != "evet")
            {
                break;
            }
        }
    }

    static void ManavBolumu()
    {
        while (true)
        {
            Console.WriteLine("Manav Bölümü");
            Console.WriteLine("Meyve mi sebze mi?");
            string secim2 = Console.ReadLine();

            if (secim2.ToLower() == "meyve")
            {
                // Manav meyve listesini göster
                foreach (var meyve in urunListeleri["meyve"])
                {
                    Console.WriteLine($"{meyve} - Stok Miktarı: {urunStoklari[meyve]}");
                }
            }
            else if (secim2.ToLower() == "sebze")
            {
                // Manav sebze listesini göster
                foreach (var sebze in urunListeleri["sebze"])
                {
                    Console.WriteLine($"{sebze} - Stok Miktarı: {urunStoklari[sebze]}");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen meyve veya sebze girin.");
            }

            Console.Write("Başka bir işlem yapmak ister misiniz? (Evet/Hayır): ");
            string devamSecim = Console.ReadLine();

            if (devamSecim.ToLower() != "evet")
            {
                break;
            }
        }
    }

    static void MusteriBolumu()
    {
        while (true)
        {
            Console.WriteLine("Müşteri Bölümü");
            Console.WriteLine("Meyve mi sebze mi?");
            string secim3 = Console.ReadLine();

            if (secim3.ToLower() == "meyve" || secim3.ToLower() == "sebze")
            {
                List<string> urunler = urunListeleri[secim3.ToLower()];

                for (int i = 0; i < urunler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{urunler[i]} - Stok Miktarı: {urunStoklari[urunler[i]]}");
                }

                Console.Write($"Hangi numaralı ürünü almak istersiniz? (1-{urunler.Count}): ");
                int secilenUrunIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                if (secilenUrunIndex >= 0 && secilenUrunIndex < urunler.Count)
                {
                    string secilenUrun = urunler[secilenUrunIndex];

                    Console.Write($"Kaç kilo {secilenUrun} almak istiyorsunuz: ");
                    int kilo = Convert.ToInt32(Console.ReadLine());

                    double fiyat = kilo * (secim3.ToLower() == "meyve" ? 5 : 3); // Kilogram başı fiyat
                    if (para >= fiyat && urunStoklari[secilenUrun] >= kilo)
                    {
                        para -= fiyat;
                        urunStoklari[secilenUrun] -= kilo; // Stok miktarını azalt
                        Console.WriteLine($"{kilo} kilo {secilenUrun} aldınız. Kalan para: ${para}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye veya yetersiz stok. Daha az kilo seçin veya başka bir ürün seçin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün numarası.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen meyve veya sebze girin.");
            }

            Console.Write("Başka bir işlem yapmak ister misiniz? (Evet/Hayır): ");
            string devamSecim = Console.ReadLine();

            if (devamSecim.ToLower() != "evet")
            {
                break;
            }
        }
    }
}
