using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
    
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

    public static BigInt operator +(BigInt a, BigInt b)
    {
        int i = a.bigInt.Length, j = b.bigInt.Length, carry = 0;
        StringBuilder sb = new StringBuilder();

        while(i >= 0 || j >= 0 || carry >= 0)
        {
            int aNum = a.bigInt[i] - '0';
            int bNum = b.bigInt[j] - '0';

            if(aNum + bNum > 9)
            {
                carry++;
            }
            else string[i] = carry + aNum + bNum + '0';
        }

        return new BigInt("");
    }
    
}