using System;
using Orleans;
using System.Threading.Tasks;

namespace GrainInterfacesCore
{
    public interface IHello : IGrainWithIntegerKey {
        Task<string> GetGreeting();
    }
}
