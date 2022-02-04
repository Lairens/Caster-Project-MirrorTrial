using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    #region Variables

    public GameObject mainArea;
    public GameObject playerArea;
    public GameObject enemyArea;

    public List<GameObject> spells = new List<GameObject>();

    public GameObject[] spellSlots = new GameObject[3];

    #endregion

    #region Server

    public override void OnStartClient()
    {
        base.OnStartClient();
        RpcShowPlayerUI();
        RpcInitializeSpells();
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    #endregion

    #region Commands

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

    // Attributing a personnal UI to the Client
    [ClientRpc]
    void RpcShowPlayerUI()
    {
        // Is the client the owner of the object it is requesting a UI for
        if(hasAuthority)
        {
            // Temporary variables to stock an instance of the different UI element prefabs for ease of use
            GameObject playerAreaInstance = Instantiate<GameObject>(playerArea);
            GameObject enemyAreaInstance = Instantiate<GameObject>(enemyArea);
            GameObject mainAreaInstance = Instantiate<GameObject>(mainArea);

            //Trying to individualise the UI to each player-------------------------

            /******NEEDS FURTHER TESTING******/

            // Spawning the UI Instance and giving it to the specific client requesting it and tying it to the connection ID
            NetworkServer.Spawn(mainAreaInstance, connectionToClient);
            NetworkServer.Spawn(playerAreaInstance, connectionToClient);
            NetworkServer.Spawn(enemyAreaInstance, connectionToClient);
            
            // Setting the UI Instances as a Child of the PlayerManager object to prevent interactions from other clients
            mainAreaInstance.transform.SetParent(gameObject.transform, true);
            playerAreaInstance.transform.SetParent(gameObject.transform, true);
            enemyAreaInstance.transform.SetParent(gameObject.transform, true);
        }
    }

    [ClientRpc]
    void RpcClearAndRandomizeSpellSelection()
    {

    }

    [ClientRpc]
    void RpcInitializeSpells()
    {
        if(!hasAuthority){return;}
        for(int i = 0; i < spellSlots.Length; i++)
        {
            spellSlots[i] = spells[Random.Range(0, spells.Count)];
            Debug.Log(spellSlots[i].name);
        }
    }

    [TargetRpc]
    void RpcInflictDamage(int spellDamage)
    {

    }

    #endregion
}