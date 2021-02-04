using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Helpers
{
    public interface ISendEmail
    {
        bool Send(string email, string message);
    }
}
