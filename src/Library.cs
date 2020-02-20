using System.Collections.Generic;
using System;

namespace GoogleHashCode2020
{

    class Library
    {
        private int signUpTime { get; set; }
        private int totalDaysToProcess { get; set; }
        public int priority { get; set; }

        public List<int> books;

        private int id { get; set; }

        public Library(int signUp, int totalDaysToProcess, int priority, int id, List<int> books)
        {
            this.signUpTime = signUp;
            this.totalDaysToProcess = totalDaysToProcess;
            this.priority = priority;
            this.id = id;
            this.books = books;
        }

        public override string ToString()
        {
            return ("Library ID: " + this.id + "\n" +
            "SignUpTime: " + this.signUpTime + " days\n" +
            "Priority: " + this.priority + "\n" +
            "Total Days to Process all books: " + this.totalDaysToProcess + "\n");
        }

        public List<int> getBooks()
        {
            return this.books;
        }

    }
}