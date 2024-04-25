using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private PlayCell currentCell;
    public GameObject gameManagerobj;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = gameManagerobj.GetComponent< GameManager >();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            PlayCell cell = hit.collider.GetComponent<PlayCell>();

            if (cell != null && cell != currentCell)
            {

                if (currentCell != null)
                {
                    currentCell.OnHoverExit();
                }

                currentCell = cell;

                currentCell.OnHoverEnter();
            }

            if (Input.GetMouseButtonDown(0))
            {

                if (currentCell != null)
                {
                    Debug.Log("Cellule cliquée : " + currentCell.coords);
                    gameManager.PlayInCell(currentCell);
                }
            }
        }
        else
        {

            if (currentCell != null)
            {
                currentCell.OnHoverExit();
                currentCell = null;
            }
        }
    }
}