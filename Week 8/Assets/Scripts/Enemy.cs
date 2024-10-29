using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Bullet bullet;
    public float shotCooldown;
    public float firstShotDelay;

    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = shotCooldown + firstShotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0.0f)
        {
            cooldownTimer = shotCooldown;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;

        Bullet spawnedBullet = Instantiate(bullet);
        spawnedBullet.Fire(enemyPos, playerPos);
    }
}
