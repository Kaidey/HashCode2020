using System.Collections.Generic;

namespace GoogleHashCode2020
{

    class Library
    {
        private int signUpTime { get; set; }
        private int totalDaysToProcess { get; set; }
        private int priority { get; set; }

        public Library(int signUp, int totalDaysToProcess, int priority)
        {
            this.signUpTime = signUp;
            this.totalDaysToProcess = totalDaysToProcess;
            this.priority = priority;
        }
    }
}