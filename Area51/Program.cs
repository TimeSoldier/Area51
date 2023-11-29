namespace Area51
{
    internal class Program

    {

        const int AgentCount = 10;

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
    
}
