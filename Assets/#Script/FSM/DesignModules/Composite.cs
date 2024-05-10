using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();
    private string name;

    public Composite(string name)
    {
        this.name = name;
    }

    public void Add(IComponent component)
    {
        foreach (var item in children)
        {
            if(item.GetType() == component.GetType())
            {
                // 
            }
        }
        children.Add(component);
    }

    public void Remove(IComponent component)
    {
        children.Remove(component);
    }

    public void Display(int depth)
    {
        // Console.WriteLine(new string('-', depth) + name);

        // 자식 객체들에게 Display 메서드를 호출하여 트리 구조를 출력
        foreach (var child in children)
        {
            child.Display(depth + 2);
        }
    }

    E_WeaponComponent IComponent.GetType()
    {
        throw new System.NotImplementedException();
    }
}

public class RifleParts : IComponent
{
    private string name;

    public RifleParts(string name)
    {
        this.name = name;
    }

    public void Display(int depth)
    {
        // 컴포넌트기능구현
        Debug.Log(new string('-', depth) + name);
    }

    public void SetParts()
    {

    }

    E_WeaponComponent IComponent.GetType()
    {
        throw new System.NotImplementedException();
    }
}
