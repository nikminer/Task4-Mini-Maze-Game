using Assets.Interfaces;

namespace Assets.Staff
{
    internal class MazeGeneratorCell : MazeCell, IMazeGeneratorCell
    {
        public bool Visited { get; set; } = false;
        public int DistanceFromStart { get; set; } = 0;
    }
}
