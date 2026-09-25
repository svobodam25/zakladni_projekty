namespace Kamen_nuzky_papir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadej KAMEN/NUZKY/PAPIR: ");
            string vstup = Console.ReadLine();
            int nase_odpoved = 0;
            if (vstup == "KAMEN")
            {
                nase_odpoved = 0;
            }
            else if (vstup == "NUZKY")
            {
                nase_odpoved = 1;
            }
            else if (vstup == "PAPIR")
            {
                nase_odpoved = 2;
            }
            else
            {
                Console.WriteLine("Neplatny pohyb");
                return;
            }

            Random nahodny_generator = new Random();
            int odpoved_nahody = nahodny_generator.Next(0, 3);

            if (odpoved_nahody == nase_odpoved)
            {
                Console.WriteLine("Remiza oba jste pouzili {0}.", vstup);
                return;
            }

            if (odpoved_nahody == 0)
            {
                if (nase_odpoved == 1) {
                    Console.WriteLine("Prohral jsi! KAMEN rozdrtil NUZKY.");
                } else
                {
                    Console.WriteLine("Vyhral jsi! PAPIR porazil KAMEN.");
                }
            } else if (odpoved_nahody == 1)
            {
                if (nase_odpoved == 0)
                {
                    Console.WriteLine("Vyhral jsi! KAMEN rozdrtil NUZKY.");
                } else
                {
                    Console.WriteLine("Prohral jsi! Nuzky porazili PAPIR.");
                }
            } else
            {
                if (nase_odpoved == 0)
                {
                    Console.WriteLine("Prohral jsi! PAPIR porazil KAMEN.");
                }
                else if (nase_odpoved == 1)
                {
                    Console.WriteLine("Vyhral jsi! NUZKY osekaly PAPIR.");
                }
            }
        }
    }
}
