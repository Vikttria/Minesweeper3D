using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    //távolság
    private Vector3 cDistance;

    private Vector3 cameraRot = new Vector3(42, -120, 0);

    private float f = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        cDistance = player.transform.position - transform.position;

    }

    private void FixedUpdate()
    {
        f += 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(cameraRot + new Vector3(Mathf.Sin(f / 18) * 2f, Mathf.Sin(f / 4) * 4f));
    }

    void LateUpdate()
    {
        Vector3 nextPos = player.transform.position - cDistance;
        //interpolár két vektor közt, a kamera simábban mozog
        transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
    }
}
