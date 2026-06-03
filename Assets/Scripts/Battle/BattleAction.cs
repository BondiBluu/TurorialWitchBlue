public class BattleAction
    {
        public MoveSO move;
        public FighterSO user;
        public FighterSO target;

        public BattleAction(FighterSO _user, MoveSO _move, FighterSO _target)
        {
            user = _user;
            move = _move;
            target = _target;
        }
    }