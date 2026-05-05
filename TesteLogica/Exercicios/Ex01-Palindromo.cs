namespace Exercicios;

public static class Ex01_Palindromo
{
    public static bool IsPalindrome(string input)
    {
        if(string.IsNullOrWhiteSpace(input))
            return false;

        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            char leftChar = char.ToLower(input[left]);
            char rightChar = char.ToLower(input[right]);

            if(leftChar == ' ')
            {
                left++;
                continue;
            }

            if(rightChar == ' ')
            {
                right--;
                continue;
            }

            if(leftChar != rightChar)
                return false;

            left++;
            right--;
        }
        return true;
    }
}