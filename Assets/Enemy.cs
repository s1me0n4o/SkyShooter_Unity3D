using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject dead;
    [SerializeField] Transform parent; // providing a perent position for all dead clones

    void Start()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
      //  enemyCollider.transform.position.reset;
        enemyCollider.isTrigger = false;
    }
    
    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(dead, transform.position, Quaternion.identity);
        fx.transform.parent = parent; // making the perent an perent to all dead clones
        Destroy(gameObject);
    }
}
