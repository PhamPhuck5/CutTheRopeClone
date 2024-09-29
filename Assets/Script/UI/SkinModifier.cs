using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SkinModifier : Singleton<SkinModifier>
{
    [SerializeField] SkinBase[] SkinBases;
    [SerializeField] RopeBase[] RopeBases;
    [SerializeField] Transform CandyContent;
    [SerializeField] Transform RopeContent;
    [SerializeField] GameObject CandyItem;//prefab
    [SerializeField] GameObject RopeItem;//prefab
    private GameObject CurCandy;
    private GameObject CurRope;
    private Color NoAddColor;
    [SerializeField] Text Money;
    [SerializeField] GameObject RopeList;
    [SerializeField] GameObject CandyList;
    [SerializeField] Button CandyButton;
    [SerializeField] Button RopeButton;
    [SerializeField] Button ReturnButton;


    private void Start()
    {
        ColorUtility.TryParseHtmlString("FFFFFF", out NoAddColor);
        IstanCandy();
        IstanROpe();
        RopeList.SetActive(false);
        CandyButton.onClick.AddListener(CandyOn);
        RopeButton.onClick.AddListener(RopeOn);
        ReturnButton.onClick.AddListener(Return);
        UpdateMoney();
    }
    private void IstanCandy()
    {
        bool[] BoughtSkininfo = new bool[7];
        BoughtSkininfo = SaveLoad.Instance.Log.BoughtSkin;
        for (int i = 0; i < 7; i++)
        {
            GameObject Temp = Instantiate(CandyItem, CandyContent);
            CandySkin ThisCS = Temp.GetComponent<CandySkin>();
            ThisCS.ThisSkin = SkinBases[i];
            ThisCS.Init(BoughtSkininfo[i]);
            if (i == SaveLoad.Instance.Log.CurCandyNO) 
            {
                CurCandy = Temp;
                ThisCS.ChangeSkin();
            }
        }
    }
    private void IstanROpe()
    {
        bool[] BoughtSkininfo = new bool[6];
        BoughtSkininfo = SaveLoad.Instance.Log.BoughtRope;
        for (int i = 0; i < 6; i++)
        {
            GameObject Temp = Instantiate(RopeItem, RopeContent);
            RopeSkin ThisCS = Temp.GetComponent<RopeSkin>();
            ThisCS.ThisSkin = RopeBases[i];
            ThisCS.Init(BoughtSkininfo[i]);
            if (i == SaveLoad.Instance.Log.CurRopeNO) 
            {
                CurRope = Temp;
                ThisCS.ChangeSkin();
            }
        }
    }
    public void ChangeSkin(string type,GameObject NewSkin)
    {
        GameObject temp = new GameObject();
        if (type =="Rope") 
        {
            temp = CurRope;
            CurRope = NewSkin;
        }
        else if(type == "Candy") 
        {
            temp = CurCandy;
            CurCandy = NewSkin;
        }
        temp.GetComponent<Image>().color = NoAddColor;
    }
    public void UpdateMoney()
    {
        Money.text = SaveLoad.Instance.Log.Money.ToString();
    }
    private void CandyOn()
    {
        CandyList.SetActive(true);
        RopeList.SetActive(false);
    }
    private void RopeOn()
    {
        CandyList.SetActive(false);
        RopeList.SetActive(true);
    }
    private void Return()
    {
        SceneManager.LoadScene("Start");
    }

}
