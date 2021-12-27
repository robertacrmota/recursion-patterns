using System.Collections.Generic;

namespace OrderingPatternNS
{
    public static class OrderingPattern
    {
        /*
            # QUESTION LIST

            Question 1: Given a set of items, find all permutations of those items

            Question 2: Given a set of items, find all permutations with a specific number of those items
●
        */

        /// <summary>
        /// Question 1: Given a set of items, find all permutations of those items
        /// </summary>
        public static List<LinkedList<int>> Permutations(int[] arr) {
            HashSet<int> remaining = new HashSet<int>(arr);
            List<LinkedList<int>> perms = new List<LinkedList<int>>();
            PermutationsRecursive(remaining, new LinkedList<int>(), perms);
            return perms;
        }
            
        public static void PermutationsRecursive(HashSet<int> remain, LinkedList<int> perm, List<LinkedList<int>> allPerms) {
            if (remain.Count == 0) {
                LinkedList<int> newPerm = new LinkedList<int>(perm);
                allPerms.Add(newPerm);
                return;
            }

            HashSet<int> temp = new HashSet<int>(remain);
            foreach(int elem in remain) {
                perm.AddFirst(elem);
                temp.Remove(elem);
                PermutationsRecursive(temp, perm, allPerms);
                perm.RemoveFirst();
                temp.Add(elem);
            }
        }

        public static void SampleQ1() {
            List<LinkedList<int>> perms = Permutations(new int[]{1, 2, 3});

            foreach(LinkedList<int> perm in perms) {
                foreach(int item in perm) {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }

        /// <summary>
        /// Question 2: Given a set of items, find all permutations with a specific number of those items
        /// </summary>
        public static List<LinkedList<int>> PermutationsOfLength(int[] arr, int length) {
            HashSet<int> remaining = new HashSet<int>(arr);
            List<LinkedList<int>> perms = new List<LinkedList<int>>();
            PermutationsOfLengthRecursive(length, remaining, new LinkedList<int>(), perms);
            return perms;
        }

        public static void PermutationsOfLengthRecursive(int length, HashSet<int> remain, LinkedList<int> perm, List<LinkedList<int>> allPerms) {
            if (perm.Count == length) {
                allPerms.Add(new LinkedList<int>(perm));
                return;
            }

            HashSet<int> temp = new HashSet<int>(remain);
            foreach(int elem in remain) {
                perm.AddFirst(elem);
                temp.Remove(elem);
                PermutationsOfLengthRecursive(length, temp, perm, allPerms);
                temp.Add(elem);
                perm.RemoveFirst();
            }
        }

        public static void SampleQ2() {
            List<LinkedList<int>> perms = PermutationsOfLength(new int[]{1, 2, 3, 4, 5}, 3);

            foreach(LinkedList<int> perm in perms) {
                foreach(int item in perm) {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}