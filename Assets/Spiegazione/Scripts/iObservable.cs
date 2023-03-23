using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iObservable 
{
    void AddObserver(iObserver observer);
    void RemoveObserver(iObserver observer);  
}
