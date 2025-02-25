using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        BigInt bigInt = new BigInt("12345");
        BigInt bigInt2 = new BigInt("1");

        Console.WriteLine(bigInt2 + bigInt);
    }
}

class BigInt
{
    string bigInt;
    int length;

    public BigInt(string bigInt)
    {
        this.bigInt = bigInt;
    }

    // public BigInt(int smallInt)
    // {

    // }

    public override string ToString()
    {
        return "int: " + bigInt;
    }

    public static BigInt operator +(BigInt a, BigInt b)
    {
        int i = a.bigInt.Length - 1, j = b.bigInt.Length - 1, carry = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append(a.bigInt);
        
        Console.WriteLine("i: " + i + ", j: " + j);

        while(i >= 0 && j >= 0)
        {
            Console.WriteLine(a.bigInt[i]);

            int aNum = a.bigInt[i] - '0';
            int bNum = b.bigInt[j] - '0';

            if(aNum + bNum > 9)
            {
                carry ++;
            }
            else 
            {
                sb.Append(carry + aNum + bNum + '0');
            }

            i--;
            j--;

            Console.WriteLine(sb);
        }

        return new BigInt(sb.ToString());
    }
    
}