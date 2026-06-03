using System.Collections.Generic;
using UnityEngine;

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
