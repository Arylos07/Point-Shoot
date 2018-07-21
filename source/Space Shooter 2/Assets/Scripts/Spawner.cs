//Author: Michael Cox 2016
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Spawner : MonoBehaviour
{
    //Numbers for object 1
	public float MaxRadius1 = 1f;
	public float Interval1 = 5f;
    public float StartTime1 = 3;

    //Numbers for object 2
    public float MaxRadius2 = 1f;
    public float Interval2 = 5f;
    public float StartTime2 = 3;

    //Numbers for object 3
    public float MaxRadius3 = 1f;
    public float Interval3 = 5f;
    public float StartTime3 = 3;

    //Numbers for object 4
    public float MaxRadius4 = 1f;
    public float Interval4 = 5f;
    public float StartTime4 = 3;

    //Objects to Spawn
    public GameObject ObjToSpawn1 = null;
    public GameObject ObjToSpawn2 = null;
    public GameObject ObjToSpawn3 = null;
    public GameObject ObjToSpawn4 = null;

    private Transform Origin = null;
	//------------------------------
	void Awake()
	{
		Origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	//------------------------------
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn1", StartTime1, Interval1);
        InvokeRepeating("Spawn2", StartTime2, Interval2);
        InvokeRepeating("Spawn3", StartTime3, Interval3);
        InvokeRepeating("Spawn4", StartTime4, Interval4);
    }
	//------------------------------
	void Spawn1 () 
	{
		if(Origin == null)return;

        if (ObjToSpawn1 != null)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius1;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn1, SpawnPos, Quaternion.identity);
        }
    }
    //------------------------------

    void Spawn2()
    {
        if (Origin == null) return;

        if (ObjToSpawn2 != null)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius1;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn2, SpawnPos, Quaternion.identity);
        }
    }
    //------------------------------

    void Spawn3()
    {
        if (Origin == null) return;

        if (ObjToSpawn3 != null)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius1;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn3, SpawnPos, Quaternion.identity);
        }
    }
    //------------------------------

    void Spawn4()
    {
        if (Origin == null) return;

        if (ObjToSpawn4 != null)
        {
            Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius1;
            SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
            Instantiate(ObjToSpawn4, SpawnPos, Quaternion.identity);
        }
    }
}
//------------------------------