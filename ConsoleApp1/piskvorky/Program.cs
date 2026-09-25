namespace piskvorky
{
    internal class Program
    {

        static void vytisknout(int[] pole, int sirka, int vyska)
        {
            for (int y = 0; y < vyska; y++)
            {
                for (int x = 0; x < sirka; x++)
                {
                    int index = y * sirka + x;
                    int status = pole[index];
                    string symbol = status switch
                    {
                        1 => "X",
                        2 => "O",
                        _ => Convert.ToString(index+1),
                    };
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int volbahrace(int sirka_piskvorek, int vyska_piskvorek)
        {
            Console.WriteLine();
            Console.Write("Vyberte jedno z volných polí: ");
            string vstup = Console.ReadLine();
            int maxVolba = sirka_piskvorek * vyska_piskvorek;
            try
            {
                int volba = int.Parse(vstup);
                if (volba <= maxVolba)
                {
                    return volba-1;
                } else
                {
                    Console.WriteLine("Neplatný vstup. Zadejte číslo.");
                    return volbahrace(sirka_piskvorek, vyska_piskvorek);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Neplatný vstup. Zadejte číslo.");
                return volbahrace(sirka_piskvorek, vyska_piskvorek);
            }
        }

        static int volbapocitace(int[] pole)
        {
            Random random = new Random();
            List<int> volne_pozice = new List<int>();
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] == 0)
                {
                    volne_pozice.Add(i);
                }
            }
            return volne_pozice[random.Next(0, volne_pozice.Count)];
        }

        static int vyhodnoceni(int[] pole, int k_dokonceni, int sirka, int vyska)
        {
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] != 0)
                {
                    for (int j = 0; j < k_dokonceni; j++)
                    {
                        if (i + j * sirka < pole.Length && pole[i + j * sirka] == pole[i])
                        {
                            if (j == k_dokonceni - 1)
                            {
                                return pole[i];
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }   
            return 0;
        }

        static void Main(string[] args)
        {
            int sirka_piskvorek = 3;
            int vyska_piskvorek = 3;
            int k_dokonceni = 3;

            int[] pole = new int[sirka_piskvorek * vyska_piskvorek];
            vytisknout(pole, sirka_piskvorek, vyska_piskvorek);
            while (true) {
                int volba_hrace = volbahrace(sirka_piskvorek, vyska_piskvorek);
                pole[volba_hrace] = 1;
                vytisknout(pole, sirka_piskvorek, vyska_piskvorek);
                int vysledek = vyhodnoceni(pole, k_dokonceni, sirka_piskvorek, vyska_piskvorek);
                if (vysledek == 1)
                {
                    Console.WriteLine("Vyhrál hráč!");
                    return;
                }
                else if (vysledek == 2)
                {
                    Console.WriteLine("Vyhrál počítač!");
                    return;
                }
                int volba_pocitace = volbapocitace(pole);
                pole[volba_pocitace] = 2;
                vytisknout(pole, sirka_piskvorek, vyska_piskvorek);
                vysledek = vyhodnoceni(pole, k_dokonceni, sirka_piskvorek, vyska_piskvorek);
                if (vysledek == 1)
                {
                    Console.WriteLine("Vyhrál hráč!");
                    return;
                }
                else if (vysledek == 2)
                {
                    Console.WriteLine("Vyhrál počítač!");
                    return;
                }

            }
        }
    }
}
