using System.Text;

namespace ConsoleApp10;

class Program
{
    static void Main()
    {
        MyString myString = new MyString("hello");
        
        Console.WriteLine("Original comparing: " + String.Compare("abc", "ABC"));
        Console.WriteLine("Custom string comparing: " + MyString.Compare("abc", "ABC"));
        Console.WriteLine("Custom string comparing with IgnoreCase option: " + MyString.Compare("abc", "ABC", MyString.CompareOptions.IgnoreCase));
        Console.WriteLine("Custom string comparing with IgnoreSymbols option: " + MyString.Compare("abc", "abc!", MyString.CompareOptions.IgnoreCase));
        Console.WriteLine("Custom string are equals: " + myString.Equals("hello"));
        Console.WriteLine("Custom string static equals: " + MyString.Equals(myString, "world"));
        
        MyString mySecondString = new MyString("world");
        
        Console.WriteLine("Custom string join: " + MyString.Join(", ", myString, mySecondString));

        MyString concatString = myString + mySecondString;
        
        Console.WriteLine("Custom string + operator: " + concatString.GetString());
        
        Console.WriteLine("Custom string StartsWith (myString): " + myString.StartsWith("wo") + ". StartsWith (mySecondString): " + mySecondString.StartsWith("wo"));
        Console.WriteLine("Custom string EndsWith (myString): " + myString.EndsWith("ld") + ". EndsWith (mySecondString): " + mySecondString.EndsWith("ld"));
        
        // indexer

        mySecondString[10] = 'a'; // invalid index
        
        Console.WriteLine("mySecondString 1 index old char: " + mySecondString[1]);
        
        mySecondString[1] = 'r'; // valid index

        Console.WriteLine("mySecondString 1 index new char: " + mySecondString[1]);
    }
}

class MyString
{
    private readonly char[]? _chars;

    public enum CompareOptions
    {
        None,
        IgnoreCase,
        IgnoreSymbols
    }

    static private readonly char[] SpecialSymbols = { '@', '#', '$', '%', '!', '*', '&', '^' };

    // Constructors
    
    public MyString() { }
    
    public MyString(params string[]? str)
    {
        if (str == null)
            return;

        int totalLength = 0;

        foreach (ref string s in str.AsSpan())
            totalLength += s.Length;
        
        _chars = new char[totalLength];

        int offset = 0;
        
        foreach (ref string s in str.AsSpan())
        {
            for (int i = 0; i < s.Length; i++)
            {
                _chars[offset++] = s[i];
            }
        }
    }

    public MyString(string? str)
    {
        if (str == null)
            return;

        _chars = new char[str.Length];
        
        for (int i = 0; i < str.Length; i++)
        {
            _chars[i] = str[i];
        }
    }
    
    public MyString(char[] charArray)
    {
        _chars = new char[charArray.Length];
        
        for (int i = 0; i < charArray.Length; i++)
        {
            _chars[i] = charArray[i];
        }
    }
    
    public MyString(char[] firstCharArray, char[] secondCharArray)
    {
        _chars = new char[firstCharArray.Length + secondCharArray.Length];

        Array.Copy(firstCharArray, _chars, firstCharArray.Length);
        Array.Copy(secondCharArray, 0, _chars, firstCharArray.Length, secondCharArray.Length);
    }
    
    // Indexer

    public char this[int index]
    {
        get
        {
            if (_chars == null)
            {
                Console.WriteLine("Custom string is not allocated.");
                return '0';
            }
            
            if (index < 0 || index >= _chars.Length)
            {
                Console.WriteLine("Invalid index.");
                return '0';
            }
            
            return _chars[index];
        }
        set
        {
            if (_chars == null)
            {
                Console.WriteLine("Custom string is not allocated.");
                return;
            }
            
            if (index < 0 || index >= _chars.Length)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            
            _chars[index] = value;
        }
    }
    
    // Methods

    public string? GetString()
    {
        if (_chars == null)
            return null;
        
        StringBuilder sb = new StringBuilder();

        foreach(ref char c in _chars.AsSpan())
        {
            sb.Append(c);
        }

        return sb.ToString();
    }

    static public int Compare(string? strA, string? strB)
    {
        if (strA == null)
            return 1;
        
        else if (strB == null)
            return -1;
        
        else if (strA.Length != strB.Length)
            return -1;
        
        for(int i = 0; i < strA.Length; i++)
        {
            if (strA[i] > strB[i])
                return 1;
            else if (strA[i] < strB[i])
                return -1;
        }

        return 0;
    }
    
    static public int Compare(string? strA, string? strB, CompareOptions option)
    {
        if (strA == null)
            return 1;
        
        else if (strB == null)
            return -1;
        
        switch (option)
        {
            case CompareOptions.None:
                if (strA.Length != strB.Length)
                    return strA.Length > strB.Length ? 1 : -1;
                
                for (int i = 0; i < strA.Length; i++)
                {
                    if (i == strB.Length)
                        return 0;
                    
                    if (strA[i] > strB[i])
                        return 1;
                    else if (strA[i] < strB[i])
                        return -1;
                }

                break;
            case CompareOptions.IgnoreCase: 
                for (int i = 0; i < strA.Length; i++)
                {
                    if (i == strB.Length)
                        return 0;
                    
                    if (char.ToLower(strA[i]) > char.ToLower(strB[i]))
                        return 1;
                    else if (char.ToLower(strA[i]) < char.ToLower(strB[i]))
                        return -1;
                }
                
                break;
            case CompareOptions.IgnoreSymbols:
                bool isSpecialSymbol = false;
                
                for (int i = 0; i < strA.Length; i++)
                {
                    if (i == strB.Length)
                        return 0;
                    
                    foreach (ref char symbol in SpecialSymbols.AsSpan())
                    {
                        if (strA[i] == symbol || strB[i] == symbol)
                        {
                            isSpecialSymbol = true;
                            break;
                        }
                    }

                    if (isSpecialSymbol)
                    {
                        isSpecialSymbol = false;
                        continue;
                    }

                    if (char.ToLower(strA[i]) > char.ToLower(strB[i]))
                        return 1;
                    else if (char.ToLower(strA[i]) < char.ToLower(strB[i]))
                        return -1;
                }
                
                break;
        }

        return 0;
    }

    public override bool Equals(object? other)
    {
        if (_chars == null || other is not string otherStr || _chars.Length != otherStr.Length) 
            return false;

        for (int i = 0; i < _chars.Length; i++)
        {
            if (_chars[i] != otherStr[i])
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_chars);
    }

    static public bool Equals(MyString instance, object? other)
    {
        if (instance._chars == null || other is not string otherStr || instance._chars.Length != otherStr.Length) 
            return false;
        
        for (int i = 0; i < instance._chars.Length; i++)
        {
            if (instance._chars[i] != otherStr[i])
                return false;
        }

        return true;
    }

    public static string Join(string? separator, params MyString?[]? value)
    {
        if (value == null) return "error";
        
        StringBuilder sb = new StringBuilder();

        if (separator == null)
        {
            for(int i = 0; i < value.Length; i++)
            {
                if (value[i] == null) continue;
                
                for (int j = 0; j < value[i]._chars.Length; j++)
                {
                    sb.Append(value[i]._chars[j]);
                }
            }
        }
        else
        {
            for(int i = 0; i < value.Length; i++)
            {
                if (value[i] == null) continue;
                    
                for (int j = 0; j < value[i]._chars.Length; j++)
                {
                    sb.Append(value[i]._chars[j]);
                }
                
                if(i < value.Length - 1) 
                    sb.Append(separator);
            }
        }

        return sb.ToString();
    }
    
    public static string Concat(params MyString?[]? value)
    {
        return Join(null, value);
    }

    public bool EndsWith(string subString)
    {
        if (_chars is null || subString.Length > _chars.Length)
            return false;
        
        for (int i = _chars.Length - 1, strIndex = subString.Length - 1; i != 0; i--)
        {
            if (strIndex < 0)
                break;
            
            if (_chars[i] != subString[strIndex--])
                return false;
        }

        return true;
    }

    public bool StartsWith(string subString)
    {
        if (_chars is null || subString.Length > _chars.Length)
            return false;

        for (int i = 0; i < _chars.Length; i++)
        {
            if (i >= subString.Length) break;

            if (_chars[i] != subString[i])
                return false;
        }

        return true;
    }
    
    // Operators overloading
    
    public static bool operator ==(MyString? strA, MyString? strB)
    {
        if (strA is null && strB is null)
            return true;
        
        if (strA is null || strB is null || strA._chars is null || strB._chars is null || strA._chars.Length != strB._chars.Length) 
            return false;

        for (int i = 0; i < strA._chars.Length; i++)
        {
            if (strA._chars[i] != strB._chars[i])
                return false;
        }

        return true;
    }
    
    public static bool operator !=(MyString? strA, MyString? strB)
    {
        if (strA == null && strB == null)
            return false;
        
        if (strA == null || strB == null || strA._chars == null || strB._chars == null || strA._chars.Length != strB._chars.Length) 
            return true;

        for (int i = 0; i < strA._chars.Length; i++)
        {
            if (strA._chars[i] != strB._chars[i])
                return true;
        }

        return false;
    }

    public static MyString operator +(MyString? strA, MyString? strB)
    {
        if (strA == null && strB == null)
            return new MyString();
        
        if (strA == null || strB == null || strA._chars == null || strB._chars == null) 
            return new MyString();
        
        return new MyString(strA._chars, strB._chars);
    }
}