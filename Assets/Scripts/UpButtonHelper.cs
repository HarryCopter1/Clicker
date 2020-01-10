using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
    public bool IsHero;
    public bool IsRuby;
    public GameObject HeroPrefab;

    public GameObject UpPrefab;
    public Image IcoImage;
    public Text DamageText;
    public Text PriceText;
    public int Damage = 10;
    public int Price = 10;
    GameHelper _gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();   

        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();          
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void UpClick()
    {
        if(!IsRuby && _gameHelper.PlayerGold >= Price
        ||
        IsRuby && _gameHelper.PlayerRuby >= Price)
        {
            if(!IsRuby)
            _gameHelper.PlayerGold -= Price;
            else
            _gameHelper.PlayerRuby -= Price;

            if(IsHero == false)
            {
                _gameHelper.PlayerDamage += Damage;
            }
            else
            {
                GameObject hero = Instantiate(HeroPrefab).gameObject;
                Vector3 heroPos = new Vector3(
                    Random.Range(3.0f,7.0f),
                    Random.Range(-3.5f,-3.0f),
                    0
                );
                hero.transform.position = heroPos;
            }

            GameObject upEffect = Instantiate(UpPrefab).gameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IcoImage.sprite;

            Destroy(upEffect,1.2f);
            if(IsHero == false)
                Destroy(gameObject);
        }
    }
}
