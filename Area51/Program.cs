namespace Area51
{
    internal class Program

    {

        const int AgentCount = 100;

        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();

            List<Thread> agentThreads = new List<Thread>(AgentCount);
            for (int i = 0; i < AgentCount; i++)
            {
                Agent agent = new Agent(i.ToString());
                Thread t = new Thread(
                    () =>
                    {
                        agent.WorkDay(elevator);
                    });
                t.Start();
                agentThreads.Add(t);
            }
            foreach (var t in agentThreads) t.Join();
            
        }
    }
    /*internal class Program
    {
        const int StudentCount = 100;

        static void Main(string[] args)
        {
            Elevator bar = new Elevator();
            List<Thread> studentThreads = new List<Thread>(StudentCount);
            for (int i = 0; i < StudentCount; i++)
            {
                Agent agent = new Agent(i.ToString());
                Thread t = new Thread(
                    () =>
                    {
                        agent.PaintTheTownRed(bar);
                    });
                t.Start();
                studentThreads.Add(t);
            }
            foreach (var t in studentThreads) t.Join();
            Console.WriteLine($"Bar made: {bar.Turnover} tonight.");
        }
    }*/
}