using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPower : MonoBehaviour
{
    [SerializeField] Button MagneticPageMask;
    [SerializeField] Button PowerPageMask;
    [SerializeField] Button BackButton;

    [SerializeField] Button Buy1Magnetic;
    [SerializeField] Button Buy5Magnetic;
    [SerializeField] Button Buy10Magnetic;
    [SerializeField] Button Buy50Magnetic;

    [SerializeField] Button Buy1Power;
    [SerializeField] Button Buy5Power;
    [SerializeField] Button Buy10Power;
    [SerializeField] Button Buy50Power;

    [SerializeField] Text MagneticRemain;
    [SerializeField] Text PowerRemain;

    [SerializeField] Transform BuyPowerPage;
    [SerializeField] Transform BuyMagneticPage;
    [SerializeField] GameObject SettingPhase;
    private void Awake()
    {
        MagneticPageMask.onClick.AddListener(() =>
        {
            BuyMagneticPage.SetAsLastSibling();
        });
        PowerPageMask.onClick.AddListener(() =>
        {
            BuyPowerPage.SetAsLastSibling();
        });
        BackButton.onClick.AddListener(() =>
        {
            SettingPhase.SetActive(true);
            gameObject.SetActive(false);
        });
        Buy1Magnetic.onClick.AddListener(()=> BuyMagneticFunc(1,50));
        Buy5Magnetic.onClick.AddListener(() => BuyMagneticFunc(5, 200));
        Buy10Magnetic.onClick.AddListener(() => BuyMagneticFunc(10, 380));
        Buy50Magnetic.onClick.AddListener(() => BuyMagneticFunc(50, 1500));
        Buy1Power.onClick.AddListener(()=> BuyPowerFunc(1,50));
        Buy5Power.onClick.AddListener(() => BuyPowerFunc(5, 200));
        Buy10Power.onClick.AddListener(() => BuyPowerFunc(10, 380));
        Buy50Power.onClick.AddListener(() => BuyPowerFunc(50, 1500));
    }

    private void BuyMagneticFunc(int numbers,int Price)
    {
        if (SaveLoad.Instance.Log.Money > Price)
        {
            SaveLoad.Instance.Log.Money -= Price;
            SaveLoad.Instance.Log.MagneticRemain += numbers;
            MagneticRemain.text = SaveLoad.Instance.Log.MagneticRemain.ToString();
        }
    }
    private void BuyPowerFunc(int numbers, int Price)
    {
        if (SaveLoad.Instance.Log.Money > Price)
        {
            SaveLoad.Instance.Log.Money -= Price;
            SaveLoad.Instance.Log.PowerRemain += numbers;
            PowerRemain.text = SaveLoad.Instance.Log.PowerRemain.ToString();
        }
    }

}
