﻿using UnityEngine;

public class Coin : BaseBehaviour {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            ConfigurationScript.coinsCollected += ConfigurationScript.regularCoinValue;
            print(ConfigurationScript.coinsCollected);
        }
    }
}
