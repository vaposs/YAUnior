using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    private bool stayCollider = false;
    private bool exitCollider = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (AudioSource.isPlaying == false)
            {
                AudioSource.Play();
                AudioSource.volume = 0.01f;

                Debug.Log("включили воспроизведение звука - " + AudioSource.volume);
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stayCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            exitCollider = true;
            stayCollider = false;
        }
    }

    private void Update()
    {
        if(stayCollider == true)
        {
            AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, 1, 0.1f * Time.deltaTime);

            Debug.Log("стоим в границах тригера/громкость верх - " + AudioSource.volume);
        }

        if(exitCollider == true)
        {
            AudioSource.volume = Mathf.MoveTowards(AudioSource.volume, 1, (0.1f * Time.deltaTime) * -1);

            Debug.Log("вышли за границы тригера/громкость вниз - " + AudioSource.volume);
        }

        if(AudioSource.volume == 0)
        {
            AudioSource.Stop();
            stayCollider = false;
            exitCollider = false;

            Debug.Log("выключили звук");
        }

    }
}