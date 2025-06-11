using System.Reflection;

namespace IpValidatorCli;

internal static class Program
{
    // TODO: consider using actual command line parser
    // TODO: consider if the exe should be ipv4.exe and act as a classifier as well
    static int Main(string[] args)
    {
        var helpMessage =
            $"Usage - ipv4-validator.exe [<Ipv4 Address>]{Environment.NewLine}{Environment.NewLine}`<Ipv4 Address>` is a value such as 192.168.1.1.";

        foreach (var a in args)
        {
            if (a.Contains("-h") || a.Contains("-?") || a.Contains("--help"))
            {
                Console.WriteLine(helpMessage);
                return 0;
            }

            if (a.Contains("--version"))
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version ??
                              throw new InvalidOperationException("Assembly version was not found.");
                Console.WriteLine($"v{version.Major}.{version.Minor}.{version.Build}");
                return 0;
            }
        }

        if (args.Length == 0)
        {
            var exit = RunInteractiveMode();
            return exit;
        }

        if (args.Length != 1)
        {
            Console.WriteLine(helpMessage);
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