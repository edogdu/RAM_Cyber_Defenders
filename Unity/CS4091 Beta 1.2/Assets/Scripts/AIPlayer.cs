using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    //[SerializeField] private GameObject cardPostion;
    private Animator animator;
    [SerializeField] private GameObject botHand;
    [SerializeField] private GameObject deckManagerGameObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CardsInformation cardInfo;
    private GameObject[] blueSockets; // Store references to blue sockets
    private GameObject[] greenSockets; // Store references to green sockets
    private GameObject[] redSockets; // Store references to green sockets
    [SerializeField] private GameObject wastedDeck;
    public MessageWasted messageWasted;
    //public float speed = 1.0f;
    bool pickUp = false;
    //private Vector3 targetPosition2;
    string cardString = "Your dialogue text here";
    //dialogue  text box from ai
    [SerializeField] public Dialogue dialogueScript;

    // needed for card moving animation
    private GameObject moving;
    private GameObject destination;
    private float speed = 0.03f;
    private bool animationTrigger = false;
	
	private int socketNumber = 0;
	//private int cardColor = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        deckManager = FindObjectOfType<DeckManager>();
        blueSockets = GameObject.FindGameObjectsWithTag("BlueSocketPlayer2");
        greenSockets = GameObject.FindGameObjectsWithTag("GreenSocketPlayer2");
        redSockets = GameObject.FindGameObjectsWithTag("RedSocketPlayer2");
        Debug.Log("Number of blue sockets found: " + blueSockets.Length);
        //targetPosition2 = cardPostion2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AIPlayer Update called");
        deckManagerGameObject = deckManager.GetTopCard;
        cardInfo = deckManagerGameObject.GetComponent<CardsInformation>();
        //StartCoroutine(WaitToPlay());
        botHand = GameObject.FindWithTag("botHand");

        // card moving animation(to AI)
        /*
        if (pickUp == true)
        {

            botHand.transform.position = deckManagerGameObject.transform.position;
            pickUp = false;
            animationTrigger = true;
        }*/

        // card moving animation(from AI)
        if (animationTrigger == true)
        {
            if (moving.transform.position != destination.transform.position)
            {
                moving.transform.position = Vector3.MoveTowards(moving.transform.position, destination.transform.position, speed);
            }
            else
            {
                animationTrigger = false;
            }
        }
    }

// [ Trying to use this to set up the Socket parameter in the animator, but I'm having trouble getting it to work right ]
    GameObject FindFirstAvailableBlueSocket()
    {
		animator.SetInteger("Color", 1);
		
		
        foreach (GameObject socket in blueSockets)
        {

			
            XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
            if (socketHandler != null && !socketHandler.IsOccupied())
            {
				// This gets me a number, but it doesn't seem to be working how I want it to... 
				socketNumber = Array.IndexOf(blueSockets, socket);
				
				animator.SetInteger("Socket", socketNumber);
				
                return socket;
            }
        }
		
		animator.SetInteger("Socket", 0);
		
        return null; // No available blue socket found
    }

    GameObject FindFirstAvailableGreenSocket(CardsInformation cardInfo)
    {
		animator.SetInteger("Color", 2);

        greenSockets = GameObject.FindGameObjectsWithTag("GreenSocketPlayer2");
        Debug.Log("Number of green sockets found: " + greenSockets.Length);
        foreach (GameObject socket in greenSockets)
        {
            GreenSocketCardHandler socketHandler = socket.GetComponent<GreenSocketCardHandler>();
            if (socketHandler != null && !socketHandler.IsOccupied() && cardInfo.GetSymbol() == socketHandler.GetCardType())
            {
                return socket;
            }
        }
		
		animator.SetInteger("Socket", 0);
		
        return null; // No available green socket found
    }

    GameObject FindFirstAvailableRedSocket(CardsInformation cardInfo)
    {
		animator.SetInteger("Color", 3);

        redSockets = GameObject.FindGameObjectsWithTag("RedSocketPlayer2");
        Debug.Log("Number of red sockets found: " + redSockets.Length);
        foreach (GameObject socket in redSockets)
        {
            RedSocketPlayer2 socketHandler = socket.GetComponent<RedSocketPlayer2>();
            if (socketHandler != null && (cardInfo.GetSymbol() == socketHandler.GetCardType() || cardInfo.GetSymbol() == 5))
            {
                return socket;
            }
        }
		
		animator.SetInteger("Socket", 0);
		
        return null; // No available red socket found
    }
    
    // function for card moving animation; check Update() function to see further process
    void setForCardMoving(GameObject movingObject, GameObject arrival)
    {
        moving = movingObject;    // what is moving
        destination = arrival;    // where to go
        animationTrigger = true;  // check the Update() function
    }

    void MoveCardToWasteDeck(GameObject card)
    {
        if (wastedDeck != null && card != null)
        {
            setForCardMoving(card, wastedDeck);
            //card.transform.position = wastedDeck.transform.position;
        }
    }

    public void aiTurn()
    {
        StartCoroutine(WaitToPlay());
    }
    public IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(1);
     
		if (cardInfo.GetPlayer() == 2)
        {
            Rigidbody rb = deckManagerGameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // Disable gravity

                //rb.isKinematic = true;
            }
            //dialogueScript.Speech(cardString);
            // Move the deckManagerGameObject towards targetPosition using Translate
            //deckManagerGameObject.transform.position = targetPosition2;
            // Move the deckManagerGameObject towards targetPosition2 using Translate

            // pickUp = true;
            //yield return new WaitForSeconds(1);
            animator.SetTrigger("PickUp");
            yield return new WaitForSeconds(1);
            // pickUp = false;
            Debug.Log("Player 2's turn");
            //this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");

            if (cardInfo.GetColor() == 1)
            {

                GameObject firstAvailableSocket = FindFirstAvailableBlueSocket();
                //got a blue card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {
                    if(cardInfo.GetSymbol() == 1)
                    {
                        cardString = "This is a cell phone card. It is an Asset Card. We use cell phones every day, and they connected the internet!";
                    }
                    else if (cardInfo.GetSymbol() == 2)
                    {
                        cardString = "This is a computer card. It is an Asset Card. We use computers to do homework and play games. I should protect it from viruses!";
                    }
                    else if (cardInfo.GetSymbol() == 3)
                    {
                        cardString = "This is a gaming console card. It is an Asset Card. I love to play video games! I need to protect my games!";
                    }
                    else if (cardInfo.GetSymbol() == 4)
                    {
                        cardString = "This is a private information card. It is an Asset Card. Private information like your password and credit card details are important to keep safe!";
                    }

                    dialogueScript.Speech(cardString);

                    setForCardMoving(deckManagerGameObject, firstAvailableSocket);
                    // deckManagerGameObject.transform.position = firstAvailableSocket.transform.position;
                }
                else
                {
                    cardString = "This is an Assets Card; however, I don't have room to place it. Unfortunate.";
                    dialogueScript.Speech(cardString);
                    MoveCardToWasteDeck(deckManagerGameObject);
                }

            }
            else if (cardInfo.GetColor() == 2)
            {
                GameObject firstAvailableSocket = FindFirstAvailableGreenSocket(cardInfo);
                //got a green card
                if (firstAvailableSocket != null)
                {
                    if (cardInfo.GetSymbol() == 1)
                    {
                        cardString = "This is an Encryption card. It is a Defense Card. It locks my information on my phone using a password so hackers can't find me.";
                    }
                    else if (cardInfo.GetSymbol() == 2)
                    {
                        cardString = "This is a Fire-Wall card. It is a Defense Card. A firewall protects the computer from viruses and attacks.";
                    }
                    else if (cardInfo.GetSymbol() == 3)
                    {
                        cardString = "This is an Anti-malware card. It is a Defense Card. With an Anti-malware defense card, I can protect my gaming console from malware.";
                    }
                    else if (cardInfo.GetSymbol() == 4)
                    {
                        cardString = "This is an Education card. It is a Defense Card. Learning about cybersecurity can help us better recognize attacks.";
                    }

                    dialogueScript.Speech(cardString);

                    setForCardMoving(deckManagerGameObject, firstAvailableSocket);
                    // deckManagerGameObject.transform.position = firstAvailableSocket.transform.position;
                }
                else
                {
                    cardString = "I got a defense card, however, there is no card to protect. Unfortunate.";
                    dialogueScript.Speech(cardString);
                    MoveCardToWasteDeck(deckManagerGameObject);
                }
            }
            else if (cardInfo.GetColor() == 3)
            {
                GameObject firstAvailableSocket = FindFirstAvailableRedSocket(cardInfo);
                //got a red card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {
                    if (cardInfo.GetSymbol() == 1)
                    {
                        cardString = "This is a Wireless Attack card. It is an Attack Card. Attackers can attack your phone through the internet. Don't connect to suspicious networks.";
                    }
                    else if (cardInfo.GetSymbol() == 2)
                    {
                        cardString = "This is a hacker card. It is an Attack Card. A hacker is someone who tries to attack your computer and steal your information. They are criminals";
                    }
                    else if (cardInfo.GetSymbol() == 3)
                    {
                        cardString = "This is a Malware card. It is an Attack Card. Malware is designed to cause damage to your console and steal your game files.";
                    }
                    else if (cardInfo.GetSymbol() == 4)
                    {
                        cardString = "This is a Phishing card. It is an Attack Card. Some emails are send by an imposter. Don't click on links in emails unless you know who sent it!";
                    }
                    else if (cardInfo.GetSymbol() == 5)
                    {
                        cardString = "This is a Cyber Attack card. It is an Attack Card. I can destroy any card with a cyber attack card. Cyber attacks are dangerous.";
                    }

                    dialogueScript.Speech(cardString);

                    setForCardMoving(deckManagerGameObject, firstAvailableSocket);
                    // deckManagerGameObject.transform.position = firstAvailableSocket.transform.position;
                }
                else
                {
                    cardString = "I got a attack card, however, there is no card to attack. HAHA.";
                    dialogueScript.Speech(cardString);
                    MoveCardToWasteDeck(deckManagerGameObject);
                }
            }
            else
            {
                cardString = "I don't know what card this is. ???";
                dialogueScript.Speech(cardString);
                MoveCardToWasteDeck(deckManagerGameObject);
            }
        }

    }

	public void GameEnd()
	{
		int i = gameManager.WhoWon();
		
		animator.SetInteger("Game End", i);
	}

}

