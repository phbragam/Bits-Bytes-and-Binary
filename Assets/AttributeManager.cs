using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    // 10000
    static public int MAGIC = 16;
    // 01000
    static public int INTELLIGENCE = 8;
    // 00100
    static public int CHARISMA = 4;
    // 00010
    static public int FLY = 2;
    // 00001
    static public int INVISIBLE = 1;


    public Text attributeDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MAGIC_KEY")
        {
            attributes |= MAGIC;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "INTELLIGENCE_KEY")
        {
            attributes |= INTELLIGENCE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "CHARISMA_KEY")
        {
            attributes |= CHARISMA;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "FLY_KEY")
        {
            attributes |= FLY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "INVISIBLE_KEY")
        {
            attributes |= INVISIBLE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "MAGIC")
        {
            // ^ (XOR) compara os bits e retorna verdadeiro apenas quando são diferentes 
            // usado para Toggling (alternar, ativar quando passa e desativar quando passa de novo)
            // Ex: 10001 ^ 10001 = 00001 
            //     00001 ^ 10001 = 10001  
            attributes ^= MAGIC;
        }
        else if (other.gameObject.tag == "INTELLIGENCE")
        {
            attributes ^= INTELLIGENCE;
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes ^= CHARISMA;
        }
        else if (other.gameObject.tag == "FLY")
        {
            attributes ^= FLY;
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes ^= INVISIBLE;
        }
        else if (other.gameObject.tag == "ANTIMAGIC")
        {
            // & compara cada bit e retorna 1 apenas se os dois bits comparados forem 1
            // como ~MAGIC consiste em 01111, ele vai retornar o bit de mágic como zero
            // ex: 10001 & 01111 (que é ~MAGIC) = 00001
            // os outros bits não serão alterados, uma vez que 0 & 1 = 0 e 1 & 1 = 1
            attributes &= ~MAGIC;
        }
        else if (other.gameObject.tag == "REMOVE")
        {
            attributes &= ~ (INTELLIGENCE | MAGIC);
        }
        else if (other.gameObject.tag == "ADD")
        {
            attributes ^= (INTELLIGENCE | MAGIC | CHARISMA);
        }
        else if (other.gameObject.tag == "RESET")
        {
            attributes = 0;
        }
        else if (other.gameObject.tag == "GOLDEN_KEY")
        {
            // attributes = 31;
            // o mesmo que:
            attributes |= (INTELLIGENCE | MAGIC | CHARISMA | FLY | INVISIBLE);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
