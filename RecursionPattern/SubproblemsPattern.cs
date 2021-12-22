using System.Collections.Generic;
namespace SubproblemsPatternNS
{
    public static class SubproblemsPattern
    {

        /*
            # QUESTION LIST

            Question 1: Towers of Hanoi
            Given N disks, find the number of moves required to move all the disks from
            position 1 to position 3
            - only one disk can be moved at a time
            - a larger disk cannot be placed on top of a smaller disk


            Question 2: Stair steps
            Given a staircase of height N, write a function that finds the number of combinations you 
            can get to the top of the staircase taking steps of size 1, 2, or 3

            Question 3: Stair steps - 2
            Given a staircase of height N, write a function that finds all of the ways you 
            can get to the top of the staircase taking steps of size 1, 2, or 3
        */

        /// <summary>
        /// Question 1: Towers of Hanoi
        /// Given N disks, find the number of moves required to move all the disks from position 1 to position 3
        ///    - only one disk can be moved at a time
        ///    - a larger disk cannot be placed on top of a smaller disk
        /// </summary>
        public static int TowersHanoi(int n) {
            if (n == 1) { return 1; }

            // #moves(n-1) to trasnfer n-1 disks to position 2 + 1 move to transfer nth disk to position 3 + #moves(n-1) n-1 disks to position 3
            return 2 * TowersHanoi(n-1) + 1; 
        }

        public static void SampleQ1( ) {
            System.Console.WriteLine(TowersHanoi(4));
        }

        /// <summary>
        /// Question 2: Stair steps
        /// Given a staircase of height N, write a function that finds the number of combinations you 
        /// can get to the top of the staircase taking steps of size 1, 2, or 3
        /// </summary>
        public static int StairSteps(int n) {
            if (n < 0 ) { return 0; }
            if (n == 0) { return 1; }

            return StairSteps(n-1) + StairSteps(n-2) + StairSteps(n-3);
        }
         public static void SampleQ2( ) {
            System.Console.WriteLine(StairSteps(4));
        }

        /// <summary>
        /// Question 3: Stair steps - 2
        /// Given a staircase of height N, write a function that finds all of the ways you
        /// can get to the top of the staircase taking steps of size 1, 2, or 3
        /// </summary>
        public static List<List<int>> StairSteps2Recursive(int step, int height) {
            if (step >= height) { 
                List<List<int>> sequence = new List<List<int>>(); 
                if(step == height) { sequence.Add(new List<int>()); }
                return sequence;
            }

             List<List<int>> result = new List<List<int>>();
             foreach(List<int> sequence in StairSteps2Recursive(step+1, height)) {
                   sequence.Add(1); 
                   result.Add(sequence);
             }
             foreach(List<int> sequence in StairSteps2Recursive(step+2, height)) {
                 sequence.Add(2);
                 result.Add(sequence);
             }
             foreach(List<int> sequence in StairSteps2Recursive(step+3, height)) {
                sequence.Add(3);
                result.Add(sequence);
             }

            return result;
        }

        public static List<List<int>> StairSteps2(int n) {
            return StairSteps2Recursive(0, n);
        }

        public static void SampleQ3( ) {
            List<List<int>> sequences = StairSteps2(4);

            foreach(List<int> seq in sequences) {
                foreach(int step in seq) {
                    System.Console.Write(step + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}