using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelper : MonoBehaviour
{
    public int RubyChance;
    public int Gold = 50;
    public int MaxHealth = 100;
    public int Health = 100;
    bool _isDead;

    GameHelper _gameHelper;
    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        _gameHelper.HealthSlider.maxValue = MaxHealth;
        _gameHelper.HealthSlider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetHit(int damage)
    {
        if(_isDead)
        return;

        int health = Health - damage;

        if(health <= 0)
        {
            _isDead = true;
            _gameHelper.TakeGold(Gold);

            int random = Random.Range(0,100);
            if(random < RubyChance)
                _gameHelper.TakeRuby(1);      

            Destroy(gameObject);
        }
        
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;

        _gameHelper.HealthSlider.value = Health;
    }
}
