using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<key>
{

    public class StateFunction
    {
        public StateFunction(bool _active, FunctionPointer _function)
        {

            active = _active;
            functionPointer = _function;
        }
        public void Set_active(bool data) { active = data; }
        public bool active;
        public FunctionPointer functionPointer;
    }
    public delegate void FunctionPointer();
    public StateMachine()
    {
        stateDictionary = new Dictionary<key, StateFunction>();
    }
    public Dictionary<key, StateFunction> stateDictionary;

    public void Add(key numID, FunctionPointer _function)
    {
        StateFunction data = new StateFunction(false, _function);
        stateDictionary.Add(numID, data);
    }

    public void Execution()
    {
        var data = stateDictionary.Values.GetEnumerator();

        while (data.MoveNext())
        {
            if (data.Current.active == true)
            {
                data.Current.functionPointer();
            }
        }
    }
    public void Set_Statebool(key numID, bool _set)
    {
        stateDictionary[numID].Set_active(_set);
    }
    public bool Get_Statebool(key numID)
    {
        return stateDictionary[numID].active;
    }
}