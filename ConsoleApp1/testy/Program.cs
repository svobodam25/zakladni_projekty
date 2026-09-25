namespace testy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] poleCisel;
            poleCisel = new int[10];

            Console.WriteLine(poleCisel);

            List<int> cisla = new List<int>();
            cisla.Add(1);
            for (int i = 0; i < 10; i++)
            {
                cisla.Add(i);
            }

            foreach (int cislo in cisla)
            {
                Console.WriteLine(cislo);
            }
        }
    }
}
