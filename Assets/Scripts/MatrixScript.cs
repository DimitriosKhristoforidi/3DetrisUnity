using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScript {

    public static int length_of_playground = 4;
    public static int width_of_playground = 4;
    public static int column = 27;

    public static Transform[,,] grid = new Transform[length_of_playground, width_of_playground, column];

    public static Vector3 RoundVector(Vector3 vector3)
    {
        return new Vector3 (Mathf.Round(vector3.x), Mathf.Round(vector3.y), Mathf.Round(vector3.z));
    }

    public static bool isInsideBorders(Vector3 posistion)
    {
        return ((int)posistion.x >= 0 && (int)posistion.x < length_of_playground && (int)posistion.z >= 0 && (int)posistion.z >= width_of_playground && (int)posistion.y >= 0);
    }

    public static void deleteRow (int y)
    {
        for (int x = 0; x < length_of_playground; ++x)
        {
            for (int z = 0; z < width_of_playground; ++z)
            {
                GameObject.Destroy(grid[x, y, z].gameObject);
                grid[x, y, z] = null;
            }
        }
    }

    public static void decreaseRow(int y)
    {
        for (int x = 0; x < length_of_playground; ++x)
        {
            for (int z = 0; z < width_of_playground; ++z)
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

    public static void decreaseRowsAbove(int y)
    {
        for (int i=y; i < column; ++i)
        {
            decreaseRow(i);
        }
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < length_of_playground; ++x)
        {
            for (int z = 0; z < width_of_playground; ++z)
            {
                if(grid[x,y,z] != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void deleteWholeRows()
    {
        for(int y = 0; y < column; ++y)
        {
            if (IsRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
            }
        }

    }
}
