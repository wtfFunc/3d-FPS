
public interface IComponent
{
    void Display(int depth);
    E_WeaponComponent GetType();

    public delegate void PartsEquip();
    public delegate void PartsUse();
    public delegate void PartsDispose();
}


