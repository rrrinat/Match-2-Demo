namespace Match2.Common.StateMachine
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}