using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborRoom
{
    public int XPos { get; set; }
    public int YPos { get; set; }

    public NeighborRoom(int Y, int X)
    {
        XPos = X;
        YPos = Y;
    }

    
}
