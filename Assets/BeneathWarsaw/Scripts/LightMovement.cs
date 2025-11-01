using System.Collections;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    private Animator anim;
    private MeshRenderer mesh;
    private CapsuleCollider collider;

    public float lightOn;
    public float lightOff;


    private void Start()
    {
        anim = GetComponent<Animator>();
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<CapsuleCollider>();

        StartCoroutine(LightSearch());
    }

    IEnumerator LightSearch()
    {
        while (true) {
            anim.enabled = true;
            mesh.enabled = true;
            collider.enabled = true;

            Debug.Log("animating");

            yield return new WaitForSeconds(lightOn);

            anim.enabled = false;
            mesh.enabled = false;
            collider.enabled= false;
            Debug.Log("stopping anim");

            yield return new WaitForSeconds(lightOff);
        }
    }
}
