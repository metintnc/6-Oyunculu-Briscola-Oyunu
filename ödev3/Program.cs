rastgele[] dagıtım = new rastgele[6];
oyun başla = new oyun();

for (int i = 0; i < 6; i++)
{
    Console.Write("{0}. oyuncunun adı:", i + 1);
    başla.oyuncular[i] = Convert.ToString(Console.ReadLine());
    dagıtım[i] = new rastgele();
    dagıtım[i].rast();
    Console.WriteLine("{0} {1} - {2} {3} - {4} {5}", dagıtım[i].tur[0], dagıtım[i].sahip[0], dagıtım[i].tur[1], dagıtım[i].sahip[1],
                                                     dagıtım[i].tur[2], dagıtım[i].sahip[2]);
}
başla.koz = dagıtım[0].koz;
başla.koztur = dagıtım[0].koztur;
Console.WriteLine("\nKoz: {0} {1}\n", dagıtım[0].koztur, dagıtım[0].koz);

List<string> bir = new List<string>();
List<string> iki = new List<string>();
List<string> uc = new List<string>();
List<string> dort = new List<string>();
List<string> bes = new List<string>();
List<string> altı = new List<string>();

for (int s = 0; s < 1;)
{
    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine("{0} adlı oyuncunun sırası(1.{1} {2} - 2.{3} {4} - 3.{5} {6})", başla.oyuncular[i], dagıtım[i].tur[0], dagıtım[i].sahip[0],
                                                                                  dagıtım[i].tur[1], dagıtım[i].sahip[1], dagıtım[i].tur[2], dagıtım[i].sahip[2]);
        dagıtım[i].sayi = Convert.ToInt32(Console.ReadLine());
        başla.oynanan[i] = dagıtım[i].sahip[dagıtım[i].sayi - 1];
        başla.turler[i] = dagıtım[i].tur[dagıtım[i].sayi - 1];
        
    }
    başla.sıra();
    bir.Add(string.Format("{0} {1}", dagıtım[0].tur[dagıtım[0].sayi - 1], dagıtım[0].sahip[dagıtım[0].sayi - 1]));
    iki.Add(string.Format("{0} {1}", dagıtım[1].tur[dagıtım[1].sayi - 1], dagıtım[1].sahip[dagıtım[1].sayi - 1]));
    uc.Add(string.Format("{0} {1}", dagıtım[2].tur[dagıtım[2].sayi - 1], dagıtım[2].sahip[dagıtım[2].sayi - 1]));
    dort.Add(string.Format("{0} {1}", dagıtım[3].tur[dagıtım[3].sayi - 1], dagıtım[3].sahip[dagıtım[3].sayi - 1]));
    bes.Add(string.Format("{0} {1}", dagıtım[4].tur[dagıtım[4].sayi - 1], dagıtım[4].sahip[dagıtım[4].sayi - 1]));
    altı.Add(string.Format("{0} {1}", dagıtım[5].tur[dagıtım[5].sayi - 1], dagıtım[5].sahip[dagıtım[5].sayi - 1]));

    for (int i = 0; i < 6; i++)
    {
        if (başla.toplampuanlar[i] > 61)
        {
            Console.WriteLine("Oyunu {0} puan ile {1} kazanıyor. Oyun bitiyor.\n", başla.toplampuanlar[i], başla.oyuncular[i]);
            s = 1;
            i = 6;
        }
    }
    for(int i = 0; i < 6; i++)
    {
        if (s == 0)
        {
            dagıtım[i].siradakikart();
        }
    }
}

for (int i = 0; i < 6; i++)
{
    Console.WriteLine("{0} adlı oyuncunun kartları: {1} {2} - {3} {4} - {5} {6}", başla.oyuncular[i], dagıtım[i].tur[0], dagıtım[i].sahip[0],
                                                                                  dagıtım[i].tur[1], dagıtım[i].sahip[1], dagıtım[i].tur[2], dagıtım[i].sahip[2]);
}
Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[0]);
foreach (string s in bir)
    Console.WriteLine(s);

Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[1]);
foreach (string s in iki)
    Console.WriteLine(s);

Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[2]);
foreach (string s in uc)
    Console.WriteLine(s);

Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[3]);
foreach (string s in dort)
    Console.WriteLine(s);

Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[4]);
foreach (string s in bes)
    Console.WriteLine(s);

Console.WriteLine("\n{0} adlı oyuncunun oyun boyunca yaptığı hamleler:", başla.oyuncular[5]);
foreach (string s in altı)
    Console.WriteLine(s);

Console.ReadKey();
public class oyun
{
    public int[] toplampuanlar = new int[6];
    public string[] oyuncular = new string[6];
    public string[] oynanan = new string[6];
    public int[] puan = new int[6];
    public string koz;
    public string koztur;
    public string[] turler = new string[6];
    public void sıra()
    {
        int kazanan = 0;
        int ı = -1;

        for (int i = 0; i < 6; i++)
        {
            switch (oynanan[i])
            {
                case "As":
                    puan[i] = 11;
                    break;
                case "Kral":
                    puan[i] = 4;
                    break;
                case "3":
                    puan[i] = 10;
                    break;
                case "At":
                    puan[i] = 3;
                    break;
                case "Vale":
                    puan[i] = 2;
                    break;
                default:
                    puan[i] = 0;
                    break;
            }
        }
        for (int i = 0; i < 6; i++)
        {
            if (koztur == turler[i] && puan[i] >= kazanan)
            {
                kazanan = puan[i];
                ı = i;
            }
        }

        if (ı == -1)
        {
            for (int i = 0; i < 6; i++)
            {
                if (puan[i] >= kazanan && turler[0] == turler[i])
                {
                    kazanan = puan[i];
                    ı = i;
                }
            }
        }
        for (int i = 0; i < 6; i++)
        {
            kazanan += puan[i];
        }
        toplampuanlar[ı] += kazanan;
        Console.WriteLine("bu elin kazananı {0} puan ile {1} oluyor", kazanan, oyuncular[ı]);
        Console.WriteLine("Puan Durumu");
        for (int i = 0; i < 6; i++)
            Console.WriteLine("{0}: {1}", oyuncular[i], toplampuanlar[i]);
    }
}

public class rastgele
{
    public string[] sahip = new string[3];
    public string[] kartlar = { "As", "Kral", "3", "At", "Vale", "2", "4", "5", "6", "7" };
    public string[] turler = { "Karo", "Maça", "Sinek", "Kupa" };
    public string[] tur = new string[3];
    public string koz;
    public string koztur;
    public int sayi;
    Random rnd = new Random();
    public void rast()
    {
        sahip[0] = kartlar[rnd.Next(0, 9)];
        sahip[1] = kartlar[rnd.Next(0, 9)];
        sahip[2] = kartlar[rnd.Next(0, 9)];
        tur[0] = turler[rnd.Next(0, 4)];
        tur[1] = turler[rnd.Next(0, 4)];
        tur[2] = turler[rnd.Next(0, 4)];
        koz = kartlar[rnd.Next(0, 9)];
        koztur = turler[rnd.Next(0, 4)];
    }
    public void siradakikart()
    {
        tur[sayi - 1] = turler[rnd.Next(0, 4)];
        sahip[sayi - 1] = kartlar[rnd.Next(0, 9)];
    }
}