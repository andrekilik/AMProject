﻿using UnityEngine;
using System.Collections;

public class Bixao : BaseBehaviour {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        handleVisibilityOnly = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(rb.velocity.x, -30f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
    }
}
