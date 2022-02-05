using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerInputHandler : NetworkBehaviour
{
    public PlayerManager playerManager;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if(!hasAuthority) {return;}
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
    }
    

    #region Player Inputs

    /****** Send calls to the server to select, or deselect the spells and have it print on the UI passing in the specific spell slot ******/
    public void OnSpell_0(InputAction.CallbackContext context)
    {
        if(!context.action.triggered){return;}
        playerManager.CmdToggleSpell(context.action.name);
    }

    public void OnSpell_1(InputAction.CallbackContext context)
    {
        if(!context.action.triggered){return;}
        playerManager.CmdToggleSpell(context.action.name);
    }

    public void OnSpell_2(InputAction.CallbackContext context)
    {
        if(!context.action.triggered){return;}
        playerManager.CmdToggleSpell(context.action.name);
    }

    /****** Send call to the server to randomise the selected spells ******/
    public void OnRandomizeSpell(InputAction.CallbackContext context)
    {
        if(!context.action.triggered){return;}
        playerManager.CmdRandomizeSelectedSpells();
    }

    /****** Send call to the server to cast the spell ******/
    public void OnCastSpell(InputAction.CallbackContext context)
    {
        if(!context.action.triggered){return;}
        playerManager.CmdCastSelectedSpell();
    }

    #endregion
}