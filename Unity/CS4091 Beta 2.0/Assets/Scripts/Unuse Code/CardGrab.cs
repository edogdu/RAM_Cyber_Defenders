/*
 * using UnityEngine;

public class CardGrab_outofDate: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            DeckManager deckManager = FindObjectOfType<DeckManager>();

            if (deckManager != null)
            {
                GameObject drawnCard = deckManager.DrawCard();

                if (drawnCard != null)
                {
                    GameObject cardInstance = Instantiate(drawnCard, transform.position + Vector3.up, Quaternion.identity);
                }
            }
        }
    }
}
*/