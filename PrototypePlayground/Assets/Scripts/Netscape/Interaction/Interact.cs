using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interact : MonoBehaviour
{

    public float range = 10f;
    public Camera fpsCam;
    public LayerMask lm;

    private 

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)))
        {

                InteractWith();
        }
        //Debug.DrawRay (fpsCam.transform.position, fpsCam.transform.forward);
    }

    void InteractWith()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, lm))
        {
            Interaction target = hit.collider.transform.GetComponent<Interaction>();
            Debug.Log(hit.transform.name);
            if (target != null)
            {
                target.interaction();
                Debug.Log (target.name);
            }
        }


    }
}
