using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDock
{
    class GroupBoxData
    {

        public GroupBox _GroupBox { get; private set; } = null;
        public int _Height { get; private set; } = 0;


        public GroupBoxData()
        {

        }

        public GroupBoxData(GroupBox groupBox,int height)
        {
            this._GroupBox = groupBox;
            this._Height = height;
        }
    }
}
