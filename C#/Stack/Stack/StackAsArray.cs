using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            top = 0;
            size = iSize;
        }

        public bool Push(int iNum)
        {
            if (top < size)
            {
                data[top] = iNum;
                top++;
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
                top = size;
                size = size * 2;
                data = newData;

                // Push
                data[top] = iNum;
                top++;
            }

            return true;
        }

        public bool Pop()
        {
            data[top] = 0;
            top--;

            return true;
        }

        public int Peak()
        {
            return data[top];
        }

        public bool Print()
        {
            for(int i = 0; i < top; i++)
            {
                Console.WriteLine(data[i]);
            }

            return true;
        }
    }
}
