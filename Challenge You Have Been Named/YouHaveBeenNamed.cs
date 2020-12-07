using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class YouHaveBeenNamed : MonoBehaviour
{
    private List<string> names= new List<string>{"John","James","Jane","Alex","Bob"};
    // Start is called before the first frame update
    void Start()
    {
        names.ForEach(n => Debug.Log(n));
        int named = Random.Range(0, names.Count);
        names.RemoveAt(named);
        names.ForEach(n => Debug.Log(n));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
