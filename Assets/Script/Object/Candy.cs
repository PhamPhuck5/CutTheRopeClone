using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Singleton<Candy>
{
    [HideInInspector]public HingeJoint2D[] CandyHJ;
    [HideInInspector] public Rigidbody2D ThisRB;
    protected override void Awake()
    {
        base.Awake();
        CandyHJ = GetComponents<HingeJoint2D>();
        Debug.Log(CandyHJ.Length);
        ThisRB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GameControler.Instance.Candy.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.CompareTag("Star"))
            {
                Destroy(other.gameObject);
                InGameUI.Instance.AddStar();
            }
            else if (other.gameObject.CompareTag("Trap"))
            {
                LeverControler.Instance.Lose();
            }
        }
    }
}
