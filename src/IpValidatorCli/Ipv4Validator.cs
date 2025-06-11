namespace IpValidatorCli;

public class Ipv4Validator
{
    // TODO: make the validation treat the address as an 32-bit unsigned integer.
    // TODO: consider further refinement of value to classify into classes such as a Class C network address.
    // TODO: consider support other formats than `192.168.1.1` such as hex (or bin)
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