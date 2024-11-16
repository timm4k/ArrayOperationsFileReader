class Program
{
    static void Main()
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"File '{inputFilePath}' not found. Create the file and add data.");
                return;
            }

            string input = File.ReadAllText(inputFilePath).Trim();
            int[] array = Array.ConvertAll(input.Split(' '), int.Parse);

            Console.WriteLine("Array from input file:");
            Console.WriteLine(string.Join(" ", array));

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Find the min element of the array");
            Console.WriteLine("2. Calculate the product of elements before first zero");

            int option;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out option) && (option == 1 || option == 2))
                {
                    break;
                }
                Console.WriteLine("Select 1 or 2");
            }

            string result;
            switch (option)
            {
                case 1:
                    int minElement = FindMin(array);
                    result = $"Min element of the array is: {minElement}";
                    break;

                case 2:
                    int product = ProductBeforeZero(array);
                    result = $"Product of elements before first zero is: {product}";
                    break;

                default:
                    result = "Invalid option";
                    break;
            }

            File.WriteAllText(outputFilePath, result);

            if (File.Exists(outputFilePath))
            {
                Console.WriteLine($"Result saved to '{outputFilePath}'.");

                System.Diagnostics.Process.Start("notepad.exe", outputFilePath);
            }
            else
            {
                Console.WriteLine($"Failed to create file '{outputFilePath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int FindMin(int[] array)
    {
        int min = array[0];
        foreach (int num in array)
        {
            if (num < min)
            {
                min = num;
            }
        }
        return min;
    }

    static int ProductBeforeZero(int[] array)
    {
        int product = 1;
        bool foundNonZero = false;

        foreach (int num in array)
        {
            if (num == 0)
            {
                break;
            }
            product *= num;
            foundNonZero = true;
        }

        return foundNonZero ? product : 0;
    }
}