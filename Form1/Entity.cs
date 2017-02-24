using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assessment4
{
    //NEEDS WORK
    public class Entity : IDamageable, IDamager
    {
        [XmlIgnore]
        public FSM<EntityState> ESM
        {
            get { return this.eStateMachine; }
            set { this.eStateMachine = value; }
        }

        private string name;
        private float health;
        private int maxHealth;
        private float attack;
        private float speed;
        private bool dead;
        private FSM<EntityState> eStateMachine;
        
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

        //ENTITY CONSTRUCTOR
        public Entity(string e_Name, float e_Health, float e_Attack, float e_Speed)
        {
            this.name = e_Name;
            this.health = e_Health;
            this.maxHealth = (int)health;
            this.attack = e_Attack;
            this.speed = e_Speed;
            this.dead = false;

            //INITLIZE OBJECT 'ENTITY' FSM
            this.eStateMachine = new FSM<EntityState>(EntityState.DEAD);

            //POPULATE STATE'S DICTIONARY WITH BOXED COMBAT FUNCTIONS
            this.eStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.INIT, (StateManager)InitOnEnter);
            this.eStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.INIT, (StateManager)InitOnExit);

            this.eStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.IDLE, (StateManager)IdleOnEnter);
            this.eStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.IDLE, (StateManager)IdleOnExit);

            this.eStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.ATTACK, (StateManager)AttackOnEnter);
            this.eStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.ATTACK, (StateManager)AttackOnExit);
            
            this.eStateMachine.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEAD, (StateManager)DeadOnEnter);
            this.eStateMachine.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEAD, (StateManager)DeadOnExit);

            //CREATE TRANSITION LIST FOR 'ENTITY'
            this.eStateMachine.AddTransition(EntityState.INIT, EntityState.IDLE);
            this.eStateMachine.AddTransition(EntityState.IDLE, EntityState.ATTACK);
            this.eStateMachine.AddTransition(EntityState.IDLE, EntityState.DEAD);
            this.eStateMachine.AddTransition(EntityState.ATTACK, EntityState.IDLE);            

            //START THE STATE MANAGER
            this.eStateMachine.StartMachine(EntityState.INIT);

            //UPDATE THE CURRENT STATE
            this.UpdateEntityState();
        }
        public Entity() { }
        public void UpdateEntityState()
        {
            State tmp = this.eStateMachine.getCurrentState();
            this.currentState = (EntityState)tmp.StateName;
        }
        public void DealDamage(IDamageable damageable)
        {
            damageable.TakeDamage(this.attack);
        }
        public void TakeDamage(float damageDelt)
        {
            this.health -= damageDelt;
        }        

        //ENTITY 'INITONENTER()'
        //  - WHEN ENTITYSTATE.INIT ENTERS, CHANGE THE ESTATEMACHINE.CURRENTSTATE TO ENTITYSTATE.IDLE
        public void InitOnEnter()
        {
            this.eStateMachine.ChangeState(EntityState.IDLE);
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
