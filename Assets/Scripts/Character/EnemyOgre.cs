using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : IEnemy
{
    public override void DoPlayHitSound()
    {
        Debug.Log("未定义 EnemyOgre 的 DoPlayHitSound()");
    }

    public override void DoShowHitEffect()
    {
        Debug.Log("未定义 EnemyOgre 的 DoShowHitEffect()");
    }
}
