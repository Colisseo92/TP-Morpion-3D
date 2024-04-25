using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();

    private int currentPlayer = 0;

    private void Start()
    {
        Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayer].color);
        Vector3Int vec = new Vector3Int(0, 0, 0);
        Debug.Log(vec.Equals(new Vector3Int(0, 0, 0)));
    }

    // Start is called before the first frame update

    // Update is called once per frame

    private void nextPlayer()
    {
        int playerNumber = players.Count;
        if(currentPlayer+1 < playerNumber)
        {
            currentPlayer += 1;
            Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayer].color);
        }
        else
        {
            currentPlayer = 0;
            Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayer].color);
        }
    }

    public void PlayInCell(PlayCell cell)
    {
        if (!cell.HasToken)
        {
            GameObject playerObject = players[currentPlayer].tokenPrefab;
            GameObject token = Instantiate(playerObject, cell.transform);
            players[currentPlayer].plays.Add(cell.coords);
            Debug.Log(players[currentPlayer].plays.Count);
            token.transform.position = cell.transform.position;
            cell.SetToken(token.gameObject);
            if (players[currentPlayer].hasWon())
            {
                Debug.Log("Player " + currentPlayer + " has won");
            }
            nextPlayer();
        }
    }
}
