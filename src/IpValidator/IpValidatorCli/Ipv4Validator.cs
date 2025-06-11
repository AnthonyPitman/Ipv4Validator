namespace IpValidatorCli;

public class Ipv4Validator
{
    public static string Validate(string input)
    {
        var split = input.Split('.');
        if (split.Length != 4)
        {
            return $"Invalid format `{input}` should be in format `192.168.1.1`.";
        }

        foreach (var s in split)
        {
            if (!int.TryParse(s, out var octet))
            {
                return "Each octet inside the IP address should be integers.";
            }

            if (octet < 0)
            {
                return "Each octet must have a minimum value of 0.";
            }

            if (octet > 255)
            {
                return "Each octet must have a maximum value of 255";
            }
        }

        return "";
    }
}