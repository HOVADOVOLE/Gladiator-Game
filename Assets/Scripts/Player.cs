using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Player : Figure
    {
        float xp;

        [SerializeField] Player player;
        [SerializeField] Enemy enemy;

        [SerializeField] PolygonCollider2D colider;
        [SerializeField] PolygonCollider2D enCol;

        Animator playerAnimator;
        Animator enemyAnimator;

        [SerializeField] Canvas deathScreen;
        [SerializeField] PlayerScriptableObject playerScriptableObject;

        public static bool movement { get; private set; } = true;

        protected override void Awake()
        {
            LoadData();
            Show(lvl, (acualHp / hp));

            movement = true;

            playerAnimator = GetComponent<Animator>();
            enemyAnimator = enemy.GetComponent<Animator>();

            colider = GetComponent<PolygonCollider2D>();

            enCol = enemy.GetComponent<PolygonCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Attack();
        }

        void Attack()
        {
            //Player attacked
            if (colider.enabled == true)
            {
                enemy.acualHp -= player.Dmg - enemy.Defense;
                IsEnemyAlive();
            }
            //Enemy attacked
            else if (enCol.enabled == true)
            {
                player.acualHp -= enemy.Dmg - player.Defense;
                IsPlayerAlive();
            }
        }
        void IsPlayerAlive()
        {
            if (player.acualHp < 1)
            {
                playerAnimator.SetTrigger("Death");
                movement = false;
                deathScreen.gameObject.SetActive(true);
            }
        }
        void IsEnemyAlive()
        {
            if(enemy.acualHp < 1)
            {
                enemyAnimator.SetTrigger("Death");
                movement = false;

                playerScriptableObject.money += (int)((lvl * 20) / (lvl * 0.5f));
                LelevLogic();
                SaveData();
            }
        }
        void SaveData()
        {
            playerScriptableObject.hp = Hp;
            playerScriptableObject.acualHp = acualHp;

            playerScriptableObject.xp = xp;

            playerScriptableObject.defense = Defense;
            playerScriptableObject.dmg = Dmg;
            
            playerScriptableObject.lvl = Lvl;
        }
        void LoadData()
        {
            hp = playerScriptableObject.hp;
            acualHp = playerScriptableObject.acualHp;

            xp = playerScriptableObject.xp;
            
            dmg = playerScriptableObject.dmg;
            defense = playerScriptableObject.defense;
            
            lvl = playerScriptableObject.lvl;
        }

        void LelevLogic()
        {
            xp += Random.Range((lvl * (dmg + hp + defense) * 0.1f), (lvl * (dmg + hp + defense)));
            if(xp >= playerScriptableObject.xpToNxtLvl)
            {
                xp -= playerScriptableObject.xpToNxtLvl;
                playerScriptableObject.xpToNxtLvl = lvl * (dmg + hp + defense) * 0.5f;
                lvl++;

                playerScriptableObject.availablePoints += 5;
                playerScriptableObject.levlUp = true;
            }
        }
    }
}
