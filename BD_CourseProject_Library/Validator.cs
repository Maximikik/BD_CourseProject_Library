using System.Text.RegularExpressions;

namespace BD_CourseProject_Library
{
    static class Validator
    {
        public static bool IsPhone(string str)
        {
            var rg = new Regex(@"^(\+375+(24|25|29|33|44)+([0-9]){7})$");
            if (!rg.IsMatch(str))
                return false;
            return true;
        }
    }
}
