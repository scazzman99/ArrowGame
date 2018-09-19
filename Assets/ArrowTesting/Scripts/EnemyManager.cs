using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    private Gameobject enemySpawn;

    public vector3 center;
    public vector3 size;


	// Use this for initialization
	void Start () {
        SpawnEnemy();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemySpawn = 0)
            SpawnEnemy();
	}

    public void SpawnEnemy()
    {
        Vector3 pos = center + new vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(enemySpawn, pos, Quaternion.identity);
    }
    void onDrawGizmosSelected()
    {
        Gizmos.DrawCube(center, size);
    }
}
