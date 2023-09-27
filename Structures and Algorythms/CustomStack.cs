using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures_and_Algorythms
{
    class CustomStack<T>
    {
        private int maxSize;
        private T[] stackArray;
        private int top;

        public CustomStack(int size)
        {
            maxSize = size;
            stackArray = new T[maxSize];
            top = -1;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Стек переполнен!");
                return;
            }

            stackArray[++top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст!");
                return default(T);
            }

            return stackArray[top--];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст!");
                return default(T);
            }

            return stackArray[top];
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }

        public bool IsFull()
        {
            return (top == maxSize - 1);
        }
    }
}
