namespace MissingNumber;

class Program
{
    static void Main(string[] args)
    {
        Methods methods = new Methods();
        Parser parser = new Parser();
        
        int[] mockArr = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        
        Console.WriteLine("Welcome! Please enter the input array:");
        string input = Console.ReadLine();

        int[] numbers =
            input == ""
                ? mockArr
                : parser.parseInput(input);
        
        int missingNumber = methods.findMissingNumber(numbers);

        Console.WriteLine(missingNumber);
    }

    
}

class Methods
{
    public int findMissingNumber(int[] numbers)
    {
        int length = numbers.Length;
        int missingNumber = sumNaturalNumbers(length) - numbers.Sum();
        
        return missingNumber;
    }
    int sumNaturalNumbers(int n)
    {
        return n * (n + 1) / 2;
    }
    
}

class Parser
{
    public int[] parseInput(string input)
    {
        int[] parsedArr = input
            .Trim('[', ']')
            .Split(',')
            .Select(x => int.Parse(x.Trim()))
            .ToArray();
        return parsedArr;
    }
}