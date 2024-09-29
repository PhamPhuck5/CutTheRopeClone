using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : Singleton<SaveLoad>
{
    public readonly string SAVE_PLACE = System.IO.Path.Combine(Application.dataPath, "Save/Data.json");
    public SaveLog Log = new SaveLog();
    protected override void Awake()
    {
        base.Awake();
        if (HavingSave())
        {
            LoadInventory();
        }
        else
        {
            string directoryPath = Path.GetDirectoryName(SAVE_PLACE);
            System.IO.Directory.CreateDirectory(directoryPath);
        }
    }
    private void OnApplicationQuit()
    {
        SaveInventory();
    }
    public void LoadInventory()
    {
        if (HavingSave())
        {
            string temp = System.IO.File.ReadAllText(SAVE_PLACE);
            Log = JsonUtility.FromJson<SaveLog>(temp);
        }
        else 
        {
            Debug.LogError("MissaveFile");
        }
    }
    public void SaveInventory()
    {
        string SaveString = JsonUtility.ToJson(Log);
        System.IO.File.WriteAllText(SAVE_PLACE, SaveString);
    }
    public bool HavingSave()
    {
        if (System.IO.File.Exists(SAVE_PLACE)) return true;
        else return false;
    }
}
public class SaveLog
{
    public bool[] BoughtSkin = new bool[7];
    public bool[] BoughtRope = new bool[6];
    public int CurLever;
    public int Money;
    public int _CurLanguageNO;
    public int CurCandyNO;
    public int CurRopeNO;
    public int MagneticRemain;
    public int PowerRemain;
    public AlbumLog Album;
    public ProgessLog Progess;


    public SaveLog()
    {
        BoughtSkin[0] = true;
        BoughtRope[0] = true;
        for (int i=1;i<7;i++) { BoughtSkin[i] = false; }
        for (int i = 1; i < 6; i++) { BoughtRope[i] = false; }
        CurLever = 1101;
        Money = 2000;
        _CurLanguageNO = 0;
        CurCandyNO = 0;
        CurRopeNO = 0;
        MagneticRemain = 0;
        PowerRemain = 0;
        Album = new AlbumLog();
        Progess = new ProgessLog();

    }
    public class AlbumLog
    {
        public bool[,] AlbumExist = new bool[3, 4];
        public bool[] Reward=new bool[3];
        public AlbumLog()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    AlbumExist[i, j] = false;
                }
                Reward[i] = false;
            }
        }
    }
    public class ProgessLog
    {
        public int CurSeason = 0;
        public int CurBox = 0;
        public int CurLever = 0;
        public List<int>[,] StarNumberinLever = new List<int>[3, 3];//[season,box]
        public int TotalStars = 0;

        public ProgessLog()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    StarNumberinLever[i, j] = new List<int>();
                }
            }
        }

        public void UpdateStarsLog(int StartCounter, GameControler LeverInfo)
        {
            if (StarNumberinLever[LeverInfo.Season - 1, LeverInfo.BoxNO - 1][LeverInfo.lever - 1] < StartCounter)
            {
                StarNumberinLever[LeverInfo.Season - 1, LeverInfo.BoxNO - 1][LeverInfo.lever - 1] = StartCounter;
            }
        }
    }
}
