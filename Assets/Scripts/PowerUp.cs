using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Star,
        ExtraLife,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Star:
                GameManager.Instance.AddStars();
                break;
            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;
        }

        Destroy(gameObject);
    }
}
