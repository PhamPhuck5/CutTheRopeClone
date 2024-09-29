using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyOutScreen : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy")){
            LeverControler.Instance.Lose();
        }
    }
}
