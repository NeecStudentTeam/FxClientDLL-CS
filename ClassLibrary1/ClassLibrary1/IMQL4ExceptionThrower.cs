using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    interface IMql4ExceptionThrower
    {
        void CheckError(string funcName, object result);
    }
}
