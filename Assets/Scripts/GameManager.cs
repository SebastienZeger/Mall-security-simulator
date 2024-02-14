using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timerDuration = 120f; 
    [SerializeField] GameObject guard; 
    private float timer;

    void Start()
    {
        timer = timerDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0f || IsGuardInteracted() || IsObjectiveCompleted())
        {
            ResetLevel();
        }
    }

    bool IsGuardInteracted()
    {
        // Vérifie si le joueur a interagi avec le gardien
        // Vous devez implémenter cette logique selon votre jeu
        return false; // Changez cette condition en fonction de votre logique d'interaction
    }

    bool IsObjectiveCompleted()
    {
        if (StoresQuest.countStore == 5 || RatTrapQuest.countRatTrap == 2 || ToiletteQuest.countToilette == 1)
        {
             
        }
        return true;
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}