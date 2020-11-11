using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerDirection direction;
    [HideInInspector] public float stepLength=0.2f;
    [HideInInspector] public float movementFrequency=0.1f;
    private float counter;
    private bool move;
    [SerializeField] private GameObject tailPrefab;
    private List<Vector3> deltaPosition;
    private List<Rigidbody> nodes;
    private Rigidbody mainBody;
    private Rigidbody headBody;
    private Transform tr;
    private bool createNodeAtTail;
    // Start is called before the first frame update
    void Awake()
    {
        tr=transform;
        mainBody=GetComponent<Rigidbody>();

        InitSnakeNodes();
        InitPlayer();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitSnakeNodes(){
        nodes=new List<Rigidbody>();

        //Get rigidbody components of the initial snake
        nodes.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(2).GetComponent<Rigidbody>());

        //Set headBody reference to point to the head game object rigid body 
        headBody=nodes[0];
    }

    void InitPlayer(){
        
        SetRandomDirection();

        switch(direction) {

            case PlayerDirection.RIGHT:
                nodes[1].position=nodes[0].position- new Vector3(Metrics.NODE,0f,0f);
                nodes[2].position=nodes[0].position- new Vector3(Metrics.NODE*2f,0f,0f);
                break;

            case PlayerDirection.LEFT:
                nodes[1].position=nodes[0].position+ new Vector3(Metrics.NODE,0f,0f);
                nodes[2].position=nodes[0].position+ new Vector3(Metrics.NODE*2f,0f,0f);
                break;

            case PlayerDirection.UP:
                nodes[1].position=nodes[0].position- new Vector3(0f,Metrics.NODE,0f);
                nodes[2].position=nodes[0].position- new Vector3(0f,Metrics.NODE*2f,0f);
                break;

            case PlayerDirection.DOWN:
                nodes[1].position=nodes[0].position+ new Vector3(0f,Metrics.NODE,0f);
                nodes[2].position=nodes[0].position+ new Vector3(0f,Metrics.NODE*2f,0f);
                break;

        }
    }

    void SetRandomDirection(){
        int dirRandom=Random.Range(0, (int)PlayerDirection.COUNT);
        direction=(PlayerDirection)dirRandom;
    }
}
