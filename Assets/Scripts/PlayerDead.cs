using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string deathAnimTrigger = "Die";
    public GameObject deathMenu;
    
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit an enemy and we aren't already dead
        if (collision.gameObject.CompareTag(enemyTag) && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        // 1. Play the animation
        if (anim != null)
        {
            anim.SetTrigger(deathAnimTrigger);
        }

        // 2. Disable movement/physics so the player doesn't slide around while dead
        GetComponent<Rigidbody2D>().simulated = false; 

        // 3. Start the timer to destroy the object
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Wait for a specific amount of time (adjust this to your animation length)
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
        FinishingDeath();
    }

    public void FinishingDeath()
    {
        deathMenu.SetActive(true);
    }


}