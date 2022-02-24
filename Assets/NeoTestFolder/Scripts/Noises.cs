using UnityEngine.Audio;
using UnityEngine;

public class Noises : MonoBehaviour
{
    private float dist;
    private float AggroRange = 20;
    [SerializeField] private GameObject Enemy;
    private bool hasPlayed = false;
    private void Update()
    {
        dist = Vector3.Distance(Enemy.transform.position, transform.position);
        if (dist <= AggroRange && hasPlayed == false)
        {
            HeartBeat();
        }
    }
    private void HeartBeat()
    {
        Debug.Log("Player in Range");
        FindObjectOfType<AudioManager>().PlaySound("EnemyHeartBeat");
        hasPlayed = true;
    }
}
