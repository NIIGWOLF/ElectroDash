using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour
{
    public GameObject wirePrefab;
    public Dictionary<string, Wire> Wires = new Dictionary<string, Wire>();

    public string getKey(ActivElement element1, ActivElement element2)
    {
        int id1 = element1.GetInstanceID();
        int id2 = element2.GetInstanceID();
        if (id1 > id2)
        {
            return id1.ToString() + "." + id2.ToString();
        }
        else
        {
            return id2.ToString() + "." + id1.ToString();
        }
    }

    
    public class Wire
    {
        ActivElement element1;
        ActivElement element2;
        public GameObject wire;
        string key;

        public Wire(ActivElement element1, ActivElement element2)
        {
            this.element1 = element1;
            this.element2 = element2;
            wire = Instantiate(ScriptManager.wireManager.wirePrefab);
            wire.GetComponent<WireLine>().SetElement(element1,element2);
            if (!element1.transform.position.y.Equals(element2.transform.position.y)){
                wire.transform.eulerAngles= new Vector3(0,0,90);
            }
            wire.transform.position=Vector3.Lerp(element1.transform.position,element2.transform.position,0.5f);
            wire.GetComponent<SpriteRenderer>().size = new Vector2(Vector3.Distance(element1.transform.position,element2.transform.position),wire.GetComponent<SpriteRenderer>().size.x);
        }

        public override bool Equals(object obj)
        {
            Wire wire = (Wire)obj;
            return key.Equals(wire.key);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void GetKey()
        {
            int id1 = element1.GetInstanceID();
            int id2 = element2.GetInstanceID();
            if (id1 > id2)
            {
                key = id1.ToString() + "." + id2.ToString();
            }
            else
            {
                key = id2.ToString() + "." + id1.ToString();
            }
        }
    }
}
