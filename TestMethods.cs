using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal static uint StackFirstPrime(Stack<uint> stack)
        {
            Stack<uint> tempStack = new Stack<uint>(stack); 

           while (tempStack.Count > 0) 
           {
             uint num = tempStack.Pop(); 
             if (num > 1)
                {
                 bool isPrime = true;
                 for (uint i = 2; i * i <= num; i++)
                     {
                      if (num % i == 0)
                         {
                           isPrime = false;
                           break;
                         }
                     }
                     if (isPrime) return num; 
                }
           }

           return 0; // Si no se encontró un primo
          }

        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
             Stack<uint> tempStack = new Stack<uint>();
             bool removed = false;

             while (stack.Count > 0)
            {
                   uint num = stack.Pop();
                   if (!removed && IsPrimeNumber(num))
                   {
                       removed = true;
                   }
                   else
                   {
                        tempStack.Push(num);
                   }
            }

            while (tempStack.Count > 0)
            {
                  stack.Push(tempStack.Pop());
            }

            return stack;
        }

        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            Queue<uint> queue = new Queue<uint>();
            Stack<uint> tempStack = new Stack<uint>();

            while (stack.Count > 0)
            {
                   tempStack.Push(stack.Pop());
            }

            while (tempStack.Count > 0)
            {
                  uint num = tempStack.Pop();
                  queue.Enqueue(num);
                  stack.Push(num);
            }

            return queue;
        }

        internal static List<uint> StackToList(Stack<uint> stack)
        {
            List<uint> list = new List<uint>();
            Stack<uint> tempStack = new Stack<uint>();

            while (stack.Count > 0)
            {
                  uint num = stack.Pop();
                  tempStack.Push(num);
                  list.Add(num);
            }

            while (tempStack.Count > 0)
            {
                   stack.Push(tempStack.Pop());
            }

             return list;
        }

        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
             for (int i = 1; i < list.Count; i++)
             {
                  int key = list[i];
                  int j = i - 1;

                  while (j >= 0 && list[j] > key)
                  {
                        list[j + 1] = list[j];
                        j--;
                  }
                  list[j + 1] = key;
             }

             int left = 0, right = list.Count - 1;
             while (left <= right)
             {
                    int mid = left + (right - left) / 2;

                    if (list[mid] == value)
                    {
                       return true;
                    }
                    if (list[mid] < value)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                         right = mid - 1;
                    }
             }

             return false;
        }

        private static bool IsPrimeNumber(uint num)
        {
             if (num < 2) return false;
             for (uint i = 2; i * i <= num; i++)
             {
                 if (num % i == 0)
                 {
                    return false;
                 }
             }
             return true;
       }
    }
}
