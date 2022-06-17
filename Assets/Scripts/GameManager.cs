using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Simple game manager can reset the game if pressing R, or can add a new ball when the game starts
/// </summary>
public  class GameManager : MonoBehaviour
{
    // game state
    private bool m_isActive = false;
    private bool m_isFalling = false;

    // ball params
    [SerializeField] Transform m_ballTransform;
    [SerializeField] Rigidbody m_ballRigidbody;
    [SerializeField] Vector3 m_ballStartingPoint;
    [SerializeField] float m_ballMouseSpeed;

    // scorekeeping
    [HideInInspector] public static int m_currentScore;
    private int m_internalScore;
    [SerializeField] private TextMeshProUGUI m_scoreUIText;

    private void Awake()
    {
        m_ballTransform.transform.position = m_ballStartingPoint;
        m_ballTransform.rotation = Quaternion.identity;
        
    }

    private void Update()
    {
        // restart game is key R is pressed
        if (Input.GetKey(KeyCode.R))
        {
            StartGame();
        }


        if (!m_isFalling)
        {
            // obtain the mouse position and the pixel coordinate of the middle of the screen
            var mouseXPos = Input.mousePosition.x;
            float midScreen = Screen.width / 2;

            // move ball to either side depending on mouse pos
            if (mouseXPos <= midScreen && m_ballTransform.position.x < 5.42 ) m_ballTransform.transform.Translate(Vector3.right * m_ballMouseSpeed * Time.deltaTime);

            if (mouseXPos > midScreen && m_ballTransform.position.x > -5.26) m_ballTransform.transform.Translate(Vector3.left * m_ballMouseSpeed * Time.deltaTime);
        }

        // start ball falling is mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            m_isFalling = true;
            m_ballRigidbody.isKinematic = false;
        }
    }


    private void StartGame()
    {
        // reset score and scoreboard
        m_currentScore  = 0;
        m_scoreUIText.text = m_currentScore.ToString();

        // move ball at the center top
        m_ballTransform.transform.position = m_ballStartingPoint;
        m_ballTransform.rotation = Quaternion.identity;

        //remove gravity effect on ball
        m_ballRigidbody.isKinematic = true;

        // make ball be attracted by mouse position
        m_isFalling = false;
    }


    public void UpdateScore(int points)
    {
        // sum more points to score
        m_currentScore += points;

        // Update TMPro text component
        m_scoreUIText.text = m_currentScore.ToString();

    }


}
