using System;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Text;
using Enumarate;

class Mystring {

    private char[] _arr;
    public bool Isempty{ get { return _arr == null; } }
    public int Length { get { return _arr.Length; } }
    
    public Mystring() {
        _arr = null;
    }
    

    
    public Mystring(char[] str) {
        if (str == null || str.Length == 0) {
            throw new ArgumentNullException("str is nullable");
        }
        _arr = new char[str.Length];
        Array.Copy(str, _arr, str.Length);     
    }
    
    public Mystring (char[] str, int index, int count) {
        
        if (index < 0) {
            throw new ArgumentOutOfRangeException("Index is less than 0");
        }

        else if (index >= str.Length || count <= 0 || index > str.Length - count) {
            throw new IndexOutOfRangeException("Index is out of range");
        }        
        _arr = new char[count];
        Array.Copy(str, index, _arr, 0, count);

    }

    public Mystring(string[] array) {
        string str = string.Join(" ", array);
        _arr = new char[str.Length];
        _arr = str.ToCharArray();
    }


    public Mystring (Mystring str, int index, int count) {
        if (str.Isempty) {
            throw new ArgumentNullException("String is nullable");
        }
        
        else if (index < 0) {
            throw new ArgumentOutOfRangeException("Index is less than 0");
        }

        else if (index >= str.Length || count <= 0 || index > str.Length - count) {
            throw new IndexOutOfRangeException("Index is out of range");
        } 

        _arr = new char[count];
        Array.Copy(str._arr, index, _arr, 0, count);    
    }

    
    
    public char this[int index] {
        
        get { 

            if (index < 0){
                throw new ArgumentException("Index is less 0");        
            }

            else if (index > Length) {
                throw new IndexOutOfRangeException("Index is bigger length");
            }
            return _arr[index]; 
        
        }
    }

    public static int MyCompare(Mystring str1, Mystring str2, CompareOption compareOption) {
        if (str1.Isempty || str2.Isempty) {
            throw new ArgumentException("One of this strings is empty");
        }
        int length = str1.Length <= str2.Length ? str1.Length : str2.Length;

        string copy = new string(str1._arr);
        string copy2 = new string(str2._arr);

        switch (compareOption) {

            case CompareOption.CaseInsensitive:
            copy = copy.ToLower();
            copy2 = copy2.ToLower();
            break;

            case CompareOption.ReverseOrder:
            copy = (string)copy.Reverse();
            copy2 = (string)copy2.Reverse();
            break;

            case CompareOption.WhiteSpaces:
            copy = copy.Trim();
            copy2 = copy2.Trim();
            break;

            default:
            Console.WriteLine("------------------");
            Console.WriteLine("Invalid case:::");
            Console.WriteLine("------------------");
            throw new Exception("Invalid option");
        }

        for (int i = 0; i < length; ++i) {
            if (copy[i] > copy2[i]) {
                return 1;
            }
            else if (copy[i] < copy2[i]) {
                return -1;
            }
        }

        if (copy.Length == copy2.Length) {
            return 0;
        }
        
        return copy.Length <= copy2.Length ? -1 : 1;
    }

    public static bool operator ==(Mystring str1, Mystring str2) {
        
        if (str1.Isempty || str2.Isempty) {
            return false;
        }

        int compareres = Mystring.MyCompare(str1,str2, CompareOption.CaseSensitive);
        
        bool res = compareres == 0 ? true : false;

        return res;

    }

    public static bool operator !=(Mystring str1, Mystring str2) {
        return !(str1 == str2);
    }


    public override bool Equals(object? obj)
    {

        if (obj == null || (this.GetType() != obj.GetType())) {
            throw new ArgumentNullException("Object is null or another types");
        }

        return this == (Mystring)obj;
        
    }

    public static bool Equals(Mystring str1, Mystring str2) {
        if (str1.Isempty || str2.Isempty) {
            throw new ArgumentNullException("One of this objects is nullable");
        }

        return str1._arr.Equals(str2._arr);
    
    }

    public override int GetHashCode() {
        return base.GetHashCode() ^ 7;
    }

    public static string Join(Mystring[] array, char seperator) {
        
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Isempty) {
                continue;
            }

            if (i == array.Length - 1){
                sb.Append(array[i].ToString());
                continue;
            }

            sb.Append(array[i].ToString());
            sb.Append(seperator);

        }

        return sb.ToString();

    }


    public bool EndsWith(string value) {
        
        if (this.Isempty) {
            throw new ArgumentNullException("The object is nullable you cannot call EndsWith meyhod");
        }

        if (_arr.Length < value.Length) {
            Console.WriteLine("The elements size is other");
            return false;
        }   

        for (int i = _arr.Length - value.Length, j = 0; j < value.Length; ++i, ++j) {
            if (value[j] != _arr[i]) {
                return false;
            }
        }

        return true;
    } 


    public bool StartsWith(string value) {
        
        if (this.Isempty) {
            throw new ArgumentNullException("The object is nullable you cannot call EndsWith meyhod");
        }

        if (_arr.Length < value.Length) {
            Console.WriteLine("The elements size is other");
            return false;
        }   

        for (int j = 0; j < value.Length; ++j) {
            if (value[j] != _arr[j]) {
                return false;
            }
        }

        return true;
    } 

    public static Mystring operator +(Mystring str1, Mystring str2) {
        
        if (str1.Isempty || str2.Isempty) {
            throw new ArgumentNullException("Object is nullable");
        }

        string str = new string(str1._arr) + new string(str2._arr) ;
        return new Mystring(str.ToCharArray());

    }

    public override string ToString()
    {
        return new string(_arr);
    }

}

class Program {
    static void Main(string[] args) {
        char[] arr = new char[] { 'H', 'E', 'L', 'L', 'O'};
        char[] arr2 = new char[] { 'h', 'e', 'l', 'l'};
        Mystring mystring = new Mystring(arr);
        Mystring mystring1 = new Mystring(arr2);

        if (Mystring.MyCompare(mystring,mystring1,CompareOption.CaseInsensitive) == 0) {
            Console.WriteLine("the strings are equal");
        }
    }
}