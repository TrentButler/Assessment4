using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment4
{    
    //NEEDS WORK
    public partial class Form1 : Form
    {
        //NEEDS WORK
        private FSM<GameState> GameFSM;

        private GameState currentState;

        private Combat combat;

        private Entity selectedEntity;
              
        //WINFORM ENTRY POINT
        //NEEDS WORK
        public Form1()
        {
            InitializeComponent();

            //INTILIZE FORM ASSETS
            this.GameFSM = new FSM<GameState>(GameState.EXIT);

            this.combatBox.Visible = false;
            this.combatBox.Enabled = false;
            this.levelProgressBar.Visible = false;
            this.combat = new Combat();          

            //BOX '' FUNCTIONS WITH 'COMBATMANAGER' DELEGATE
            StateManager InitEnter = InitOnEnter;
            StateManager InitExit = InitOnExit;
            StateManager IdleEnter = IdleOnEnter;
            StateManager IdleExit = IdleOnExit;
            StateManager NewEnter = NewOnEnter;
            StateManager NewExit = NewOnExit;
            StateManager SaveEnter = SaveOnEnter;
            StateManager SaveExit = SaveOnExit;
            StateManager LoadEnter = LoadOnEnter;
            StateManager LoadExit = LoadOnExit;
            StateManager RunEnter = RunOnEnter;
            StateManager RunExit = RunOnExit;
            StateManager ExitEnter = ExitOnEnter;
            StateManager ExitExit = ExitOnExit;

            //POPULATE 'FSM<>' STATES DICTIONARY WITH BOXED 'ONENTER' AND 'ONEXIT' FUNCTION(S)
            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.INIT, InitEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.INIT, InitExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.IDLE, IdleEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.IDLE, IdleExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.NEWGAME, NewEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.NEWGAME, NewExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.SAVE, SaveEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.SAVE, SaveExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.LOAD, LoadEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.LOAD, LoadExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.RUN, RunEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.RUN, RunExit);

            this.GameFSM.AddStateFunction(DelegateEnum.ONENTER, GameState.EXIT, ExitEnter);
            this.GameFSM.AddStateFunction(DelegateEnum.ONEXIT, GameState.EXIT, ExitExit);

            //CREATE GAME TRANSITIONS
            this.GameFSM.AddTransition(GameState.INIT, GameState.IDLE);
            this.GameFSM.AddTransition(GameState.IDLE, GameState.NEWGAME);
            this.GameFSM.AddTransition(GameState.IDLE, GameState.LOAD);
            this.GameFSM.AddTransition(GameState.IDLE, GameState.EXIT);
            this.GameFSM.AddTransition(GameState.NEWGAME, GameState.RUN);
            this.GameFSM.AddTransition(GameState.LOAD, GameState.RUN);
            this.GameFSM.AddTransition(GameState.RUN, GameState.SAVE);
            this.GameFSM.AddTransition(GameState.RUN, GameState.EXIT);
            this.GameFSM.AddTransition(GameState.RUN, GameState.IDLE);
            this.GameFSM.AddTransition(GameState.SAVE, GameState.RUN);

            //NEEDS WORK
            //THIS FUNCTION IS BEING INVOKED MORE THAN ONCE????
            this.GameFSM.StartMachine(GameState.INIT);

            //CONVERT 'STATE' TO GAMESTATE TYPE
            //  - TYPECAST STATE 'TMP' AS GAMESTATE
            Singleton.Instance.SaveCombat = this.combat;
            this.UpdateApp();
        }

        //NEWGAME() FUNCTION
        //  - NEW UP THE COMBAT CONSTRUCTOR

        //'RUNAPP()' FUNCTION
        //NEEDS WORK
        public void RunApp()
        {
            switch (this.currentState)
            {
                case GameState.INIT:
                    {
                        this.GameFSM.ChangeState(GameState.IDLE);
                        this.UpdateApp();
                        this.RunApp();
                        break;
                    }

                case GameState.IDLE:
                    {
                        //MEUN SCREEN
                        break;
                    }

                case GameState.NEWGAME:
                    {
                        //MAKE A NEW GAME FUNCTION
                        //  - NEEDS WORK
                        this.combat.NewGame(this.combat.InitilizePlayer(1), this.combat.InitilizeEntity(1));
                        this.GameFSM.ChangeState(GameState.RUN);
                        this.UpdateApp();
                        break;
                    }

                case GameState.LOAD:
                    {
                        //NEEDS WORK
                        //this.loadGameDialog.OpenFile();
                        this.loadGameDialog.ShowDialog();
                        this.GameFSM.ChangeState(GameState.IDLE);
                        this.UpdateApp();
                        this.RunApp();
                        break;
                    }

                case GameState.SAVE:
                    {
                        this.saveGameDialog.ShowDialog();                        
                        this.GameFSM.ChangeState(GameState.RUN);
                        this.updateCombatUI();
                        this.UpdateApp();
                        this.RunApp();
                        break;
                    }

                case GameState.RUN:
                    {
                        this.combatBox.Enabled = true;
                        this.combatBox.Visible = true;

                        this.menuBox.Enabled = false;
                        this.menuBox.Visible = false;

                        this.updateCombatUI();
                        this.UpdateApp();
                        break;
                    }

                case GameState.EXIT:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        //'UPDATEAPP()' FUNCTION
        //  - NEEDS WORK
        public void UpdateApp()
        {
            //CONVERT 'STATE' TO GAMESTATE TYPE
            //  - TYPECAST STATE 'TMP' AS GAMESTATE
            State tmp = this.GameFSM.getCurrentState();
            this.currentState = (GameState)tmp.StateName;
            Singleton.Instance.SaveCombat = this.combat;
        }

        //'UPDATECOMBATUI()' FUNCTION
        //  - UPDATES THE COMBAT UI
        //  - NEEDS WORK
        private void updateCombatUI()
        {
            //IF 'COMBATBOX.ENABLED' RETURNS TRUE,
            //  - UPDATE THE COMBAT UI
            if (this.combatBox.Enabled == true && this.combat.CurrentState != CombatState.EXIT && this.combat.CurrentState != CombatState.END)
            {
                //UPDATE UI WITH ENTITYLIST INFO
                if (this.combat.EntityList != null)
                {
                    if (this.combat.EntityList[0].Dead == true)

                    {
                        this.entityTextBox1.Enabled = false;
                        this.entityHealthBar1.Enabled = false;
                        this.entityAttack1.Enabled = false;

                        this.entityTextBox1.Visible = false;
                        this.entityHealthBar1.Visible = false;
                        this.entityAttack1.Visible = false;
                    }
                    this.entityTextBox1.Text = this.combat.EntityList[0].Name;
                    this.entityHealthBar1.Maximum = (int)this.combat.EntityList[0].MaxHealth;
                    this.entityHealthBar1.Value = (int)this.combat.EntityList[0].Health;
                    this.entityAttack1.Text = this.combat.EntityList[0].Attack.ToString();

                    if (this.combat.EntityList.Count > 1)
                    {
                        if (this.combat.EntityList[1].Dead == true)
                        {
                            this.entityTextBox2.Enabled = false;
                            this.entityHealthBar2.Enabled = false;
                            this.entityAttack2.Enabled = false;

                            this.entityTextBox2.Visible = false;
                            this.entityHealthBar2.Visible = false;
                            this.entityAttack2.Visible = false;
                        }
                        this.entityTextBox2.Text = this.combat.EntityList[1].Name;
                        this.entityHealthBar2.Maximum = (int)this.combat.EntityList[1].MaxHealth;
                        this.entityHealthBar2.Value = (int)this.combat.EntityList[1].Health;
                        this.entityAttack2.Text = this.combat.EntityList[1].Attack.ToString();
                    }

                    if (this.combat.EntityList.Count > 2)
                    {
                        if (this.combat.EntityList[2].Dead == true)
                        {
                            this.entityTextBox3.Enabled = false;
                            this.entityHealthBar3.Enabled = false;
                            this.entityAttack3.Enabled = false;

                            this.entityTextBox3.Visible = false;
                            this.entityHealthBar3.Visible = false;
                            this.entityAttack3.Visible = false;
                        }
                        this.entityTextBox3.Text = this.combat.EntityList[2].Name;
                        this.entityHealthBar3.Maximum = (int)this.combat.EntityList[2].MaxHealth;
                        this.entityHealthBar3.Value = (int)this.combat.EntityList[2].Health;
                        this.entityAttack3.Text = this.combat.EntityList[2].Attack.ToString();
                    }

                    if (this.combat.EntityList.Count > 3)
                    {
                        if (this.combat.EntityList[3].Dead == true)
                        {
                            this.entityTextBox4.Enabled = false;
                            this.entityHealthBar4.Enabled = false;
                            this.entityAttack4.Enabled = false;

                            this.entityTextBox4.Visible = false;
                            this.entityHealthBar4.Visible = false;
                            this.entityAttack4.Visible = false;
                        }
                        this.entityTextBox4.Text = this.combat.EntityList[3].Name;
                        this.entityHealthBar4.Maximum = (int)this.combat.EntityList[3].MaxHealth;
                        this.entityHealthBar4.Value = (int)this.combat.EntityList[3].Health;
                        this.entityAttack4.Text = this.combat.EntityList[3].Attack.ToString();
                    }

                }

                //UPDATE UI WITH PLAYERLIST INFO
                if (this.combat.PlayerList != null)
                {
                    if (this.combat.PlayerList[0].Dead == true)
                    {
                        this.playerTextBox1.Enabled = false;
                        this.playerHealthBar1.Enabled = false;
                        this.playerAttack1.Enabled = false;

                        this.playerTextBox1.Visible = false;
                        this.playerHealthBar1.Visible = false;
                        this.playerAttack1.Visible = false;
                    }
                    this.playerTextBox1.Text = this.combat.PlayerList[0].Name + "  " + "LEVEL("+ this.combat.PlayerList[0].Level + ")";
                    this.playerHealthBar1.Maximum = (int)this.combat.PlayerList[0].MaxHealth;
                    this.playerHealthBar1.Value = (int)this.combat.PlayerList[0].Health;
                    this.playerAttack1.Text = "ATTACK(" + this.combat.PlayerList[0].Attack.ToString() + ")";
                    this.playerNeededExp1.Text = "NEEDED EXP(" + (this.combat.PlayerList[0].NeededExp - this.combat.PlayerList[0].Exp).ToString() + ")";

                    if (this.combat.PlayerList.Count > 1)
                    {
                        if (this.combat.PlayerList[1].Dead == true)
                        {
                            this.playerTextBox2.Enabled = false;
                            this.playerHealthBar2.Enabled = false;
                            this.playerAttack2.Enabled = false;

                            this.playerTextBox2.Visible = false;
                            this.playerHealthBar2.Visible = false;
                            this.playerAttack2.Visible = false;
                        }
                        this.playerTextBox2.Text = this.combat.PlayerList[1].Name + "  " + "LEVEL(" + this.combat.PlayerList[1].Level + ")";
                        this.playerHealthBar2.Maximum = (int)this.combat.PlayerList[1].MaxHealth;
                        this.playerHealthBar2.Value = (int)this.combat.PlayerList[1].Health;
                        this.playerAttack2.Text = "ATTACK(" + this.combat.PlayerList[1].Attack.ToString() + ")";
                        this.playerNeededExp2.Text = "NEEDED EXP(" + (this.combat.PlayerList[1].NeededExp - this.combat.PlayerList[1].Exp).ToString() + ")";
                    }

                    if (this.combat.PlayerList.Count > 2)
                    {
                        if (this.combat.PlayerList[2].Dead == true)
                        {
                            this.playerTextBox3.Enabled = false;
                            this.playerHealthBar3.Enabled = false;
                            this.playerAttack3.Enabled = false;

                            this.playerTextBox3.Visible = false;
                            this.playerHealthBar3.Visible = false;
                            this.playerAttack3.Visible = false;
                        }
                        this.playerTextBox3.Text = this.combat.PlayerList[2].Name + "  " + "LEVEL(" + this.combat.PlayerList[2].Level + ")";
                        this.playerHealthBar3.Maximum = (int)this.combat.PlayerList[2].MaxHealth;
                        this.playerHealthBar3.Value = (int)this.combat.PlayerList[2].Health;
                        this.playerAttack3.Text = "ATTACK(" + this.combat.PlayerList[2].Attack.ToString() + ")";
                        this.playerNeededExp3.Text = "NEEDED EXP(" + (this.combat.PlayerList[2].NeededExp - this.combat.PlayerList[2].Exp).ToString() + ")";
                    }

                    if (this.combat.PlayerList.Count > 3)
                    {
                        if (this.combat.PlayerList[3].Dead == true)
                        {
                            this.playerTextBox4.Enabled = false;
                            this.playerHealthBar4.Enabled = false;
                            this.playerAttack4.Enabled = false;

                            this.playerTextBox4.Visible = false;
                            this.playerHealthBar4.Visible = false;
                            this.playerAttack4.Visible = false;
                        }
                        this.playerTextBox4.Text = this.combat.PlayerList[3].Name + "  " + "LEVEL(" + this.combat.PlayerList[3].Level + ")";
                        this.playerHealthBar4.Maximum = (int)this.combat.PlayerList[3].MaxHealth;
                        this.playerHealthBar4.Value = (int)this.combat.PlayerList[3].Health;
                        this.playerAttack4.Text = "ATTACK(" + this.combat.PlayerList[3].Attack.ToString() + ")";
                        this.playerNeededExp4.Text = "NEEDED EXP(" + (this.combat.PlayerList[3].NeededExp - this.combat.PlayerList[3].Exp).ToString() + ")";
                    }

                    //IF CURRENT STATE OF 'COMBAT' == COMBATSTATE.PTURN
                    //  - DISPLAY THE PLAYER'S CONTROLLS, AND ENABLE THEM
                    if (this.combat.CurrentState == CombatState.PTURN)
                    {
                        this.attackButton.Visible = true;
                        this.attackButton.Enabled = true;

                        this.defendButton.Visible = true;
                        this.defendButton.Enabled = true;

                        this.chargeButton.Visible = true;
                        this.chargeButton.Enabled = true;

                        this.nextEntityButton.Visible = false;
                        this.nextEntityButton.Enabled = false;

                        this.playerSelectEntity();
                    }

                    //IF CURRENTSTATE OF 'COMBAT' == COMBATSTATE.ETURN
                    //  - REMOVE PLAYER CONTROLS
                    if (this.combat.CurrentState == CombatState.ETURN)
                    {
                        this.nextEntityButton.Visible = true;
                        this.nextEntityButton.Enabled = true;

                        this.attackButton.Visible = false;
                        this.attackButton.Enabled = false;

                        this.defendButton.Visible = false;
                        this.defendButton.Enabled = false;

                        this.chargeButton.Visible = false;
                        this.chargeButton.Enabled = false;

                        this.selectedEntityLabel.Text = "";
                        this.selectedEntity = null;

                        this.entityHealthBar1.Enabled = false;
                        this.entityHealthBar2.Enabled = false;
                        this.entityHealthBar3.Enabled = false;
                        this.entityHealthBar4.Enabled = false;
                    }

                    //ASSIGN THE NAME OF THE CURRENT ENTITY
                    this.currentEntitylabel.Text = this.combat.CombatQue[this.combat.CombatIndex].Name;

                }


                this.combatStateLabel.Text = "CURRENT STATE: " + this.combat.CurrentState.ToString();
                this.currentEntitylabel.Text = this.combat.CombatQue[this.combat.CombatIndex].Name;

                //GETS THE LEVEL OF THE GAME, FILLS PROGRESS BAR ACCORDINGLY
                //  - LEARN HOW TO SPELL
                this.levelProgressBar.Value = this.gameProgression();

                if (this.selectedEntity != null)
                {
                    this.selectedEntityLabel.Text = this.selectedEntity.Name;
                }

                this.endRoundButton.Enabled = false;
                this.endRoundButton.Visible = false;

                this.pauseGameButton.Enabled = true;
                this.pauseGameButton.Visible = true;

                this.returnToGameButton.Enabled = false;
                this.returnToGameButton.Visible = false;
                this.saveGameButton.Enabled = false;
                this.saveGameButton.Visible = false;
                this.mainMenuButton.Enabled = false;
                this.mainMenuButton.Visible = false;
                this.exitGameButton.Enabled = false;
                this.exitGameButton.Visible = false;
            }

            //GETS THE LEVEL OF THE GAME, FILLS PROGRESS BAR ACCORDINGLY
            //  - LEARN HOW TO SPELL
            this.levelProgressBar.Value = this.gameProgression();

            if (this.combat.CurrentState == CombatState.END)
            {
                this.disableUI();
                this.endRoundButton.Enabled = true;
                this.endRoundButton.Visible = true;
            }

        }

        private void disableUI()
        {
            this.attackButton.Enabled = false;
            this.attackButton.Visible = false;
            this.chargeButton.Enabled = false;
            this.chargeButton.Visible = false;
            this.defendButton.Enabled = false;
            this.defendButton.Visible = false;
            this.nextEntityButton.Enabled = false;
            this.nextEntityButton.Visible = false;
            this.pauseGameButton.Enabled = false;
            this.pauseGameButton.Visible = false;
            this.returnToGameButton.Enabled = false;
            this.returnToGameButton.Visible = false;
            this.saveGameButton.Enabled = false;
            this.saveGameButton.Visible = false;
            this.mainMenuButton.Enabled = false;
            this.mainMenuButton.Visible = false;
            this.exitGameButton.Enabled = false;
            this.exitGameButton.Visible = false;

            this.selectedEntityLabel.Enabled = false;
            this.selectedEntityLabel.Visible = false;
            this.combatStateLabel.Enabled = false;
            this.combatStateLabel.Visible = false;
            this.currentEntitylabel.Enabled = false;
            this.currentEntitylabel.Visible = false;
            this.debugLabel.Enabled = false;
            this.debugLabel.Visible = false;

            this.playerTextBox1.Enabled = false;
            this.playerTextBox1.Visible = false;
            this.playerTextBox2.Enabled = false;
            this.playerTextBox2.Visible = false;
            this.playerTextBox3.Enabled = false;
            this.playerTextBox3.Visible = false;
            this.playerTextBox4.Enabled = false;
            this.playerTextBox4.Visible = false;

            this.entityTextBox1.Enabled = false;
            this.entityTextBox1.Visible = false;
            this.entityTextBox2.Enabled = false;
            this.entityTextBox2.Visible = false;
            this.entityTextBox3.Enabled = false;
            this.entityTextBox3.Visible = false;
            this.entityTextBox4.Enabled = false;
            this.entityTextBox4.Visible = false;

            this.playerHealthBar1.Enabled = false;
            this.playerHealthBar1.Visible = false;
            this.playerHealthBar2.Enabled = false;
            this.playerHealthBar2.Visible = false;
            this.playerHealthBar3.Enabled = false;
            this.playerHealthBar3.Visible = false;
            this.playerHealthBar4.Enabled = false;
            this.playerHealthBar4.Visible = false;

            this.entityHealthBar1.Enabled = false;
            this.entityHealthBar1.Visible = false;
            this.entityHealthBar2.Enabled = false;
            this.entityHealthBar2.Visible = false;
            this.entityHealthBar3.Enabled = false;
            this.entityHealthBar3.Visible = false;
            this.entityHealthBar4.Enabled = false;
            this.entityHealthBar4.Visible = false;

            this.playerAttack1.Enabled = false;
            this.playerAttack1.Visible = false;
            this.playerAttack2.Enabled = false;
            this.playerAttack2.Visible = false;
            this.playerAttack3.Enabled = false;
            this.playerAttack3.Visible = false;
            this.playerAttack4.Enabled = false;
            this.playerAttack4.Visible = false;

            this.playerNeededExp1.Enabled = false;
            this.playerNeededExp1.Visible = false;
            this.playerNeededExp2.Enabled = false;
            this.playerNeededExp2.Visible = false;
            this.playerNeededExp3.Enabled = false;
            this.playerNeededExp3.Visible = false;
            this.playerNeededExp4.Enabled = false;
            this.playerNeededExp4.Visible = false;

            this.entityAttack1.Enabled = false;
            this.entityAttack1.Visible = false;
            this.entityAttack2.Enabled = false;
            this.entityAttack2.Visible = false;
            this.entityAttack3.Enabled = false;
            this.entityAttack3.Visible = false;
            this.entityAttack4.Enabled = false;
            this.entityAttack4.Visible = false;
        }

        private void pauseGame()
        {
            this.pauseGameButton.Enabled = false;
            this.pauseGameButton.Visible = false;

            this.returnToGameButton.Enabled = true;
            this.returnToGameButton.Visible = true;
            this.saveGameButton.Enabled = true;
            this.saveGameButton.Visible = true;
            this.mainMenuButton.Enabled = true;
            this.mainMenuButton.Visible = true;
            this.exitGameButton.Enabled = true;
            this.exitGameButton.Visible = true;

            if (this.combat.CurrentState == CombatState.PTURN)
            {
                this.attackButton.Enabled = false;
                //this.attackButton.Visible = false;
                this.chargeButton.Enabled = false;
                //this.chargeButton.Visible = false;
                this.defendButton.Enabled = false;
                //this.defendButton.Visible = false;
            }
            if (this.combat.CurrentState == CombatState.ETURN)
            {
                this.nextEntityButton.Enabled = false;
                this.nextEntityButton.Visible = true;
            }
            this.selectedEntityLabel.Enabled = false;
            //this.selectedEntityLabel.Visible = false;
            this.combatStateLabel.Enabled = false;
            //this.combatStateLabel.Visible = false;
            this.currentEntitylabel.Enabled = false;
            //this.currentEntitylabel.Visible = false;
            this.debugLabel.Enabled = false;
            //this.debugLabel.Visible = false;

            this.playerTextBox1.Enabled = false;
            //this.playerTextBox1.Visible = false;
            this.playerTextBox2.Enabled = false;
            //this.playerTextBox2.Visible = false;
            this.playerTextBox3.Enabled = false;
            //this.playerTextBox3.Visible = false;
            this.playerTextBox4.Enabled = false;
            //this.playerTextBox4.Visible = false;

            this.entityTextBox1.Enabled = false;
            //this.entityTextBox1.Visible = false;
            this.entityTextBox2.Enabled = false;
            //this.entityTextBox2.Visible = false;
            this.entityTextBox3.Enabled = false;
            //this.entityTextBox3.Visible = false;
            this.entityTextBox4.Enabled = false;
            //this.entityTextBox4.Visible = false;

            this.playerHealthBar1.Enabled = false;
            //this.playerHealthBar1.Visible = false;
            this.playerHealthBar2.Enabled = false;
            //this.playerHealthBar2.Visible = false;
            this.playerHealthBar3.Enabled = false;
            //this.playerHealthBar3.Visible = false;
            this.playerHealthBar4.Enabled = false;
            //this.playerHealthBar4.Visible = false;

            this.entityHealthBar1.Enabled = false;
            //this.entityHealthBar1.Visible = false;
            this.entityHealthBar2.Enabled = false;
            //this.entityHealthBar2.Visible = false;
            this.entityHealthBar3.Enabled = false;
            //this.entityHealthBar3.Visible = false;
            this.entityHealthBar4.Enabled = false;
            //this.entityHealthBar4.Visible = false;

            this.playerAttack1.Enabled = false;
            //this.playerAttack1.Visible = false;
            this.playerAttack2.Enabled = false;
            //this.playerAttack2.Visible = false;
            this.playerAttack3.Enabled = false;
            //this.playerAttack3.Visible = false;
            this.playerAttack4.Enabled = false;
            //this.playerAttack4.Visible = false;

            this.playerNeededExp1.Enabled = false;
            this.playerNeededExp2.Enabled = false;
            this.playerNeededExp3.Enabled = false;
            this.playerNeededExp4.Enabled = false;

            this.entityAttack1.Enabled = false;
            //this.entityAttack1.Visible = false;
            this.entityAttack2.Enabled = false;
            //this.entityAttack2.Visible = false;
            this.entityAttack3.Enabled = false;
            //this.entityAttack3.Visible = false;
            this.entityAttack4.Enabled = false;
            //this.entityAttack4.Visible = false;
        }

        private void unPauseGame()
        {

            this.pauseGameButton.Enabled = true;
            this.pauseGameButton.Visible = true;

            this.returnToGameButton.Enabled = false;
            this.returnToGameButton.Visible = false;
            this.saveGameButton.Enabled = false;
            this.saveGameButton.Visible = false;
            this.mainMenuButton.Enabled = false;
            this.mainMenuButton.Visible = false;
            this.exitGameButton.Enabled = false;
            this.exitGameButton.Visible = false;

            if (this.combat.CurrentState == CombatState.PTURN)
            {
                this.attackButton.Enabled = true;
                this.attackButton.Visible = true;
                this.chargeButton.Enabled = true;
                this.chargeButton.Visible = true;
                this.defendButton.Enabled = true;
                this.defendButton.Visible = true;
            }
            if (this.combat.CurrentState == CombatState.ETURN)
            {
                this.nextEntityButton.Enabled = true;
                this.nextEntityButton.Visible = true;
            }

            this.selectedEntityLabel.Enabled = true;
            this.selectedEntityLabel.Visible = true;
            this.combatStateLabel.Enabled = true;
            this.combatStateLabel.Visible = true;
            this.currentEntitylabel.Enabled = true;
            this.currentEntitylabel.Visible = true;
            this.debugLabel.Enabled = true;
            this.debugLabel.Visible = true;

            this.playerTextBox1.Enabled = true;
            this.playerTextBox1.Visible = true;
            this.playerTextBox2.Enabled = true;
            this.playerTextBox2.Visible = true;
            this.playerTextBox3.Enabled = true;
            this.playerTextBox3.Visible = true;
            this.playerTextBox4.Enabled = true;
            this.playerTextBox4.Visible = true;

            this.entityTextBox1.Enabled = true;
            this.entityTextBox1.Visible = true;
            this.entityTextBox2.Enabled = true;
            this.entityTextBox2.Visible = true;
            this.entityTextBox3.Enabled = true;
            this.entityTextBox3.Visible = true;
            this.entityTextBox4.Enabled = true;
            this.entityTextBox4.Visible = true;

            this.playerHealthBar1.Enabled = true;
            this.playerHealthBar1.Visible = true;
            this.playerHealthBar2.Enabled = true;
            this.playerHealthBar2.Visible = true;
            this.playerHealthBar3.Enabled = true;
            this.playerHealthBar3.Visible = true;
            this.playerHealthBar4.Enabled = true;
            this.playerHealthBar4.Visible = true;

            this.entityHealthBar1.Enabled = true;
            this.entityHealthBar1.Visible = true;
            this.entityHealthBar2.Enabled = true;
            this.entityHealthBar2.Visible = true;
            this.entityHealthBar3.Enabled = true;
            this.entityHealthBar3.Visible = true;
            this.entityHealthBar4.Enabled = true;
            this.entityHealthBar4.Visible = true;

            this.playerAttack1.Enabled = true;
            this.playerAttack1.Visible = true;
            this.playerAttack2.Enabled = true;
            this.playerAttack2.Visible = true;
            this.playerAttack3.Enabled = true;
            this.playerAttack3.Visible = true;
            this.playerAttack4.Enabled = true;
            this.playerAttack4.Visible = true;

            this.playerNeededExp1.Enabled = true;
            this.playerNeededExp1.Visible = true;
            this.playerNeededExp2.Enabled = true;
            this.playerNeededExp2.Visible = true;
            this.playerNeededExp3.Enabled = true;
            this.playerNeededExp3.Visible = true;
            this.playerNeededExp4.Enabled = true;
            this.playerNeededExp4.Visible = true;

            this.entityAttack1.Enabled = true;
            this.entityAttack1.Visible = true;
            this.entityAttack2.Enabled = true;
            this.entityAttack2.Visible = true;
            this.entityAttack3.Enabled = true;
            this.entityAttack3.Visible = true;
            this.entityAttack4.Enabled = true;
            this.entityAttack4.Visible = true;
        }

        private void playerSelectEntity()
        {
            if (this.combat.EntityList != null)
            {
                if (this.combat.EntityList[0].Dead == false)
                {
                    this.entityHealthBar1.Enabled = true;
                }

                if (this.combat.EntityList.Count > 1)
                {
                    if (this.combat.EntityList[1].Dead == false)
                    {
                        this.entityHealthBar2.Enabled = true;
                    }
                }

                if (this.combat.EntityList.Count > 2)
                {
                    if (this.combat.EntityList[2].Dead == false)
                    {
                        this.entityHealthBar3.Enabled = true;
                    }
                }

                if (this.combat.EntityList.Count > 3)
                {
                    if (this.combat.EntityList[3].Dead == false)
                    {
                        this.entityHealthBar4.Enabled = true;
                    }
                }
            }
        }

        //GAMEPROGRESSION() FUNCTION
        //  - NEEDS WORK
        private int gameProgression()
        {
            int gameProgressBar = 0;
            switch (this.combat.GameLevel)
            {
                case 1:
                    {
                        gameProgressBar = 10;
                        break;
                    }

                case 2:
                    {
                        gameProgressBar = 20;
                        break;
                    }

                case 3:
                    {
                        gameProgressBar = 30;
                        break;
                    }

                case 4:
                    {
                        gameProgressBar = 40;
                        break;
                    }

                case 5:
                    {
                        gameProgressBar = 50;
                        break;
                    }

                case 6:
                    {
                        gameProgressBar = 60;
                        break;
                    }

                case 7:
                    {
                        gameProgressBar = 70;
                        break;
                    }

                case 8:
                    {
                        gameProgressBar = 80;
                        break;
                    }

                case 9:
                    {
                        gameProgressBar = 90;
                        break;
                    }

                case 10:
                    {
                        gameProgressBar = 100;
                        break;
                    }
            }
            return gameProgressBar;

        }       

        public void InitOnEnter()
        {
            Console.WriteLine("ENTER INIT");
            this.debugLabel.Text = "ENTER INIT";
            //this.GameFSM.ChangeState(new State(GameState.RUN));
        }

        public void InitOnExit()
        {
            Console.WriteLine("EXIT INIT");
            this.debugLabel.Text = "EXIT INIT";
        }

        //MENU SCREEN
        //  - NEEDS WORK
        public void IdleOnEnter()
        {
            Console.WriteLine("ENTER IDLE");
            this.debugLabel.Text = "ENTER IDLE";
        }

        public void IdleOnExit()
        {
            Console.WriteLine("EXIT IDLE");
            this.debugLabel.Text = "EXIT IDLE";
        }

        //NEW GAME
        //  - NEEDS WORK
        public void NewOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER START");
            this.debugLabel.Text = "ENTER START";

            this.levelProgressBar.Visible = true;

            //List<Player> pList = new List<Player>();
            //List<Entity> eList = new List<Entity>();
            //for (int i = 0; i < 3; i++)
            //{
            //    eList.Add(new Entity("DEBUG " + i.ToString(), 100, 20, 10));
            //    pList.Add(new Player("DEBUG PLAYER " + i.ToString(), 100, 100, (12 + i)));
            //}

            //this.combat = new Combat(pList, eList);

            //this.combat.NewGame();

            //DEBUG THE COMBAT
            this.updateCombatUI();
            this.RunApp();
        }

        public void NewOnExit()
        {
            Console.WriteLine("EXIT START");
            this.debugLabel.Text = "EXIT START";
        }

        //SAVE GAME
        //  - NEEDS WORK
        public void SaveOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER SAVE");
        }

        public void SaveOnExit()
        {
            Console.WriteLine(this.ToString() + "EXIT SAVE");
            this.unPauseGame();
        }

        //LOAD GAME
        //  - NEEDS WORK
        public void LoadOnEnter()
        {
            Console.WriteLine("ENTER LOAD");
            this.debugLabel.Text = "ENTER LOAD";

        }

        public void LoadOnExit()
        {
            Console.WriteLine("EXIT LOAD");
            this.debugLabel.Text = "EXIT LOAD";
        }

        //RUN GAME
        //  - NEEDS WORK
        public void RunOnEnter()
        {
            this.UpdateApp();
            this.RunApp();
        }

        public void RunOnExit()
        {
            Console.WriteLine(this.ToString() + "EXIT RUN");
        }

        //EXIT GAME
        //  - NEEDS WORK
        public void ExitOnEnter()
        {
            Console.WriteLine(this.ToString() + "ENTER EXIT");
        }

        public void ExitOnExit()
        {
            Console.WriteLine(this.ToString() + "EXIT EXIT");
        }

        //LOAD THE GAME
        private void loadGameDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.combat = new Combat();
            this.combat = DataSerialization.DeserializeGame(this.loadGameDialog.FileName);
            this.combat.LoadGame(this.combat);
            this.GameFSM.ChangeState(GameState.RUN);
            this.updateCombatUI();
            this.UpdateApp();
            this.RunApp();
            this.combat.RunCombat(this.combat.PlayerList[this.combat.PlayerIndex], this.combat.EntityList[this.combat.EntityIndex]);
        }                

        private void saveGameDialog_FileOk_1(object sender, CancelEventArgs e)
        {
            //NEEDS WORK
            DataSerialization.SerializeGame(this.saveGameDialog.FileName);
        }

        //'NEW GAME' BUTTON
        //  - START A NEW 'GAME'
        private void button1_Click_1(object sender, EventArgs e)
        {
            //NEEDS WORK
            //START A NEW GAME
            this.GameFSM.ChangeState(GameState.NEWGAME);
            this.UpdateApp();
            this.RunApp();
        }

        //'LOAD GAME' BUTTON
        //  - LOAD A SAVE FILE FOR A GAME
        //  - USE TOOL 'OPENDIALOGBOX' FOR LOADING A GAME
        private void button2_Click_1(object sender, EventArgs e)
        {
            //DESERIALIZE GAME 
            //RESTORE THE GAME
            //NEEDS WORK

            //CHANGE THE STATE TO 'LOAD'
            //DISABLE THE MENU SCREEN????
            this.GameFSM.ChangeState(GameState.LOAD);
            this.UpdateApp();
            this.RunApp();
        }

        //PLAYER SELECT 1ST ENTITY
        //CHECK IF ITS PLAYER'S TURN BEFORE ASSIGNING THE SELECTED ENTITY
        //CHECK IF THE ENTITY LIST IS NOT EMPTY
        private void healthBar2_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN && this.combat.EntityList.Count > 0 && this.combat.EntityList[0].Dead == false)
            {
                this.selectedEntity = this.combat.EntityList[0];
                this.UpdateApp();
                this.updateCombatUI();
            }
        }

        //PLAYER SELECT 2ND ENTITY
        //CHECK IF ITS PLAYER'S TURN BEFORE ASSIGNING THE SELECTED ENTITY
        //CHECK IF THE ENTITY LIST IS NOT EMPTY
        private void healthBar3_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN && this.combat.EntityList.Count > 1 && this.combat.EntityList[1].Dead == false)
            {
                this.selectedEntity = this.combat.EntityList[1];
                this.UpdateApp();
                this.updateCombatUI();
            }
        }

        //PLAYER SELECT 3RD ENTITY
        //CHECK IF ITS PLAYER'S TURN BEFORE ASSIGNING THE SELECTED ENTITY
        //CHECK IF THE ENTITY LIST IS NOT EMPTY
        private void healthBar4_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN && this.combat.EntityList.Count > 2 && this.combat.EntityList[2].Dead == false)
            {
                this.selectedEntity = this.combat.EntityList[2];
                this.UpdateApp();
                this.updateCombatUI();
            }
        }

        //PLAYER SELECT 4TH ENTITY
        //CHECK IF ITS PLAYER'S TURN BEFORE ASSIGNING THE SELECTED ENTITY
        //CHECK IF THE ENTITY LIST IS NOT EMPTY
        private void healthBar5_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN && this.combat.EntityList.Count > 3 && this.combat.EntityList[3].Dead == false)
            {
                this.selectedEntity = this.combat.EntityList[3];
                this.UpdateApp();
                this.updateCombatUI();
            }
        }

        //PLAYER ATTACK 'SELECTEDENTITY'
        //  - NEEDS WORK
        private void attackButton_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN)
            {
                if (this.selectedEntity == null)
                {
                    this.selectedEntityLabel.Text = "SELECT A ENEMY";
                    this.selectedEntity = null;
                }

                if (this.selectedEntity != null)
                {
                    this.combat.PlayerList[this.combat.PlayerIndex].PSM.ChangeState(EntityState.ATTACK);
                    this.combat.PlayerList[this.combat.PlayerIndex].UpdatePlayerState();
                    this.combat.RunCombat(this.combat.PlayerList[this.combat.PlayerIndex], this.selectedEntity);                    
                }
            }            
            this.UpdateApp();
            this.updateCombatUI();
            this.RunApp();
        }

        //PLAYER DEFEND ATTACK FROM ENTITY
        //  - NEEDS WORK
        private void defendButton_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN)
            {
            }
        }

        //PLAYER CHARGE ATTACK
        //  - NEEDS WORK
        private void chargeButton_Click(object sender, EventArgs e)
        {
            if (this.combat.CurrentState == CombatState.PTURN)
            {

            }
        }

        //NEXT ENTITY
        //  - NEEDS WORK
        private void nextEntityButton_Click(object sender, EventArgs e)
        {
            //MAKE 'EACTIONCHOICE()' FUNCTION
            //this.combat.endEturn();
            this.combat.EActionChoice();
            this.updateCombatUI();
            this.UpdateApp();
            this.RunApp();
        }

        //END ROUND BUTTON
        //  - NEEDS WORK
        private void endRoundButton_Click(object sender, EventArgs e)
        {
            this.combat.CSM.ChangeState(CombatState.EXIT);
            this.updateCombatUI();
            this.UpdateApp();
            this.RunApp();
            this.updateCombatUI();
        }

        //PAUSE GAME BUTTON
        private void pauseGameButton_Click(object sender, EventArgs e)
        {
            this.pauseGame();            
        }

        //SAVE GAME BUTTON
        //  - NEEDS WORK
        private void saveGameButton_Click(object sender, EventArgs e)
        {
            this.GameFSM.ChangeState(GameState.SAVE);
            this.UpdateApp();
            this.RunApp();
        }

        //UNPAUSE GAME BUTTON
        private void returnToGameButton_Click(object sender, EventArgs e)
        {
            this.unPauseGame();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.combatBox.Enabled = false;
            this.combatBox.Visible = false;
            this.menuBox.Enabled = true;
            this.menuBox.Visible = true;
            this.levelProgressBar.Enabled = false;
            this.levelProgressBar.Visible = false;

            this.GameFSM.ChangeState(GameState.IDLE);
            this.UpdateApp();
            this.RunApp();            
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}