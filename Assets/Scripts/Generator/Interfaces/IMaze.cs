using UnityEngine;

namespace Assets.Interfaces
{
    public interface IMaze
    {
        public IMazeCell[,] Cells { get; set; }
        public Vector2Int MazeExit { get; set; }
    }
}
