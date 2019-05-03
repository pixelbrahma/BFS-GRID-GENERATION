using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour {

    public Transform nodePrefab;
    private Queue<Vector3> frontier;
    private List<Vector3> visited;
    [SerializeField] private int halfMapSize;
    private Dictionary<Transform, Vector3> allNodes;
    private Dictionary<Vector3, Transform> colorNodes;
    private Transform temp;
    private Transform trans;

    void Start () {
        allNodes = new Dictionary<Transform, Vector3>();
        colorNodes = new Dictionary<Vector3, Transform>();
        frontier = new Queue<Vector3>();
        visited = new List<Vector3>();
        frontier.Enqueue(Vector3.zero);
        Transform node = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity) as Transform;
        allNodes.Add(node, Vector3.zero);
        colorNodes.Add(Vector3.zero, node);
        visited.Add(Vector3.zero);
        StartCoroutine(VisitNodes());
	}
	
  IEnumerator VisitNodes()
    {
        Vector3 current;
        while (frontier.Count > 0)
        {
            current = frontier.Dequeue();
            List<Vector3> neighbours = GetNeighbours(current);
            foreach (var neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    frontier.Enqueue(neighbour);
                    Transform node = Instantiate(nodePrefab, neighbour, Quaternion.identity) as Transform;
                    allNodes.Add(node, neighbour);
                    colorNodes.Add(neighbour, node);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }

    private List<Vector3> GetNeighbours(Vector3 pos)
    {
        List<Vector3> neighbours = new List<Vector3>();
        Vector3 temp;
        temp = pos + Vector3.up;
        if(temp.y <= halfMapSize)
            neighbours.Add(pos + Vector3.up);
        temp = pos + Vector3.right;
        if (temp.x <= halfMapSize)
            neighbours.Add(pos + Vector3.right);
        temp = pos + Vector3.left;
        if (temp.x >= -halfMapSize)
            neighbours.Add(pos + Vector3.left);
        temp = pos + Vector3.down;
        if (temp.y >= -halfMapSize)
            neighbours.Add(pos + Vector3.down);
        return neighbours;
    }

    void Update()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            temp = hit.collider.gameObject.transform;
            if(temp != trans)
            {
                Vector3 clean = new Vector3(-halfMapSize, -halfMapSize, 0f);
                while(clean.x <= halfMapSize)
                {
                    while(clean.y <= halfMapSize)
                    {
                        colorNodes[clean].GetComponent<MeshRenderer>().material.color = Color.green;
                        clean = new Vector3(clean.x, clean.y+1, clean.z);
                    }
                    clean = new Vector3(clean.x+1, -halfMapSize, clean.z);
                }
            }
            Vector3 nodePosition = allNodes[hit.collider.gameObject.transform];
            if(nodePosition.x>=0)
            {
                while (nodePosition.x >= 0)
                {
                    trans = colorNodes[nodePosition];
                    trans.GetComponent<MeshRenderer>().material.color = Color.red;
                    if (nodePosition.x != 0)
                    {
                        nodePosition = new Vector3(nodePosition.x - 1, nodePosition.y, nodePosition.z);
                    }
                    else
                        break;
                }
            }
            else if(nodePosition.x <=0)
            {
                while (nodePosition.x <= 0)
                {
                    trans = colorNodes[nodePosition];
                    trans.GetComponent<MeshRenderer>().material.color = Color.red;
                    if (nodePosition.x != 0)
                    {
                        nodePosition = new Vector3(nodePosition.x + 1, nodePosition.y, nodePosition.z);
                    }
                    else
                        break;
                }
            }
            if(nodePosition.y >= 0)
            {
                while (nodePosition.y >= 0)
                {
                    trans = colorNodes[nodePosition];
                    trans.GetComponent<MeshRenderer>().material.color = Color.red;
                    if (nodePosition.y != 0)
                    {
                        nodePosition = new Vector3(nodePosition.x, nodePosition.y - 1, nodePosition.z);
                    }
                    else
                        break;
                }
            }
            else if(nodePosition.y <= 0)
            {
                while (nodePosition.y <= 0)
                {
                    trans = colorNodes[nodePosition];
                    trans.GetComponent<MeshRenderer>().material.color = Color.red;
                    if (nodePosition.y != 0)
                    {
                        nodePosition = new Vector3(nodePosition.x, nodePosition.y + 1, nodePosition.z);
                    }
                    else
                        break;
                }
            } 
        }
    }
}
