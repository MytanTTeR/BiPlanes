using UnityEngine;
using System.Collections;

public class StandartMap : MapFactory
{
    public GameObject GO;

    public override GameObject CreateMap()
    {
        return GO;
    }
}
