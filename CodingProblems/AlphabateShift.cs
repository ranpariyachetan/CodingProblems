using System;
using System.Text;

namespace CodingProblems
{
    public class AlphabateShift
    {
        public string alphabeticShift(string inputString) {
    char[] chArr = inputString.ToCharArray();
    String Str = "";

    foreach(char ch in chArr)
    {
        var AsciiChar = Encoding.ASCII.GetBytes(ch.ToString());
        int nxtChar = 0;
        if(Convert.ToInt32(AsciiChar[0]) == 122)
        {
            nxtChar = 97;
        }
        else if(Convert.ToInt32(AsciiChar[0]) == 90)
        {
            nxtChar =60;
        }
        else
        {
            nxtChar = Convert.ToInt32(AsciiChar[0]) + 1;
        }

        char c=Convert.ToChar(nxtChar);
        Str = Str + c.ToString();
    }

    Console.WriteLine("Output string is =" + Str);
    return Str;
}

public static String alphabeticShiftV2(String inputString) {
char[] inputCharArray = inputString.ToCharArray();
for(int i=0;i<inputCharArray.Length;i++){
    inputCharArray[i]= (char)((inputCharArray[i]-'a'+1)%26+'a');

}
return new String(inputCharArray);
}


    }
}