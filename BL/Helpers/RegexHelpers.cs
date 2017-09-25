using System.Text.RegularExpressions;

namespace BL.Helpers
{
    public static class RegexHelpers
    {
        public static Regex validEmailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.Compiled);

        public static bool IsValidEmail(string Email)
        {
            return validEmailRegex.IsMatch(Email);
        }
    }
}
