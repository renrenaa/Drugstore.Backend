using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Application.Common.Exteptions
{
    public class NotFoundExteption : Exception
    {
        public NotFoundExteption(string name, object key)
            : base($"Entity \"{name}\"({key}) not found.") { }
    }
}
