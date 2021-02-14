using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class DorOpen : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("DorOpen", 0, 0f);
        }

    }

    public void Open()
    {

        Debug.Log("再生開始");
        animator.Play("DorOpen", 0, 0f);
    }
}
