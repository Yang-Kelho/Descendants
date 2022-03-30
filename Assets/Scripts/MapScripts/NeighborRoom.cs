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

    public bool equals(NeighborRoom room1)
    {
        bool equal;
        if (room1.XPos == this.XPos && room1.YPos == this.YPos)
        {
            equal = true;
            return equal;
        }
        else
        {
            equal = false;
            return equal;
        }
    }
}
