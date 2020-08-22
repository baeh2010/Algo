using System;
using System.Collections.Generic;
namespace InterviewPractise_VSCODE
{
   
    class Program
    {

        

  // merge intervals
    public static int[][] IntervalIntersection(int[][] A, int[][] B) {
     
        List<int[]> result = new List<int[]>();
        int i=0;
        int j=0;
        while(i<A.Length&&j<B.Length){
            int lo= Math.Max(A[i][0],B[j][0]);
            int hi=Math.Min(A[i][1],B[j][1]);
            if(lo<=hi)
                result.Add(new int[2]{lo,hi});
            if(A[i][1]<B[j][1]){
                i++;
            }else{
                j++;
            }
         
        }
           return result.ToArray();
    }






        static void Main(string[] args)
        {
           /* Console.WriteLine("***shortest distance in adj List***");
            int[][] graph = new int[5][] { new int[1] { 1 }, new int[1]{2}, new int[1] { 3 }, new int[1] { 4 }, new int[0] };
            int start = 0;
            int target = 4;
           Console.WriteLine(shortestDistance(graph, start, target));
            var path = shortestPath(graph, start, target);
            foreach (int vertix in path)
            {
               Console.Write(vertix + "  ");
            }


            int[][]matrix=new int[3][]{new int[3]{0,0,0},new int[3]{1,1,0},new int[3]{1,1,0}};
           Console.WriteLine("");
            Console.WriteLine("***shortest distance in a binary matrix***");
            Console.WriteLine(shortestDistance(matrix));
            int[][]matrix2=new int[3][]{new int[3]{0,0,0},new int[3]{1,1,0},new int[3]{1,1,0}};
           var path2 = shortestPath(matrix2);
             foreach(int[]pair in path2){
                Console.Write("( "+pair[0]+" , "+pair[1]+" )");
            }

        
             Console.WriteLine("");
          //   Console.WriteLine("****shortest path in weighted directed asyclc graph ****");
             List<int[]>[] DAG= new List<int[]>[8];
             DAG[0]=new List<int[]>();
             DAG[0].Add(new int[2]{1,3});
             DAG[0].Add(new int[2]{2,6});
             DAG[1]= new List<int[]>();
             DAG[1].Add(new int[2]{3,11});
             DAG[1].Add(new int[2]{2,4});
             DAG[1].Add(new int[2]{4,4});
             DAG[2]=new List<int[]>();
             DAG[2].Add(new int[2]{4,8});
             DAG[2].Add(new int[2]{6,11});
             DAG[3]=new List<int[]>();
             DAG[3].Add(new int[2]{7,9});
             DAG[4]=new List<int[]>();
             DAG[4].Add(new int[2]{3,-4});
             DAG[4].Add(new int[2]{5,5});
             DAG[4].Add(new int[2]{6,2});
             DAG[5]=new List<int[]>();
             DAG[5].Add(new int[2]{7,1});
             DAG[6]=new List<int[]>();
             DAG[6].Add(new int[2]{7,2});
             DAG[7]=new List<int[]>();
         //  var shortestPathDAG= ShortestPathInWeightedDAG(DAG,2,6);
         //  foreach(var s in shortestPathDAG){
         //    Console.Write(s+"  ");
         //  }*/

        // Console.WriteLine("***coin problen o(n)***");

        // Console.WriteLine(BinarySearch.BiggestCoinRow(8));

//Console.WriteLine(DynamicProgramming.ClimbStairsTopDown(103));
//Console.WriteLine(DynamicProgramming.ClimbStairsBottomUp(103));           
  //Console.WriteLine(DynamicProgramming.TripleSteps(103));
  //Console.WriteLine(DynamicProgramming.TripleStepsBU(103));
 // int[] inputArray=new int[3]{1,2,3};
 // Console.WriteLine(BinarySearch.FindMagicIndex(inputArray));
 // Console.WriteLine(BinarySearch.FindMagicIndexBinarySearch(inputArray));
       /* var result= DynamicProgramming.AllSubSets(inputArray);
        foreach(var array in result){
            Console.Write("[ ");
            foreach(var element in array){
                Console.Write(element+",");
            }
            Console.Write("]");
        }*/
    /*var validP=DynamicProgramming.ValidParanthesis(3);
    foreach(string v in validP){
        Console.WriteLine(v+" ");
    }*/
      
    
   // int[] coins=new int[3]{1,5,25};
  //  Console.WriteLine(DynamicProgramming.MakingChange(8,coins,new List<int>())+" ways");
          int[][]matrix=new int[4][]{new int[4]{1,0,0,0},new int[4]{0,0,0,0},new int[4]{0,0,0,0},new int[4]{0,0,0,0}};
  
        var path=  Graphs.eulrianPath(matrix);
        foreach(int[]pair in path){
                Console.Write("( "+pair[0]+" , "+pair[1]+" )");
            }
        }
  
    }
}
