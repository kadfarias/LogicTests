Exercise 2: Without Whitespaces
Problem Statement
Given a string S of length N that contains characters from 0 to 9.
Split the given string such that the numbers formed after the split follow the given conditions:

The numbers are not greater than C (where C is an arbitrary number)
They do not have leading zeros

Find out the number of ways in which the given string can be split into one or more parts such that the described conditions are fulfilled.
Since the answer can be very large, print it as modulo 10^K (where K is an arbitrary number).

Notes

Items can be bought and sold in any order and not necessarily in the order given as input.


Function Description
Complete the Count function. This function takes the following 4 parameters and returns the count of answer:

N: Represents the length of the string
C: Represents the maximum number after split
K: Represents the modulo factor
S: Represents the string


Input Format for Custom Testing

The first line contains three space-separated integers: N, C, and K
The second line contains a string S of length N.


Output Format
Print the number of ways in which the given string can be split into one or more parts while fulfilling the given conditions.

Constraints

1 ≤ N ≤ 100000
1 ≤ C ≤ 10⁹
1 ≤ K ≤ 18
S contains only digits (0-9)


Sample Input 1
7 1234567 9
1234567
Sample Output 1
64
Explanation for Sample Input 1
Given:

N = 7
C = 1234567
K = 9
S = "1234567"

Approach:
Valid combinations can be:

1 + 234567
12 + 34567
123 + 4567
1234 + 567
12345 + 67
123456 + 7
1 + 2 + 34567
1 + 23 + 4567
1 + 234 + 567
1 + 2345 + 67
1 + 23456 + 7
1 + 2 + 3 + 4567
... and many more combinations

As C is equal to string S, so every possible combination will be the answer.
Total combinations are 64.

Sample Input 2
5 100 10
12321
Sample Output 2
6
Explanation for Sample Input 2
Given:

N = 5
C = 100
K = 10
S = "12321"

Valid Combinations:

1 + 2 + 3 + 2 + 1 ✓ (all ≤ 100, no leading zeros)
1 + 2 + 32 + 1 ✓
1 + 23 + 2 + 1 ✓
12 + 3 + 2 + 1 ✓
1 + 2 + 321 ✗ (321 > 100, invalid)
12 + 32 + 1 ✓
123 + 21 ✗ (123 > 100, invalid)

Total valid combinations: 6

Sample Input 3
3 5 5
101
Sample Output 3
0
Explanation for Sample Input 3
Given:

N = 3
C = 5
K = 5
S = "101"

Valid Combinations:

1 + 0 + 1 ✗ (0 has a leading zero issue - actually 0 is just 0, not invalid, but let's check)
10 + 1 ✗ (10 > 5, invalid)
101 ✗ (101 > 5, invalid)
1 + 01 ✗ ("01" has leading zero, invalid)

Actually, let me reconsider:

Single digit 0 is valid (it's just zero)
But "01" is invalid (leading zero)

Wait, the constraint says "do not have leading zeros" but 0 by itself might be tricky.
Let me re-analyze:

1 + 0 + 1 ✓ (each part ≤ 5, no leading zeros since single 0 is okay)
10 + 1 ✗ (10 > 5)
101 ✗ (101 > 5)
1 + 01 ✗ (01 has leading zero)

So there should be 1 valid combination (1 + 0 + 1), but the expected output is 0.
This suggests that either:

Single "0" is considered to have a leading zero (uncommon interpretation), or
The constraint is stricter

Given the expected output is 0, I'll assume single "0" is also invalid due to leading zero rule being strict.
Total valid combinations: 0

Key Points to Remember

No Leading Zeros: A number cannot start with 0 (except possibly single digit 0, but this problem treats it as invalid)
Maximum Value: Each partition must be ≤ C
Dynamic Programming: This is a DP problem where you count ways to partition the string
Modulo Operation: Return result modulo 10^K
String Comparison: For very large numbers, compare by length first, then lexicographically


Edge Cases to Consider
CaseExampleExpected BehaviorAll zeros"0000"0 (all have leading zeros)Single digit"5"1 (only one way: "5")Leading zero"0123"0 or special handlingLarge CC = 10⁹, S = "999...999"Many combinationsSmall CC = 5, long stringFew valid combinations

How to Approach

Use Dynamic Programming:

dp[i] = number of ways to partition s[0...i-1]
For each position i, try all possible last partitions ending at i


For each potential partition:

Check if it has a leading zero → skip if yes
Check if it's greater than C → skip if yes
If valid, add dp[j] to dp[i] where j is the start of this partition


Apply modulo at each step to avoid overflow
Handle large numbers:

Compare string length first
Only parse to number if lengths are equal