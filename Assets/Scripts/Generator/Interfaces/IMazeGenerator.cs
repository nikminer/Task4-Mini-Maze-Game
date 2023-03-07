namespace Assets.Interfaces
{
    internal interface IMazeGenerator
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IMaze GenerateMaze();
    }
}
