using System;
using System.Collections.Generic;
namespace InterviewPractise_VSCODE
{
   
    class Program
    {

        // shortest distance code BFS   from ADJList
        static int shortestDistance(int[][] graph, int start, int end)
        {
            int[] distance = new int[graph.Length];
            Array.Fill(distance, -1);
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            distance[start] = 0;
            while (q.Count > 0)
            { 
                int count=q.Count;
                int curr = q.Dequeue();
                if (curr == end)
                    return distance[end];
                foreach (int neighbor in graph[curr])
                {
                    if (distance[neighbor] == -1)
                    {
                        distance[neighbor] = distance[curr] + 1;
                        q.Enqueue(neighbor);
                    }
                }
            }
            return -1;
        }
        // shortest path 
        static List<int> shortestPath(int[][] graph, int start, int end)
        {
            int[] parent = new int[graph.Length];
            Array.Fill(parent, -1);
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            parent[start] = start;
            while (q.Count > 0)
            {
                int curr = q.Dequeue();
                if (curr == end)
                {
                    return constructPath(parent, curr);
                }
                foreach (int neighbor in graph[curr])
                {
                    if (parent[neighbor] == -1)
                    {
                        parent[neighbor] = curr;
                        q.Enqueue(neighbor);
                    }
                }
            }
            return new List<int>();
        }
        private static List<int> constructPath(int[] parent, int curr)
        {
            List<int> result = new List<int>();
            result.Add(curr);
            while (parent[curr] != curr)
            {
                result.Add(parent[curr]);
                curr = parent[curr];
            }
            result.Reverse();
            return result;
        }

    
      
       // shortest distanse code BFS  .. from MATRIX

       static int shortestDistance(int[][]matrix){
           int[][]dir = new int[8][]{new int[2]{1,0},new int[2]{-1,0},new int[2]{0,1},new int[2]{0,-1},new int[2]{1,1},new int[2]{-1,-1},new int[2]{1,-1},new int[2]{-1,1}};
           Queue<int[]>q =new Queue<int[]>();
           int[,]distance=new int[matrix.Length,matrix[0].Length];
           matrix[0][0]=1;
           q.Enqueue(new int[2]{0,0});
           while(q.Count>0){
               int[]curr =q.Dequeue();
               if(curr[0]==matrix.Length-1&&curr[1]==matrix[0].Length-1)
                    return distance[curr[0],curr[1]]+1;
               for(int i=0;i<dir.Length;i++){
                   int x=curr[0]+dir[i][0];
                   int y=curr[1]+dir[i][1];
                  if(x>=0&&x<matrix.Length&&y>=0&&y<matrix[0].Length){
                      if(matrix[x][y]==0){
                        matrix[x][y]=1;
                        distance[x,y]=distance[curr[0],curr[1]]+1;
                        q.Enqueue(new int[2]{x,y});
                      }
                  }
               }
           }
           return -1;
       }

       
        static List<int[]> shortestPath(int[][]matrix)
        {
            int[][]dir = new int[8][]{new int[2]{1,0},new int[2]{-1,0},new int[2]{0,1},new int[2]{0,-1},new int[2]{1,1},new int[2]{-1,-1},new int[2]{1,-1},new int[2]{-1,1}};
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[2]{0,0});
            matrix[0][0]=1;
            Dictionary<(int,int),int[]> parents = new Dictionary<(int,int),int[]>();
            parents.Add((0,0),new int[0]);
            while(q.Count>0){
                int[] curr=q.Dequeue();
                if(curr[0]==matrix.Length-1&&curr[1]==matrix[0].Length-1){
                    return constructPath(parents,curr[0],curr[1]);
                }
                for(int i=0;i<dir.Length;i++){
                    int x=curr[0]+dir[i][0];
                    int y=curr[1]+dir[i][1];
                    if(x>=0&&x<matrix.Length&&y>=0&&y<matrix[0].Length){
                        if(matrix[x][y]==0){
                            matrix[x][y]=1;
                            parents.Add((x,y),new int[2]{curr[0],curr[1]});
                            q.Enqueue(new int[2]{x,y});
                        }
                    }
                }

            }
            return new List<int[]>();
        }
      
      private static List<int[]> constructPath(Dictionary<(int,int),int[]>parents,int x,int y){
         List<int[]> result = new List<int[]>();
         int[]curr = new int[2]{x,y};
         while(curr.Length>0){
             result.Add(curr);
             curr=parents[(curr[0],curr[1])];
         }
         result.Reverse();
         return result;
      }
     
   

    public static List<int> ShortestPathInWeightedDAG(List<int[]>[] graph,int start,int end){
       if(graph.Length==0)
       return new List<int>();
       int[] status = new int[graph.Length]; // 0 unvisited // 1 arrived // 2 departured 
       Stack<int>stack = new Stack<int>();
  
             if(!dfsTopologicalSort(graph,start,status,stack)){
                 return new List<int>();
             }
      
       // relax the topologically sorted edges then return the shortest path 
       long[] dist=new long[graph.Length];
       int[] parents = new int[graph.Length];
      
       Array.Fill(dist,long.MaxValue);
       dist[start]=0;
       while(stack.Count>0){
           int node= stack.Pop();
           foreach(var v in graph[node]){
              if(dist[v[0]]>dist[node]+v[1]){
                  dist[v[0]]=dist[node]+v[1];
                  parents[v[0]]=node;
              }
           }
       }
       parents[start]=start;
      List<int>result = constructPath(parents,end);
       return result;
    }

    private static bool dfsTopologicalSort(List<int[]>[] graph,int i,int[] status,Stack<int> stack){
          status[i]=1;
          foreach(var neighbor in graph[i]){
              if(status[neighbor[0]]==0){
                 if(!dfsTopologicalSort(graph,neighbor[0],status,stack))
                 return false;
              }
              else if(status[neighbor[0]]==1)
              {
                 return false;
              }
          }
         status[i]=2;
         stack.Push(i);
         return true;
    }




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
            Console.WriteLine("***shortest distance in adj List***");
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
             Console.WriteLine("");
             Console.WriteLine("****shortest path in weighted directed asyclc graph ****");
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
           var shortestPathDAG= ShortestPathInWeightedDAG(DAG,2,6);
           foreach(var s in shortestPathDAG){
             Console.Write(s+"  ");
           }

      
        
            //Console.WriteLine("my testing ground is here ");
        }
    }
}
