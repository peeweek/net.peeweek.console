using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSpawner : MonoBehaviour {

    public Vector2 Extents = new Vector2(2, 2);
    public GameObject PrefabToSpawn;
    public float Delay;

    float ttl;

	// Use this for initialization
	void Start () {
        ttl = Delay;	
	}
	
	// Update is called once per frame
	void Update () {
        ttl -= Time.deltaTime;
        if(ttl < 0)
        {
            ttl = Delay;
            var obj = GameObject.Instantiate(PrefabToSpawn);
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-1.0f, 1.0f) * Extents.x, transform.position.y, transform.position.z + Random.Range(-1.0f, 1.0f) * Extents.y);
            obj.transform.rotation = Random.rotation;
            float scale = Random.Range(0.1f, 1.0f);
            obj.transform.localScale = new Vector3(scale, scale, scale);
        }
	}
}
