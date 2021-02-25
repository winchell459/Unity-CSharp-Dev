using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject ProjectilePrefab;

    public float EnemySpawnRate = 1;
    public float EnemySpawnDistance = 3;
    public float EnemySpeed = 1;

    public float FireRate = 2;
    public float FireSpeed = 2;

    private float enemySpawnTime = float.NegativeInfinity;
    private float fireTime = float.NegativeInfinity;

    public int Health = 10;
    private float sceneStart;

    public enum TargetEnemyTypes
    {
        Random,
        Closest,
        Furthest,
        Best,
        Hold
    }
    public TargetEnemyTypes TargetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        sceneStart = Time.fixedTime;
        TargetEnemy = StudyHandler.SH.GetOrders();
    }

    private void FixedUpdate()
    {
        if (FireRate + fireTime < Time.fixedTime)
        {
            Transform target = findTarget();
            if (target != null)
            {
                GameObject projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                Vector2 direction = (target.position - transform.position).normalized;
                projectile.transform.up = direction;
                projectile.GetComponent<Rigidbody2D>().velocity = direction * FireSpeed;
                fireTime = Time.fixedTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawnTime + EnemySpawnRate < Time.fixedTime)
        {
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //print(direction);
            GameObject enemy = Instantiate(EnemyPrefab, direction.normalized * EnemySpawnDistance, Quaternion.identity);
            enemy.GetComponent<Enemy>().Initialize(transform, EnemySpeed);
            enemySpawnTime = Time.fixedTime;
        }

        
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
        if (Health <= 0)
        {
            print(Time.fixedTime - sceneStart);
            StudyHandler.SH.BaseDeath(Time.fixedTime - sceneStart);
            Destroy(gameObject);
        }
    }
    //public bool RandomFire = false;
    private Transform findTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length > 0)
        {
            if (TargetEnemy == TargetEnemyTypes.Random) return enemies[0].transform;
            else if (TargetEnemy == TargetEnemyTypes.Closest) return findClosestTarget(enemies);
            else if (TargetEnemy == TargetEnemyTypes.Furthest) return findFurthestTarget(enemies);
            else if (TargetEnemy == TargetEnemyTypes.Best) return findBestTarget(enemies);
        }
        return null;
    }

    private Transform findClosestTarget(Enemy[] enemies)
    {
        Transform closest = enemies[0].transform;
        float closestDistance = Vector2.Distance(closest.position, transform.position);
        for(int i = 1; i < enemies.Length; i += 1)
        {
            if(Vector2.Distance(transform.position, enemies[i].transform.position) < closestDistance){
                closest = enemies[i].transform;
                closestDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
            }
        }

        return closest;
    }

    private Transform findFurthestTarget(Enemy [] enemies)
    {
        Transform furthest = enemies[0].transform;
        float furthestDistance = Vector2.Distance(furthest.position, transform.position);
        for (int i = 1; i < enemies.Length; i += 1)
        {
            if (Vector2.Distance(transform.position, enemies[i].transform.position) > furthestDistance)
            {
                furthest = enemies[i].transform;
                furthestDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
            }
        }

        return furthest;
    }

    public float tooClose = 1;
    private Transform findBestTarget(Enemy[] enemies)
    {
        Transform best = enemies[0].transform;
        float bestDistance = Vector2.Distance(best.position, transform.position);
        for (int i = 1; i < enemies.Length; i += 1)
        {
            float distance = Vector2.Distance(transform.position, enemies[i].transform.position);
            if (distance > tooClose && (distance < bestDistance || bestDistance < tooClose))
            {
                best = enemies[i].transform;
                bestDistance = distance;
            }
        }

        return best;
    }


}
