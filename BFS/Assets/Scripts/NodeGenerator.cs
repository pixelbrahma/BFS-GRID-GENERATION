/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour {

    public Transform nodePrefab;
    public Vector2 mapsize;
    private float nodeOriginalScale;
    private string nodeParentNAme;
    [Range(0,1)]
    public float outline;

    private Queue<Vector3> frontier;
    private List<Vector3> visited;
    private Dictionary<Vector3, GameObject> nodeData;
    private Dictionary<Vector3, Vector3> camerfrom;

   
	// Use this for initialization
	void Start () {
        nodeOriginalScale = nodePrefab.localScale.x;
        nodeParentNAme = "nodeParent";
        createNodes();
	}
    public void CreateNodes()
    {
        if (transform.Find(nodeParentNAme))
        {
            DestroyImmediate(transform.Find(nodeParentNAme).gameObject);
        }

        gameObject np = new gameObject();
        np.name = nodeParentNAme;
        np.transform.setparent(transform);
        for (int y = 0; y < mapsize.y; y++)
        {
            for (int x = 0; x < mapsize.x; x++)
            {
                Transform node = Instantiate(nodePrefab, new Vector3(-mapsize.x / 2 + nodeOriginalScale / 2 + x, 0,
                    -mapsize.y / 2 + nodeOriginalScale / 2 + y), Quaternion.Euler(Vector3.right + 90));
                node.localScale = Vector3
                node.setparent(np.transform);
            }
        }
    }


    private void Initialize()
    {
        frontier = new Queue<Vector3>();
        visited = new List<Vector3>();
        nodeData = new Dictionary<Vector3, GameObject>();
        camerfrom = new Dictionary<Vector3, Vector3>();
    }

    private void visitNodes()
    {
        Vector3 current;
        while (frontier.Count > 0)
        {
            current = frontier.Dequeue();
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
*/