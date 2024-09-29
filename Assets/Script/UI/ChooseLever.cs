using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLever : MonoBehaviour
{
    private Button ThisBT;
    private int lever;
    [SerializeField] Text LeverText;
    [SerializeField] GameObject StarGroup;
    private void Start()
    {
        ThisBT = GetComponent<Button>();
        ThisBT.onClick.AddListener(GoToLever);
    }
    public void Init(int _lever, int starNumber, Sprite NoStar)
    {
        lever = _lever;
        LeverText.text = lever.ToString();
        if (starNumber < 3) {
            for (int i = 0; i < 3 - starNumber; i++)
            {
                Transform Temp = StarGroup.transform.GetChild(i);
                Temp.gameObject.GetComponent<Image>().sprite = NoStar;
            }
        }
    }
    private void GoToLever()
    {
        GameControler.Instance.lever = lever;
        string temp = "Lever" + GameControler.Instance.LeverInfo.ToString();
        SceneManager.LoadScene(temp);
    }
}
