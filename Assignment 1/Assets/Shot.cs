using System;
using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private readonly WaitForSeconds _shotDuration = new WaitForSeconds(0.07f);
    private static Material _rayMaterial;
    private bool _shotButtonPressed;

    private float _rayLength = 10;
    private Ray _ray;
    private Vector3 _rayDirectionAndLength;


    // Explosion
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootTarget();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

        }

        // Will be called after all regular rendering is done

    }

    public void OnRenderObject()
    {
        if (!_shotButtonPressed) return;
        if (_rayMaterial == null)
            _rayMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        _rayMaterial.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(_ray.origin);
        GL.Vertex(_ray.origin + _rayDirectionAndLength);
        GL.End();
    }

    private IEnumerator ShotEffect()
    {
        _shotButtonPressed = true;
        yield return _shotDuration;
        _shotButtonPressed = false;
    }

    private void ShootTarget()
    {


        StartCoroutine(ShotEffect());
        Debug.Log("Shoot!!!");

        _rayDirectionAndLength = transform.TransformDirection(Vector3.forward) * _rayLength;

        _ray.origin = transform.position;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, Mathf.Infinity))
        {
            Debug.Log("Did Hit");
            Instantiate(Explosion, hit.point, Quaternion.Euler(0, 0, 0));
            Destroy(Explosion);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}