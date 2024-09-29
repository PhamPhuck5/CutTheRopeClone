using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUIFollowX : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    [SerializeField] RectTransform RectTransform;
    [SerializeField] RectTransform BlackRT;
    [SerializeField] Canvas canvas;
    [SerializeField] Scrollbar Scrollbar;
    [SerializeField] int NumberBox;
    private float RangeScroll;
    private Coroutine MoveBoxCoroutine;
    private bool CoroutineRuning = false;
    [SerializeField] GameObject CheckPoint1;
    [SerializeField] GameObject CheckPoint2;
    [SerializeField] Image Frog;
    private Image ThisImg;
    private PointerEventData PointerEventData1;
    private PointerEventData PointerEventData2;
    [SerializeField] GraphicRaycaster GraphicRaycaster;
    private void Start()
    {
        ThisImg = GetComponent<Image>();
        RangeScroll = 1f / (float)(NumberBox-1);
        PointerEventData1 = new PointerEventData(EventSystem.current);
        PointerEventData2 = new PointerEventData(EventSystem.current);
        Vector3 Temp1 = CheckPoint1.transform.position;
        Vector3 Temp2 = CheckPoint2.transform.position;
        PointerEventData1.position = Camera.main.WorldToScreenPoint(Temp1);
        PointerEventData2.position = Camera.main.WorldToScreenPoint(Temp2);
    }
    private void Update()
    {
        List<RaycastResult> results1 = new List<RaycastResult>();
        List<RaycastResult> results2 = new List<RaycastResult>();
        GraphicRaycaster.Raycast(PointerEventData1, results1);
        GraphicRaycaster.Raycast(PointerEventData2, results2);
        Frog.enabled = CheckFrog(results1, results2); 
    }
    private bool CheckFrog(List<RaycastResult> results1, List<RaycastResult> results2)
    {
        int i = 0;
        foreach(RaycastResult Obj in results1)
        {
            if (Obj.gameObject.CompareTag("Box"))
            {
                i++;
                break;
            }
        }
        if (i == 0)
        {
            return false;
        }
        foreach (RaycastResult Obj in results2)
        {
            if (Obj.gameObject.CompareTag("Box"))
            {
                i++;
                break;
            }
        }
        if (i == 2)
        {
            return true;
        }
        return false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        ThisImg.raycastTarget = false;
        if (CoroutineRuning)
        {
            StopCRT();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 Temp = 2f*Vector2.right * eventData.delta.x;
        RectTransform.anchoredPosition += Temp / canvas.scaleFactor;
        BlackRT.anchoredPosition = RectTransform.anchoredPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        ThisImg.raycastTarget = true;
        int CurrentPlace = (int)(Scrollbar.value / RangeScroll);
        float Temp = Scrollbar.value - CurrentPlace * RangeScroll;
        float Taget = (Temp < RangeScroll / 2) ? CurrentPlace* RangeScroll : (CurrentPlace + 1) * RangeScroll;
        Debug.Log(Taget / RangeScroll);
        MoveBoxCoroutine = StartCoroutine(SnapToPoint(Taget));
    }
    IEnumerator SnapToPoint(float Taget)
    {
        CoroutineRuning = true;
        while (Mathf.Abs(Scrollbar.value - Taget) > 0.01)
        {
            Scrollbar.value += (Taget - Scrollbar.value) * Time.deltaTime * 3f;
            BlackRT.anchoredPosition = RectTransform.anchoredPosition;
            yield return null;
        }
        StopCRT();
    }
    private void StopCRT()
    {
        CoroutineRuning = false;
        StopCoroutine(MoveBoxCoroutine);//this coroutine
    }
}
