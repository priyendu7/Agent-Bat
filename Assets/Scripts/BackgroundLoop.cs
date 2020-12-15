using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] backGrounds;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in backGrounds)
        {
            loadBackground(obj);
        }
        
    }
    void loadBackground(GameObject obj)
    {
        float objWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x -choke;
        float objHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y - choke;

        //int childNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objWidth);
        int childNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objHeight);

        //int childNeeded = 3;
        //Debug.Log(objWidth + ";" + screenBounds.x + ";"+childNeeded);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i= 0; i <= childNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(obj.transform.position.x,objHeight*i, obj.transform.position.z);
            c.name = obj.name + 1;

        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    private void LateUpdate()
    {
        foreach (GameObject obj in backGrounds)
        {
            repoSitionChildObjects(obj);
        }
    }
    void repoSitionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            //float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y - choke;
            if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
            }
            else if (transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfObjectHeight * 2, firstChild.transform.position.z);
            }
        }
    }
}
