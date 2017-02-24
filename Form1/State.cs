using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    public class State
    {
        //CLASS 'STATE' MEMBER VARIABLE(S)
        private string name;

        public string Name
        {
            get { return name; }
        }

        public Enum StateName;

        //DEFAULT CONSTRUCTOR
        //  - NEEDS WORK
        public State() { }

        //STATE CONSTRUCTOR
        //  - ASSIGNS THE PASSED IN ENUM 'E' TYPEDCASED AS A STRING
        //      - 'e.ToString()'
        //  - TO THE STATE MEMBER VARIABLE 'NAME'
        public State(Enum e)
        {
            this.name = e.ToString();
            this.StateName = e;
        }

        //ONENTER() DELEGATE
        //  - AFTER TRANSITION, INVOKE ALL FUNCTIONS INSIDE OF DELEGATE 'ONENTER' 
        //  - WHEN ENTERING ANOTHER STATE        
        public StateManager onEnter = null;

        //ONEXIT() DELEGATE
        //  - AFTER TRANSITION, INVOKE ALL FUNCTIONS INSIDE OF DELEGATE 'ONEXIT' 
        //  - WHEN LEAVING ANOTHER STATE        
        public StateManager onExit = null;

        //FUNCTION 'ADDENTERFUNCTION()'
        //  - ADDS A FUNCTION OF SAME TYPE AND ARGUMENT LIST TO DELEGATE 'ONENTER'
        public void AddEnterFunction(Delegate del)
        {
            //TYPECAST DELEGATE 'DEL' WITH THE DELEGATE TYPE 'STATEMANAGER'
            //  - ADD TYPECAST DELEGATE 'DEL' TO MEMBER DELEGATE ONENTER
            //  - LEARN MORE..
            //  - 01-27-17 LEARN HOW TO SPELL..
            //var cb = del as StateManager;            
            this.onEnter += del as StateManager;
        }

        //FUNCTION 'ADDEXITFUNCTION()'
        //  - ADDS A FUNCTION OF SAME TYPE AND ARGUMENT LIST TO DELEGATE 'ONEXIT'
        public void AddExitFunction(Delegate del)
        {
            //TYPECAST DELEGATE 'DEL' WITH DELEGATE TYPE 'STATEMANAGER'
            //  - ADD TYPECAST DELEGATE 'DEL' TO MEMEBER DELEGATE ONEXIT
            this.onExit += del as StateManager;
        }
    }

    //'STATEMANAGER()' DELEGATE
    //INITILIZES AN DELEGATE INSTANCE FOR WRAPPING FUNCTIONS
    public delegate void StateManager();

    public enum DelegateEnum
    {
        ONENTER = 0,
        ONEXIT = 1,
    }
    public enum EntityState
    {
        INIT = 0,
        IDLE = 1,
        ATTACK = 2,
        DEFEND = 3,
        CHARGE = 4,
        DEAD = 5,
        //SAVE = 7000,
        //LOAD = 8000,
    }
    public enum CombatState
    {
        INIT = 0,
        PTURN = 1,
        ETURN = 2,
        END = 3,
        EXIT = 9000,
    }
    enum GameState
    {
        INIT = 0,
        IDLE = 1,
        NEWGAME = 2,
        RUN = 3,
        SAVE = 4,
        LOAD = 5,
        EXIT = 9000
    }
}
