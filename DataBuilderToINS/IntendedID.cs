
using System.Text.RegularExpressions;

static class IntendedID
{
    public static int Intended(string input)
    {
        if (IsRodneCislo(input))
        {
            return 1;
        }
        else if (IsIC(input))
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    private static bool IsRodneCislo(string input)
    {
        // Regular expression pattern for matching valid rodné číslo
        string pattern = @"^\d{6}\/\d{3,4}$";
        return Regex.IsMatch(input, pattern);
    }

    private static bool IsIC(string input)
    {
        // Regular expression pattern for matching valid IČ
        string pattern = @"^\d{8,10}$";
        return Regex.IsMatch(input, pattern);
    }
}
