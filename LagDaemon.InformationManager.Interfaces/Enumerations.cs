using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.Interfaces
{
    public enum StartupStages
    {
        Init,
        Starting,
        Running,
        ShutingDown,
        Finalizing,
        Shutodwn
    }
}
