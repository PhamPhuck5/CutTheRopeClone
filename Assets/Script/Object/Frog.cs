using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    
    [SerializeField] Animator Animator;

    private void Start()
    {
        InvokeRepeating("Waiting",1f,7f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Animator.SetBool("Eat", true);
            other.gameObject.SetActive(false);
            LeverControler.Instance.Knife.SetActive(false);
            InGameUI.Instance.WinningObject.SetActive(true);
        }
    }
    private void Waiting()
    {
        int Temp = Random.Range(1, 2);
        switch (Temp)
        {
            case 0:
                Animator.Play("WannaEat");
                break;
            default:
                Animator.Play("Waiting");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Animator.SetBool("Close", true);
            Animator.Play("CloseCandi");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Animator.SetBool("Close", false);
        }
    }
}
