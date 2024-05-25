public interface IInteractable
{
    public int emfLevel { get; set; }
    public void Interact();

}

public interface IThrowable
{
    public bool canThrow { get; set; }
    public int emfLevel { get; set; }
    public void Throw(float force);
}
