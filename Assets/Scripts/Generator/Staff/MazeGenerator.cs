using Assets.Interfaces;
using Assets.Staff;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class MazeGenerator: IMazeGenerator
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public MazeGenerator(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IMaze GenerateMaze()
        {
            IMaze maze = new Maze();
            maze.Cells = new MazeGeneratorCell[Width, Height];

            for (int x = 0; x < maze.Cells.GetLength(0); x++)
            {
                for (int y = 0; y < maze.Cells.GetLength(1); y++)
                {
                    maze.Cells[x, y] = new MazeGeneratorCell { X = x, Y = y };

                    if (Height - 1 == y)
                    {
                        maze.Cells[x, y].Floor = false;
                        maze.Cells[x, y].WallLeft = false;
                    }

                    if (Width -1 == x)
                    {
                        maze.Cells[x, y].Floor = false;
                        maze.Cells[x, y].WallBottom = false;
                    }
                }
            }

            RemoveWalls(maze);

            maze.MazeExit = PlaceMazeExit(maze);

            return maze;
        }



        private void RemoveWalls(IMaze maze)
        {
            IMazeGeneratorCell current = (IMazeGeneratorCell)maze.Cells[0, 0];
            current.Visited = true;

            Stack<IMazeGeneratorCell> stack = new Stack<IMazeGeneratorCell>();

            do
            { 
                List<IMazeGeneratorCell> neighbours = GetNeigbours((IMazeGeneratorCell[,])maze.Cells, current);

                if (neighbours.Count > 0)
                {
                    IMazeGeneratorCell chosen = neighbours[Random.Range(0, neighbours.Count)];

                    RemoveWall(current, chosen);

                    chosen.Visited = true;
                    current = chosen;
                    stack.Push(chosen);
                    chosen.DistanceFromStart = stack.Count;
                }
                else
                {
                    current = stack.Pop();
                }

            } while (stack.Count > 0);
        }

        private List<IMazeGeneratorCell> GetNeigbours(IMazeGeneratorCell[,] maze, IMazeGeneratorCell currentCell)
        {
            List<IMazeGeneratorCell> neighbours = new List<IMazeGeneratorCell>();

            int x = currentCell.X;
            int y = currentCell.Y;

            if (x > 0 && !maze[x - 1, y].Visited)
            {
                neighbours.Add(maze[x - 1, y]);
            }

            if (y > 0 && !maze[x, y - 1].Visited)
            {
                neighbours.Add(maze[x, y - 1]);
            }

            if (x < Width - 2 && !maze[x + 1, y].Visited)
            {
                neighbours.Add(maze[x + 1, y]);
            }

            if (y < Height - 2 && !maze[x, y + 1].Visited)
            {
                neighbours.Add(maze[x, y + 1]);
            }

            return neighbours;
        }

        private void RemoveWall(IMazeGeneratorCell a, IMazeGeneratorCell b)
        {
            if (a.X == b.X)
            {
                if (a.Y > b.Y)
                {
                    a.WallBottom = false;
                }
                else
                {
                    b.WallBottom = false;
                }
            }
            else
            {
                if (a.X > b.X)
                {
                    a.WallLeft = false;
                }
                else
                {
                    b.WallLeft = false;
                }
            }
        }


        private Vector2Int PlaceMazeExit(IMaze maze)
        {
            IMazeGeneratorCell furthest = (IMazeGeneratorCell) maze.Cells[0,0];
            IMazeGeneratorCell checkCell;
            for (int x = 0; x < maze.Cells.GetLength(0); x++)
            {
                checkCell = (IMazeGeneratorCell) maze.Cells[x, Height - 2];

                if (checkCell.DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = checkCell;
                }

                checkCell = (IMazeGeneratorCell)maze.Cells[x, 0];

                if (checkCell.DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = checkCell;
                }
            }

            for (int y = 0; y < maze.Cells.GetLength(1); y++)
            {
                checkCell = (IMazeGeneratorCell)maze.Cells[Width - 2, y];

                if (checkCell.DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = checkCell;
                }
                
                checkCell = (IMazeGeneratorCell)maze.Cells[0, y];

                if (checkCell.DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = checkCell;
                }
            }

            if (furthest.X == 0)
            {
                furthest.WallLeft = false;
            }
            else if (furthest.Y == 0)
            {
                furthest.WallBottom = false;
            }
            else if (furthest.X == Width - 2)
            {
                maze.Cells[furthest.X + 1, furthest.Y].WallLeft = false;
            }
            else if (furthest.Y == Height - 2)
            {
                maze.Cells[furthest.X, furthest.Y + 1].WallBottom = false;
            }

            furthest.Floor = false;

            return new Vector2Int(furthest.X, furthest.Y);
        }
    }
}
