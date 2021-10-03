using System;
using System.Collections.Generic;
namespace InterviewPractise_VSCODE
{
   
    class Program
    {

    
      
    
        static void Main(string[] args)
        {
         Strings strings =new Strings();
         Console.WriteLine(strings.addBinary("100","1"));
         Console.WriteLine(strings.addBinary("11","1"));
        Console.WriteLine(strings.addBinary("1","0"));
         
         /*
            ["colorado","color","cold"] return "col"
      ["a","b","c"] return ""
      ["spot","spotty","spotted"] return "spot"
         */
   Console.WriteLine(strings.longestCommonPrefix(new string[] {"colorado","color","cold"}));
     Console.WriteLine(strings.longestCommonPrefix(new string[] {"a","b","c"}));
      Console.WriteLine(strings.longestCommonPrefix(new string[] {"spot","spotty","spotted"}));
        }
     
  
    }
}
