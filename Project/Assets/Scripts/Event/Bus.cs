using UnityEngine;

/// <summary>
/// Event Bus Pattern
/// ����Ƽ���� �������� ����� �� �ִ� C# �̺�Ʈ ���� �ý���
/// �ʿ��� Ŭ������ IEvent�� �����ؼ� �� �� ����
/// Bus<�̺�ƮŸ��>.Raise();�� ȣ�� ����
/// OnEvent += �Լ��� ���ָ� ������ �޾Ƽ� ó�� ����
/// </summary>
public class Bus<T> where T : IEvent
{
    public delegate void Event(T evt);
    public static event Event OnEvent;
    public static void Raise(T evt) => OnEvent?.Invoke(evt);
}

public interface IEvent
{

}
