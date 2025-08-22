using System.Collections;
using UnityEngine;

public class BombConroller : MonoBehaviour
{
    private Animator _animator;
    private bool isPressed = false;
    private bool exploded = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPressed)
        {
            isPressed = true;
            BurnBomb();
            Debug.Log("123");
        }
        
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.IsName("BOOM") && !exploded)
        {
            BoomBomb();
        }
    }

    private void BurnBomb()
    {
        _animator.SetBool("isBurn", true);
    }

    private void BoomBomb()
    {
        var point = GetComponent<PointEffector2D>();
        point.enabled = true;
        StartCoroutine(WaitBeforeDestroy());

    }

    private IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
 }
