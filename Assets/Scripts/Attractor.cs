using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    //!!! NU MI-AM COMENTAT CODU CA NU AM STIUT CA O SA FACEM IN GRUP, DA VA PRINDETI VOI :))) DE ACUMA COMENTAM.
    public static List<Attractor> Attractors;
    public Rigidbody rb;
    public float G = 60f;

    private void FixedUpdate()
    {
        foreach(Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();
        Attractors.Add(this);
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
