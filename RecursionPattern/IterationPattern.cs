using System.Collections.Generic;
using System.Collections;
namespace IterationPattern
{
    /*
        Question 1:
        Write a funcion that inserts an element at the bottom of a stack

    */
    
    public class IterationPattern
    {
        // Question 1: Write a funcion that inserts an element at the bottom of a stack
        public static void InsertBottomStack(Stack stack, int value) {
            if (stack.Count == 0) {  stack.Push(value); return; }

            int item = (int) stack.Pop();
            InsertBottomStack(stack, value);
            stack.Push(item);
        }
        
        public static void SampleQ1( ) {
            Stack stack = new Stack();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            InsertBottomStack(stack, 4);

            while(stack.Count > 0) {
                System.Console.WriteLine(stack.Pop());
            }
        }

        static void Main(string[] args)
        {
            // Question 1: Write a funcion that inserts an element at the bottom of a stack
            // SampleQ1();
        }
    }
}