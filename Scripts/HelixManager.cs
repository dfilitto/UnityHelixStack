using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings; //An�is
    private float ySpawn = 0; //coordenada para criar os an�is
    private float ringsDistance = 5; //dist�ncia entre os an�is
    public int numberOfRings = 0; //quantidade de an�is da torre

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex+3;
        SpawnRing(0);
        for (int i = 0; i < numberOfRings-1; i++)
        {
            SpawnRing(Random.Range(1,helixRings.Length-1));
        }
        SpawnRing(helixRings.Length - 1);
    }

    private void SpawnRing(int i)
    {
        GameObject go = Instantiate(helixRings[i], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform; //anel pertence a torre
        ySpawn -= ringsDistance;
    }
}
