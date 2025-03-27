namespace Game;

public interface ICharacter
{
    public void MoveLeft();

    public void MoveRight();

    public void MoveUp();

    public void MoveDown();

    public void Die();
}