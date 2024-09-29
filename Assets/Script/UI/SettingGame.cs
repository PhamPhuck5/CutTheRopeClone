using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingGame : MonoBehaviour
{
    [SerializeField] Button LanguageButton;
    [SerializeField] Button AboutButton;
    [SerializeField] Button AboutProductButton;
    [SerializeField] Button ReturnButton;
    [SerializeField] Button MusicButton;
    [SerializeField] Button SoundEffectButton;

    [SerializeField] GameObject Phase1;
    [SerializeField] GameObject About;
    [SerializeField] GameObject AboutProduct;
    [SerializeField] GameObject MusicDisable;
    [SerializeField] GameObject SoundDisable;
    //should use List or array in general with large infomation;
    private int Road = 0;
    private int phase
    {
        get
        {
            int i = 1;
            int _Road = Road;
            while (_Road != 0)
            {
                i++;
                _Road /= 10;
            }
            return i;
        }
    }
    [SerializeField] Text LanguageText;
    [SerializeField] Text AboutText;
    [SerializeField] Text GameProgessText;
    [SerializeField] Text PrivatePolicyText;
    [SerializeField] Text TermOfSirviceText;
    [SerializeField] Text AboutProductText;
    private LanguageSO TempLanguage;

    private void Awake()
    {
        AboutButton.onClick.AddListener(ClickAbout);
        AboutProductButton.onClick.AddListener(ProductButton);
        ReturnButton.onClick.AddListener(ClickReturn);
        LanguageButton.onClick.AddListener(ChangLanguage);
        MusicButton.onClick.AddListener(ClickMusicButton);
        SoundEffectButton.onClick.AddListener(ClickSoundButton);
    }
    private void ChangLanguage()
    {
        GameControler.Instance.ChangeLanguage();
        SetLanguage();
    }
    private void SetLanguage()
    {
        TempLanguage = GameControler.Instance.CurLanguage;
        LanguageText.text = TempLanguage.Language;
        AboutText.text = TempLanguage.About;
        GameProgessText.text = TempLanguage.GameProgess;
        PrivatePolicyText.text = TempLanguage.PrivatePolicy;
        TermOfSirviceText.text= TempLanguage.TermOfSirvice;
        AboutProductText.text = TempLanguage.AboutProduct;

    }
    private void ClickAbout()
    {
        Phase1.SetActive(false);
        About.SetActive(true);
        Road = 2;
    }
    private void ProductButton()
    {
        AboutProduct.SetActive(true);
        About.SetActive(false);
        Road = 23;
    }
    private void ClickReturn()
    {
        if(phase == 1)
        {
            SceneManager.LoadScene("Start");
        }
        else if (phase == 2)
        {
            About.SetActive(false);
            Phase1.SetActive(true);
        }
        else
        {
            About.SetActive(true);
            AboutProduct.SetActive(false);
        }
        Road /= 10;
    }
    private void ClickMusicButton()
    {
        bool temp = MusicDisable.activeSelf;
        AudioControler.Instance.Music.mute = !temp;
        MusicDisable.SetActive(!temp);
    }
    private void ClickSoundButton()
    {
        bool temp = SoundDisable.activeSelf;
        AudioControler.Instance.EffectSound.mute = !temp;
        SoundDisable.SetActive(!temp);
    }
}
