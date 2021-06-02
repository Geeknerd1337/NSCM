using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    [SerializeField]
    private Rigidbody lid;
    [SerializeField]
    private float lidForce;
    [SerializeField]
    private float lidRotationForce;

    [SerializeField]
    private List<GameObject> lootItems;

    [SerializeField]
    private Transform lootSpawnpoint;

    [SerializeField]
    private float lootForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loot()
    {
        lid.isKinematic = false;
        lid.AddForce((Vector3.up * lidForce) + Vector3.right * lidForce * 0.1f);
        lid.AddTorque(transform.right * lidRotationForce);
        StartCoroutine(WaitToSpawnLoot());
    }

    public void SpawnLoot()
    {
        for(int i = 0; i < lootItems.Count; i++)
        {
            GameObject g = Instantiate(lootItems[i]);
            g.transform.position = lootSpawnpoint.position;
            g.GetComponent<Rigidbody>().AddForce((Vector3.up + transform.forward) * lootForce);
        }
    }


    IEnumerator WaitToSpawnLoot()
    {
        yield return new WaitForSeconds(0.1f);
        SpawnLoot();
    }
}
