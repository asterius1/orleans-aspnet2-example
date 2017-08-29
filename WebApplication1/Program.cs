using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Orleans;
using Orleans.Runtime.Configuration;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args) {
            ClientTest();
            Console.WriteLine("hello world!");
            Console.ReadKey();
            //BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void ClientTest() {
            var config = ClientConfiguration.LocalhostSilo();
            var client = new ClientBuilder()
                .UseConfiguration(config)
                .UseServiceProviderFactory(new DefaultServiceProviderFactory())
                .Build();
            client.Connect().Wait();

            Console.WriteLine("connected");
            var hello = client.GetGrain<GrainInterfacesCore.IHello>(0);
            var greet1 = hello.GetGreeting().Result;
            var greet2 = hello.GetGreeting().Result;
            var greet3 = hello.GetGreeting().Result;
            Console.WriteLine("greet: {0} {1} {2}", greet1, greet2, greet3);
        }
    }
}
