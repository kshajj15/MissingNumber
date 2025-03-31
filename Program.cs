namespace MissingNumber;

class App
{
    
    // isUserInput is a toggleable flag that determines whether the app takes user input for the array or uses an array defined in code
    private static bool isUserInput = true;
    
    // numbersInput is a changeable array that is used in case the user does not input anything, or if the isUserInput flag is set to false
    private static int[] numbersInput = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
    
    static void Main(string[] args)
    {
        Methods methods = new Methods();
        Parser parser = new Parser();
        UI ui = new UI();

        int[] numbers = numbersInput; // defining the array of numbers and setting default value in case user input is disabled
        
        if (isUserInput)
        { // if user input is enabled, get user input and parse into an array of integers
            string input = ui.getUserInput();
            numbers =
                input == ""
                    ? numbersInput
                    : parser.parseInput(input);
        }
        
        // finding number missing from array
        int missingNumber = methods.findMissingNumber(numbers);

        // printing missing number
        ui.printMissingNumber(numbers, missingNumber);
    }

    
}

// 
class UI
{
    // User Interface class to handle all user console interactions
    
    // Method to prompt user to input and return it
    public string getUserInput()
    {
        Console.WriteLine("Welcome! Please enter the input array:");
        string input = Console.ReadLine();
        return input;
    }

    // Method to format and print missing number from numbers array
    public void printMissingNumber(int[] numbers,  int missingNumber)
    {
        Console.WriteLine("The number missing from [" + string.Join(", ", numbers) + "] is: " + missingNumber);
    }
}

class Methods
{
    // Methods class to handle all numerical methods
    
    // Method to find number missing from array by calculating the difference between the expected sum of integers 0...n, and the actual sum
    public int findMissingNumber(int[] numbers)
    {
        int length = numbers.Length;
        int missingNumber = sumNaturalNumbers(length) - numbers.Sum();
        
        return missingNumber;
    }
    
    // Method to store the formula to find the sum of natural numbers 0...n
    int sumNaturalNumbers(int n)
    {
        return n * (n + 1) / 2;
    }
    
}

class Parser
{
    
    // Parser class to handle string parsing
    
    // Method to parse input string into array of integers
    public int[] parseInput(string input)
    {
        int[] parsedArr = input
            .Trim('[', ']')
            .Split(',')
            .Select(str => int.Parse(str.Trim()))
            .ToArray();
        return parsedArr;
    }
}