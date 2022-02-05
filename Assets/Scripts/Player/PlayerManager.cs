using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public struct SpellSlots
{
    public GameObject spell;
}


public class PlayerManager : NetworkBehaviour
{
    #region Variables

    public GameObject mainArea;
    public GameObject playerArea;
    public GameObject enemyArea;

    public GameObject fireSpell;
    public GameObject iceSpell;
    public GameObject lightningSpell;
    public GameObject shieldSpell;
    public GameObject slowSpell;

    List<GameObject> spells = new List<GameObject>();

    GameObject[] spellSlots = new GameObject[3];
    
    string[] spellSlotsID = new string[3];

    #endregion

    #region Server

    public override void OnStartClient()
    {
        base.OnStartClient();

        mainArea = GameObject.Find("MainArea");
        playerArea = GameObject.Find("PlayerArea");
        enemyArea = GameObject.Find("EnemyArea");
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
        
        spells.Add(fireSpell);
        spells.Add(iceSpell);
        spells.Add(lightningSpell);
        spells.Add(shieldSpell);
        spells.Add(slowSpell);
    }

    #endregion

    #region Commands

    [Command]
    public void CmdGetSpellInitialized()
    {

    }

    [Command]
    public void CmdToggleSpell(string action)
    {
        //TODO: Select or Deselect the passed-in spell
        Debug.Log(action + " toggled");
    }

    [Command]
    public void CmdRandomizeSelectedSpells()
    {
        // GameObject spell = Instantiate(spells[Random.Range(0, spells.Count)], new Vector2(0, 0), Quaternion.identity);
        // NetworkServer.Spawn(spell, connectionToClient);
        //TODO: Logic to swap the active spells and update the UI of both players

        Debug.Log("Randomize");
    }

    [Command]
    public void CmdCastSelectedSpell()
    {
        //TODO: Logic to cast the spell at the enemy
        Debug.Log("Cast");
    }

    [Command]
    public void CmdInflictDamage(GameObject castedSpell)
    {
        // TODO: Call the server to inflict damage on the enemy and clear the spell selection
        //       Call the server to randomise the spell selection that was casted
        // RpcInflictDamage(castedSpell.damage);
        RpcClearAndRandomizeSpellSelection();
    }

    #endregion

    #region Remote Procedure Calls

    
    [ClientRpc]
    void RpcClearAndRandomizeSpellSelection()
    {

    }

    [ClientRpc]
    void RpcInitializeSpells()
    {
        
    }

    [ClientRpc]
    void RpcInitializeSpellSlots()
    {
        
    }

    [ClientRpc]
    void RpcPrintSpellsOnUI()
    {
        
    }

    [TargetRpc]
    void RpcInflictDamage(int spellDamage)
    {

    }

    #endregion
}