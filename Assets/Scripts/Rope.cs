using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject prefabRopeSeg;
    public int numLinks = 0;

    public HingeJoint2D top;

    private float distanceAnchors =0;
    public Rigidbody2D anchor2;
    void Start()
    {
        GenerateRope();
    }

    private void FixedUpdate()
    {
        distanceAnchors = Vector2.Distance(hook.transform.position, anchor2.transform.position);
        //Debug.Log(distanceAnchors);
        //sDebug.Log(numLinks);
        if (numLinks < (Mathf.Abs((distanceAnchors)*2) + 7))
        {
            numLinks++;
            addLink();
            Debug.Log("Adicionou");
        }
        else if(numLinks > (Mathf.Abs((distanceAnchors)*2) + 9))
        {
            removeLink();
            Debug.Log("Removeu");
            numLinks--;
        }
    }



    void GenerateRope()
    {
        
            Rigidbody2D prevBod = hook;
            for (int i = 0; i < numLinks; i++)
            {
                GameObject newSeg = Instantiate(prefabRopeSeg);
                newSeg.transform.parent = transform;
                newSeg.transform.position = transform.position;
                HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
                hj.connectedBody = prevBod;

                prevBod = newSeg.GetComponent<Rigidbody2D>();

                if (i == 0)
                {
                    top = hj;
                }
                if( i == numLinks - 1)
                {
               
                anchor2.GetComponent<HingeJoint2D>().connectedBody = prevBod;
                anchor2.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, -7);
                }
            }
          

    }
    
    public void addLink()
    {
        GameObject newLink = Instantiate(prefabRopeSeg);
        newLink.transform.parent = transform;
        newLink.transform.position = transform.position;
        HingeJoint2D hj = newLink.GetComponent<HingeJoint2D>();
        hj.connectedBody = hook;
        newLink.GetComponent<RopeSegment>().connectedBelow = top.gameObject;
        top.connectedBody = newLink.GetComponent<Rigidbody2D>();
        top.GetComponent<RopeSegment>().ResetAnchor();
        top = hj;

    }

    public void removeLink()
    {
        HingeJoint2D newTop = top.gameObject.GetComponent<RopeSegment>().connectedBelow.GetComponent<HingeJoint2D>();
        newTop.connectedBody = hook;
        newTop.gameObject.transform.position = hook.gameObject.transform.position;
        newTop.GetComponent<RopeSegment>().ResetAnchor();
        Destroy(top.gameObject);
        top = newTop;
    }

}
