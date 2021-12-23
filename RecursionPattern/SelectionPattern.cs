using System.Collections.Generic;
namespace SelectionPatternNS
{
    public static class SelectionPattern
    {
        /*
            # QUESTION LIST

            Question 1: Compute the number of combinations with a specific number of array items

            Question 2: Generate all the combinations with a specific number of array items
        */

        /// <summary>
        /// Question 1: Compute the number of combinations with a specific number of array items
        /// </summary>
        public static int CombinationsOfLength(int[] arr, int length) {
            return CombinationsOfLengthRecursive(arr, 0, 0, length);
        }

        public static int CombinationsOfLengthRecursive(int[] arr, int i, int currLength, int length) {
            if (currLength == length) { return 1; }

            // reached end of array and did not create a combination with specified size
            if (i == arr.Length) { return 0; } 

            int includeItem = CombinationsOfLengthRecursive(arr, i+1, currLength+1, length);
            int excludeItem = CombinationsOfLengthRecursive(arr, i+1, currLength, length);

            return includeItem + excludeItem;
        }

        public static void SampleQ1() {
            System.Console.WriteLine(CombinationsOfLength(new int[]{1, 2, 3, 4, 5}, 3));
        }

        /// <summary>
        /// Question 2: Generate all the combinations with a specific number of array items
        /// </summary>
        public static List<LinkedList<int>> CombinationsOfLength2(int[] arr, int length) {
            return CombinationsOfLength2Recursive(arr, 0, 0, length);
        }

        public static List<LinkedList<int>> CombinationsOfLength2Recursive(int[] arr, int i, int currLength, int length) {
           if (currLength == length) { 
                List<LinkedList<int>> result = new List<LinkedList<int>>();
                result.Add(new LinkedList<int>());
                return result;
            }

            if(i == arr.Length) { return new List<LinkedList<int>>(); }

            List<LinkedList<int>> excludeCombs = CombinationsOfLength2Recursive(arr, i+1, currLength, length);
            List<LinkedList<int>> includeCombs = CombinationsOfLength2Recursive(arr, i+1, currLength+1, length);

            List<LinkedList<int>> combs = new List<LinkedList<int>>();
            combs.AddRange(excludeCombs);

            foreach(LinkedList<int> comb in includeCombs) {
                comb.AddFirst(arr[i]);
                combs.Add(comb);
            }

            return combs;
        }

        public static void SampleQ2() {
            List<LinkedList<int>> combs = CombinationsOfLength2(new int[]{1, 2, 3, 4, 5}, 3);

            foreach(LinkedList<int> comb in combs) {
                foreach(int item in comb) {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}