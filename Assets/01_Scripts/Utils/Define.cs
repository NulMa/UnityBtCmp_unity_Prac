using UnityEngine;

public class Define
{
    public enum MouseEvent
    {
        Press,
        Click
    }   

    public const int CLICK_LAYER = (1 << 6) + (1 << 8);
}
