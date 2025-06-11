namespace IpValidatorCli;

internal static class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            var exit = RunInteractiveMode();
            return exit;
        }

        if (args.Length != 1)
        {
            Console.WriteLine("Usage - ipv4-validator.exe [<IPv4 Address>]");
            return -1;
        }

        Console.WriteLine($"Input: {args.First()}");
        var result = Validate(args.First());
        return result;
    }

    static int RunInteractiveMode()
    {
        Console.Write("Enter IPv4 Address to be validated: ");
        var input = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(input.Trim()))
        {
            Console.WriteLine("Invalid. Input an Ipv4 address in the format such as 192.168.1.1");
            return -1;
        }

        var result = Validate(input);
        return result;
    }

    static int Validate(string input)
    {
        var result = Ipv4Validator.Validate(input);
        if (result != "")
        {
            Console.WriteLine(result);
            return -1;
        }

        Console.WriteLine($"The input `{input}` validated successfully.");
        return 0;
    }
}