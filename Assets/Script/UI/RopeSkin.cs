using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class RopeSkin : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public RopeBase ThisSkin;
    private Image ThisImagine;
    private bool IsBought = false;
    private GameObject Rope;
    [SerializeField] GameObject Equipt;
    [SerializeField] GameObject BuyBroad;
    private Color ThisColor;
    private void Awake()
    {
        Transform temp = transform.GetChild(0);
        Rope = GameControler.Instance.Rope;
        ThisImagine = temp.gameObject.GetComponent<Image>();
    }
    public void Init(bool _ISBought)
    {
        ColorUtility.TryParseHtmlString(ThisSkin._Color, out ThisColor);
        ThisImagine.color = ThisColor;
        if (_ISBought)
        {
            IsBought = true;
            BuyBroad.SetActive(false);
            Equipt.SetActive(true);
            Equipt.GetComponent<Text>().text = GameControler.Instance.CurLanguage.Equip;
        }
        else
        {
            BuyBroad.SetActive(true);
            Equipt.SetActive(false);
            GameObject Price = BuyBroad.transform.GetChild(0).gameObject;
            Price.GetComponent<Text>().text = ThisSkin._Price.ToString();
        }
    }
    public void OnPointerDown(PointerEventData evenData)
    {
        if (IsBought)
        {
            ChangeSkin();
        }
        else
        {
            if (SaveLoad.Instance.Log.Money >= ThisSkin._Price)
            {
                SaveLoad.Instance.Log.Money -= ThisSkin._Price;
                int i = transform.GetSiblingIndex();
                SaveLoad.Instance.Log.BoughtRope[i] = true;
                SkinModifier.Instance.UpdateMoney();
                Init(true);
            }
        }
    }
    public void ChangeSkin()
    {
        SkinModifier.Instance.ChangeSkin("Rope",gameObject);
        Rope.GetComponent<SpriteRenderer>().color = ThisColor;
        gameObject.GetComponent<Image>().color = GameControler.Instance.AddColor;
    }
}
