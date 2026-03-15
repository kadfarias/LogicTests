internal class Program
{
    private record TestInput(int n, int c, int k, string s);

    private static void Main(string[] args)
    {
        var input = GetInput1();

        long result = Solution(input);

        Console.WriteLine("\n====================================");
        Console.WriteLine("INPUT:");
        Console.WriteLine("====================================");
        Console.WriteLine($"input: {input}");
        Console.WriteLine();

        Console.WriteLine("====================================");
        Console.WriteLine("RESULT:");
        Console.WriteLine("====================================");
        Console.WriteLine($"Your Output: {result}");
        Console.WriteLine();
    }

    private static long Solution(TestInput input)
    {

        //N  >= 1 && <= 100 000 -- String lenght
        //C >= 1 && <= 10^9 -- Maximum number after split
        //K >= 1 && <= 18 -- modulo
        //S only digits 0-9 -- the string

        int casaInicial = 1;


        var valores = Enumerable.Range(0, input.s.Split(" ").Count()).
            Select(i => new
            {
                valor = 1
            });

        return 1;
    }

    private static long Iterar(TestInput input, int casaInicial)
    {
        foreach (char c in input.s)
        {
            Console.WriteLine($"Character: {c}");
        }
        return 1;
    }

    private static TestInput GetInput1()
    {
        int n = 5;
        int c = 100;
        int k = 10;
        string s = "12321";
        return new TestInput(n, c, k, s);
    }
}