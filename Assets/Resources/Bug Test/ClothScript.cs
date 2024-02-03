using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothScript : MonoBehaviour
{
    public int clothWidth = 10;
    public int clothHeight = 10;
    public float spacing = 1.0f;
    public float stiffness = 0.1f;
    public float damping = 0.01f;

    private GameObject[,] clothParticles;

    void Start()
    {
        InitializeCloth();

    }

    void Update()
    {
        SimulateCloth();
    }

    void InitializeCloth()
    {
        clothParticles = new GameObject[clothWidth, clothHeight];

        for (int i = 0; i < clothWidth; i++)
        {
            for (int j = 0; j < clothHeight; j++)
            {
                GameObject particle = new GameObject("Particle_" + i + "_" + j);
                particle.transform.position = new Vector3(i * spacing, -j * spacing, 0);
                particle.AddComponent<Rigidbody2D>();
                particle.AddComponent<CircleCollider2D>();
                particle.GetComponent<CircleCollider2D>().radius = 0.1f; // Adjust the radius as needed
                clothParticles[i, j] = particle;

                if (i != 0)
                {
                    // Connect to the left neighbor
                    DistanceJoint2D joint = particle.AddComponent<DistanceJoint2D>();
                    joint.connectedBody = clothParticles[i - 1, j].GetComponent<Rigidbody2D>();
                    joint.distance = spacing;
       
                }

                if (j != 0)
                {
                    // Connect to the top neighbor
                    DistanceJoint2D joint = particle.AddComponent<DistanceJoint2D>();
                    joint.connectedBody = clothParticles[i, j - 1].GetComponent<Rigidbody2D>();
                    joint.distance = spacing;
                  
                }
            }
        }
    }

    void SimulateCloth()
    {
        // You can add external forces or other simulation logic here if needed
    }
}
