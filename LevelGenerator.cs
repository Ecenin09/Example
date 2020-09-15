using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject jewelPrefab;
    public int numberOfJewel;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = 1.3f;
    public float maxY = 3f;
    private Vector3 _spawnPositionPlatform;
    private Vector3 _spawnPositionJewel;

    private void Start()
    {
        _spawnPositionJewel = gameObject.transform.position;
        _spawnPositionPlatform = gameObject.transform.position;
        Spawn(platformPrefab,_spawnPositionPlatform,numberOfPlatforms,2);
        Spawn(jewelPrefab, _spawnPositionJewel, numberOfJewel,5);
    }
    private void Spawn(GameObject prefab, Vector3 startPos, int numberOfObject, int frequence)
    {
        for (int i = 0; numberOfObject >= 0; i++)
        {
            if (i%frequence==0)
            {
                startPos.y += Random.Range(minY, maxY);
                startPos.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(prefab, startPos,Quaternion.identity);
                numberOfObject--;
            }  
        }
    }
}
