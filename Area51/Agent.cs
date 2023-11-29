using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
    internal class Agent
    {
        public string Name { get; private set; }

        public string f { get; private set; }

        public string stringClearance { get; set; }
        private Elevator Elevator { get; set; }

        public enum Clearance {Confidential, Secret, TopSecret};

        static object lockobj = new object();

        public Agent(string name)
        {
            Name = name;
            var intClearance = Random.Shared.Next(Enum.GetValues(typeof(Agent.Clearance)).Length);
            Agent.Clearance actualClearance = (Agent.Clearance)intClearance;
            stringClearance = Convert.ToString(actualClearance);
            f = "Ground";

        }
        public void Right()
        {
            Elevator.Leave(this);
            Console.WriteLine($"{Name} got off the elevator at level: ({f}) with clearance ({stringClearance}).");
        }


        private void GoToFloor()
        {
            bool m = false;
            do {
                var intFloor = Random.Shared.Next(Enum.GetValues(typeof(Elevator.Floors)).Length);
                Elevator.Floors actualFloor = (Elevator.Floors)intFloor;
                f = Convert.ToString(actualFloor);

                Elevator.CheckFloor(stringClearance, f, ref m);
                if(m==false)Console.WriteLine($"{Name} was denied entry at level {f} with clearance {stringClearance}");
            }
            while (m!=true);
        }

        public void WorkDay(Elevator elevator)
        {
            Elevator = elevator;
            Console.WriteLine($"{Name} is waiting to enter the elevator at level {f}.");
            lock (lockobj)
            {
                Elevator.Enter(this);
                Console.WriteLine($"{Name} has entered the elevator.");
                GoToFloor();
                Right();
            }
        }

    }
    
}
