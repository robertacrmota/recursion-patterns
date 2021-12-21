using System.Collections.Generic;
using System.Collections;
namespace IterationPatternNS
{
    /*
        # QUESTION LIST

        Question 1:
        Write a funcion that inserts an element at the bottom of a stack

        Question 2:
        Given a string, write a function that returns a list of all substrings
    */
    
    public class IterationPattern
    {
        /// <summary>
        /// Question 1: Write a funcion that inserts an element at the bottom of a stack
        /// </summary>
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

        /// <summary>
        /// Question 2: Given a string, write a function that returns a list of all substrings

        /// (1) brute force  solution: 2 pointers

        ///     str = a b c d e
        ///           i
        ///             j

        ///     for(int i=0; i < str.Length; i++) {
        ///         for(int j=i; j < str.Length; j++) {
        ///             ...
        ///         }
        ///     }

        ///     (2) recursive solution: instead of nested for loops, each loop is a recursive function

        /// </summary>
        public static void IterateSecondPointer(string str, int i, int j, List<string> result) {
            if (j == str.Length) { return; }

            result.Add(str.Substring(i, j-i+1));
            IterateSecondPointer(str, i, j+1, result);
        }
        public static void IterateFirstPointer(string str, int i, List<string> result) {
            if (i == str.Length) { return; }

            IterateSecondPointer(str, i, i, result);
            IterateFirstPointer(str, i+1, result);
        }

        public static List<string> GenerateSubstrings(string str) {
            List<string> result = new List<string>();
            IterateFirstPointer(str, 0, result);
            return result;
        }
        
        public static void SampleQ2( ) {
            List<string> subs = GenerateSubstrings("abcde");

            foreach(string str in subs) {
                System.Console.WriteLine(str);
            }
        }
    }
}