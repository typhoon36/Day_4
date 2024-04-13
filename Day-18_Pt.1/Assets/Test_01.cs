using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//�߻�ȭ,�������̽�

//�߻�ȭ; ��� �޴� child class ���忡�� �߻��Լ��� ������ �ǹ�ȭ�ϴ� class
//Ư¡
//1. �Ϲ� ����,�Լ��� ���� �� ������ ���� ����� �� �� ����.
//2. �߻�Ŭ������ ��ӹ��� Ŭ������ �ݵ�� �߻��Լ��� �������̵�������Ѵ�.
//3. �߻��Լ��� ������ �ִ� Ŭ������ ��ü�� ���� �� ����
//4. �߻�Ŭ������ �θ� Ŭ������ ���� �� �ִ�. �� ���� �ｼ ��������� �����ϴٴ� �Ҹ���
//5.  public & protected�� �����ϳ� private�� �ȵ�.(�������̵��� �߻�ȭ�� �Ӽ��� �����غ���.)


//<����>
//�߻�Ŭ������ 1���̻��� �߻��Լ��� ���� ��üȭ �Ҽ� ���� Ŭ������ �ǹ�.
//��üȭ �Ҽ� ���� ������ �ڽĿ��� ������ ���� �����Ѵ�.
//����� �߻� Ŭ���������� ���� ����(�޼���)�� ���� ������ "�ñ״�ó"�� �����ִ� ���̴�.



//�������̽� : �ñ״�ó�θ� ��ӹ޴� child �ʿ��� �������̽��Լ��� ������ �ǹ�ȭ�ϴ� Ŭ����..
//<Ư¡>
//1. �������̽��� �Ϲݺ����� ���������.
//2. �Լ��� ������Ƽ...� ���� �� �ִ�.��, �ñ״�ó(����)�� �ְ�
//��ӹ��� Ŭ���� ������ ����������Ѵ�. 
//3. �������̽��� ���� ��ü�� ���� �� ����.
//4. �������̽� Ŭ������ �θ� ���� �� ������ ���� ����� �����ϴ�.(C# ��Ʋ� �������̽��� ���߻�� C�� C++�� �ƴѰ� Ȯ���ߴ�.)
//5. ��� �Լ��� public�� �����ϴ�.

//abstract class Weapon
//{
//    //�Ϲ� �����Լ��Ͻ� �������̵� ���ص���(�ڽ�Ŭ�����϶���)
//    //public virtual void Attack() //�Ϲ� �����Լ��Ͻ� �������̵� ���ص���(�ڽ�Ŭ�����϶���)
//    //{

//    //}

//    //{

//    //}

//    //���� �����Լ�(�߻��Լ�)
//    public abstract void Attack(); //�Ϲ� �����Լ��Ͻ� �������̵� ���ص���(�ڽ�Ŭ�����϶���)
//    //�߻� �Լ�; public&protected�� �����ϳ� private�� �ȵ�.(�������̵��� �߻�ȭ�� �Ӽ��� �����غ���.)



//}


public class Item
{
    public int m_Level = 1;
    public int m_Grade = 7;
    public int m_Star = 2;

    public void ShowInfo()
    {
        Debug.Log($"������ ����({m_Level}) ������ ����({m_Star}) �����۵��({m_Grade})");
    }

}


interface Weapon //interface
{
    void Attack(); //�����ϸ� �⺻ ���� �����ڰ� public 

    //public int m_WeaponID = 1000; //�Ϲ� ������ ����� ����

  int price {  get; set; } //������Ƽ�� ���� ������


}



class Knife : Item, Weapon
{
    public int m_Power = 10;

    int m_price = 1000;
    public int price //������Ƽ�� �ǹ������� ����� ����Ѵ�.
    {
        get { return m_price; }
        set { m_price = value; } //value ; set ������ ���� �Ϲ��� �Ű�����
    }

    



    public void PrintInfo()
    {
        Debug.Log("Į�� �� : " + m_Power);
    }

    public void Attack()
    {
        //�߻�Ŭ������ ��ӹ��� Ŭ������ �������̵� �ʿ�
        Debug.Log("Į�� ����");
    }
}


public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Weapon a_Wp = new Weapon(); -- �̰� ����
        //�߻��Լ��� ������ �ִ� Ŭ������ �ν��Ͻ��� ���� �� ����.

        Knife a_Knife = new Knife();
        a_Knife.PrintInfo();
        a_Knife.ShowInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
