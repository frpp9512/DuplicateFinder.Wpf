using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartB1t.Toolbox.DuplicateFinder
{
    public interface IDuplicateFinder
    {
        Task FindDuplicatesAsync();

        void Cancel();
    }
}
