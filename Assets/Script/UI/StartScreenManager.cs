using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartScreenManager : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button VipMembership;
    [SerializeField] Button SkinButton;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button SettingButton;
    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        VipMembership.onClick.AddListener(OpenVip);
        SkinButton.onClick.AddListener(SkinManager);
        CollectionButton.onClick.AddListener(ToCollection);
        SettingButton.onClick.AddListener(TOSetting);

    }
    private void OpenVip()
    {
        SceneManager.LoadScene("BuyVipMembership"); 
    }
    private void SkinManager()
    {
        SceneManager.LoadScene("SkinManager");
    }
    private void ToCollection()
    {
        SceneManager.LoadScene("Collection");
    }
    private void TOSetting()
    {
        SceneManager.LoadScene("Setting");
    }
    private void StartGame()
    {
        SceneManager.LoadScene("ChoseSeason");
    }
}
