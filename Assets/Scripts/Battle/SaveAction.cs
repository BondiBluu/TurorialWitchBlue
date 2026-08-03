using System.Collections.Generic;
using UnityEngine;

//saves the action of the fighter for the turn and adds it to a list of actions to be executed in order
public class SaveAction : MonoBehaviour
{
    List<BattleAction> actionQueue = new List<BattleAction>();
    public FighterSO pendingUser;
    public MoveSO pendingMove;
    public FighterSO pendingTarget;

    public void SetUser(FighterSO user)
    {
        pendingUser = user;
    }

    public void SetMove(MoveSO move)
    {
        pendingMove = move;
    }

    public void SetTarget(FighterSO target)
    {
        pendingTarget = target;
    }

    //add to list of attacks and set all to null for the next turn
    public void AddToQueue()
    {
        actionQueue.Add(new BattleAction(pendingUser, pendingMove, pendingTarget));

        pendingUser = null;
        pendingMove = null;
        pendingTarget = null;
    }
}
