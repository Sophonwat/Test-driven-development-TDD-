using System;

public class Converter
{
    public static double ConvertTo(double inches, string unit)
    {
        switch (unit)
        {
            case "-mm":
                return inches * 25.4;
            case "-cm":
                return inches * 2.54;
            case "-m":
                return inches * 0.0254;
            default:
                throw new ArgumentException("Invalid unit. Use -mm, -cm, or -m.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: convert <value> <unit>");
            Console.WriteLine("Example: convert 3 -cm");
            return;
        }

        double inches;
        if (!double.TryParse(args[0], out inches))
        {
            Console.WriteLine("Invalid value. Please enter a valid number.");
            return;
        }

        string unit = args[1].ToLower();
        try
        {
            double result = Converter.ConvertTo(inches, unit);
            Console.WriteLine($"{result:F2} {unit}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
