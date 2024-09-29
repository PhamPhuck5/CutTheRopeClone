using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BoxUI : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private readonly float ClickThreshold = 0.05f; //Max time duration to be a click
    private float TimeClick = 0f;
    [SerializeField] string TagetScene;
    [SerializeField] int BoxNum;
    [SerializeField] bool UnLocked;
    [SerializeField] GameObject Notice;

    public void OnPointerDown(PointerEventData evenData)
    {
        TimeClick = Time.time;
    }
    public void OnPointerUp(PointerEventData evenData)
    {
        if (Time.time - TimeClick < ClickThreshold)
        {
            if (UnLocked)
            {
                GameControler.Instance.BoxNO = BoxNum;
                SceneManager.LoadScene(TagetScene);
            }
            else
            {
                Notice.SetActive(true);
                StartCoroutine("NoticeBroad");
            }
        }
    }
    IEnumerator NoticeBroad()
    {
        yield return new WaitForSeconds(2f);
        Notice.SetActive(false);
        yield break;

    }
}
