public class Action
    {
        public MoveSO move;
        public FighterSO user;
        public FighterSO target;

        public Action(FighterSO _user, MoveSO _move, FighterSO _target)
        {
            user = _user;
            move = _move;
            target = _target;
        }
    }