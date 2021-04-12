using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    public ScoreManager scoreManager;
    public int swordScore = 0;
    public int shieldScore = 0;

    public Button playButton;
    public Button quitButton;

    //public ScoreManager scoreManager;
    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        playButton.transform.localScale = new Vector3(0,0,0);
        quitButton.transform.localScale = new Vector3(0,0,0);
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        //top across
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        //middle across
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        //bottom across
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        //left down
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        //middle down
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        //right down
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        //left diagonal
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        //right diagonal
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            if (CurrentPlayer == Owner.Sword)
            {
                Debug.Log(CurrentPlayer + " score is " + ++swordScore);
                scoreManager.SwordIncriment(swordScore);
            }
            else if (CurrentPlayer == Owner.Shield)
            {
                Debug.Log(CurrentPlayer + " score is " + ++shieldScore);
                scoreManager.ShieldIncriment(shieldScore);
            }
            for (int i = 0; i < 9; ++i)
            {
                CurrentPlayer = Owner.None;
                Tiles[i].owner = CurrentPlayer;
            }
            RestartGame();
            playButton.transform.localScale = new Vector3(2, 6, 1);
            quitButton.transform.localScale = new Vector3(2, 6, 1);
            return true;
        }

        return false;
    }
    public void ResetGrid()
    {
        for (int i = 0; i < 9; ++i)
        {
            CurrentPlayer = Owner.None;
            Tiles[i].owner =CurrentPlayer;
            Tiles[i].GetComponent<SpriteRenderer>().color = Color.white;

        }
        playButton.transform.localScale = new Vector3(0, 0, 0);
        quitButton.transform.localScale = new Vector3(0, 0, 0);
        RestartGame();
    }
    public void RestartGame()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
    }
    public void QuitGame()
    {
        print("Game has been quit");
        Application.Quit();
    }
}
