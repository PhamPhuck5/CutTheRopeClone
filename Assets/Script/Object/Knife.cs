using UnityEngine;
public class Knife : Singleton<Knife>
{
    [SerializeField] TrailRenderer TrailRenderer;
    private Vector3 POSSISTION;
    private float TimerNotClick;
    private bool FirstCut = true;
    private void Update()
    {
        if (Input.touchCount==1)
        {
            Touch Touch = Input.GetTouch(0);
            if (Touch.phase == TouchPhase.Began)
            {
                TimerNotClick = Time.time;
                FirstCut = true;
            }
            else if (Time.time - TimerNotClick > 0.1f)
            {
                if (FirstCut)
                {
                    TrailRenderer.enabled = false;
                    POSSISTION = Camera.main.ScreenToWorldPoint(Touch.position);
                    POSSISTION.z = 0;
                    transform.position = POSSISTION;
                    TrailRenderer.enabled = true;
                    FirstCut = false;
                    
                }
                else
                {
                    POSSISTION = Camera.main.ScreenToWorldPoint(Touch.position);
                    POSSISTION.z = 0;
                    transform.position = POSSISTION;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Link"))
        {
            DestroyLinks(other.transform.parent);
        }
    }
    private void DestroyLinks(Transform parent)
    {
        parent.gameObject.GetComponent<Hook>().OnDestroyLink();
        for(int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(false);
        }
    }
}
