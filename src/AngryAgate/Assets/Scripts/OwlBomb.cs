using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBomb : Bird
{
    [SerializeField]
    public bool _alreadyExploded = false;

    public void Explode()
    {
        if (State == BirdState.Thrown && !_alreadyExploded)
        {
            // RigidBody.AddForce(RigidBody.velocity * _boostForce);
            _alreadyExploded = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Explode();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Bird" || tag == "Enemy" || tag == "Obstacle")
        {
            Destroy(col.gameObject);
            if(_state == BirdState.HitSomething)
            {
                _flagDestroy = true;
            }
        }
    }
}
