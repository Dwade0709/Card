using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;

namespace Client.Core
{
    public static class GlobalClientFacade
    {
        public static ILoggerService Logger { get; set; }
    }
}
