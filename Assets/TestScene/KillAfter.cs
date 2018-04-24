using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfter : MonoBehaviour {

    public float Delay = 7.0f;
    float ttl;

	void Start () {
        ttl = Delay;
	}

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0)
            Destroy(gameObject);
    }

}
