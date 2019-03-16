using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject dead;
    [SerializeField] Transform parent; // providing a perent position for all dead clones
    [SerializeField] int scorePerKill = 10;
    [SerializeField] int hitsToKill = 20;
    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = ScoreBoard.FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        hitsToKill--;

        if (hitsToKill <= 0)
        {
            scoreBoard.ScoreHit(scorePerKill);
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(dead, transform.position, Quaternion.identity);
        fx.transform.parent = parent; // making the perent an perent to all dead clones
        Destroy(gameObject);
    }
}
