using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//추상화,인터페이스

//추상화; 상속 받는 child class 입장에서 추상함수의 구현을 의무화하는 class
//특징
//1. 일반 변수,함수를 만들 수 있으나 다중 상속을 할 수 없다.
//2. 추상클래스를 상속받은 클래스는 반드시 추상함수를 오버라이딩해줘야한다.
//3. 추상함수를 가지고 있는 클래스는 객체를 만들 수 없음
//4. 추상클래스는 부모 클래스를 가질 수 있다. 이 말인 즉슨 다차상속은 가능하다는 소리다
//5.  public & protected는 가능하나 private는 안됨.(오버라이딩과 추상화의 속성을 생각해보자.)


//<정리>
//추상클래스는 1개이상의 추상함수로 인해 객체화 할수 없는 클래스를 의미.
//객체화 할수 없기 때문에 자식에게 구현을 강제 위임한다.
//어찌보면 추상 클래스에서는 실제 구현(메서드)가 없는 일종의 "시그니처"가 적혀있는 셈이다.



//인터페이스 : 시그니처로만 상속받는 child 쪽에서 인터페이스함수의 구현을 의무화하는 클래스..
//<특징>
//1. 인터페이스는 일반변수를 만들수없다.
//2. 함수와 프로퍼티...등만 가질 수 있다.즉, 시그니처(선언)만 있고
//상속받은 클래스 내에서 구현해줘야한다. 
//3. 인터페이스는 따로 객체를 만들 수 없음.
//4. 인터페이스 클래스는 부모를 가질 수 없으며 다중 상속이 가능하다.(C# 통틀어서 인터페이스만 다중상속 C언어나 C++은 아닌걸 확인했다.)
//5. 멤버 함수는 public만 가능하다.

//abstract class Weapon
//{
//    //일반 가상함수일시 오버라이딩 안해도됨(자식클래스일때만)
//    //public virtual void Attack() //일반 가상함수일시 오버라이딩 안해도됨(자식클래스일때만)
//    //{

//    //}

//    //{

//    //}

//    //순수 가상함수(추상함수)
//    public abstract void Attack(); //일반 가상함수일시 오버라이딩 안해도됨(자식클래스일때만)
//    //추상 함수; public&protected는 가능하나 private는 안됨.(오버라이딩과 추상화의 속성을 생각해보자.)



//}


public class Item
{
    public int m_Level = 1;
    public int m_Grade = 7;
    public int m_Star = 2;

    public void ShowInfo()
    {
        Debug.Log($"아이템 레벨({m_Level}) 아이템 성급({m_Star}) 아이템등급({m_Grade})");
    }

}


interface Weapon //interface
{
    void Attack(); //생략하면 기본 접근 제한자가 public 

    //public int m_WeaponID = 1000; //일반 변수를 만들수 없음

  int price {  get; set; } //프로퍼티는 만들 수있음


}



class Knife : Item, Weapon
{
    public int m_Power = 10;

    int m_price = 1000;
    public int price //프로퍼티를 의무적으로 만들어 줘야한다.
    {
        get { return m_price; }
        set { m_price = value; } //value ; set 접근자 사용시 암묵적 매개변수
    }

    



    public void PrintInfo()
    {
        Debug.Log("칼의 힘 : " + m_Power);
    }

    public void Attack()
    {
        //추상클래스를 상속받은 클래스는 오버라이딩 필요
        Debug.Log("칼로 공격");
    }
}


public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Weapon a_Wp = new Weapon(); -- 이건 못함
        //추상함수를 가지고 있느 클래스는 인스턴스를 만들 수 없음.

        Knife a_Knife = new Knife();
        a_Knife.PrintInfo();
        a_Knife.ShowInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
