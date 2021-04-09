
using System;
using System.Text;

namespace CodingProblems
{
    // Given a string, find the shortest possible string which can be achieved by adding characters to the end of initial string to make it a palindrome.
    public class BuildPalindrome {
        public static string buildPalindrome(string st) {
    
    bool isPalindromePossible; 
    // start from the strng Length and keep adding charaters until we find the palindrone
    for( int i = st.Length ; ; i++)
    {
        isPalindromePossible = true; 

        for(int j = 0 ; j < st.Length ; j++)
        {
            if( i - j <= st.Length && st[j] != st[i-j-1])
            {
                isPalindromePossible = false;
                break;
            }
        }
        if (isPalindromePossible) 
        {
            // append the characters to form the palindrome
           for (int j = st.Length; j < i; j++) 
           {
             st += st[i - j - 1];
           }
           return st;
         }
    }
}

public  string buildPalindromeV3(string st) {
    var builder = new StringBuilder(st);
    for(int i = 0; i < st.Length; i++){
        var subStr = st.Substring(0, i);
        builder.Append(ReverseString(subStr));        

        if(IsPalindrome(builder.ToString())){
            return builder.ToString();
        }
        else{
            builder = new StringBuilder(st);
        }
    }
    return builder.ToString();
}

bool IsPalindrome(string st){
    if(st.Equals(ReverseString(st))){
        return true;
    }
    return false;
}

string ReverseString(string st){
    char[] arr = st.ToCharArray();
    Array.Reverse(arr);
    return new String(arr);
}

bool isPalindrome(string s) {
    int l = 0, r = s.Length - 1;
    while (l < r) {
        if (s[l] != s[r]) {
            return false;
        }
        ++l;
        --r;
    }
    return true;
}

string buildPalindromeV4(string st) {
    if (isPalindrome(st)) {
        return st;
    }
    string temp = "";
    for (int i = 0; i < st.Length; ++i) {
        temp = st[i] + temp;
        if (isPalindrome(st + temp)) {
            return st + temp;
        }
    }
    return temp;
}

    }
}

// Input:
// st: "abcdc"
// Output:
// "abcdcba"
// Expected Output:
// "abcdcba"

// Input:
// st: "ababab"
// Output:
// "abababa"
// Expected Output:
// "abababa"

// Input:
// st: "abba"
// Output:
// "abba"
// Expected Output:
// "abba"

// Input:
// st: "abc"
// Output:
// "abcba"
// Expected Output:
// "abcba"

// Input:
// st: "abcabc"
// Output:
// "abcabcbacba"
// Expected Output:
// "abcabcbacba"

// Input:
// st: "euotmn"
// Output:
// "euotmnmtoue"
// Expected Output:
// "euotmnmtoue"