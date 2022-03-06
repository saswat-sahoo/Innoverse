using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_redirect : MonoBehaviour
{
    [SerializeField] private string Event_1 = "";
    [SerializeField] private string Event_2 = "";
    [SerializeField] private string Event_3 = "";
    [SerializeField] private string Event_4 = "";
    [SerializeField] private string Event_5 = "";
    [SerializeField] private string Event_6 = "";
    [SerializeField] private string Event_7 = "";
    [SerializeField] private string Event_8 = "";

    public void event1()
   {
        Application.OpenURL(Event_1);
   }
    public void event2()
    {
        Application.OpenURL(Event_2);
    }
    public void event3()
    {
        Application.OpenURL(Event_3);
    }
    public void event4()
    {
        Application.OpenURL(Event_4);
    }
    public void event5()
    {
        Application.OpenURL(Event_5);
    }
    public void event6()
    {
        Application.OpenURL(Event_6);
    }
    public void event7()
    {
        Application.OpenURL(Event_7);
    }
    public void event8()
    {
        Application.OpenURL(Event_8);
    }
}
