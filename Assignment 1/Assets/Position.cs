using System;
using UnityEngine;

public class Position : MonoBehaviour
{
    private Transform _nose;
    private Transform _earthTarget;
    private string _text;

    private string _text2;

    // Start is called before the first frame update
    void Start()
    {
        var spaceShuttleTarget = transform.Find("SpaceShuttleTarget");
        _nose = spaceShuttleTarget.Find("Nose");

        _earthTarget = transform.Find("EarthTarget");
    }

    // Update is called once per frame
    void Update()
    {
        var noseWorldPosition = _nose.localToWorldMatrix.MultiplyPoint(_nose.position);
        var noseLocalPositionOnEarth = _earthTarget.worldToLocalMatrix.MultiplyPoint(noseWorldPosition);

        _text = $"Local Position: x: {noseLocalPositionOnEarth.x}, y: {noseLocalPositionOnEarth.y}, z: {noseLocalPositionOnEarth.z}";

        var noseDistanceToEarthCenter = Vector3.Distance(_nose.position, _earthTarget.position);

        //var earthRadius = _earthTarget.GetComponent<MeshFilter>().mesh.bounds.extents.x * _earthTarget.lossyScale;
        if (noseDistanceToEarthCenter < _earthTarget.lossyScale.x / 2)
        {
            _text2 = noseLocalPositionOnEarth.z > 0 ? "North" : "South";
            _text2 = "Hemisphere: " + _text2;
        }
        else
            _text2 = string.Empty;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 500, 100), _text);
        GUI.Label(new Rect(10, 110, 500, 100),  _text2);
    }
}
