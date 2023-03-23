using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iRPGObservable
{
    void AddObserver(iRPGObserver observer);
    void RemoveObserver(iRPGObserver observer);
}
