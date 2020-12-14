using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{

    public ParticleSystem p;
    public ParticleSystem p2;
    public AudioSource a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayParts()
    {
        p.Play();
        p2.Play();
        CameraShakeInstance c = new CameraShakeInstance(0.5f, 20, 0f, 0.5f);
        c.PositionInfluence = Vector3.one * 1f;
        c.RotationInfluence = new Vector3(4, 1, 1);
        CameraShaker.Instance.Shake(c);
    }

    public void Gitch()
    {
        FindObjectOfType<GlitchEffectCinematic>().Jump();
        a.Play();
        CameraShakeInstance c = new CameraShakeInstance(0.5f, 20, 0f, 0.5f);
        c.PositionInfluence = Vector3.one * 1f;
        c.RotationInfluence = new Vector3(4, 1, 1);
        CameraShaker.Instance.Shake(c);
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public void Leave()
    {
        SceneManager.LoadScene(0);
    }
}
