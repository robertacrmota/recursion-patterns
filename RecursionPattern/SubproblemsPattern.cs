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
        */

        /// <summary>
        /// Question 1: Towers of Hanoi
        /// Given N disks, find the number of moves required to move all the disks from position 1 to position 3
        ///    - only one disk can be moved at a time
        ///    - a larger disk cannot be placed on top of a smaller disk
        /// </summary>
        public static int towersHanoi(int n) {
            if (n == 1) return 1;
            return 2 * towersHanoi(n-1) + 1; 
        }

        public static void SampleQ1( ) {
            System.Console.WriteLine(towersHanoi(4));
        }
    }
}