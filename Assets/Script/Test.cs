using UnityEngine;

public class Test : MonoBehaviour
{
    bool open = false;
    [ContextMenu("MoveCover")]
    void MoveCover()
    {
        
        switch (open)
        {
            case false:
            transform.Translate(4.3f,0,0);
            open = !open;
            break;
            case true:
             transform.Translate(-4.3f,0,0);
             open = !open;
            break;
        }
        
    }
}
