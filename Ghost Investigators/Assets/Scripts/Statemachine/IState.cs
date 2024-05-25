public interface IState
{
    public GhostController Owner { get; set; }
    public void OnStateEnter();
    public void Update();
    public void OnStateExit();
}