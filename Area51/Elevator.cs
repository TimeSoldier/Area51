using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    internal class Elevator
    {
        public enum Floors {Ground, Secret, TopSecret, TopTopSecret };

        private Semaphore semaphore;

        const int count = 4;

        public Elevator()
        {
            semaphore = new Semaphore(count, count);
        }

        public void Enter(Agent agent)
        {
            semaphore.WaitOne();
        }

        public void Leave(Agent agent)
        {
            semaphore.Release();
        }

        public void CheckFloor(string stringClearance, string desiredFloor, ref bool i)
        {

            if (desiredFloor == "ground")
                i = true;
            if (desiredFloor == "secret" && (stringClearance == "Secret" || stringClearance == "TopSecret"))
                i = true;
            if (desiredFloor == "topsecret" && stringClearance == "TopSecret")
                i = true;
            if (desiredFloor == "toptopsecret" && stringClearance == "TopSecret")
                i = true;
        }
    }
    /*internal class Elevator
    {
        public enum Drinks { Vodka, Whiskey, Gin, Beer, Wine };

        const int Capacity = 20;

        private Semaphore semaphore;
        public decimal Turnover { get; private set; }

        public Elevator()
        {
            semaphore = new Semaphore(Capacity, Capacity);
        }

        public void Enter(Agent agent)
        {
            semaphore.WaitOne();
        }

        public void Leave(Agent agent)
        {
            semaphore.Release();
        }

        private object turnoverLock = new object();
        private void SafeAddTrunover(decimal amount)
        {
            lock (turnoverLock)
            {
                Turnover = Turnover + amount;
            }
        }

        public void OrderDrink(Agent agent, Drinks drink)
        {
            switch (drink)
            {
                case Drinks.Vodka:
                case Drinks.Gin:
                    SafeAddTrunover(8);
                    break;
                case Drinks.Beer:
                    SafeAddTrunover(5);
                    break;
                case Drinks.Whiskey:
                    SafeAddTrunover(10);
                    break;
                case Drinks.Wine:
                    SafeAddTrunover(7);
                    break;
                default: throw new ArgumentException("Drink not supported.");
            }
        }
    }*/
}
