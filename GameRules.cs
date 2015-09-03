using UnityEngine;
using System.Collections;


public class GameRules : MonoBehaviour {

    public Player Player1, Player2;

    public int MaxScore;

    int Score1 = 0, Score2 = 0;

    void Start()
    {
        Player1.Dead += AddScorePlayer2;
        Player2.Dead += AddScorePlayer1;
    } //?+

    void Update()
    {
        if (Score1 >= MaxScore) Win(Player1);
        else if (Score2 >= MaxScore) Win(Player2);
    } //?+

    void AddScorePlayer1()
    {
        Score1++;
    } //+

    void AddScorePlayer2()
    {
        Score2++;
    } //+

    void Win(Player player)
    {
        Debug.Log("Game Over");
    } //-
}
