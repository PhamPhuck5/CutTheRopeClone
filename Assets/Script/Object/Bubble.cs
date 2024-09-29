using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerDownHandler
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            transform.parent = other.gameObject.transform;
            transform.position = other.transform.position;
            Candy.Instance.ThisRB.gravityScale = -0.25f;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Candy.Instance.ThisRB.gravityScale = 1;
        Destroy(gameObject);
    }
}
