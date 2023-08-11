using UnityEngine;

public class Player : MonoBehaviour
{
    private DeathAnimation deathAnimation;
    private int lives = 3; 

    public bool dead => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        lives--; 
        if (lives <= 0)
        {
            Death();
        }
        else
        {
            Respawn();
        }
    }

    private void Death()
    {
        deathAnimation.enabled = true;
    }

    private void Respawn()
    {
        deathAnimation.enabled = false;
    }
}
