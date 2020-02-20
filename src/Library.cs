using System.Collections.Generic;

namespace GoogleHashCode2020
{

    class Library
    {


        private Dictionary<int, int> bookSet;
        private int signUpTime;
        private int shippableAmmountPerDay;

        public Library(int signUp, int shippableAmmount, Dictionary<int, int> books)
        {
            this.signUpTime = signUp;
            this.shippableAmmountPerDay = shippableAmmount;
            bookSet = books;
        }
    }
}