using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public interface IDisplay
    {
        string DisplayName { get; set; }

        string Description { get; set; }
    }
}
