using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField] private float deathTime;
    [SerializeField] private GameObject enemyObject;

    private Material enemyMat;
    private float deathTimer;    
    private bool dying;


	// Use this for initialization
	void Start () {
        enemyMat = enemyObject.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if(dying)
        {
            if(deathTimer <=0)
            {
                Destroy(gameObject);
            }
            else
            {
                deathTimer -= Time.deltaTime;
                Color temp = enemyMat.color;
                temp.a = (deathTimer/deathTime);
                enemyMat.color = temp;
            }           
        }
	}

    private void Die()
    {
        if(!dying)
        {
            dying = true;
            deathTimer = deathTime;
        }
        
    }
}
