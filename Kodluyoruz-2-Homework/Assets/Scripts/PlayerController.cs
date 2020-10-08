using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    private Rigidbody rb;
    [SerializeField] private GameObject healthBarGO;
    [SerializeField] private GameObject scoreGO;

    private HealthBarController healthBarController;
    private ScoreBarController score;
    [SerializeField] private PlayerModel playerModel;

    
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        healthBarController = healthBarGO.GetComponent<HealthBarController>();
        score = scoreGO.GetComponent<ScoreBarController>();

        //playerModel = new PlayerModel(100);
    }

    
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        rb.velocity = movement * playerSpeed;

    }

    public void ChangeHitPoint(int damege)
    {
        playerModel.ChangeHitPoint(damege);
        if (playerModel.GetHitPoint() == 0)
        {
            //Die();
        }
        HealthVisualator();
    }

    private void HealthVisualator()
    {
        healthBarController.UpdateSliderValue(playerModel.GetHitPoint());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lemon")
        {
            healthBarController.UpdateSliderValue(10);
            Debug.Log("lemon");
            score.ChangeScore(1);

        }
        else if (other.gameObject.tag == "cherries")
        {
            score.ChangeScore(1);
            Debug.Log("cherry");
            
        }
        else
        {
            healthBarController.increaseHealth(10);
            //playerModel.ChangeHitPoint(10);
        }
    }
}
