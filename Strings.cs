using System;
using System.Collections.Generic;
using System.Text;
namespace InterviewPractise_VSCODE
{
  public class Strings{
        /*
        
         reverse all character and return result
        */

        public string reverse(string input){
          StringBuilder sb = new StringBuilder();
          for(int i=input.Length-1;i>=0;i--){
            char letter=input[i];
            sb.Append(letter);
          }
          return sb.ToString();
        }

        /*
         ignoring case and non alphabetical char
         return weather it's a palandrom


         level
         algorithm
         A man, a plan, a canal: panama

        */
        public bool isPalandrom(string input){
         int start=0;
         int end=input.Length-1;
         while(start<end){
            if(!char.IsLetter(input[start])){
              start++;
              continue;
            }
            if(!char.IsLetter(input[end])){
              end--;
              continue;
            }
            if(char.ToLower(input[start++])!=char.ToLower(input[end--]))
            return false;
         }
          return true;
        }
     /*
        is correct capatalication 
        it's correct if: 
        all letters capital 
        no letter capitalized
        only first letter capitilized
      
     */
     public bool isCorrectCapitilization(string input)
     {
       int count=0;
       foreach(char letter in input){
         if(char.IsUpper(letter))
         count++;
       }
       return count==input.Length||count==0||count==1&&char.IsUpper(input[0]);
     }

     /*
      strings containing 1s and 0s
      return their sum also a binary string 
      neither binary string will contain leading 0 unless itself is 0

      100+1 return 101
      11+1 return 100
      1+0 return 1 
     */
     public string addBinary(string num1,string num2){
       StringBuilder sb =new StringBuilder();
       int idx1=num1.Length-1;
       int idx2=num2.Length-1;
       int carry=0;
       while(idx1>=0||idx2>=0){
         int sum=carry;
         if(idx1>=0){
           sum+=num1[idx1--]-'0';
         }
         if(idx2>=0){
           sum+=num2[idx2--]-'0';
         }
         sb.Insert(0,sum%2);
         carry=sum/2;
       }
       if(carry==1)
       sb.Insert(0,"1");
       return sb.ToString();
      }

  }
}