using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject cornContentPrefab;

    [SerializeField]
    private List<CornContent> cornList;

    public static PlayerCollider playerCollider;

    private void Awake()
    {
        if (!playerCollider)
        {
            playerCollider = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddCorn(5);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RemoveCorn(6);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MultiplyCorn(2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DivideCorn(3);
        }
    }

    public void AddCorn(int value)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject currentCornContent = Instantiate(cornContentPrefab, transform);

            Vector3 createPos = new Vector3(transform.position.x + Random.Range(-3, 3),
                transform.position.y + Random.Range(-1, 2),
                transform.position.z + Random.Range(1, 5));

            currentCornContent.transform.position = createPos;
            cornList.Add(currentCornContent.GetComponent<CornContent>());
            PlayerRotate.playerRotate.AddCorn(currentCornContent.GetComponent<CornContent>());
        }
    }

    public void MultiplyCorn(int value)
    {
        int cornCount = cornList.Count * (value - 1);

        AddCorn(cornCount);
    }

    public void RemoveCorn(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (cornList.Count > 1)
            {
                CornContent destroyCorn = cornList[cornList.Count - 1];
                Destroy(destroyCorn, 0.1f);
                destroyCorn.gameObject.SetActive(false);
                destroyCorn.gameObject.transform.parent = null;
                cornList.Remove(destroyCorn);
                PlayerRotate.playerRotate.RemoveCorn(destroyCorn);

                //if (cornList[i].isExploded)
                //{
                //    userInterfaceManager.DecreasePopcornCount();
                //}
            }
            else
            {
                Debug.Log("Game Over!");
            }
        }
    }

    public void RemoveCorn(CornContent destroyCorn)
    {
        Destroy(destroyCorn, 0.1f);
        destroyCorn.gameObject.SetActive(false);
        destroyCorn.gameObject.transform.parent = null;
        cornList.Remove(destroyCorn);
        PlayerRotate.playerRotate.RemoveCorn(destroyCorn);
        if (cornList.Count <= 0)
        {
            Manager.manager.FinishLevel();
        }
    }

    public void DivideCorn(int value)
    {
        int cornCount = ((cornList.Count) / (value));
        int removeCornCount = (cornList.Count - cornCount);

        Debug.Log("Corn Count: " + removeCornCount);

        RemoveCorn(removeCornCount);
    }
}
