using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    
    public class FSM<T>
    {
        //INSTANCE OF CLASS 'STATE'
        //  - HOLDS THE CURRENT 'STATE' OF THE APPLICATION
        private State currentState;        
        //INSTANCE OF CLASS 'DICTIONARY' NAMED 'STATES'
        //KEY = STRING
        //VALUE = STATE
        private Dictionary<string, State> states;
        //INSTANCE OF CLASS 'DICTIONARY' NAMED 'TRANSITIONS'
        //  - KEY = STRING
        //  - VALUE = LIST<STATE>
        private Dictionary<string, List<State>> transitions;
        //INSTANCE OF CLASS 'STATE'
        //  - USED FOR FUNCTION 'RESTARTMACHINE()'
        //  - HOLDS THE STATE THE MACHINE WAS FIRST STARTED TO
        private T restartState;
        private T stopState;

        public State CurrentState
        {
            get { return this.currentState; }
            set { }
        }
        public Dictionary<string, State> States
        {
            get { return this.states; }
            set { }
        }
        public Dictionary<string, List<State>> Transitions
        {
            get { return this.transitions; }
            set { }
        }       

        

        //DEFAULT CONSTRUCTOR
        //  - CONVERTS ENUM INTO A LIST OF STATES
        public FSM(T StopState)
        {
            //INITILIZE MEMBER VARIABLES HERE?
            //01-26-17 YES 
            //  - WHEN CLASS 'FSM()' IS CONSTRUCTED DICTIONARY 'STATES' GET POPULATED
            //01-27-17
            //  - INITILIZE DICTIONARY 'TRANSITIONS'
            this.transitions = new Dictionary<string, List<State>>();

            //INITILIZE DICTIONARY 'STATES'
            this.states = new Dictionary<string, State>();

            //ASSIGN VAR 'V' THE LIST OF ENUMS
            //  - USE 'TYPEOF(T)' 
            //      - USED FOR DIFFERENT STATES
            var enumList = Enum.GetValues(typeof(T));

            //ITERATE THROUGH 'ENUMLIST'
            //  - CREATE A NEW STATE, TYPECAST 'FSM_ENUM' WITH TYPE ENUM
            //  - ADD EACH NEW STATE TO DICTIONARY 'STATES'
            //  - WITH THE CORRECT KEY AND VALUE '<STRING, STATE()>'
            foreach (var fsm_enum in enumList)
            {
                State s = new State(fsm_enum as Enum);
                this.states.Add(s.Name, s);
            }
            this.stopState = StopState;
        }

        public FSM() { }

        //ISVALIDTRANSITION() FUNCTION
        //RETURNS TRUE IF STATE 'TO' IS IN THE TRANSITION DICTIONARY
        //IF STATE 'TO' IS NOT IN THE TRANSITION DICTIONARY
        //  - RETURN FALSE
        private bool isValidTransition(T to)
        {
            string stateKey = this.currentState.Name + "->" + to.ToString();
            if (this.transitions.ContainsKey(stateKey))
            {
                return true;
            }
            return false;
        }

        //ADDSTATE() FUNCTION
        //  - CHECKS IF THE STATE BEING ADDED EXISTS IN DICTIONARY 'TRANSITIONS'
        public bool AddState(T state)
        {
            //ACCESS INSTANCE OF DICTIONARY CLASS NAMED 'TRANSITIIONS'
            //  - CHECK IF DICTIONARY 'TRANSITIONS' == NULL
            //  - CHECK IF STATE ALREADY EXISTS
            if (this.states.ContainsKey(state.ToString()) == false)
            {
                //IF STATE DOES NOT EXITS IN DICTIONARY 'TRANSITIONS'
                //  - ADD THE STATE'S NAME AND A NEW LIST OF STATES TO THE DICTIONARY
                this.states.Add(state.ToString(), new State(state as Enum));
                //RETURN TRUE IF SUCCESSFUL
                return true;
            }
            //IF STATE ALREADY EXISTS IN DICTIONARY 'TRANSITIONS'
            //  - RETURN FALSE
            return false;
        }

        //ADDSTATEFUNCTION() FUNCTION
        //  - ADDS A FUNCTION TO A STATE'S 'ONENTER' OR 'ONEXIT' DELEGATE
        //  - NEEDS WORK
        public bool AddStateFunction(DelegateEnum delegateType, T state, Delegate del)
        {
            //STRING 'STATEKEY'
            //  - TYPECAST TEMPLATED VARIABLE 'STATE' AS AN ENUM, INVOKE THE OBJECT METHOD FUNCTION '.TOSTRING()' TO CONVERT ENUM TO STRING
            //  - USED AS THE INDEXER FOR DICTIONARY 'STATES'
            string stateKey = (state as Enum).ToString();

            //IF STRING 'FUNCNAME' == 'ONENTER'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDENTERFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'D' AS THE ARGUMENT FOR 'ADDENTERFUNCTION()'
            //  - RETURN TRUE
            if (delegateType == DelegateEnum.ONENTER)
            {
                this.states[stateKey].AddEnterFunction(del);
                return true;
            }

            //IF STRING 'FUNCNAME' == 'ONEXIT'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDEXITFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'DEL' AS THE ARGUMENT FOR 'ADDEXITFUNCTION()'
            //  - RETURN TRUE
            if (delegateType == DelegateEnum.ONEXIT)
            {
                this.states[stateKey].AddExitFunction(del);
                return true;
            }

            //IF ERROR, RETURN FALSE
            return false;
        }

        //GETCURRENTSTATE() FUNCTION
        //  - RETURNS THE CURRENT STATE 
        public State getCurrentState()
        {
            return this.currentState;
        }

        //CHANGESTATE() FUNCTION
        //  - CHECKS IF STATE 'CURRENTSTATE' -> STATE 'STATETO' IS A VALID TRANSITION
        //  - INVOKES STATE 'CURRENTSTATE'S 'ONEXIT' DELEGATE
        //  - ASSIGNS STATE 'CURRENTSTATE' WITH THE STATE 'STATETO'
        //  - INVOKES STATE 'CURRENTSTATE'S 'ONENTER' DELEGATE
        //  - NEEDS WORK
        public void ChangeState(T stateTo)
        {
            if (this.isValidTransition(stateTo) == true)
            {
                //STRING 'STATEKEY' IS ASSIGNED THE CURRENT STATE + "->" + 'STATETO'
                string stateKey = this.currentState.Name + "->" + stateTo.ToString();
                //CHECK IF STATE 'STATETO' IS A VALID TRANSITION FROM MEMEBER VARIABLE 'CURRENTSTATE'
                //  - INVOKE DICTIONARY 'TRANSITIONS' MEMBER FUNCTION 'CONTAINSKEY'
                //  - 'STATEKEY' IS PASSED IN AS THE ARGUMENT, RETURNS A BOOLEAN VARIABLE (TRUE/FALSE)
                //  - IF TRUE, INVOKE STATE 'CURRENTSTATE'S 'ONEXIT' DELEGATE
                //  - ASSIGN STATE 'STATETO' TO STATE 'CURRENTSTATE'
                //  - INVOKE 'CURRENTSTATE'S 'ONENTER' DELEGATE
                if (this.transitions.ContainsKey(stateKey))
                {
                    this.currentState.onExit.Invoke();
                    this.currentState = this.states[stateTo.ToString()];
                   this.currentState.onEnter.Invoke();
                }
            }
        }

        //ADDTRANSITION() FUNCTION
        //  - CREATES A STRING NAMED 'TRANSITIONKEY'
        //  - ADDS THE TWO STATES TO THE DICTIONARY 'TRANSITIONS'
        public bool AddTransition(T stateFrom, T stateTo)
        {
            if (this.states.ContainsKey(stateFrom.ToString()) == true && this.states.ContainsKey(stateTo.ToString()) == true)
            {
                //STRING 'TRANSITIONKEY'
                //  - TYPECASTS 'STATEFROM' AND 'STATETO' AS AN ENUM, OBJECT METHOD FUNCTION 'TOSTRING()' IS INVOKED
                //  - USE OF STRING '->' FOR CONVENCTION AS DICTACTED BY INSTRUCTOR
                //string transitionKey = (stateFrom as State).name + "->" + (stateTo as State).name;
                string transitionKey = stateFrom.ToString() + "->" + stateTo.ToString();

                //CHECK IF DICTIONARY 'TRANSITIONS' CONTAINS 'TRANSITIONKEY'
                //  - IF FALSE, ADD STRING 'TRANSITIONKEY' AS DICTIONARY 'TRANSITIONS'S KEY
                //      - ADD LIST 'TRANSITION' AS DICTIONARY 'TRANSITIONS'S VALUE
                if (this.transitions.ContainsKey(transitionKey) == false)
                {
                    //LIST<STATE> 'TRANSITION'
                    //  - CREATES A NEW LIST NAMED 'TRANSITION'
                    //  - ADDS 'STATEFROM' AND 'STATETO' TYPECASTED AS AN STATE TO LIST 'TRANSITION'
                    //  -RESEARCH TUPLE
                    List<State> Transition = new List<State>();
                    Transition.Add(this.states[stateFrom.ToString()]);
                    Transition.Add(this.states[stateTo.ToString()]);
                    this.transitions.Add(transitionKey, Transition);
                    return true;
                }
            }
            return false;
        }

        //'STARTMANAGER()' FUNCTION
        //  - STARTS UP THE FINITE STATE MACHINE
        //  - NEEDS WORK
        public void StartMachine(T startState)
        {
            if (this.states.ContainsKey(startState.ToString()))
            {
                //ASSIGN MEMEBER VARIABLE 'CURRENTSTATE' WITH THE STATE FROM MEMEBER DICTIONARY 'STATES'
                this.currentState = this.states[startState.ToString()];
                //INVOKE MEMEBER VARIABLE 'CURRENTSTATE' DELEGATE 'ONENTER'
                this.restartState = startState;
                this.currentState.onEnter.Invoke();
                //UPDATE THE FSM
                //this.UpdateManager();
            }
        }

        //RESTARTMACHINE() FUNCTION
        //  - INVOKES THE MEMBER FUNCTION 'STARTMACHINE()'
        public void RestartMachine()
        {
            this.StartMachine(this.restartState);
        }

        //ENDMACHINE() FUNCTION
        //INVOKES 'STARTMACHINE()' FUNCTION WITH THE PASSED IN STATE 'ENDSTATE'
        public void StopMachine()
        {
            this.StartMachine(this.stopState);
        }
    }
}