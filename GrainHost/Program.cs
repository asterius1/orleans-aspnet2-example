using System;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;

namespace GrainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            InitSilo(args);

            Console.WriteLine("initialized silo!!!");
            //GrainClient.Initialize(ClientConfiguration.LocalhostSilo());
            //var hello = GrainClient.GrainFactory.GetGrain<GrainInterfacesCore.IHello>(0);
            //var greet1 = hello.GetGreeting().Result;
            //var greet2 = hello.GetGreeting().Result;
            //var greet3 = hello.GetGreeting().Result;
            Console.WriteLine("finished");
            Console.ReadKey();
            
            ShutdownSilo();
        }

        public void ClientTest() {
            GrainClient.Initialize(ClientConfiguration.LocalhostSilo());
            var hello = GrainClient.GrainFactory.GetGrain<GrainInterfacesCore.IHello>(0);
            var greet1 = hello.GetGreeting().Result;
            var greet2 = hello.GetGreeting().Result;
            var greet3 = hello.GetGreeting().Result;
            Console.WriteLine("greet: {0} {1} {2}", greet1, greet2, greet3);
        }

        static void InitSilo(string[] args) {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run()) {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo() {
            if (hostWrapper != null) {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
    }
}
