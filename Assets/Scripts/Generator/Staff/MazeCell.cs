using Assets.Interfaces;

namespace Assets
{
    public class MazeCell: IMazeCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool WallLeft { get; set; } = true;
        public bool WallBottom { get; set; } = true;

        public bool Floor { get; set; } = true;
    }
}
