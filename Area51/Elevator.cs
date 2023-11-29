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

        public void CheckFloor(string stringClearance, string k, ref bool m)
        {

            if (k.Equals("Ground"))
                m = true;                
            else if (k.Equals("Secret") && (stringClearance.Equals("Secret") || stringClearance.Equals("TopSecret")))
                m = true;
            else if (k.Equals("TopSecret") && stringClearance.Equals("TopSecret"))
                m = true;
            else if (k.Equals("TopTopSecret") && stringClearance.Equals("TopSecret"))
                m = true;
        }
    }
    
}
