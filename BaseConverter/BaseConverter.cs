void Main()
{
	var s = BaseConvert.Convert(16, "ABCD012", 10);
	Console.WriteLine(s);
}

// Define other methods and classes here
class BaseConvert
{
    private static int BaseDigit(char c)
    {
        if  ( c >= '0' && c <= '9' )
            return c - '0';
        else if ( c >= 'a' && c <= 'z')
            return c - 'a' + 10;
        else if ( c >= 'A' && c <= 'Z')
            return c - 'A' + 10;
        else
            throw new ArgumentOutOfRangeException("c", c.ToString());
    }
    private static string ToBase(long val, int bas)
    {
        long v = val/bas;
        if (v != 0)
        {
            return ToBase(v, bas) + ToBase(val%bas, bas);
        }
        v = val%bas;
        return (v < 10 ? Char.ConvertFromUtf32((int)v + (int)'0') : Char.ConvertFromUtf32 ((int)v-10 + (int)'a'));
    }
    
    public static string Convert(
        int inBase,
        string input,
        int outBase)
    {
        string output;
        long inVal = 0;
		if (inBase > 36 || inBase < 2) throw new ArgumentOutOfRangeException("inBase",inBase.ToString());
		if (outBase > 36 || outBase < 2) throw new ArgumentOutOfRangeException("outBase",outBase.ToString());
		
        //read input into a int64
        // inputval = sum( C_i*B^i), where input = C_n,..,C_0 and B = inBase
        Char[] inputChars = input.ToCharArray();
        foreach (var c in inputChars)
        {
            var i = BaseDigit(c);
            if (i >= inBase)
            {
                throw new ArgumentOutOfRangeException("c", c.ToString());
            }
            inVal = checked(inVal * inBase + i);
        }
        if (inVal == 0) return ("0");
        output = ToBase(inVal, outBase);
        return output;
    }
}