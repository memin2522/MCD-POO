Console.WriteLine("Enter the first number");
int numA = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter the second number");
int numB = Convert.ToInt16(Console.ReadLine());

List<int> primeA = DecomposeNumber(numA);
List<int> primeB = DecomposeNumber(numB);

List<List<int>> countPrimeA = CountPrimeNumbers(primeA);
List<List<int>> countPrimeB = CountPrimeNumbers(primeB);

int mcd = CalculateMCD(countPrimeA, countPrimeB);
Console.WriteLine($"The MCD of {numA} and {numB} is: {mcd}");

List<int> DecomposeNumber(int number)
{
    List<int> primeNumbers = new List<int>();

    while (number != 1)
    {
        if (number % 2 == 0)
        {
            primeNumbers.Add(2);
            number = number / 2;
        }
        else if (number % 3 == 0)
        {
            primeNumbers.Add(3);
            number = number / 3;
        }
        else if (number % 5 == 0)
        {
            primeNumbers.Add(5);
            number = number / 5;
        }
        else if (number % 7 == 0)
        {
            primeNumbers.Add(7);
            number = number / 7;
        }
        else
        {
            primeNumbers.Add(number);
            number = 1;
        }
    }
    return primeNumbers;
}

List<List<int>> CountPrimeNumbers(List<int> primeList)
{
    List<List<int>> count = new List<List<int>>();

    foreach (int prime in primeList)
    {
        bool exists = false;

        for (int i = 0; i < count.Count; i++)
        {
            if (count[i][0] == prime)
            {
                count[i][1]++;
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            count.Add(new List<int> { prime, 1 });
        }
    }

    return count;
}

int CalculateMCD(List<List<int>> countA, List<List<int>> countB)
{
    int result = 1;

    for (int i = 0; i < countA.Count; i++)
    {
        for (int j = 0; j < countB.Count; j++)
        {
            if (countA[i][0] == countB[j][0])
            {
                if (countA[i][1] < countB[j][1])
                {
                    result *= (int)Math.Pow(countA[i][0], countA[i][1]);
                }
                else
                {
                    result *= (int)Math.Pow(countB[j][0], countB[j][1]);
                }
            }
        }
    }

    return result;
}