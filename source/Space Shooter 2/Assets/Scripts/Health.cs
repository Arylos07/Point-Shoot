using UnityEngine;
using System.Collections;
//------------------------------
public class Health : MonoBehaviour
{
	public GameObject DeathParticlesPrefab = null;
	private Transform ThisTransform = null;
	public bool ShouldDestroyOnDeath = true;
    public bool Suicide;
	//------------------------------
	void Start()
	{
		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	public float HealthPoints
	{
		get
		{
			return _HealthPoints;
		}

		set
		{
			_HealthPoints = value;

			if(_HealthPoints <= 0)
			{
                // Death. Restart level.
			}
		}
	}
	//------------------------------
	[SerializeField]
	private float _HealthPoints = 100f;
}
//------------------------------