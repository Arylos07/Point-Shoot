//Author: Michael Cox 2016
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Ammo : MonoBehaviour
{
	public float Damage = 100f;
	public float LifeTime = 2f;

    public GameObject CollisionEffect= null;
    private Transform CollisionTransform;

    //------------------------------
    void OnEnable()
	{
		CancelInvoke();
		Invoke("Die", LifeTime);
	}
	//------------------------------

	// Update is called once per frame
	void OnTriggerEnter(Collider Col)
	{
        if(CollisionEffect != null)
        {
            CollisionTransform = Col.gameObject.GetComponent<Transform>();
            Instantiate(CollisionEffect, CollisionTransform.position, CollisionTransform.rotation);
        }
		//Get health component
		Health H = Col.gameObject.GetComponent<Health>();

		if(H == null)return;

		H.HealthPoints -= Damage;
        Invoke("Die", 0);
	}
	//------------------------------

	void Die()
	{
		gameObject.SetActive(false);
	}

	//------------------------------
}
//------------------------------