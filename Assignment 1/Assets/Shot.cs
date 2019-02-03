using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private readonly WaitForSeconds _shotDuration = new WaitForSeconds(0.07f);
    static Material _lineMaterial;
    private bool _shotButtonPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0);

        if (!Input.GetKeyDown(KeyCode.Space)) return;
        StartCoroutine(ShotEffect());
        Debug.Log("Shoot!!!");

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");

    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        if(!_shotButtonPressed) return;
        CreateLineMaterial();
        // Apply the line material
        _lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        var eulerAngles = transform.rotation;
        //Debug.Log("transform.rotation angles x: " + eulerAngles.x + " y: " + eulerAngles.y + " z: " + eulerAngles.z);

        Vector3 dir = eulerAngles * Vector3.forward;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.rotation.eulerAngles, out hit, 1000);

        var test = hit;



        //Vector3.


        //int degree = Random.Range(0, 360);
        //float radian = degree * Mathf.Deg2Rad;
        //float x = Mathf.Cos(radian);
        //float y = Mathf.Sin(radian);
        //spawnPoint = new Vector3(x, y, 0) * spawnDistance;


        //var vForce = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        GL.Vertex3(0, 0, 0);
        GL.Vertex3(0, 0, 10);

        GL.End();
        GL.PopMatrix();
    }

    static void CreateLineMaterial()
    {
        if (_lineMaterial) return;
        // Unity has a built-in shader that is useful for drawing
        // simple colored things.
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        _lineMaterial = new Material(shader);
        _lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        // Turn on alpha blending
        _lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        // Turn backface culling off
        _lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        // Turn off depth writes
        _lineMaterial.SetInt("_ZWrite", 0);
    }

    private IEnumerator ShotEffect()
    {
        _shotButtonPressed = true;
        yield return _shotDuration;
        _shotButtonPressed = false;
    }
}
