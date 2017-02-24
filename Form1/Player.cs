using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assessment4
{
    //NEEDS WORK
    public class Player : IDamageable, IDamager, ILeveler
    {
        [XmlIgnore]
        public FSM<EntityState> PSM
        {
            get { return this.pStateMachine; }
            set { this.pStateMachine = value; }
        }

        private string name;
        private float health;
        private int maxHealth;
        private float attack;
        private float speed;
        private bool dead;
        private int level;
        private int exp;
        private int expLeftover;
        private int currentExp;
        private int neededExp;
        private int expCurve;
        private FSM<EntityState> pStateMachine;
        public EntityState currentState;

        public bool Dead
        {
            get { return this.dead; }
            set { this.dead = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public float Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public int MaxHealth
        {
            get { return this.maxHealth; }
            set { this.maxHealth = value; }
        }
        public float Attack
        {
            get { return this.attack; }
            set { this.attack = value; }
        }
        public float EntitySpeed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public int ExpCurve
        {
            get { return this.expCurve; }
            set { this.expCurve = value; }
        }
        public int Exp
        {
            get { return this.exp; }
            set { this.exp = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int NeededExp
        {
            get { return this.neededExp; }
            set { this.neededExp = value; }
        }

        public Player(string e_Name, float e_Health, float e_Attack, float e_Speed)
        {
            this.name = e_Name;
            this.health = e_Health;
            this.maxHealth = (int)health;
            this.attack = e_Attack;
            this.speed = e_Speed;
            this.dead = false;
            this.exp = 0;
            this.level = 1;
            this.expCurve = 0;

            //INITILIZE PLAYER FSM
            this.pStateMachine = new FSM<EntityState>(EntityState.DEAD);
            
            //POPULATE STATE'S DICTIONARY WITH BOXED COMBAT FUNCTIONS
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.INIT, (StateManager)InitOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.INIT, (StateManager)InitOnExit);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.IDLE, (StateManager)IdleOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.IDLE, (StateManager)IdleOnExit);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.ATTACK, (StateManager)AttackOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.ATTACK, (StateManager)AttackOnExit);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEFEND, (StateManager)DefendOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEFEND, (StateManager)DefendOnExit);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.CHARGE, (StateManager)ChargeOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.CHARGE, (StateManager)ChargeOnExit);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEAD, (StateManager)DeadOnEnter);
            this.pStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEAD, (StateManager)DeadOnExit);

            //CREATE TRANSITION LIST FOR 'ENTITY'
            this.pStateMachine.AddTransition(EntityState.INIT, EntityState.IDLE);
            this.pStateMachine.AddTransition(EntityState.IDLE, EntityState.ATTACK);
            this.pStateMachine.AddTransition(EntityState.IDLE, EntityState.DEFEND);
            this.pStateMachine.AddTransition(EntityState.IDLE, EntityState.CHARGE);
            this.pStateMachine.AddTransition(EntityState.IDLE, EntityState.DEAD);

            this.pStateMachine.AddTransition(EntityState.ATTACK, EntityState.IDLE);
            this.pStateMachine.AddTransition(EntityState.DEFEND, EntityState.IDLE);
            this.pStateMachine.AddTransition(EntityState.CHARGE, EntityState.IDLE);

            //START THE STATE MANAGER
            this.pStateMachine.StartMachine(EntityState.INIT);

            //UPDATE THE PLAYER'S CURRENT STATE
            this.UpdatePlayerState();
        }
        public Player() { }

        public void UpdatePlayerState()
        {
            State tmp = this.pStateMachine.getCurrentState();
            this.currentState = (EntityState)tmp.StateName;
        }
        public void DealDamage(IDamageable damageable)
        {
            //'DAMAGEABLE' MEMEBER FUNCTION 'TAKEDAMAGE()'
            //  - PASS IN PLAYER'S ATTACK VALUE AS THE FUNCTION ARGUMENT
            damageable.TakeDamage(this.attack);
        }
        public void TakeDamage(float damageDelt)
        {
            //DECREMENT PLAYER HEALTH BY 'DAMAGEDELT'
            this.health -= damageDelt;
        }
        public void LevelUp()
        {
            //ASSIGN EXPLEFTOVER THE REMAINDER OF NEEDEDEXP
            this.expLeftover = this.neededExp - this.currentExp;

            //INCREMENT PLAYER LEVEL
            this.level++;

            //ASSIGN NEEDEDEXP (NEEDEDEXP + (LEFTOVEREXP * EXPCURVE))
            this.neededExp = this.neededExp + (this.expLeftover * this.expCurve);
        }
        public void AddExp(int howMuch)
        {
            Singleton.Instance.RNG = new Random();
            int gainExp = Singleton.Instance.RNG.Next(0, 20);

            if(this.level == 10)
            {
                gainExp = Singleton.Instance.RNG.Next(10, 200);
            }

            this.exp += (gainExp + howMuch);
        }


        //PLAYER 'INITONENTER()'
        //  - WHEN ENTITYSTATE.INIT ENTERS, CHANGE THE PSTATEMACHINE.CURRENTSTATE TO ENTITYSTATE.IDLE
        public void InitOnEnter()
        {
            this.pStateMachine.ChangeState(EntityState.IDLE);
        }
        public void InitOnExit()
        {

        }
        public void IdleOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER IDLE");
        }
        public void IdleOnExit()
        {

        }
        public void AttackOnEnter()
        {

        }
        public void AttackOnExit()
        {

        }
        public void DefendOnEnter()
        {

        }
        public void DefendOnExit()
        {

        }
        public void ChargeOnEnter()
        {

        }
        public void ChargeOnExit()
        {

        }
        public void DeadOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER DEAD");
            this.dead = true;
        }
        public void DeadOnExit()
        {

        }
    }
}
