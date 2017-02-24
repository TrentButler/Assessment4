using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Assessment4
{
    public class Combat
    {
        [XmlIgnore]
        public FSM<CombatState> CSM
        {
            get { return this.combatFSM; }
            set { this.combatFSM = value; }
        }
        [XmlIgnore]
        public List<IDamageable> CombatQue;
        [XmlIgnore]
        private IDamageable tmp;

        private FSM<CombatState> combatFSM;
        private List<Player> playerList;
        private List<Entity> entityList;
        private int entityChoice;
        private int entityIndex;
        private int combatIndex;
        private int playerIndex;
        private string eAllDeadKey;
        private string pAllDeadKey;
        private string eAllDeadLock;
        private string pAllDeadLock;

        public CombatState CurrentState;
        public List<Player> PlayerList
        {
            get { return this.playerList; }
            set { this.playerList = value; }
        }
        public List<Entity> EntityList
        {
            get { return this.entityList; }
            set { this.entityList = value; }
        }
        public int EntityIndex
        {
            get { return this.entityIndex; }
            set { this.combatIndex = value; }
        }
        public int CombatIndex
        {
            get { return this.combatIndex; }
            set { this.combatIndex = value; }
        }
        public int PlayerIndex
        {
            get { return this.playerIndex; }
            set { this.playerIndex = value; }
        }
        public int GameLevel
        {
            get;
            set;
        }

        public Combat(List<Player> pList, List<Entity> eList)
        {
            //INITLIZE FSM
            this.combatFSM = new FSM<CombatState>(CombatState.EXIT);
            this.GameLevel = 1;
            this.playerList = pList;
            this.entityList = eList;
            this.combatIndex = 0;
            this.entityIndex = 0;
            this.playerIndex = 0;


            //POPULATE 'FSM<>' STATES DICTIONARY WITH BOXED 'COMBATENTER' AND 'COMBATEXIT' FUNCTION(S)
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.INIT, (StateManager)InitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.INIT, (StateManager)InitOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.PTURN, (StateManager)PturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.PTURN, (StateManager)PturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.ETURN, (StateManager)EturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.ETURN, (StateManager)EturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.END, (StateManager)EndOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.END, (StateManager)EndOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.EXIT, (StateManager)ExitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.EXIT, (StateManager)ExitOnExit);

            //DEFINE FSM TRANSITIONS
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.END, CombatState.EXIT);

            //START THE FSM<>
            this.combatFSM.StartMachine(CombatState.INIT);
            this.updateCombat();
        }
        public Combat()
        {

        }
        //'RUNCOMBAT()' FUNCTION
        //  - INVOKES VARIOUS FUNCTIONS BASED ON THE CASE OF THE CURRENT STATE OF 'COMBATFSM'
        public void RunCombat(Player p1, Entity selectedEntity)
        {
            switch (this.CurrentState)
            {

                case CombatState.INIT:
                    {
                        this.updateCombat();
                        //this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
                        break;
                    }

                case CombatState.PTURN:
                    {
                        switch (this.playerList[this.playerIndex].currentState)
                        {
                            case EntityState.INIT:
                                {
                                    this.playerList[this.playerIndex].PSM.ChangeState(EntityState.IDLE);
                                    break;
                                }

                            case EntityState.IDLE:
                                {
                                    break;
                                }

                            case EntityState.ATTACK:
                                {
                                    this.playerList[this.playerIndex].DealDamage(selectedEntity);
                                    this.playerList[this.playerIndex].PSM.ChangeState(EntityState.IDLE);
                                    this.playerList[this.playerIndex].UpdatePlayerState();
                                    this.endPturn();
                                    this.updateCombat();
                                    break;
                                }

                            case EntityState.DEFEND:
                                {
                                    //NEEDS WORK
                                    this.endPturn();
                                    this.updateCombat();
                                    break;
                                }

                            case EntityState.CHARGE:
                                {
                                    //NEEDS WORK
                                    this.endPturn();
                                    this.updateCombat();
                                    break;
                                }

                            case EntityState.DEAD:
                                {
                                    this.playerList[this.playerIndex].Dead = true;
                                    break;
                                }
                        }
                        //INCREMENT 'COMBATINDEX'  AND INVOKE 'UPDATECOMBAT()' AFTER PLAYER TURN 
                        //CHANGE THE COMBAT STATE TO 'COMBATSTATE.ETURN' AFTER PLAYER TURN  

                        break;
                    }

                case CombatState.ETURN:
                    {
                        if (this.entityList[this.entityIndex].Dead == false)
                        {
                            switch (this.entityList[this.entityIndex].currentState)
                            {
                                case EntityState.INIT:
                                    {
                                        this.entityList[this.entityIndex].ESM.ChangeState(EntityState.IDLE);
                                        break;
                                    }

                                case EntityState.IDLE:
                                    {
                                        break;
                                    }

                                case EntityState.ATTACK:
                                    {
                                        this.entityList[this.entityIndex].DealDamage(this.entitySelectPlayer());
                                        this.entityList[this.entityIndex].ESM.ChangeState(EntityState.IDLE);
                                        this.entityList[this.entityIndex].UpdateEntityState();
                                        this.endEturn();
                                        this.updateCombat();
                                        break;
                                    }

                                case EntityState.DEFEND:
                                    {
                                        break;
                                    }

                                case EntityState.CHARGE:
                                    {
                                        break;
                                    }

                                case EntityState.DEAD:
                                    {
                                        Console.WriteLine(this.entityList[this.entityIndex].Name + "DEAD");
                                        break;
                                    }
                            }

                        }
                        //INCREMENT 'COMBATINDEX'  AND INVOKE 'UPDATECOMBAT()' AFTER ENTITY TURN                       
                        break;
                    }

                case CombatState.END:
                    {
                        //GATHER AFTER COMBAT INFO
                        //(DEBUG) RESTART THE COMBAT

                        break;
                    }

                case CombatState.EXIT:
                    {
                        //EXIT FROM COMBAT...
                        break;
                    }
            }

        }

        //'UPDATECOMBAT()' FUNCTION
        //  - UPDATES THE CURRENTSTATE OF 'COMBATFSM'
        //  - CHECKS WHAT 'IDAMAGEABLE' OBJECT IS IN LIST 'COMBATQUE' USING MEMBER VARIABLE 'COMBATINDEX'
        //  - NEEDS WORK
        private void updateCombat()
        {
            if (this.CurrentState != CombatState.END && this.CurrentState != CombatState.EXIT)
            {
                //NEEDS WORK
                //ALIVE CHECKS
                for (int i = 0; i < this.entityList.Count; i++)
                {
                    if (this.entityList[i].Health <= 0)
                    {
                        this.entityList[i].Health = 0;
                        this.entityList[i].ESM.ChangeState(EntityState.DEAD);
                        this.entityList[i].UpdateEntityState();
                        this.sortCombat();
                    }
                }
                //PLAYER(S) DEATH
                //  - NEEDS WORK
                for (int i = 0; i < this.playerList.Count; i++)
                {
                    if (this.playerList[i].Health <= 0)
                    {
                        this.playerList[i].Health = 0;
                        this.playerList[i].PSM.ChangeState(EntityState.DEAD);
                        this.playerList[i].UpdatePlayerState();
                        this.sortCombat();
                    }
                }

                //ALL DEAD CHECKS
                //  - NEEDS WORK
                //  - CLEAN THIS
                this.checkEDead();
                this.areEDead();
                this.checkPDead();
                this.arePDead();
                if (this.eAllDeadKey == this.eAllDeadLock || this.pAllDeadKey == this.pAllDeadLock)
                {
                    this.combatFSM.ChangeState(CombatState.END);
                }

                //LEVEL UP CHECKS
                this.playerList.ForEach(x =>
                {
                    if (x.Exp == x.NeededExp)
                    {
                        x.LevelUp();
                    }

                    if (x.Health > x.MaxHealth)
                    {
                        x.Health = x.MaxHealth;
                    }
                });


                //IF 'COMBATINDEX' == THE COUNT OF OBJECTS IN LIST 'COMBATQUE',
                //  - 'COMBATINDEX' IS ASSIGNED 0 (FIRST INDEX OF LIST)
                if (this.combatIndex == this.CombatQue.Count)
                {
                    this.combatIndex = 0;
                }
                //IF 'ENTITYINDEX' == THE COUNT OF OBJECTS IN LIST 'ENTITYLIST',
                //  - 'ENTITYINDEX' IS ASSIGNED 0 (FIRST INDEX OF LIST)
                if (this.entityIndex == this.entityList.Count)
                {
                    this.entityIndex = 0;
                }
                if (this.playerIndex == this.playerList.Count)
                {
                    this.playerIndex = 0;
                }

                //CHECK THE POSITION OF 'COMBATQUE' TO DETERMINE THE COMBAT TURN
                //  - IF THE OBJECT AT THE INDEX OF 'COMBATINDEX' == 'PLAYERONE'
                //  - CHANGE THE CURRENT STATE TO COMBATSTATE.PTURN
                if (this.CombatQue[this.combatIndex].GetType() == typeof(Player))
                {
                    this.combatFSM.ChangeState(CombatState.PTURN);
                }
                //  - IF THE OBJECT AT THE INDEX OF 'COMBATINDEX' == A ENTITY
                //  - CHANGE THE CURRENT STATE TO COMBATSTATE.ETURN
                if (this.CombatQue[this.combatIndex].GetType() == typeof(Entity))
                {
                    this.combatFSM.ChangeState(CombatState.ETURN);
                }

            }
            //UPDATE 'CURRENTSTATE'
            State tmp = this.combatFSM.getCurrentState();
            this.CurrentState = (CombatState)tmp.StateName;
        }
        private void sortCombat()
        {
            this.CombatQue = new List<IDamageable>();
            this.combatIndex = 0;

            this.entityList.ForEach((x) =>
            {
                if (x.Dead == false)
                {
                    this.CombatQue.Add(x);
                }
            });
            this.playerList.ForEach((x) =>
            {
                if (x.Dead == false)
                {
                    this.CombatQue.Add(x);
                }
            });

            this.CombatQue.Sort((x, y) => -1 * x.EntitySpeed.CompareTo(y.EntitySpeed));
            this.entityList.Sort((x, y) => -1 * x.EntitySpeed.CompareTo(y.EntitySpeed));
            this.playerList.Sort((x, y) => -1 * x.EntitySpeed.CompareTo(y.EntitySpeed));
        }

        //'NEWGAME()' FUNCTION
        //  - NEEDS WORK
        public void NewGame(List<Player> pList, List<Entity> eList)
        {
            this.combatFSM = new FSM<CombatState>(CombatState.EXIT);
            this.playerList = pList;
            this.entityList = eList;
            this.GameLevel = 1;
            this.combatIndex = 0;
            this.entityIndex = 0;
            this.playerIndex = 0;


            //POPULATE 'FSM<>' STATES DICTIONARY WITH BOXED 'COMBATENTER' AND 'COMBATEXIT' FUNCTION(S)
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.INIT, (StateManager)InitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.INIT, (StateManager)InitOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.PTURN, (StateManager)PturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.PTURN, (StateManager)PturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.ETURN, (StateManager)EturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.ETURN, (StateManager)EturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.END, (StateManager)EndOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.END, (StateManager)EndOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.EXIT, (StateManager)ExitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.EXIT, (StateManager)ExitOnExit);

            //DEFINE FSM TRANSITIONS
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.END, CombatState.EXIT);

            //START THE FSM<>
            this.combatFSM.StartMachine(CombatState.INIT);
            this.updateCombat();
        }
        public List<Player> InitilizePlayer(int howMany)
        {
            if (howMany > 4)
            {
                howMany = 4;
            }
            if (howMany < 1)
            {
                howMany = 1;
            }

            Singleton.Instance.RNG = new Random();
            int randExp = Singleton.Instance.RNG.Next(1, 25);
            List<Player> tmpList = new List<Player>();
            for (int i = 0; i < howMany; i++)
            {
                tmpList.Add(new Player("PLAYER " + (i + 1).ToString(), 100, 12, 10));
                tmpList[i].ExpCurve = randExp;
                tmpList[i].NeededExp = 100;
            }
            return tmpList;
        }
        public List<Entity> InitilizeEntity(int howMany)
        {
            if (howMany > 4)
            {
                howMany = 4;
            }
            if (howMany < 1)
            {
                howMany = 1;
            }
            List<Entity> tmpList = new List<Entity>();
            for (int i = 0; i < howMany; i++)
            {
                tmpList.Add(new Entity("ENTITY " + (i + 1).ToString(), 100, 6, 100));
            }
            return tmpList;
        }

        public void NextRound(int levelNum)
        {
            switch (levelNum)
            {
                case 0:
                    {
                        break;
                    }

                case 1:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND1");
                        this.NextLevel(this.playerList, this.InitilizeEntity(1));
                        this.sortCombat();
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND2");
                        this.NextLevel(this.playerList, this.InitilizeEntity(2));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        this.playerList.Add(new Player("ROUND2", 100, 25, 22));
                        this.playerList[this.playerList.Count - 1].ExpCurve = randExp;
                        this.playerList[this.playerList.Count - 1].NeededExp = 100;
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i;
                        }
                        this.sortCombat();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND3");
                        this.NextLevel(this.playerList, this.InitilizeEntity(3));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        this.playerList.Add(new Player("ROUND3", 100, 25, 23));
                        this.playerList[this.playerList.Count - 1].ExpCurve = randExp;
                        this.playerList[this.playerList.Count - 1].NeededExp = 100;
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i;
                        }
                        this.sortCombat();
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND4");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        this.playerList.Add(new Player("ROUND4", 100, 25, 24));
                        this.playerList[this.playerList.Count - 1].ExpCurve = randExp;
                        this.playerList[this.playerList.Count - 1].NeededExp = 100;
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + 1;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + 1;
                        }
                        this.sortCombat();
                        break;
                    }

                case 5:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND5");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + randExp;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + randExp;
                        }
                        this.sortCombat();
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND6");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + randExp;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + randExp;
                        }
                        this.sortCombat();
                        break;
                    }

                case 7:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND7");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + randExp;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + randExp;
                        }
                        this.sortCombat();
                        break;
                    }

                case 8:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND8");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + randExp;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + randExp;
                        }
                        this.sortCombat();
                        break;
                    }

                case 9:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND9");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + randExp;
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + randExp;
                        }
                        this.sortCombat();
                        break;
                    }

                case 10:
                    {
                        Console.WriteLine(this.ToString() + "ENTER ROUND10");
                        this.NextLevel(this.playerList, this.InitilizeEntity(4));
                        Singleton.Instance.RNG = new Random();
                        int randExp = Singleton.Instance.RNG.Next(1, 25);
                        this.playerList.ForEach(x =>
                        {
                            x.Health += 50;
                        });
                        for (int i = 0; i < this.entityList.Count; i++)
                        {
                            entityList[i].Attack = entityList[i].Attack + i + (randExp + randExp);
                            entityList[i].EntitySpeed = entityList[i].EntitySpeed + i + (randExp + randExp);
                            entityList[i].Health = entityList[i].Health * randExp;
                        }
                        this.sortCombat();
                        break;
                    }

            }
        }
        public void NextLevel(List<Player> pList, List<Entity> eList)
        {
            this.combatFSM = new FSM<CombatState>(CombatState.EXIT);
            this.playerList = pList;
            this.entityList = eList;
            this.combatIndex = 0;
            this.entityIndex = 0;
            this.playerIndex = 0;


            //POPULATE 'FSM<>' STATES DICTIONARY WITH BOXED 'COMBATENTER' AND 'COMBATEXIT' FUNCTION(S)
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.INIT, (StateManager)InitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.INIT, (StateManager)InitOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.PTURN, (StateManager)PturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.PTURN, (StateManager)PturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.ETURN, (StateManager)EturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.ETURN, (StateManager)EturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.END, (StateManager)EndOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.END, (StateManager)EndOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.EXIT, (StateManager)ExitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.EXIT, (StateManager)ExitOnExit);

            //DEFINE FSM TRANSITIONS
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.END, CombatState.EXIT);

            //START THE FSM<>
            this.combatFSM.StartMachine(CombatState.INIT);
            this.updateCombat();
        }

        public void LoadGame(Combat loadGame)
        {
            this.combatFSM = new FSM<CombatState>(CombatState.EXIT);
            this.playerList = loadGame.playerList;
            this.entityList = loadGame.entityList;
            this.LoadPlayer();
            this.LoadEntity();
            this.GameLevel = loadGame.GameLevel;
            this.combatIndex = loadGame.combatIndex;
            this.entityIndex = loadGame.entityIndex;
            this.playerIndex = loadGame.playerIndex;

            //POPULATE 'FSM<>' STATES DICTIONARY WITH BOXED 'COMBATENTER' AND 'COMBATEXIT' FUNCTION(S)
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.INIT, (StateManager)InitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.INIT, (StateManager)InitOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.PTURN, (StateManager)PturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.PTURN, (StateManager)PturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.ETURN, (StateManager)EturnOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.ETURN, (StateManager)EturnOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.END, (StateManager)EndOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.END, (StateManager)EndOnExit);
            this.combatFSM.AddStateFunction(DelegateEnum.ONENTER, CombatState.EXIT, (StateManager)ExitOnEnter);
            this.combatFSM.AddStateFunction(DelegateEnum.ONEXIT, CombatState.EXIT, (StateManager)ExitOnExit);

            //DEFINE FSM TRANSITIONS
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.INIT, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.ETURN);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.PTURN);
            this.combatFSM.AddTransition(CombatState.PTURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.ETURN, CombatState.END);
            this.combatFSM.AddTransition(CombatState.END, CombatState.EXIT);

            //START THE FSM<>
            this.sortCombat();
            this.combatFSM.StartMachine(loadGame.CurrentState);
            this.updateCombat();
        }
        public void LoadPlayer()
        {
            this.playerList.ForEach(x =>
            {
                //INITLIZE OBJECT 'ENTITY' FSM
                x.PSM = new FSM<EntityState>(EntityState.DEAD);

                StateManager pInitEnter = x.InitOnEnter;
                StateManager pInitExit = x.InitOnExit;
                StateManager pIdleEnter = x.IdleOnEnter;
                StateManager pIdleExit = x.IdleOnExit;
                StateManager pAttackEnter = x.AttackOnEnter;
                StateManager pAttackExit = x.AttackOnExit;
                StateManager pDefendEnter = x.DefendOnEnter;
                StateManager pDefendExit = x.DefendOnExit;
                StateManager pChargeEnter = x.ChargeOnEnter;
                StateManager pChargeExit = x.ChargeOnExit;
                StateManager pDeadEnter = x.DeadOnEnter;
                StateManager pDeadExit = x.DeadOnExit;

                //POPULATE STATE'S DICTIONARY WITH BOXED COMBAT FUNCTIONS
                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.INIT, pInitEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.INIT, pInitExit);

                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.IDLE, pIdleEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.IDLE, pIdleExit);

                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.ATTACK, pAttackEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.ATTACK, pAttackExit);

                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEFEND, pDefendEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEFEND, pDefendExit);

                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.CHARGE, pChargeEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.CHARGE, pChargeExit);

                x.PSM.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEAD, pDeadEnter);
                x.PSM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEAD, pDeadExit);

                //CREATE TRANSITION LIST FOR 'ENTITY'
                x.PSM.AddTransition(EntityState.INIT, EntityState.IDLE);
                x.PSM.AddTransition(EntityState.IDLE, EntityState.ATTACK);
                x.PSM.AddTransition(EntityState.IDLE, EntityState.DEFEND);
                x.PSM.AddTransition(EntityState.IDLE, EntityState.CHARGE);
                x.PSM.AddTransition(EntityState.IDLE, EntityState.DEAD);

                x.PSM.AddTransition(EntityState.ATTACK, EntityState.IDLE);
                x.PSM.AddTransition(EntityState.DEFEND, EntityState.IDLE);
                x.PSM.AddTransition(EntityState.CHARGE, EntityState.IDLE);

                //START THE STATE MANAGER
                x.PSM.StartMachine(x.currentState);

                //UPDATE THE CURRENT STATE
                x.UpdatePlayerState();
            });
        }
        public void LoadEntity()
        {
            this.entityList.ForEach(x =>
            {

                //INITLIZE OBJECT 'ENTITY' FSM
                x.ESM = new FSM<EntityState>(EntityState.DEAD);

                StateManager eInitEnter = x.InitOnEnter;
                StateManager eInitExit = x.InitOnExit;
                StateManager eIdleEnter = x.IdleOnEnter;
                StateManager eIdleExit = x.IdleOnExit;
                StateManager eAttackEnter = x.AttackOnEnter;
                StateManager eAttackExit = x.AttackOnExit;
                StateManager eDeadEnter = x.DeadOnEnter;
                StateManager eDeadExit = x.DeadOnExit;

                //POPULATE STATE'S DICTIONARY WITH BOXED COMBAT FUNCTIONS
                x.ESM.AddStateFunction(DelegateEnum.ONENTER, EntityState.INIT, eInitEnter);
                x.ESM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.INIT, eInitExit);

                x.ESM.AddStateFunction(DelegateEnum.ONENTER, EntityState.IDLE, eIdleEnter);
                x.ESM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.IDLE, eIdleExit);

                x.ESM.AddStateFunction(DelegateEnum.ONENTER, EntityState.ATTACK, eAttackEnter);
                x.ESM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.ATTACK, eAttackExit);

                x.ESM.AddStateFunction(DelegateEnum.ONENTER, EntityState.DEAD, eDeadEnter);
                x.ESM.AddStateFunction(DelegateEnum.ONEXIT, EntityState.DEAD, eDeadExit);

                //CREATE TRANSITION LIST FOR 'ENTITY'
                x.ESM.AddTransition(EntityState.INIT, EntityState.IDLE);
                x.ESM.AddTransition(EntityState.IDLE, EntityState.ATTACK);
                x.ESM.AddTransition(EntityState.IDLE, EntityState.DEFEND);
                x.ESM.AddTransition(EntityState.IDLE, EntityState.CHARGE);
                x.ESM.AddTransition(EntityState.IDLE, EntityState.DEAD);

                x.ESM.AddTransition(EntityState.ATTACK, EntityState.IDLE);
                x.ESM.AddTransition(EntityState.DEFEND, EntityState.IDLE);
                x.ESM.AddTransition(EntityState.CHARGE, EntityState.IDLE);

                //START THE STATE MANAGER
                x.ESM.StartMachine(x.currentState);

                //UPDATE THE CURRENT STATE
                x.UpdateEntityState();
            });
        }

        private void checkEDead()
        {
            List<char> tmp = new List<char>();
            for (int i = 0; i < this.entityList.Count; i++)
            {
                tmp.Add('1');
            }
            string key = new string(tmp.ToArray());
            this.eAllDeadKey = key;
        }
        private void checkPDead()
        {
            List<char> tmp = new List<char>();
            for (int i = 0; i < this.entityList.Count; i++)
            {
                tmp.Add('1');
            }
            string key = new string(tmp.ToArray());
            this.pAllDeadKey = key;
        }
        private void areEDead()
        {
            List<char> tmp = new List<char>();
            for (int i = 0; i < this.entityList.Count; i++)
            {
                tmp.Add('0');
            }

            if (this.entityList != null)
            {
                if (this.entityList[0].Dead == true)
                {
                    tmp[0] = '1';
                }

                if (this.entityList.Count > 1)
                {
                    if (this.entityList[1].Dead == true)
                    {
                        tmp[1] = '1';
                    }
                }
                if (this.entityList.Count > 2)
                {
                    if (this.entityList[2].Dead == true)
                    {
                        tmp[2] = '1';
                    }
                }

                if (this.entityList.Count > 3)
                {
                    if (this.entityList[3].Dead == true)
                    {
                        tmp[3] = '1';
                    }
                }
            }
            string key = new string(tmp.ToArray());
            this.eAllDeadLock = key;
        }
        private void arePDead()
        {
            List<char> tmp = new List<char>();
            for (int i = 0; i < this.playerList.Count; i++)
            {
                tmp.Add('0');
            }

            if (this.playerList != null)
            {
                if (this.playerList[0].Dead == true)
                {
                    tmp[0] = '1';
                }

                if (this.playerList.Count > 1)
                {
                    if (this.playerList[1].Dead == true)
                    {
                        tmp[1] = '1';
                    }
                }
                if (this.playerList.Count > 2)
                {
                    if (this.playerList[2].Dead == true)
                    {
                        tmp[2] = '1';
                    }
                }
                if (this.playerList.Count > 3)
                {
                    if (this.playerList[3].Dead == true)
                    {
                        tmp[3] = '1';
                    }
                }
            }
            string key = new string(tmp.ToArray());
            this.pAllDeadLock = key;
        }

        //'ENDPTURN()' FUNCTION
        //  - ENDS THE PLAYER'S TURN
        private void endPturn()
        {
            this.playerList[this.playerIndex].PSM.ChangeState(EntityState.IDLE);
            this.playerList[this.playerIndex].UpdatePlayerState();
            this.playerIndex++;
            this.combatIndex++;
            this.updateCombat();
            this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
        }
        //'ENDETURN()' FUNCTION
        //  - ENDS THE ENTITY'S TURN
        public void endEturn()
        {
            this.entityList[this.entityIndex].ESM.ChangeState(EntityState.IDLE);
            this.entityList[this.entityIndex].UpdateEntityState();
            this.entityIndex++;
            this.combatIndex++;
            this.updateCombat();
            this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
        }

        //'ENTITYSELECTPLAYER()' FUNCTION
        //  - NEEDS WORK
        private IDamageable entitySelectPlayer()
        {
            Singleton.Instance.RNG = new Random();
            int randChoice = Singleton.Instance.RNG.Next(1, this.playerList.Count);
            this.entityChoice = randChoice;
            switch (this.entityChoice)
            {
                case 1:
                    {
                        this.tmp = this.playerList[0];
                        break;
                    }

                case 2:
                    {
                        this.tmp = this.playerList[1];
                        break;
                    }

                case 3:
                    {
                        this.tmp = this.playerList[2];
                        break;
                    }

                case 4:
                    {
                        this.tmp = this.playerList[3];
                        break;
                    }
            }
            return this.tmp;
        }
        public void EActionChoice()
        {
            if (this.entityList[this.entityIndex].Dead == false && this.CurrentState == CombatState.ETURN)
            {
                this.entityList[this.entityIndex].ESM.ChangeState(EntityState.ATTACK);
                this.entityList[this.entityIndex].UpdateEntityState();
                this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
            }
            if (this.entityList[this.entityIndex].Dead == true)
            {
                this.endEturn();
            }
        }

        //BOXED FUNCTIONS
        //  - USED FOR 'COMBAT'
        public void InitOnEnter()
        {
            //INITILIZE ASSETS
            Console.WriteLine(this.ToString() + "ENTER INIT");

            this.sortCombat();
            this.updateCombat();
            this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
        }
        public void InitOnExit()
        {
            //UPDATE 'UI'
            Console.WriteLine(this.ToString() + "EXIT INIT");
        }
        public void PturnOnEnter()
        {
            //GET PLAYER CHOICE
            Console.WriteLine(this.ToString() + "ENTER PTURN");
            this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
        }
        public void PturnOnExit()
        {
            //UPDATE GAME WITH PLAYER CHOICE
            Console.WriteLine(this.ToString() + "EXIT PTURN");
            //this.combatFSM.ChangeState(new State(CombatState.ETURN));
        }
        public void EturnOnEnter()
        {
            //CURRENT ENTITY MAKES CHOICE
            Console.WriteLine(this.ToString() + "ENTER ETURN");
        }
        public void EturnOnExit()
        {
            //UPDATE GAME WITH CURRENT ENTITY CHOICE
            Console.WriteLine(this.ToString() + "EXIT ETURN");
        }
        public void EndOnEnter()
        {
            //AFTER COMBAT IS FINISHED, GATHER INFO FOR GAME
            Console.WriteLine(this.ToString() + "ENTER END");
            if (this.pAllDeadKey != this.pAllDeadLock)
            {
                this.playerList.ForEach(x => { x.AddExp(this.entityList.Count); });
            }
            if (this.pAllDeadKey == this.pAllDeadLock)
            {
                Application.Exit();
            }
        }
        public void EndOnExit()
        {
            //END GAME WITH GAME INFO
            Console.WriteLine(this.ToString() + "EXIT END");
        }
        //NEEDS WORK
        public void ExitOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER EXIT");
            this.GameLevel++;
            this.NextRound(this.GameLevel);
            this.updateCombat();
            this.RunCombat(this.playerList[this.playerIndex], this.entityList[this.entityIndex]);
        }
        public void ExitOnExit()
        {
            //END COMBAT LOOP
            Console.WriteLine(this.ToString() + "EXIT EXIT");

        }
    }
}