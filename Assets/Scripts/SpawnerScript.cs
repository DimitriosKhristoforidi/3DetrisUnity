using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] tetrisObjects;

    private void Start()
    {
        SpawnRandomObject();
    }

    public void SpawnRandomObject()
    {
        int index = Random.Range(0, tetrisObjects.Length);
        Instantiate (tetrisObjects[index], transform.position, Quaternion.identity);
    }
}
