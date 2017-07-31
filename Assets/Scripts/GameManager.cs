﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int maxPowerPerOrb = 10;
    public PowerOrb powerOrbPrefab = null;

    static public Color GetTeamColor(int team)
    {
        switch(team)
        {
            case 0:
                return new Color(0.2f, 0.85f, 0.0f);
            case 1:
                return Color.magenta;
            default:
                return Color.white;
        }
    }

    public void SpawnPowerOrbs(int power, Vector3 position, Transform reciever)
    {
        if (power <= 0 || maxPowerPerOrb <= 0 || powerOrbPrefab == null)
            return;

        int orbCount = power / maxPowerPerOrb;
        for (int i = 0; i < orbCount; i++)
        {
            GameObject gobj = Instantiate<GameObject>(powerOrbPrefab.gameObject, position, Quaternion.identity);
            PowerOrb orb = gobj.GetComponent<PowerOrb>();
            orb.powerValue = maxPowerPerOrb;
            orb.target = reciever;
        }

        //spawn remainder
        int remainingPower = power % maxPowerPerOrb;
        if (remainingPower > 0)
        {
            GameObject gobj = Instantiate<GameObject>(powerOrbPrefab.gameObject, position, Quaternion.identity);
            PowerOrb orb = gobj.GetComponent<PowerOrb>();
            orb.powerValue = remainingPower;
            orb.target = reciever;
        }
    }

    // Use this for initialization
    void Start () {
        if (maxPowerPerOrb <= 0)
        {
            Debug.LogWarningFormat("Invalid max power per orb: {0}", maxPowerPerOrb);
        }
        if (powerOrbPrefab == null)
        {
            Debug.LogWarning("Missing power orb prefab");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
