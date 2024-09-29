using UnityEngine;
using UnityEngine.UI;


public class LinkToVideo : MonoBehaviour
{
    [SerializeField] Button ThisButton;
    [SerializeField] string Link;
    private void Start()
    {
        ThisButton.onClick.AddListener(OpenLink);
    }
    private void OpenLink()
    {
        Application.OpenURL(Link);
    }
}
