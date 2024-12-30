using Concretes.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class ChapterController : MonoBehaviour
    {
        [SerializeField] GameObject teleportPoint;
        ChapterCompleteObject ChapterCompleteObject;

        private void Start()
        {
            ChapterCompleteObject = FindAnyObjectByType<ChapterCompleteObject>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.position = teleportPoint.transform.position;
                ChapterCompleteObject.SetChapterPanelActive(true);
            }
        }
    }
}
