using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class DorOpen : MonoBehaviour
{
    [SerializeField]
    Animator animator;
   
    // Start is called before the first frame update
    

    public void Open()
    {

        animator.Play("DorOpen", 0, 1f);
    }
}
