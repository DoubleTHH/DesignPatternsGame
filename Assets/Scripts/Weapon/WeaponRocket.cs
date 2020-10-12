using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public WeaponRocket() { }

    protected override void DoShowBulletEffect(ICharacter theTarget)
    {
        ShowBulletEffect(theTarget.GetPosition(), 0.8f, 0.5f);

    }

    protected override void DoShowSoundEffect()
    {
        ShowSoundEffect("RocketShot");
    }
}
