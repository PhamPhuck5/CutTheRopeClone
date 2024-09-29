using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : Singleton<GameControler>
{
    [HideInInspector]public int Season;
    [HideInInspector] public int BoxNO;
    [HideInInspector] public int lever;
    [HideInInspector] public Color AddColor;
    public int LeverInfo
    {
        get { int temp = Season * 1000 + BoxNO * 100 + lever;
            return temp;
        }
    }
    private int CurLanguageNO=0;
    [SerializeField] int MaxLangQuantiti =2;
    [SerializeField] List<LanguageSO> LanguageBase;
    private LanguageSO _CurLanguage;
    public LanguageSO CurLanguage => _CurLanguage;
    public GameObject Candy;
    public GameObject Rope;
    public int BoxLayerInt { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _CurLanguage = _CurLanguage = ScriptableObject.CreateInstance<LanguageSO>();
        UnityEngine.ColorUtility.TryParseHtmlString("#E600FF", out AddColor);
        BoxLayerInt = (1 << LayerMask.NameToLayer("Box"));
    }
    private void Start()
    {
        InitLanguage(SaveLoad.Instance.Log._CurLanguageNO);
    }
    public void InitLanguage(int no)
    {
        CurLanguageNO = no;
        _CurLanguage = LanguageBase[CurLanguageNO];
    }

    public void ChangeLanguage()
    {
        CurLanguageNO++;
        if (CurLanguageNO == MaxLangQuantiti) CurLanguageNO = 0;
        _CurLanguage = LanguageBase[CurLanguageNO];
    }
}
