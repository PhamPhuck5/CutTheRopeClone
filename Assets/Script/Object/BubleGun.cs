using UnityEngine;
using UnityEngine.EventSystems;

public class BubleGun : MonoBehaviour,IPointerDownHandler
{
    private GameObject ShootPoint;

    private void Awake()
    {
        ShootPoint = transform.GetChild(0).gameObject;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit2D[] Temp=Physics2D.BoxCastAll(ShootPoint.transform.position, new Vector2(2, 2), transform.localRotation.z,Vector2.right,0);
        for (int i = 0; i < Temp.Length; i++)
        {
            if (Temp[i].collider.gameObject.CompareTag("Candy"))
            {
                Rigidbody2D Candy =Temp[i].collider.gameObject.GetComponent<Rigidbody2D>();
                Vector3 Direction = ShootPoint.transform.position - transform.position;
                Direction = Direction.normalized;
                Candy.AddForce(new Vector2(Direction.x,Direction.y), ForceMode2D.Impulse);
            }
        }
    }
}
