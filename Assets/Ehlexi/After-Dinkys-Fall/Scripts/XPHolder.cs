using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class XPHolder : MonoBehaviour 
{ public float swordsXP = 0f;
public float axesXP = 0f; 
    public float fistsXP = 0f; 
    public float foragingXP = 0f; 
    public float fishingXP = 0f; 
    public float agilityXP = 0f; 
    public float vigorXP = 0f; 
    public float staminaXP = 0f; 
    public float processingXP = 0f; 
    public float pickupDistance = 3f;
   
    private void OnDrawGizmosSelected() 
    { Gizmos.color = Color.green; Gizmos.DrawWireSphere(transform.position, pickupDistance); }
    private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { PlayerLevelTracker playerXP = collision.GetComponent<PlayerLevelTracker>(); if (playerXP != null) { playerXP.AddXP(swordsXP, axesXP, fistsXP, foragingXP, fishingXP, agilityXP, vigorXP, staminaXP, processingXP);
                Destroy(gameObject); } } } }
