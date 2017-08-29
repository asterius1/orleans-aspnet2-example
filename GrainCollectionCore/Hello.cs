using System;
using GrainInterfacesCore;
using Orleans;
using System.Threading.Tasks;
using Orleans.Providers;

namespace GrainCollectionCore {

    public class HelloState {
        public int greetCount = 0;
    }

    [StorageProvider(ProviderName = "MyStore")]
    public class Hello : Grain<HelloState>, IHello {
        public Task<string> GetGreeting() {
            Console.WriteLine("getting greeting");
            State.greetCount++;
            string greet = string.Format("hello {0} times!", State.greetCount);
            Console.WriteLine("created greet: " + greet);
            return Task.FromResult(greet);
        }
    }
}
