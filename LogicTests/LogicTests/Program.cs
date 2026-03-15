internal class Program
{
    // Record para encapsular os dados de entrada
    private record TestInput(int N, long K, long[] Cost, long[] Sell);

    private static void Main(string[] args)
    {
        var input = GetInput1();

        long result = Solution(input.N, input.K, input.Cost, input.Sell);

        Console.WriteLine("\n====================================");
        Console.WriteLine("INPUT:");
        Console.WriteLine("====================================");
        Console.WriteLine($"N: {input.N}");
        Console.WriteLine($"K: {input.K}");
        Console.WriteLine($"Cost: [{string.Join(", ", input.Cost)}]");
        Console.WriteLine($"Sell: [{string.Join(", ", input.Sell)}]");
        Console.WriteLine();

        Console.WriteLine("====================================");
        Console.WriteLine("RESULT:");
        Console.WriteLine("====================================");
        Console.WriteLine($"Your Output: {result}");
        Console.WriteLine();
    }

    private static long Solution(int n, long k, long[] cost, long[] sell)
    {
        var caixa = k;

        var nItens = n;

        long totalProfit = 0;

        var vendas = Enumerable.Range(0, nItens)
            .Select(i => new
            {
                lucro = sell[i] - cost[i],
                cost = cost[i],
                sell = sell[i]
            }).Where(x => x.lucro > 0)
                .OrderByDescending(p => p.lucro).ToList();

        foreach (var item in vendas)
        {
            if (caixa >= item.cost)
            {
                caixa -= item.cost;
                caixa += item.sell;
                totalProfit += item.lucro;
            }
        }


        return totalProfit;
    }

    private static TestInput GetInput1()
    {
        int n = 2;
        long k = 50;
        string costStr = "25 30";
        string sellStr = "25 37";

        long[] cost = costStr.Split().Select(long.Parse).ToArray();
        long[] sell = sellStr.Split().Select(long.Parse).ToArray();

        return new TestInput(n, k, cost, sell);
    }

    // ============================================================
    // TEST CASE 2: All Items Profitable
    // ============================================================
    private static TestInput GetInput2()
    {
        int n = 4;
        long k = 100;
        string costStr = "10 20 30 40";
        string sellStr = "15 30 45 60";

        long[] cost = costStr.Split().Select(long.Parse).ToArray();
        long[] sell = sellStr.Split().Select(long.Parse).ToArray();

        return new TestInput(n, k, cost, sell);
    }

    // ============================================================
    // TEST CASE 3: No Profitable Items (All Losses)
    // ============================================================
    private static TestInput GetInput3()
    {
        int n = 3;
        long k = 100;
        string costStr = "50 60 70";
        string sellStr = "40 55 65";

        long[] cost = costStr.Split().Select(long.Parse).ToArray();
        long[] sell = sellStr.Split().Select(long.Parse).ToArray();

        return new TestInput(n, k, cost, sell);
    }

    // ============================================================
    // TEST CASE 4: Insufficient Capital
    // ============================================================
    private static TestInput GetInput4()
    {
        int n = 3;
        long k = 10;
        string costStr = "50 60 70";
        string sellStr = "100 120 140";

        long[] cost = costStr.Split().Select(long.Parse).ToArray();
        long[] sell = sellStr.Split().Select(long.Parse).ToArray();

        return new TestInput(n, k, cost, sell);
    }

    // ============================================================
    // TEST CASE 5: Array Size Mismatch (Robustness Test)
    // ============================================================
    private static TestInput GetInput5()
    {
        int n = 5;
        long k = 100;
        string costStr = "10 20 30 40";      // Only 4 elements
        string sellStr = "50 60 70 80";      // Only 4 elements

        long[] cost = costStr.Split().Select(long.Parse).ToArray();
        long[] sell = sellStr.Split().Select(long.Parse).ToArray();

        return new TestInput(n, k, cost, sell);
    }
}