Console.WriteLine("Enter the first number");
int numA = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter the second number");
int numB = Convert.ToInt16(Console.ReadLine());

List<int> primeA = DecomposeNumber(numA);
List<int> primeB = DecomposeNumber(numB);

List<List<int>> countPrimeA = CountPrimeNumbers(primeA);
List<List<int>> countPrimeB = CountPrimeNumbers(primeB);


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
    }
    return primeNumbers;
}

List<List<int>> CountPrimeNumbers(List<int> lista)
{
    List<List<int>> conteo = new List<List<int>>();

    foreach (int p in lista)
    {
        bool encontrado = false;

        for (int i = 0; i < conteo.Count; i++)
        {
            if (conteo[i][0] == p)
            {
                conteo[i][1]++;
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            conteo.Add(new List<int> { p, 1 });
        }
    }

    return conteo;
}