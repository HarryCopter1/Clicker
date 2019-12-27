using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
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
        if(_gameHelper.PlayerGold >= Price)
        {
            _gameHelper.PlayerGold -= Price;
            _gameHelper.PlayerDamage += Damage;

            GameObject upEffect = Instantiate(UpPrefab).gameObject;
            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IcoImage.sprite;

            Destroy(upEffect,1.2f);
            Destroy(gameObject);
        }
    }
}
