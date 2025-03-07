using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int scorePoint = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerController>() != null)
            {
                GameManager.Instance.IncreaseScore(scorePoint);
                AudioManager.Instance.Play("Coin");
                Destroy(this.gameObject);
            }
        }
    }
}
