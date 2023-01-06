using System;

namespace Stack
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

        public bool Push(int iNum)
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

            return true;
        }

        public bool Pop()
        {
            if (top >= 0)
            {
                data[top] = 0;
                top--;
            }

            return true;
        }

        public int Peak()
        {
            if (top >= 0)
            {
                return data[top];
            }
            return -1;
        }

        public bool Print()
        {
            for(int i = 0; i <= top; i++)
            {
                Console.WriteLine(data[i]);
            }

            return true;
        }
    }
}
