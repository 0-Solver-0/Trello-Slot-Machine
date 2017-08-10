using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Generateur
{
    public static Random rand = new Random();
    public static int randScore(int m, int mx)
    {
        return rand.Next(m, mx);
    }
}
public class ParseInt
{
    public static int ParseFast(string s)
    {
        int r = 0;
        for (var i = 0; i < s.Length; i++)
        {
            char letter = s[i];
            r = 10 * r;
            r = r + (int)char.GetNumericValue(letter);
        }
        return r;
    }
}



