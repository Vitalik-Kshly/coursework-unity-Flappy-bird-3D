using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody birdRg;
    private float punchVel = 9;
    private float gravity = -11f;
    private Object _column;
    public GameObject canvas;
    static public bool isDied;
    private Animator _playerAnimator;
    private int Score = 0;
    void Start()
    {
        _playerAnimator = this.GetComponent<Animator>();
        birdRg = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        birdLogic();
        if(isDied){
            // canvas.SetActive(true);
            Time.timeScale = 0;
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            _playerAnimator.SetBool("isDead", false);
        }else   
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = Score.ToString();



    }
    public void birdLogic(){
        if(!isDied)
        if(Input.GetMouseButtonDown(0))
        {   
            SoundManager.PlaySound(SoundManager.Sound.Jump);
            birdRg.velocity = new Vector3(0, 0, 0);
            birdRg.AddForce(new Vector3(0, punchVel, 0) , ForceMode.Impulse);
            
        }
        if(birdRg.velocity.y < 0)
            birdRg.transform.rotation = new Quaternion(0, 180, 10, 0);
        else if(birdRg.velocity.y > 0)
            birdRg.transform.rotation = new Quaternion(0, 180, -10, 0);
        else
            birdRg.transform.rotation = new Quaternion(0, 180, 0, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Column"){
            SoundManager.PlaySound(SoundManager.Sound.Die);
            isDied = !isDied;
        }else
        if(other.tag == "Coin"){
            SoundManager.PlaySound(SoundManager.Sound.CoinColl);
            Score++;
            Destroy(other.gameObject);
        }
    }
}
