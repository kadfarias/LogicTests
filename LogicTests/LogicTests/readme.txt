Problem Statement
A shopkeeper has the option to buy N items from a producer at a cost of cost[i], and he can sell them at sell[i]. 
Initially, he has K rupees (initial capital) and 0 items in his shop. At any moment, his store can accommodate at most 1 item, 
which means he has to sell the previous item before buying the next one from the producer.
What is the maximum profit he can achieve?

Notes

He can buy and sell any number of items
He can use the profit previously earned to buy new items
One item can be bought and sold almost once
Items can be bought and sold in any order and not necessarily in the order given as input

Function Description
Complete the function Solution() provided in the editor. The function takes the following 4 parameters and returns the solution:

N: Represents the number of items available to buy
K: Represents the initial amount of capital (in rupees)
cost: Represents the cost price of each item (array)
sell: Represents the selling price of each item (array)

Input Format for Custom Testing

The first line contains three space-separated integers: N, K, and modulo factor (not used for this exercise, ignore)
The second line contains cost array values separated by spaces
The third line contains sell array values separated by spaces

Output Format
Print an integer, representing the maximum total profit.

Constraints

1 ≤ N ≤ 10⁵
0 ≤ K ≤ 10⁹
1 ≤ cost[i] ≤ 10⁹
1 ≤ sell[i] ≤ 10⁹

Test Cases for Local Testing
Copy each test case into Visual Studio and test separately.
Test Case 1: Basic Example (From Problem)

Input:
2 50 0
25 30
25 37

Expected Output:
7

Explanation:
- Buy item 1 (cost 30) → Sell for 37 → Profit: 7, Money left: 57
- Item 0 has zero profit (25-25=0), skip it or buy after
- Maximum profit: 7

Test Case 2: All Items Profitable

Input:
4 100 0
10 20 30 40
15 30 45 60

Expected Output:
60

Explanation:
- Buy item 0 (10) → Sell (15) → Profit: 5, Money: 105
- Buy item 1 (20) → Sell (30) → Profit: 10, Money: 115
- Buy item 2 (30) → Sell (45) → Profit: 15, Money: 130
- Buy item 3 (40) → Sell (60) → Profit: 20, Money: 150
- Total profit: 5 + 10 + 15 + 20 = 50
Wait, let me recalculate...
Actually: Starting with 100
- Buy item 3 (40) → Sell (60) → Profit: 20, Money: 120
- Buy item 2 (30) → Sell (45) → Profit: 15, Money: 135
- Buy item 1 (20) → Sell (30) → Profit: 10, Money: 145
- Buy item 0 (10) → Sell (15) → Profit: 5, Money: 150
- Total profit: 20 + 15 + 10 + 5 = 50
Total money: 100 + 50 = 150, so profit is 50

Test Case 3: No Profitable Items (All Losses)

Input:
3 100 0
50 60 70
40 55 65

Expected Output:
0

Explanation:
- Item 0: profit = 40 - 50 = -10 (loss, skip)
- Item 1: profit = 55 - 60 = -5 (loss, skip)
- Item 2: profit = 65 - 70 = -5 (loss, skip)
- No profitable items, maximum profit: 0

Test Case 4: Insufficient Capital (Edge Case)

Input:
3 10 0
50 60 70
100 120 140

Expected Output:
0

Explanation:
- Capital is 10 rupees
- Cheapest item costs 50
- Cannot afford any item
- Maximum profit: 0

Test Case 5: Single Item

Input:
1 100 0
30
80

Expected Output:
50

Explanation:
- Only one item available
- Buy for 30, Sell for 80
- Profit: 50
- Money left: 100 - 30 + 80 = 150
- Maximum profit: 50

Test Case 6: Array Size Mismatch (EDGE CASE - Tests Robustness)

Input:
5 1000 0
100 200 300 400
100 200 300 400

Expected Output:
400

Explanation:
This tests if your code handles when N=5 but arrays have only 4 elements.
- Actual items: 4 (take minimum of array lengths)
- Profitable items: all 4 (profit of 0, 0, 0, 0)
- Actually all have 0 profit, so maximum profit: 0
Actually wait, let me recalculate:
- Item 0: 100-100 = 0
- Item 1: 200-200 = 0
- Item 2: 300-300 = 0
- Item 3: 400-400 = 0
- Expected Output: 0

Let me fix this test case...

Test Case 6 (CORRECTED): Array Size Mismatch

Input:
5 100 0
10 20 30 40
50 60 70 80

Expected Output:
200

Explanation:
- N=5 but arrays have 4 elements
- Your code must use Math.Min(cost.Length, sell.Length, n) = 4
- Item 0: profit = 50-10 = 40
- Item 1: profit = 60-20 = 40
- Item 2: profit = 70-30 = 40
- Item 3: profit = 80-40 = 40
- All profitable, capital sufficient for all
- Total profit: 40 + 40 + 40 + 40 = 160
Wait, let me trace execution:
Starting with 100:
- Buy item 3 (40) → Sell (80) → Profit: 40, Money: 140
- Buy item 2 (30) → Sell (70) → Profit: 40, Money: 180
- Buy item 1 (20) → Sell (60) → Profit: 40, Money: 220
- Buy item 0 (10) → Sell (50) → Profit: 40, Money: 260
- Total profit: 40 + 40 + 40 + 40 = 160

Test Case 7: Large Numbers (Overflow Risk)

Input:
3 1000000000 0
999999999 500000000 750000000
1000000000 600000000 800000000

Expected Output:
700000001

Explanation:
- Tests if you use `long` instead of `int`
- Item 0: profit = 1000000000 - 999999999 = 1
- Item 1: profit = 600000000 - 500000000 = 100000000
- Item 2: profit = 800000000 - 750000000 = 50000000
- All profitable, order matters for capital
- Buy item 1 (500000000) → Sell (600000000) → Profit: 100000000, Money: 1100000000
- Buy item 2 (750000000) → Sell (800000000) → Profit: 50000000, Money: 1350000000
- Buy item 0 (999999999) → Sell (1000000000) → Profit: 1, Money: 1350000001
- Total profit: 100000000 + 50000000 + 1 = 150000001
Wait let me recalculate...
Starting: 1000000000
After item 1: 1000000000 - 500000000 + 600000000 = 1100000000
After item 2: 1100000000 - 750000000 + 800000000 = 1150000000
After item 0: 1150000000 - 999999999 + 1000000000 = 1150000001
Final money: 1150000001
Initial: 1000000000
Profit: 1150000001 - 1000000000 = 150000001

Test Case 8: Empty Profitable Set with Some Capital Left

Input:
4 500 0
100 200 300 400
80 150 250 350

Expected Output:
0

Explanation:
- Item 0: profit = 80 - 100 = -20 (loss)
- Item 1: profit = 150 - 200 = -50 (loss)
- Item 2: profit = 250 - 300 = -50 (loss)
- Item 3: profit = 350 - 400 = -50 (loss)
- No profitable items despite having capital
- Maximum profit: 0

Test Case 9: Greedy Order Matters

Input:
3 50 0
30 40 20
40 45 100

Expected Output:
70

Explanation:
This tests if you correctly order by profit (highest first)
- Item 0: profit = 40 - 30 = 10
- Item 1: profit = 45 - 40 = 5
- Item 2: profit = 100 - 20 = 80 (highest!)
- Correct order: Item 2 (80), then Item 0 (10), then Item 1 (5)
Starting with 50:
- Buy item 2 (20) → Sell (100) → Profit: 80, Money: 130
- Buy item 0 (30) → Sell (40) → Profit: 10, Money: 140
- Buy item 1 (40) → Sell (45) → Profit: 5, Money: 145
- Total profit: 80 + 10 + 5 = 95


Test Case 10: Zero Profit Items (Border Case)

Input:
3 100 0
10 20 30
10 20 30

Expected Output:
0

Explanation:
- Item 0: profit = 10 - 10 = 0
- Item 1: profit = 20 - 20 = 0
- Item 2: profit = 30 - 30 = 0
- All items have zero profit
- Your code should SKIP them (profit > 0 check)
- Maximum profit: 0


Summary of Edge Cases Tested
Test #Focus AreaRisk Being Tested1BasicUnderstanding2All profitableGreedy ordering3All lossesFiltering
logic4Insufficient capitalCapital validation5Single itemBoundary6Array mismatchIndexOutOfRangeException7Large 
numbersint overflow → use long8Profitable skipFiltering
zero/negative profit9Greedy orderSorting by profit DESC10Zero profitEdge of filtering condition