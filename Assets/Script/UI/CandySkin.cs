using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CandySkin : MonoBehaviour,IPointerDownHandler
{
    [HideInInspector]public SkinBase ThisSkin;
    private Image ThisImagine;
    private bool IsBought = false;
    private GameObject Candy;
    [SerializeField] GameObject Equipt;
    [SerializeField] GameObject BuyBroad;
    private void Awake()
    {
        Transform temp = transform.GetChild(0);
        Candy = GameControler.Instance.Candy;
        ThisImagine = temp.gameObject.GetComponent<Image>();
    }
    public void Init(bool _ISBought)
    {
        ThisImagine.sprite = ThisSkin._Image;
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
            if (SaveLoad.Instance.Log.Money > ThisSkin._Price)
            {
                SaveLoad.Instance.Log.Money -= ThisSkin._Price;
                int i = transform.GetSiblingIndex();
                SaveLoad.Instance.Log.BoughtSkin[i] = true;
                SkinModifier.Instance.UpdateMoney();
                Init(true);
            }
            else { Debug.Log("Not enough money"); }
        }
    }
    public void ChangeSkin()
    {
        SkinModifier.Instance.ChangeSkin("Candy",gameObject);
        Candy.GetComponent<SpriteRenderer>().sprite = ThisSkin._Image;
        gameObject.GetComponent<Image>().color = GameControler.Instance.AddColor;
    }
}
