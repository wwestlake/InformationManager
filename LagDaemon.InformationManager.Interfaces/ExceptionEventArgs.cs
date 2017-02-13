using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.Interfaces
{
    public class ExceptionEventArgs : Exception
    {
        public ExceptionEventArgs(string message, Exception innerException) : base(message, innerException) { }
    }
}
