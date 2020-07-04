using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public float speed = 20.0f;
    public string PathName;
    public float fPointRate = 0.01f;
    public bool loop = false ;
    float pathRate;
    // Start is called before the first frame update
    void Start()
    {
        pathRate = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        pathRate += speed * Time.deltaTime;
        if ( pathRate > 1.0f)
        {
            if ( loop)
            {
                pathRate = 0.0f;
            }
            else
            {
                return;
            }
        }
        if ( pathRate + fPointRate < 1.0f)
        {
            Vector3 fpos = iTween.PointOnPath(iTweenPath.GetPath(PathName), pathRate + fPointRate);
            iTween.PutOnPath(gameObject, iTweenPath.GetPath(PathName), pathRate);
            gameObject.transform.LookAt(fpos);
        }
        else
        {
            iTween.PutOnPath(gameObject, iTweenPath.GetPath(PathName), pathRate);
        }
        
        
    }
}
