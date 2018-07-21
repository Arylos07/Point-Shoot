//Author: Michael Cox 2016
//------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//------------------------------
public class PlayerController : MonoBehaviour
{
	//------------------------------
	private Rigidbody ThisBody = null;
	private Transform ThisTransform = null;

    public bool WASDMove = false;
	public bool MouseLook = true;
	public string HorzAxis = "Horizontal";
	public string VertAxis = "Vertical";
	public string FireAxis = "Fire1";

    public float MaxSpeed = 5f;
    public float AttackDelay = 0.3f;
    public bool CanFire = true;

    public Transform[] TurretTransforms;

	//------------------------------
	// Use this for initialization

	void Awake ()
	{
		ThisBody = GetComponent<Rigidbody>();
		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	// Update is called once per frame

	void FixedUpdate ()
	{
        if (WASDMove == true)
        {
            //Update movement
            float Horz = Input.GetAxis(HorzAxis);
            float Vert = Input.GetAxis(VertAxis);
            Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
            ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

            //Clamp speed
            ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
                                            Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
                                            Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));
        }
		
		//Should look with mouse?
		if(MouseLook)
		{
			//Update rotation - turn to face mouse pointer
			Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
			MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
			
			//Get direction to cursor
			Vector3 LookDirection = MousePosWorld - ThisTransform.position;
			
			//FixedUpdate rotation
			ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized,Vector3.up);
		}

        // Check Fire control
        if (Input.GetButton(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
                AmmoManager.SpawnAmmo(T.position, T.rotation);

            CanFire = false;
            Invoke("EnableFire", AttackDelay);
        }

	}
    //------------------------------

    void EnableFire()
    {
        CanFire = true;
    }
    //------------------------------

    public void Die()
    {
        Destroy(gameObject);
    }
    //------------------------------

    void OnDestroy()
    {
        GameController.PlayerKilled = true;
    }
}
//------------------------------