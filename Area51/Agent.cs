using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    internal class Agent
    {
        bool i = false;
        public string Name { get; private set; }

        public Elevator.Floors f { get; private set; }
        public Agent.Clearance c { get; private set; }
        public string stringClearance { get; set; }
        private Elevator Elevator { get; set; }

        public enum Clearance {Confidential, Secret, TopSecret};

        public Agent(string name)
        {
            Name = name;
            var intClearance = Random.Shared.Next(Enum.GetValues(typeof(Agent.Clearance)).Length);
            Agent.Clearance actualClearance = (Agent.Clearance)intClearance;
            c = actualClearance;
            f = Elevator.Floors.Ground;

        }
        public void Right()
        {
            Elevator.Leave(this);
            Console.WriteLine($"{Name} got off the elevator at level: /({f}/).");
        }


        private bool GoToFloor()
        {            

            var intFloor = Random.Shared.Next(Enum.GetValues(typeof(Elevator.Floors)).Length);
            Elevator.Floors actualFloor = (Elevator.Floors)intFloor;
            f= actualFloor;
            int randomValue = Random.Shared.Next(100);
            if (randomValue < 40)
            {
                Elevator.CheckFloor(stringClearance, "Ground", ref i);
            }
            else if (randomValue < 60)
            {
                Elevator.CheckFloor(stringClearance, "Secret", ref i);
            }
            else if (randomValue < 80)
            {
                Elevator.CheckFloor(stringClearance, "TopSecret",ref  i);
            }
            else if (randomValue < 80)
            {
                Elevator.CheckFloor(stringClearance, "TopTopSecret", ref i);
            }

            return i;
        }

        public void WorkDay(Elevator elevator)
        {
            Elevator = elevator;
            Console.WriteLine($"{Name} is waiting to enter the elevator at level {f}.");
            Elevator.Enter(this);
            Console.WriteLine($"{Name} has entered the elevator.");
           
            
            while(i != true)
            {                
                Console.WriteLine($"{Name} has no clearance /({c}/) for level{f}");
                GoToFloor();
            }
            Right();


        }

    }
    /*internal class Agent
    {
        public string Name { get; private set; }
        private Elevator Elevator { get; set; }

        public Agent(string name)
        {
            Name = name;
        }

        private void RandomSleep()
        {
            Thread.Sleep(Random.Shared.Next(500, 2500));
        }

        private void Drink()
        {
            var intDrink = Random.Shared.Next(Enum.GetValues(typeof(Elevator.Drinks)).Length);
            Elevator.Drinks actualDrink = (Elevator.Drinks)intDrink;
            Elevator.OrderDrink(this, actualDrink);
            Console.WriteLine($"{Name} is drinking {actualDrink}");
            RandomSleep();
        }

        private void Talk()
        {
            Console.WriteLine($"{Name} is talking with someone (or to no-one)");
            RandomSleep();
        }

        private void Dance()
        {
            Console.WriteLine($"{Name} is ruling the dancefloor.");
            RandomSleep();
        }

        public void PaintTheTownRed(Elevator elevator)
        {
            Elevator = elevator;
            Console.WriteLine($"{Name} is waiting to enter the bar.");
            Elevator.Enter(this);
            Console.WriteLine($"{Name} is entered the bar.");
            while (true)
            {
                int randomValue = Random.Shared.Next(100);
                if (randomValue < 40)
                {
                    Drink();
                }
                else if (randomValue < 60)
                {
                    Talk();
                }
                else if (randomValue < 80)
                {
                    Dance();
                }
                else
                {
                    break;
                }
            }
            Elevator.Leave(this);
            Console.WriteLine($"{Name} left the bar and is going home.");
        }
    }*/
}
