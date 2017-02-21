using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;

namespace Client.Core
{
    public class BaseInfoService : IInformService
    {
        public void ShowInfo(string str)
        {
            Console.WriteLine(str);
        }
    }
}
