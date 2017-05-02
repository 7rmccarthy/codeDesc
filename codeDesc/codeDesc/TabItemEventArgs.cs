using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeDesc
{
    public class TabItemEventArgs : EventArgs
    {
        public int Index { get; }
        public int OldIndex { get; }

        public TabItemEventArgs(int index,int oIndex)
        {
            this.Index = index;
            this.OldIndex = oIndex;
        }
    }
}
