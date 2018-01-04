void Main()
{
    int [] numbers = new int[] {1,2,3,4,5,6,7,8,9,10};
	Rotate.RotateArrayLeft(numbers, 3);
	//numbers.Dump();
}

class Rotate
{
    static void Reverse(int[] ar, int offset, int n)
    {
        for (int i=offset,j = offset+n-1; i < j; i++,j--)
        {
            // swap
            int v = ar[i];
            ar[i] = ar[j];
            ar[j] = v;
        }
    }
    public static void RotateArrayLeft(int[] a, int pos)
    {
        if (a == null || a.Length <= 0)
        {
            return;
        }
        pos = pos % a.Length;
        // array = {1, 2, 3, 4, 5}
        // RotateLeft(array, 2) -> { 3, 4, 5, 1, 2};
        // Step 1 get the two sections in the right place by reversing
        // {5, 4, 3, 2, 1}

        Reverse(a, 0, a.Length);
        // Step 2 - correct the order by reversing each section
        // {3, 4, 5,
        //  1, 2 }
        Reverse(a, 0, a.Length - pos);
        Reverse (a, a.Length - pos, pos);
    }
}
