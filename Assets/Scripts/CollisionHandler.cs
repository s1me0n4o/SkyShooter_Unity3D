using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In sec")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("explosions load")] [SerializeField] GameObject deathExplosion;

    void OnTriggerEnter(Collider other)
    {
        StartDeadSequence();
    }

    private void StartDeadSequence()
    {
        gameObject.SendMessage("OnPlayerDeath");
        deathExplosion.SetActive(true);
        Invoke("Restart", levelLoadDelay);
    }

    private void Restart() //string ref
    {
        SceneManager.LoadScene(1);
    }
}
