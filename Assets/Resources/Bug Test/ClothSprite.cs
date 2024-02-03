using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothSprite : MonoBehaviour
{
    public float stiffness = 1f;   // Adjust the stiffness of the cloth
    public float damping = 0.1f;    // Adjust the damping of the cloth
    public float gravity = 0.5f;    // Adjust the strength of gravity

    private Vector2[] particles;
    private Vector2[] velocities;

    void Start()
    {
        InitializeCloth();
    }

    void Update()
    {
        SimulateCloth();
        UpdateSprite();
    }

    void InitializeCloth()
    {
        // Get the vertices of the sprite
        Vector2[] spriteVertices = GetComponent<SpriteRenderer>().sprite.vertices;

        // Initialize particle positions based on sprite vertices
        particles = new Vector2[spriteVertices.Length];
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i] = transform.TransformPoint(spriteVertices[i]);
        }

        // Initialize velocities
        velocities = new Vector2[particles.Length];
    }

    void SimulateCloth()
    {
        // Perform Verlet integration
        for (int i = 0; i < particles.Length; i++)
        {
            Vector2 velocity = velocities[i];
            velocities[i] += (Vector2.down * gravity + CalculateSpringForce(i) - damping * velocity) * Time.deltaTime;
            particles[i] += velocities[i] * Time.deltaTime;
        }
    }

    Vector2 CalculateSpringForce(int index)
    {
        // Calculate spring force from neighboring particles
        Vector2 force = Vector2.zero;

        if (index > 0)
        {
            force += CalculateSpringForceBetweenParticles(index, index - 1);
        }

        if (index < particles.Length - 1)
        {
            force += CalculateSpringForceBetweenParticles(index, index + 1);
        }

        return force * stiffness;
    }

    Vector2 CalculateSpringForceBetweenParticles(int index1, int index2)
    {
        Vector2 delta = particles[index2] - particles[index1];
        float distance = delta.magnitude;
        float displacement = distance - 1f;  // Adjust the rest length of the springs

        return delta.normalized * displacement;
    }

    void UpdateSprite()
    {
        // Update the SpriteRenderer with the new particle positions
        Vector2[] spriteVertices = GetComponent<SpriteRenderer>().sprite.vertices;
        for (int i = 0; i < particles.Length; i++)
        {
            spriteVertices[i] = transform.InverseTransformPoint(particles[i]);
        }

        
    }
}
