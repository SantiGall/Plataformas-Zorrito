using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyTrap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject fxFeedback;
    [SerializeField] AudioClip yeouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(yeouch);
            AffectPlayer(collision.gameObject);
            PickedUpBehavior();
            GameManager.Instance.HpDown(1);
        }
    }

    void PickedUpBehavior()
    {
        Instantiate(fxFeedback, gameObject.transform.position, Quaternion.identity);
    }

    void AffectPlayer(GameObject playerGO)
    {
        playerGO.GetComponent<PlayerBlink>().Blink();
        playerGO.GetComponent<KnockBack>().ActivateKnockBack(transform);
    }
}