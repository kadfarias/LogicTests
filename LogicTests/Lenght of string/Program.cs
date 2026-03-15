internal class Program
{
    private record TestInput(string imput);

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


        return 1;
    }

    private static TestInput GetInput1()
    {
        string imput = "0 ,1 ,2 ,3 ,4";

        return new TestInput(imput);
    }
}