namespace Sibenice
{
    internal class Program
    {
        static char vstupuzivatele()
        {
            Console.Write("Hádej písmeno:");
            string vstup = Console.ReadLine();
            if (vstup.Length != 1)
            {
                Console.WriteLine("Zadej pouze jedno písmeno.");
                return vstupuzivatele();
            }
            return vstup[0];
        }
        static void Main()
        {
            string[] slovnik = File.ReadAllLines("slovnik.txt");
            Random generator = new Random();
            string hadanka = slovnik[generator.Next(slovnik.Length)];

            string odkryte = "";
            for (int i = 0; i < hadanka.Length; i++)
            {
                odkryte += "_";
            }
            odkryte = odkryte.TrimEnd();
            while (odkryte.Contains("_"))
            {
                Console.WriteLine("Odkryté: " + odkryte);
                char vstup = vstupuzivatele();
                if (hadanka.Contains(vstup) && !odkryte.Contains(vstup))
                {
                    for (int i = 0; i < hadanka.Length; i++) { 
                        char c = hadanka.ToCharArray()[i];
                        if (c == vstup)
                        {
                            odkryte = odkryte.Remove(i, 1).Insert(i, vstup.ToString());
                        }

                    }
                }
            }
            Console.WriteLine("Gratulace! Uhodl jsi slovo: " + hadanka);



        }
    }
}
