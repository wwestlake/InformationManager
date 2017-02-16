using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public static class ContextFactory
    {
        private static IMContext context;

        public static IMContext Context
        {
            get
            {
                return context ?? (context = new IMContext());
            }
        }

    }
}
