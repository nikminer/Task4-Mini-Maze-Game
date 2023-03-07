using Assets;
using Assets.Interfaces;
using UnityEngine;

public class CellCreator : MonoBehaviour
{
    public Vector2Int MazeSize;
    public Cell Cell;
    public Vector3 CellSize = Vector3.right + Vector3.up;
    public GameObject ExitFloor;

    private void Start()
    {
        IMazeGenerator generator = new MazeGenerator(MazeSize.x, MazeSize.y);
        IMaze maze = generator.GenerateMaze();

        for (int x = 0; x < maze.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.Cells.GetLength(1); y++)
            {
                Cell cell = Instantiate(Cell, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                cell.WallLeft.SetActive(maze.Cells[x, y].WallLeft);
                cell.WallBottom.SetActive(maze.Cells[x, y].WallBottom);
                cell.Floor.SetActive(maze.Cells[x, y].Floor);
                cell.transform.SetParent(transform);

                if (maze.MazeExit == new Vector2(x,y))
                {
                    GameObject exit = Instantiate(ExitFloor, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                    exit.transform.SetParent(transform);
                }
            }
        }
    }
}
