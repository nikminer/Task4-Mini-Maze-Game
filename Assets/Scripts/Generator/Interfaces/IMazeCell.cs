namespace Assets.Interfaces
{
    public interface IMazeCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool WallLeft { get; set; }
        public bool WallBottom { get; set; }
        public bool Floor { get; set; }
    }
}
