using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecificDayEasterEgg2 : MonoBehaviour
{
    private SpriteRenderer spriteRender;

    public Sprite birthdaySprite;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        DateTime now = DateTime.Now;

        if(spriteRender.sprite.name != "PlayerWithHands")
        {
            if(spriteRender.sprite.name != "PlayerWithLaserGun")
            {
                if ((now.Month == 4) && (now.Day == 16))
                {
                    spriteRender.sprite = birthdaySprite;
                }
            }
        }
    }
}
