using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurtainPull : MonoBehaviour
{
    private float LinkLength;
    [SerializeField] RectTransform WindownRT;
    [SerializeField] Button GoUpButton;


    bool isDragging = false;
    Vector3 touchPosition;
    Vector2 ScroolDistance= new Vector2(0,0);
    private float Distance
    {
        get
        {
            Vector3 parentPosition = transform.parent.position;
            return Vector2.Distance(transform.position, parentPosition);
        }
    }
    private void Awake()
    {
        GoUpButton.onClick.AddListener(() =>
        {
            StartCoroutine(MoveToTaget(650));
        });
    }
    private void Start()
    {
        LinkLength = Distance-5f;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject == gameObject) isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        if (Distance >= LinkLength && touch.deltaPosition.y < 0 && WindownRT.anchoredPosition.y > 0)
                        {
                            ScroolDistance = WindownRT.anchoredPosition;
                            ScroolDistance.y += touch.deltaPosition.y;
                            WindownRT.anchoredPosition = ScroolDistance;
                            transform.position = touchPosition;
                            if(WindownRT.anchoredPosition.y < 0)
                            {
                                WindownRT.anchoredPosition = new Vector2(WindownRT.anchoredPosition.x, 0);
                            }
                        }
                        else if(WindownRT.anchoredPosition.y >= 0|| touch.deltaPosition.y>0)
                        {
                            transform.position = touchPosition;
                        }

                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    if(WindownRT.anchoredPosition.y >= 0)
                    {
                        StartCoroutine(MoveToTaget(0));
                    }
                    break;
            }
        }
    }
    IEnumerator MoveToTaget(int Taget)
    {
        if (Taget == 0)
        {
            while (true)
            {
                WindownRT.anchoredPosition += new Vector2(0, -1000 * Time.deltaTime);
                if (WindownRT.anchoredPosition.y <= 0)
                {
                    GoUpButton.gameObject.SetActive(true);
                    WindownRT.anchoredPosition = new Vector2(WindownRT.anchoredPosition.x, 0);
                    yield break;

                }
                yield return null;
            }
        }
        else
        {
            while (true)
            {
                WindownRT.anchoredPosition += new Vector2(0, 1000 * Time.deltaTime);
                if (WindownRT.anchoredPosition.y >650)
                {
                    WindownRT.anchoredPosition = new Vector2(WindownRT.anchoredPosition.x, 650);
                    GoUpButton.gameObject.SetActive(false);
                    yield break;
                }
                yield return null;
            }
        }
    }
    /*public void OnDrag(PointerEventData eventData)
    {
        Vector3 Temp = Input.GetTouch(0).position;
        Temp.z = 0;
        transform.position = Camera.main.ScreenToWorldPoint(Temp);
        if (Distance >= LinkLength)
        {
            FingerPosistion = eventData.delta;
            FingerPosistion.x = 0;
            WindownRT.anchoredPosition += FingerPosistion;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("hoisjfeio");
    }*/

}
