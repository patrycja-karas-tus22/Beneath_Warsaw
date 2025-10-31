using System.Collections;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    private Animator anim;
    public float lightOn;
    public float lightOff;

    private MeshRenderer mesh;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine(LightSearch());
    }

    IEnumerator LightSearch()
    {
        while (true) {
            anim.enabled = true;
            mesh.enabled = true; 

            Debug.Log("animating");

            yield return new WaitForSeconds(lightOn);

            anim.enabled = false;
            mesh.enabled = false;
            Debug.Log("stopping anim");

            yield return new WaitForSeconds(lightOff);
        }
    }
}
