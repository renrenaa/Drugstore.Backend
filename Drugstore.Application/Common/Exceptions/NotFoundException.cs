using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Application.Common.Exceptions
{
    public class NotFoundExcepcion : Exception
    {
        public NotFoundExcepcion(string name, object key)
            : base($"Entity \"{name}\"({key}) not found.") { }
    }
}
