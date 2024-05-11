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
                // ���������� ������Ʈ�� �߽߰� ��ü��������
                Debug.Log("�̹� ���� ������Ʈ�� �������ֽ��ϴ�. ����Ʈ �����ʽ��ϴ�.");
                return;
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

        // �ڽ� ��ü�鿡�� Display �޼��带 ȣ���Ͽ� Ʈ�� ������ ���
        foreach (var child in children)
        {
            child.Display(depth + 2);
        }

        // ��ü ������Ʈ ���� �ż���
    }

    E_PartsType IComponent.GetType()
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
        // ������Ʈ��ɱ���
        Debug.Log(new string('-', depth) + name);
    }

    public void SetParts()
    {

    }

    E_PartsType IComponent.GetType()
    {
        throw new System.NotImplementedException();
    }
}
