using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upecito.Bot
{
    public interface ISomeServiceFactory
    {
        T Create<T>() where T : class;
    }
}
