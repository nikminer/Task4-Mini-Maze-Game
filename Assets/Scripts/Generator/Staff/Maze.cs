using Assets.Interfaces;
using UnityEngine;

namespace Assets.Staff 
{
    public class Maze: IMaze
    {
        public IMazeCell[,] Cells { get; set; }
        public Vector2Int MazeExit { get; set; }
    }
}
