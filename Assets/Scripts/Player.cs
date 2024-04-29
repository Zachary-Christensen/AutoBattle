using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoBattle.Enums;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject hero; // reference set in editor
    public Gameboard gameboard; // reference set in editor

    public InputActionReference spawnLane1;
    public InputActionReference spawnLane2;
    public InputActionReference spawnLane3;

    void Start()
    {
        
    }

    void Update()
    {
        if (spawnLane1.action.WasPressedThisFrame())
        {
            Spawn(Lane.Left);
        }
        if (spawnLane2.action.WasPressedThisFrame())
        {
            Spawn(Lane.Mid);
        }
        if (spawnLane3.action.WasPressedThisFrame())
        {
            Spawn(Lane.Right);
        }
    }

    private void Spawn(Lane lane)
    {
        GameObject newHero = Instantiate(hero);
        newHero.transform.position = gameboard.GetPlayerLanePosition(lane);
        newHero.transform.localScale = Vector3.one * gameboard.UnitScale;
        newHero.transform.SetParent(transform);
        
    }
}
