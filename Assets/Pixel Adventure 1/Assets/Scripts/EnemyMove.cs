using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveDuration;

    private float timer = 0;

    private Vector2 direction = Vector2.left;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        timer = timer + Time.deltaTime;

        if (timer >= moveDuration)
        {
            direction = direction * -1;
            timer = 0;
        }
    }
}
