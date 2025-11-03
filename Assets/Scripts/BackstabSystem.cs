using UnityEngine;

public class BackstabSystem : MonoBehaviour
{
    [Header("References")]
    public Camera cam;              
    public LayerMask enemyMask;     
    public UIManager ui;            

    [Header("Settings")]
    public float range = 2f;        
    public float backAngle = 60f;   
    public Color hitColor = Color.red;
    public Color missColor = Color.white;

    public void TryAttack()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyMask))
        {
            Transform enemy = hit.collider.transform;
            if (IsBehind(enemy))
            {
                ui.ShowToast("Backstab Successful");
                SetEnemyColor(enemy, hitColor);
            }
            else
            {
                ui.ShowToast("Attack Failed");
                SetEnemyColor(enemy, missColor);
            }
        }
        else
        {
            ui.ShowToast("Attack Failed");
        }
    }

    bool IsBehind(Transform enemy)
    {
        Vector3 enemyForward = enemy.forward;
        Vector3 directionToPlayer = (transform.position - enemy.position).normalized;

        float dot = Vector3.Dot(enemyForward, directionToPlayer);

        float threshold = -Mathf.Cos(backAngle * Mathf.Deg2Rad);

        float dist = Vector3.Distance(transform.position, enemy.position);

        bool isBehind = dot < threshold;
        bool isClose = dist <= range;

        return isBehind && isClose;
    }

    void SetEnemyColor(Transform enemy, Color color)
    {
        Renderer r = enemy.GetComponent<Renderer>();
        if (r) r.material.color = color;

        foreach (Renderer child in enemy.GetComponentsInChildren<Renderer>())
            child.material.color = color;
    }
}
