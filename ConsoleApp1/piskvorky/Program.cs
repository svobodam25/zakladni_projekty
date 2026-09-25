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
                        _ => ".",
                    };
                    Console.Write(pole[index] + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            int sirka_piskvorek = 3;
            int vyska_piskvorek = 3;
            int k_dokonceni = 3;

            int[] pole = new int[sirka_piskvorek * vyska_piskvorek];
            vytisknout(pole, sirka_piskvorek, vyska_piskvorek);
        }
    }
}
