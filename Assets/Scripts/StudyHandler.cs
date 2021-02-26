﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StudyHandler : MonoBehaviour
{

    public static StudyHandler SH;
    public Base.TargetEnemyTypes[] MarchingOrders;
    private int ordersIndex = 0;
    public List<float> Times = new List<float>();
    // Start is called before the first frame update
    void Awake()
    {
        if (!SH)
        {
            SH = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public Base.TargetEnemyTypes GetOrders()
    {
        if (ordersIndex < MarchingOrders.Length)
        {
            Base.TargetEnemyTypes orders = MarchingOrders[ordersIndex];
            ordersIndex += 1;
            return orders;
        }
        else
        {
            int typesCount = Enum.GetNames(typeof(Base.TargetEnemyTypes)).Length;
            float[] scores = new float[typesCount];
            int[] scoreCounts = new int[typesCount];
            for(int i = 0; i < typesCount; i += 1)
            {
                scores[i] = 0;
                scoreCounts[i] = 0;
            }
            //foreach(Base.TargetEnemyTypes type in MarchingOrders)
            for (int i = 0; i < MarchingOrders.Length; i += 1)
            {
                Base.TargetEnemyTypes type = MarchingOrders[i];
                int orderIndex = (int)type;
                scores[orderIndex] += Times[i];
                scoreCounts[orderIndex] += 1;
            }

            for (int i = 0; i < typesCount; i += 1)
            {
                if(scoreCounts[i] > 0) print((Base.TargetEnemyTypes)i + " Score: " + scores[i] / scoreCounts[i]);
            }

            return Base.TargetEnemyTypes.Hold;
        }
        
    }

    public void BaseDeath(float time)
    {
        Times.Add(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShotClosest");
    }
}
