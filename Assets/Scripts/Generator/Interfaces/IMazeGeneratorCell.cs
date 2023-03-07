using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Interfaces
{
    internal interface IMazeGeneratorCell: IMazeCell
    {
        public bool Visited { get; set; }
        public int DistanceFromStart { get; set; }
    }
}
