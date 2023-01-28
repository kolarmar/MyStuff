using System;

namespace DataStructures
{
    internal class StackAsArray
    {
        public int[] data;
        public int top;
        public int size;


        public StackAsArray(int iSize)
        {
            data = new int[iSize];
            top = -1;
            size = iSize;
        }

        public void Push(int iNum)
        {
            top++;
            if (top < size)
            {
                // Push
                data[top] = iNum;
            }
            else
            {
                // Create a new array of twice the initial size
                int[] newData = new int[size * 2];

                // Copy from the old array
                for(int i = 0; i < size; i++)
                {
                    newData[i] = data[i];
                }

                // Update params of new array
                size = size * 2;
                data = newData;

                // Push
                data[top] = iNum;
            }
        }

        public void Pop()
        {
            if (top >= 0)
            {
                data[top] = 0;
                top--;
            }
        }

        public int Peak()
        {
            if (top >= 0) return data[top];

            else return -1;
        }

        public void Print()
        {
            for(int i = 0; i <= top; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
