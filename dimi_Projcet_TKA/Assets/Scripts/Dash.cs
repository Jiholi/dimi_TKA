using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dash : MonoBehaviour
{
    public float lenth = 2f;
    public GameObject closestEnemy = null;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousePos,lenth);
            float closestDistance = Mathf.Infinity;
            foreach (Collider2D collider in hitColliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    float distance = Vector3.Distance(mousePos, collider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = collider.gameObject;
                    }
                }
            }
            if (closestEnemy != null && Physics2D.Raycast(transform.position, closestEnemy.transform.position, Mathf.Infinity, 7))
            {
                print("Dash");
                StartCoroutine(dash());
            }
        }
    }
    IEnumerator dash()
    {
        Vector2 dir = closestEnemy.transform.position - transform.position.normalized*2;
        float timer = 0;
        float dashTime = 0.1f;
        while (timer < dashTime)
        {
            timer += Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.01f);
            transform.position = Vector3.Lerp(transform.position, dir, timer / dashTime);
        }
    }
}
