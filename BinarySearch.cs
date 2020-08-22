using System;
using System.Collections.Generic;
namespace InterviewPractise_VSCODE
{
  public class BinarySearch{
      // ladder with coins 

     /*
      n coins 
      example 1
      *
      **
      ***
      ****
      return 4
      *
      **
      ***
      **
      return 3 because last level is not complete
     */
     // O(n) solution no binary search yet
     public static int BiggestCoinRow(int n){
         if(n==0)
         return 0;
         int level=1;
         while(n>0){
           if(n<level){
               n-=level;
               level--;
               break;
           }
           n-=level;
           if(n==0){
               break;
           }
           level++;
           
         }
         return level;
     }

     // binary search solution o(lg n)
     // 
     // solution is binary search with math pivot*(pivot+1)/2



        //8.3 magic index in an array is defind as A[i]=i;
    // find the magic index in a distinct sorted array
    // this solution looks at all items until it find a magic index
    // doesn't take advantage of the fact that the index array elements are distinct and sorted
    // why is thig a dynamic programming problem ?
    public static int FindMagicIndex(int[] arr){
        for(int i=0;i<arr.Length;i++){
           if(arr[i]==i)
           return i;
        }
        return -1;
    }
    // how to improve it with taking into account that it's sorted and distinct 
    // with binary search if we reach  a pivot 
    // we can know if a magic index might potentialy exist to the left or to the right of the pivot
    /*
    example 
     0 1 2 3 4 5]
    [1,2,3,6,8,9]

    the following binary search only works if the array is distinct and sorted 
    followup what if the input wasn't distinct 

    */
    public static int FindMagicIndexBinarySearch(int[]arr){
      int start=0,end=arr.Length;
      while(start<=end){
        int pivot=start+(end-start)/2;
        if(pivot==arr[pivot]){
          return pivot;
        }
        if(arr[pivot]<pivot){
          start=pivot+1;
        }else{
          end=pivot-1;
        }
      }
      return -1;
    }


  }
}