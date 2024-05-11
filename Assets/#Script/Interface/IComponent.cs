
public interface IComponent
{
    void Display(int depth);
    E_PartsType GetType();

    
}


public interface IWeaponeState
{
    void Use();
    void Equip();
    void Dispose();

    public delegate void PartsEquip();
    public delegate void PartsUse();
    public delegate void PartsDispose();

}


