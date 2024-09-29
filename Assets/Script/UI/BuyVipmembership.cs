using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyVipmembership : MonoBehaviour
{
    [SerializeField] Button BackButton;
    [SerializeField] Button BuyButton;
    private void Start()
    {
        BackButton.onClick.AddListener(Back);
        BuyButton.onClick.AddListener(BuyVip);
    }
    private void Back()
    {
        SceneManager.LoadScene("Start");
    }
    private void BuyVip()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
}
