using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuHelper : MonoBehaviour
{
    public Text GoldEarned;
    public Text RecordGoldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndGame(int gold)
    {
        GoldEarned.text = gold.ToString();

        if(SettingClass.GoldRecord < gold)
        {
        SettingClass.GoldRecord = gold;
        }

        RecordGoldText.text = SettingClass.GoldRecord.ToString();
    }

    public void ButtonRestartClick()
    {
        SceneManager.LoadScene("Main");
    }
}
