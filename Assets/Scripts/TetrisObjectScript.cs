using UnityEngine;

public class TetrisObjectScript : MonoBehaviour
{
	[SerializeField]
	private string ForwardKey;
	[SerializeField]
	private string BackKey;
	[SerializeField]
	private string LeftKey;
	[SerializeField]
	private string RightKey;
	[SerializeField]
	private string XRotateKey;
	[SerializeField]
	private string YRotateKey;
	[SerializeField]
	private string ZRotateKey;
	[SerializeField]
	private string DownKey;

	float lastFall = 0f;

    void Start()
    {
        if (!IsValidGridPosition())
        {
            FindObjectOfType<GameplayController>().GameOver();
            Destroy(gameObject);
        }
    }

    void FixedUpdate () {

		if (Input.GetKeyDown(BackKey))
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

		else if (Input.GetKeyDown(ForwardKey))
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

		else if (Input.GetKeyDown(LeftKey))
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

		else if (Input.GetKeyDown(RightKey))
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

		else if (Input.GetKeyDown(ZRotateKey))
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

		else if (Input.GetKeyDown(YRotateKey))
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

		else if (Input.GetKeyDown(XRotateKey))
        {
            transform.Rotate(new Vector3(90, 0, 0));
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.Rotate(new Vector3(-90, 0, 0));
            }
        }

		else if (Input.GetKeyDown(DownKey) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (IsValidGridPosition())
            {
                UpdateMatrixGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                MatrixScript.DeleteWholeRows();
                FindObjectOfType<SpawnerScript>().SpawnRandomObject();
                enabled = false;
            }
            lastFall = Time.time;
        }

    }

    public bool IsValidGridPosition()
    {
        foreach (Transform child in transform)
        {
            Vector3 vector3 = MatrixScript.RoundVector(child.position);

            if (!MatrixScript.IsInsideBorders(vector3))
                return false;

            if (MatrixScript.grid[(int)vector3.x, (int)vector3.y, (int)vector3.z] != null && MatrixScript.grid[(int)vector3.x, (int)vector3.y, (int)vector3.z].parent != transform)
                return false;
        }
        return true;
    }

    void UpdateMatrixGrid()
    {
		for (int x = MatrixScript.start_point; x < MatrixScript.length_of_playground; ++x)
        {
            for (int z = MatrixScript.start_point; z < MatrixScript.length_of_playground; ++z)
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
