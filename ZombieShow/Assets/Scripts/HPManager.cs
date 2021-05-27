using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    //Player's HealthPoints
    public int hp;

    public RectTransform bar;
    private int maxHp;
    private float maxScale;
    public Animator playerAnimator;

    private GameObject[] enemyList;

    //Flag that stops player from loosing more HP after dieing
    private bool mayLooseHP;




    // Start is called before the first frame update
    public void Start()
    {
        mayLooseHP = true;
        maxHp = hp;
        maxScale = 1f;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void LooseHP(int i)
    {
        hp = hp - i;
        if (hp < 1 && mayLooseHP)
        {
            mayLooseHP = false;
            float scale = maxScale * hp / maxHp;
            bar.localScale = new Vector3(scale, bar.localScale.y, bar.localScale.z);

            playerAnimator.SetBool("receivesDamage", true);

            //Unables Spawnmanager to Spawn new enemies
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().canSpawn = false;

            FreezeEnemies();


            StartCoroutine("CallGameOverAfterTimeout");

        }

        //Manages the scale of the Health Points' Bar
        else if(hp>=1)
        {
            float scale = maxScale * hp / maxHp;
            bar.localScale = new Vector3(scale, bar.localScale.y, bar.localScale.z);
        }
    }


    private void FreezeEnemies()
    {
        //Gets the list of enemies
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        //Freezes every enemies' CharacterController & animators 
        foreach( GameObject enemy in enemyList)
        {
            CharacterController cc = enemy.GetComponent<CharacterController>();
            cc.enabled = false;

            Animator anim = enemy.GetComponent<Animator>();
            anim.enabled = false;
        }
    }

    private IEnumerator CallGameOverAfterTimeout()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("GameOver");
    }
}