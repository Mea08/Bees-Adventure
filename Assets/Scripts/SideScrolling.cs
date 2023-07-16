using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
   private Transform player;

   private void Awake()
   {
        player = GameObject.FindWithTag("Player").transform;
   }

   private void LateUpdate()
   {
        Vector3 camerPosition = transform.positon;
        cameraPosition.x = player.position.x;
        transform.position = cameraPosition;
   }
}
