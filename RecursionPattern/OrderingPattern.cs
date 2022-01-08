using System;
using System.Collections.Generic;

namespace OrderingPatternNS
{
    public static class OrderingPattern
    {
        /*
            # QUESTION LIST

            Question 1: Given a set of items, find all permutations of those items

            Question 2: Given a set of items, find all permutations with a specific number of those items

            Question 3: Find all the permutations of an input that may contain duplicates.
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

        /// <summary>
        /// Question 3: Find all the permutations of an input that may contain duplicates.
        /// </summary>
        public static List<LinkedList<int>> PermutationsDuplicates(int[] arr) {
            Dictionary<int, int> remain = new Dictionary<int, int>();
            List<LinkedList<int>> perms = new List<LinkedList<int>>();

            for(int i=0; i<arr.Length; i++) {
                remain[arr[i]] = remain.GetValueOrDefault(arr[i], 0) + 1;
            }

            PermutationsDuplicatesRecursive(remain, new LinkedList<int>(), perms);
            return perms;
        }

        public static void PermutationsDuplicatesRecursive(Dictionary<int, int> remain, LinkedList<int> perm, List<LinkedList<int>> allPerms) {
            if(remain.Keys.Count == 0) {
                allPerms.Add(new LinkedList<int>(perm));
                return;
            }

            HashSet<int> remainSet = new HashSet<int>(remain.Keys);
            foreach(int elem in remainSet) {
                remain[elem] -= 1;
                if(remain[elem] == 0) { remain.Remove(elem); }
                perm.AddFirst(elem);
                PermutationsDuplicatesRecursive(remain, perm, allPerms);
                perm.RemoveFirst();
                remain[elem] = remain.GetValueOrDefault(elem, 0) + 1;
            }
        }

        public static void SampleQ3() {
            List<LinkedList<int>> perms = PermutationsDuplicates(new int[]{1, 2, 3, 1});

            foreach(LinkedList<int> perm in perms) {
                foreach(int item in perm) {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}