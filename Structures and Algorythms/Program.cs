using System;
using System.Xml.Linq;

namespace App // 
{
    public class Algorythm
    {
        private static int[,] _arr = {                      // Матрица смежности для графа
            {0, 0, 3, 4, 6, 12},
            {0, 0, 0, 0, 2, 0 },
            {3, 0, 0, 6, 0, 0 },
            {4, 0, 6, 0, 0, 0 },
            {6, 2, 0, 0, 0, 8 },
            {12, 0, 0, 0, 8, 0 }
        };


        private Stack<int> _stack = new Stack<int>();       // Стак (стек) для маршрута
        private int _start = 4;                             // Точка старта, константа 2
        private int _end = 3;                               // Точка финиша, константа 4
        private static int nodesCount = _arr.GetLength(0);
        private int[] shortestDistances = new int[nodesCount];
        public void BSF()
        {
            
            bool[] visited = new bool[nodesCount];             // Массив булов для посещенных вершин
            _stack.Push(_start);                            
            visited[_stack.Peek()] = true;                  // Первая вершина посещена
            int[] previous = new int[nodesCount];
            previous[_start] = -1;
            
            for (int i = 0; i < nodesCount; i++)            // первоначальная инициализация, заполняем массивы
            {
                shortestDistances[i] = int.MaxValue;
                previous[i] = -1;
                visited[i] = false;
            }



            while (_stack.Count > 0)
            {
                int current = _stack.Pop();
                visited[current] = true;

                if (current == _end)
                {
                    break;
                }


                for (int i = 0; i < nodesCount; i++ )
                {
                    if (!visited[i] && _arr[current, i] != 0)
                    {
                        _stack.Push(i);
                        visited[i] = true;
                        previous[i] = current;
                        // расстояние от начальной вершины до соседней вершины
                        if (shortestDistances[current] + 1 < shortestDistances[i])
                        {
                            shortestDistances[i] = shortestDistances[current] + 1;
                            previous[i] = current;
                        }
                    }
                }
                
            }
            List<int> shortestPath = new List<int>();
            int node = _end;
            while (node != -1)
            {
                shortestPath.Insert(0, node);
                node = previous[node];
            }
            Console.WriteLine($"Кратчайший путь из {_start} в {_end}:");
            for (int i = 0; i < shortestPath.ToArray().Length; i++)
            {
                string a = i + 1 < shortestPath.ToArray().Length ? "->" : "";
                Console.Write(shortestPath[i] + 1 + $" {a} "  );
            }
            return;
        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            Algorythm bsf = new Algorythm();
            bsf.BSF();
        }

        
    }
}