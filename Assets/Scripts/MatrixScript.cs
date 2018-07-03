using UnityEngine;

public class MatrixScript {

	static TetrisObjectScript tetrisObject = new TetrisObjectScript();

	public static int length_of_playground = tetrisObject.LengthOfPlayground;
	public static int width_of_playground = tetrisObject.WidthOfPlayground;
	public static int column = tetrisObject.Column;
	public static int start_point = tetrisObject.StartPoint;

	public static Transform[,,] grid = new Transform[length_of_playground, column, width_of_playground];

    public static Vector3 RoundVector(Vector3 vector3)
    {
        return new Vector3 (Mathf.Round(vector3.x), Mathf.Round(vector3.y), Mathf.Round(vector3.z));
    }

    public static bool IsInsideBorders(Vector3 posistion)
    {
        return ((int)posistion.x >= start_point && (int)posistion.x < length_of_playground && (int)posistion.z >= start_point && (int)posistion.z < width_of_playground && (int)posistion.y >= start_point);
    }

    public static void DeleteRow (int y)
    {
        for (int x = start_point; x < length_of_playground; ++x)
        {
            for (int z = start_point; z < width_of_playground; ++z)
            {
                GameObject.Destroy(grid[x, y, z].gameObject);
                grid[x, y, z] = null;
            }
        }
    }

    public static void DecreaseRow(int y)
    {
        for (int x = start_point; x < length_of_playground; ++x)
        {
            for (int z = start_point; z < width_of_playground; ++z)
            {
                if (grid[x,y,z] != null)
                {
                    grid[x, y - 1, z] = grid[x, y, z];
                    grid[x, y, z] = null;

                    grid[x, y - 1, z].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public static void DecreaseRowsAbove(int y)
    {
        for (int i=y; i < column; ++i)
        {
            DecreaseRow(i);
        }
    }

    public static bool IsRowFull(int y)
    {
        for (int x = start_point; x < length_of_playground; ++x)
        {
            for (int z = start_point; z < width_of_playground; ++z)
            {
                if(grid[x,y,z] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void DeleteWholeRows()
    {
        for(int y = 0; y < column; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
            }
        }
    }
}
