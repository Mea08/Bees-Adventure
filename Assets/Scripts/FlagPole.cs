using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        int nextWorld = GameManager.Instance.world;
        int nextStage = GameManager.Instance.stage + 1;

        if(other.CompareTag("Player"))
        {
           if (GameManager.Instance.world == 1 && GameManager.Instance.stage == 1)
            {
                nextStage = 2;
            }
            else if (GameManager.Instance.world == 2 && GameManager.Instance.stage == 1)
            {
                nextStage = 3;
            }
            else if (GameManager.Instance.world == 3 && GameManager.Instance.stage == 1)
            {
                nextStage = 4;
            }
            
            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(other.transform, nextWorld, nextStage));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player, int nextWorld, int nextStage)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return MoveTo(player, poleBottom.position);
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        yield return MoveTo(player, castle.position);

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while(Vector3.Distance(subject.position, destination) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = destination;
    }
}
