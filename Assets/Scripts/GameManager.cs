using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

   public int world{ get; private set; }
   public int stage{ get; private set; }
   public int lives{ get; private set; }
   public int stars{ get; private set; }

   private void Awake()
   {
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
   }

   private void OnDestroy()
   {
        if(Instance == this){
            Instance = null;
        }
   }

   private void Start()
   {
        NewGame();
   }

   private void NewGame()
   {
        lives = 3;
        stars = 0;

        LoadLevel(1, 1);
   }

   public void LoadLevel(int world, int stage)
   {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
   }

   public void ResetLevel(float delay)
   {
        Invoke(nameof(ResetLevel), delay);
   }
   
   public void ResetLevel()
   {
        lives--;

        if(lives > 0){
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

   private void GameOver()
   {
        NewGame();
   }

   public void AddStars()
   {
        stars++;

        if(stars == 100)
        {
            AddLife();
            stars = 0;
        }

   }

   public void AddLife()
   {
        lives++;
   }

}