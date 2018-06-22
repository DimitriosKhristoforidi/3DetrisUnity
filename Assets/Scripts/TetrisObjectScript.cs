using UnityEngine;

public class TetrisObjectScript : MonoBehaviour {

    float lastFall = 0f;
	
	void FixedUpdate () {

        if (Input.GetKeyDown("s"))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown("w"))
        {
            transform.position += new Vector3(1, 0, 0);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }

        else if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(0, 0, 1);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(0, 0, -1);
            }
        }

        else if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(0, 0, -1);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(0, 0, 1);
            }
        }

        else if (Input.GetKeyDown("q"))
        {
            transform.Rotate(new Vector3(0, 0, 90));
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        else if (Input.GetKeyDown("e"))
        {
            transform.Rotate(new Vector3(0, 90, 0));
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.Rotate(new Vector3(0, -90, 0));
            }
        }

        else if (Input.GetKeyDown("space") || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                MatrixScript.deleteWholeRows();
                FindObjectOfType<SpawnerScript>().SpawnRandomObject();
                enabled = false;
            }
            lastFall = Time.time;
        }

    }

    bool IsValidGridPosition()
    {
        foreach (Transform child in transform)
        {
            Vector3 vector3 = MatrixScript.RoundVector(child.position);

            if (!MatrixScript.isInsideBorders(vector3))
                return false;

            if (MatrixScript.grid[(int)vector3.x, (int)vector3.y, (int)vector3.z] != null && MatrixScript.grid[(int)vector3.x, (int)vector3.y, (int)vector3.z].parent != transform)
                return false;
        }
        return true;
    }

    void UpdateMatrixGrid()
    {
        for (int x = 0; x < MatrixScript.length_of_playground; ++x)
        {
            for (int z = 0; z < MatrixScript.width_of_playground; ++z)
            {
                for (int y = 0; y < MatrixScript.column; ++y)
                {
                    if (MatrixScript.grid[x, y, z] != null)
                    {
                        if (MatrixScript.grid[x, y, z].parent == transform)
                        {
                            MatrixScript.grid[x, y, z] = null;
                        }
                    }

                }
            }
        }

        foreach (Transform child in transform)
        {
            Vector3 vector3 = MatrixScript.RoundVector(child.position);
            MatrixScript.grid[(int)vector3.x, (int)vector3.y, (int)vector3.z] = child;
        }
    }

}
