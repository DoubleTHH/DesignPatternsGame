using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : IEnemy
{
    public override void DoPlayHitSound()
    {
        Debug.Log("未定义 EnemyElf 的 DoPlayHitSound()");
    }

    public override void DoShowHitEffect()
    {
        Debug.Log("未定义EnemyElf 的 DoShowHitEffect()");

    }
}
