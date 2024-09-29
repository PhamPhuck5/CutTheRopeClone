using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AlbumManager : MonoBehaviour
{
    [Serializable]public struct AlbumPage
    {
        public Sprite I1;
        public Sprite I2;
        public Sprite I3;
        public Sprite I4;
    }
    [SerializeField] AlbumPage[] AlbumImage = new AlbumPage[3];
    [SerializeField] Image I1;
    [SerializeField] Image I2;
    [SerializeField] Image I3;
    [SerializeField] Image I4;
    [SerializeField] Text CurrentPageNumber;
    [SerializeField] Text GetMorePicture;
    [SerializeField] Text PhotoAlbum;
    [SerializeField] Text CollectionReward;
    [SerializeField] Text Money;
    [SerializeField] Button BuyButton;
    [SerializeField] Button UpPageButton;
    [SerializeField] Button DownPageButton;
    [SerializeField] Button OutButton;
    [SerializeField] Sprite NonImage;
    private int MaxPage = 3;
    private int CurrentPage = 1;
    private bool[,] ExistImage;

    private void Awake()
    {
        BuyButton.onClick.AddListener(Buy);
        UpPageButton.onClick.AddListener(UpPage);
        DownPageButton.onClick.AddListener(DownPage);
        OutButton.onClick.AddListener(ReturnPage);
        GetMorePicture.text= GameControler.Instance.CurLanguage.GetMorePicture;
        PhotoAlbum.text= GameControler.Instance.CurLanguage.PhotoAlbum;
        CollectionReward.text = GameControler.Instance.CurLanguage.CollectionReward;
        CurrentPageNumber.text = (CurrentPage+1).ToString()+"/3";
        Money.text = SaveLoad.Instance.Log.Money.ToString();
    }
    private void Start()
    {
        ExistImage=SaveLoad.Instance.Log.Album.AlbumExist;
        UpdatePage();
    }
    private void UpdatePage()
    {
        if (ExistImage[CurrentPage, 0]) I1.sprite = AlbumImage[CurrentPage].I1;
        else I1.sprite = NonImage;
        if (ExistImage[CurrentPage, 1]) I2.sprite = AlbumImage[CurrentPage].I2;
        else I2.sprite = NonImage;
        if (ExistImage[CurrentPage, 2]) I3.sprite = AlbumImage[CurrentPage].I3; 
        else I3.sprite = NonImage;
        if (ExistImage[CurrentPage, 3]) I4.sprite = AlbumImage[CurrentPage].I4; 
        else I4.sprite = NonImage;

    }
    private void Buy()
    {
        if (SaveLoad.Instance.Log.Money >= 300&&!IsFull())
        {
            SaveLoad.Instance.Log.Money -= 300;
            int i = 0;
            while (true)
            {
                i++;
                int temp = UnityEngine.Random.Range(0, 4);
                if(ExistImage[CurrentPage, temp] == false)
                {
                    ExistImage[CurrentPage, temp] = true;
                    SaveLoad.Instance.Log.Album.AlbumExist=ExistImage;
                    UpdatePage();
                    Money.text = SaveLoad.Instance.Log.Money.ToString();
                    return;
                }
            }
        }
        else
        {
            Debug.Log("You Can Buy");
        }
    }
    private bool IsFull()
    {
        for(int i = 0; i < 4; i++)
        {
            if (ExistImage[CurrentPage, i] == false) return false;
        }
        return true;
    }
    private void UpPage()
    {
        CurrentPage++;
        if (CurrentPage == MaxPage - 1) UpPageButton.gameObject.SetActive(false);
        else 
        {
            UpPageButton.gameObject.SetActive(true);
            DownPageButton.gameObject.SetActive(true);
        }
        CurrentPageNumber.text = (CurrentPage+1).ToString() + "/3";
        UpdatePage();
    }
    private void DownPage()
    {
        CurrentPage--;
        if (CurrentPage == 0) DownPageButton.gameObject.SetActive(false);
        else
        {
            UpPageButton.gameObject.SetActive(true);
            DownPageButton.gameObject.SetActive(true);
        }
        CurrentPageNumber.text = (CurrentPage + 1).ToString() + "/3";
        UpdatePage();
    }
    private void ReturnPage()
    {
        SceneManager.LoadScene("Start");
    }
}
