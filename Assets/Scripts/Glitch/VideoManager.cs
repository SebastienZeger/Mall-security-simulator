using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;

    private GameManager _gameManager;
    private PlayerMovement _playerMovement;
    private PlayerCam _playerCam;

    public bool _videoPlaying = false;

    void Start()
    {
        
        videoPlayer = GetComponent<VideoPlayer>();
        _gameManager = FindObjectOfType<GameManager>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCam = FindObjectOfType<PlayerCam>();
        
        videoPlayer.loopPointReached += EndReached;
    }

    public void PlayRandomVideo()
    {
        _videoPlaying = true;
        int randomIndex = Random.Range(0, videoClips.Length);
        videoPlayer.clip = videoClips[randomIndex]; 
        videoPlayer.Play();
    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        _videoPlaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameManager._videoScreen.SetActive(false);
        _playerCam.enabled = true;
        _playerMovement.enabled = true;
    }
}