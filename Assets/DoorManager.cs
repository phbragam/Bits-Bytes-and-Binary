using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    int doorType;

    private void OnCollisionEnter(Collision collision)
    {
        //if (gameObject.tag != "GOLDEN_DOOR")
        //{
        //    if ((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)
        //    {
        //        this.GetComponent<BoxCollider>().isTrigger = true;
        //    }
        //}
        //else
        //{
        //    if ((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) == doorType)
        //    {

        //    }
        //}


        if ((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) == doorType)
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<BoxCollider>().isTrigger = false;
        other.gameObject.GetComponent<AttributeManager>().attributes &= ~doorType;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "MAGIC_DOOR") doorType = AttributeManager.MAGIC;
        if (gameObject.tag == "INTELLIGENCE_DOOR") doorType = AttributeManager.INTELLIGENCE;
        if (gameObject.tag == "CHARISMA_DOOR") doorType = AttributeManager.CHARISMA;
        if (gameObject.tag == "FLY_DOOR") doorType = AttributeManager.FLY;
        if (gameObject.tag == "INVISIBLE_DOOR") doorType = AttributeManager.INVISIBLE;
        if (gameObject.tag == "GOLDEN_DOOR")
            doorType = 
                (AttributeManager.MAGIC | AttributeManager.INTELLIGENCE | AttributeManager.CHARISMA 
                | AttributeManager.FLY | AttributeManager.INVISIBLE);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
