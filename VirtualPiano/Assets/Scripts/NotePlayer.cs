using UnityEngine;
using System.Collections;

public class NotePlayer : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;
    public string note;
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);

        Debug.Log("LOADED NOTE PLAYER");

        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if(this.transform.position.y < 1.3f){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.01f, this.transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("on collision enter with " + note + " magnitude " + collision.relativeVelocity.magnitude );

        if ((collision.relativeVelocity.magnitude > 0.7)) {
                    // Debug.Log("note: "+note);
            Debug.Log(collision.gameObject.transform.parent.name + " " + note + " " + collision.relativeVelocity.magnitude);
            // audioSource.Play();
            audioSource.PlayOneShot(audioClip, 1.0f);
            this.transform.position = new Vector3(this.transform.position.x, 1.2f, this.transform.position.z);
  

        }

    }
}
