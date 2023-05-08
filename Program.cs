using System;
using System.Collections.Generic;

namespace OguzOgrenciYonetimSistemi
{
    internal class Program
    {

        static List<Ogrenci> ogrenciler = new List<Ogrenci>();

        static bool DevamMi = true;
        static void Main(string[] args)
        {
            Uygulama();
        }

        static void Uygulama()
        {
            Menu();

            while (true)
            {

                string giris = SecimAl();

                switch (giris)
                {
                    case "E":
                    case "1":
                        OgrenciEkle();
                        break;
                    case "L":
                    case "2":
                        OgrenciListele();
                        break;
                    case "S":
                    case "3":
                        OgrenciSil();
                        break;
                    case "X":
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                        break;
                }
                Console.WriteLine();
            }

        }


        static string SecimAl()
        {
            string karakterler = "1234ELSX";
            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz : ");
                string giris = Console.ReadLine().ToUpper();

                int index = karakterler.IndexOf(giris);
                Console.WriteLine();

                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else
                {
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
                Console.WriteLine();
            }
        }

        static string IlkHarfBuyut(string metin)
        {
            return metin.Substring(0, 1).ToUpper() + metin.Substring(1).ToLower();
        }

        static void OgrenciEkle()
        {

            Ogrenci o = new Ogrenci();

            Console.WriteLine("1- Öğrenci Ekle ----------");
            Console.WriteLine((ogrenciler.Count + 1) + ". Öğrencinin");

            int no;

            do
            {
                Console.Write("No: ");
                no = int.Parse(Console.ReadLine());


            } while (OgrenciVarMi(no) == true);

            o.No = no;

            Console.Write("Adı: ");
            o.Ad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Soyadı: ");
            o.Soyad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Şubesi: ");
            o.Sube = IlkHarfBuyut(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H) ");
            string secim = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (secim == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }
            Console.WriteLine();

        }

        static bool OgrenciVarMi(int no)
        {
            foreach (Ogrenci item in ogrenciler)
            {
                if (item.No == no)
                {
                    Console.WriteLine("Bu numarada öğrenci var.");
                    return true;
                }
            }
            return false;
        }

        static void OgrenciListele()
        {

            Console.WriteLine("2- Öğrenci Listele-----------");
            Console.WriteLine();

            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
                return;
            }

            Console.WriteLine("Şube".PadRight(8) + "No".PadRight(6) + "Ad Soyad");
            Console.WriteLine("----------------------------------   ");
            foreach (Ogrenci item in ogrenciler)
            {
                Console.WriteLine(item.Sube.PadRight(8) + item.No.ToString().PadRight(6) + item.Ad + " " + item.Soyad);
            }

        }

        static void OgrenciSil()
        {

            Console.WriteLine("3- Öğrenci Sil ----------");
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Silinecek öğrenci yok.");
                return;
            }

            Console.WriteLine("Silmek istediğiniz öğrencinin");
            Console.Write("No: ");
            int no = int.Parse(Console.ReadLine());

            Ogrenci ogr = null;

            foreach (Ogrenci item in ogrenciler)
            {
                if (item.No == no)
                {
                    ogr = item;
                    break;
                }
            }

            if (ogr != null)
            {
                Console.WriteLine("Adı: " + ogr.Ad);
                Console.WriteLine("Soyadı: " + ogr.Soyad);
                Console.WriteLine("Şubesi: " + ogr.Sube);
                Console.WriteLine();

                Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H) ");

                string secim = Console.ReadLine().ToUpper();

                if (secim == "E")
                {
                    ogrenciler.Remove(ogr);
                    Console.WriteLine("Öğrenci silindi.");
                }
                else
                {
                    Console.WriteLine("Öğrenci silinmedi.");
                }
            }
            else
            {
                Console.WriteLine("listede böyle bir öğrenci yok.");
                Console.WriteLine();
            }

        }


        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)       ");
            Console.WriteLine("2 - Öğrenci Listele(L)    ");
            Console.WriteLine("3 - Öğrenci Sil(S)        ");
            Console.WriteLine("4 - Çıkış(X)              ");
            Console.WriteLine();

        }
    }
}
