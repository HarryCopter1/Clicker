using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    const int Freeq = 4;
    public int GameTime = 10;
    
    public bool EndGame {get;set;}
    public Text GameTimeText;
    public EndMenuHelper endMenuHelper;
           
    public GameObject RubyPrefab;
    public Text PlayerGoldUI;
    public Text PlayerRubyUI;
    public Text DamageText;
    public Slider HealthSlider;
    public Transform StartPosition;
    public GameObject GoldPrefab;
    public GameObject[] MonstersPrefabs;
    public int PlayerDamage = 10;
    public int PlayerGold;
    public int PlayerRuby;
    int _count;
    int _currentTime;
    int _totalGold;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SpawnMonster();

        InvokeRepeating("Timer", 0, 1);
    }

    void Timer()
    {
        _currentTime++;
        GameTimeText.text = (GameTime - _currentTime).ToString();
        if(_currentTime >= GameTime)
        //End game
        {
            Time.timeScale = 0;
            EndGame = true;
            endMenuHelper.gameObject.SetActive(true);
            endMenuHelper.ShowEndGame(_totalGold);
        }    
    }


    // Update is called once per frame
    void Update()
    {
        DamageText.text = PlayerDamage.ToString();
        PlayerGoldUI.text = PlayerGold.ToString();
        PlayerRubyUI.text = PlayerRuby.ToString();
    }
    
    public void TakeRuby(int ruby)
    {
            PlayerRuby += ruby;      

            GameObject rubyObj = Instantiate(RubyPrefab) as GameObject; 
            Destroy(rubyObj, 3);
    }

    public void TakeGold(int gold)
    {
            PlayerGold += gold;       
            _totalGold += gold; 
            GameObject goldObj = Instantiate(GoldPrefab) as GameObject; 
            Destroy(goldObj, 2);
            
            SpawnMonster();
    }

    public void SpawnMonster()
    {
        _count++;  

        int randomMaxValue = _count/Freeq+1;

        if(randomMaxValue >= MonstersPrefabs.Length)
        randomMaxValue = MonstersPrefabs.Length;

        int index = Random.Range(0, randomMaxValue);

        GameObject monsterObj = Instantiate(MonstersPrefabs[index]) as GameObject; 

        monsterObj.transform.position = StartPosition.position;       
    }
}
