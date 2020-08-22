using System;
using System.Collections.Generic;
namespace InterviewPractise_VSCODE
{
   public class Graphs{
       // shortest distance code BFS   from ADJList
      public  static int shortestDistance(int[][] graph, int start, int end)
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
     

       public static List<int> shortestPath(int[][] graph, int start, int end)
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

      public static int shortestDistance(int[][]matrix){
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

     public class Node{
        public int x;
        public int y;
        public Node parent;
       public HashSet<char>keyChain;
        public Node(int x,int y,Node parent,HashSet<char>keyChain){
            this.x=x;
            this.y=y;
            this.parent=parent;
            this.keyChain=new HashSet<char>(keyChain);
        }
    }
  
 
   }
}