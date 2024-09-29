using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SupperPower : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch Touch = Input.GetTouch(0);
            Vector3 POSSISTION = Camera.main.ScreenToWorldPoint(Touch.position);
            POSSISTION.z = 0;
            transform.position = POSSISTION;
        }
    }
}
