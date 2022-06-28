using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyattacksPlayer_helper : MonoBehaviour
{
    public EnemyAI E_AI;

    private void Start()
    {
        E_AI = FindObjectOfType<EnemyAI>();
    }

    public void AttackPlayer_path()
    {
        E_AI.AttackPlayer();
    }
}
