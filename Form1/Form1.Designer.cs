namespace Assessment4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newGameLabel = new System.Windows.Forms.Label();
            this.loadGameLabel = new System.Windows.Forms.Label();
            this.loadGameButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.combatBox = new System.Windows.Forms.GroupBox();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.saveGameButton = new System.Windows.Forms.Button();
            this.returnToGameButton = new System.Windows.Forms.Button();
            this.pauseGameButton = new System.Windows.Forms.Button();
            this.endRoundButton = new System.Windows.Forms.Button();
            this.nextEntityButton = new System.Windows.Forms.Button();
            this.playerAttack4 = new System.Windows.Forms.Label();
            this.playerAttack3 = new System.Windows.Forms.Label();
            this.playerAttack2 = new System.Windows.Forms.Label();
            this.playerHealthBar4 = new System.Windows.Forms.ProgressBar();
            this.playerTextBox4 = new System.Windows.Forms.TextBox();
            this.playerHealthBar3 = new System.Windows.Forms.ProgressBar();
            this.playerTextBox3 = new System.Windows.Forms.TextBox();
            this.playerHealthBar2 = new System.Windows.Forms.ProgressBar();
            this.playerTextBox2 = new System.Windows.Forms.TextBox();
            this.currentEntitylabel = new System.Windows.Forms.Label();
            this.combatStateLabel = new System.Windows.Forms.Label();
            this.selectedEntityLabel = new System.Windows.Forms.Label();
            this.chargeButton = new System.Windows.Forms.Button();
            this.defendButton = new System.Windows.Forms.Button();
            this.attackButton = new System.Windows.Forms.Button();
            this.entityAttack4 = new System.Windows.Forms.Label();
            this.entityAttack3 = new System.Windows.Forms.Label();
            this.entityAttack2 = new System.Windows.Forms.Label();
            this.entityAttack1 = new System.Windows.Forms.Label();
            this.playerAttack1 = new System.Windows.Forms.Label();
            this.entityHealthBar4 = new System.Windows.Forms.ProgressBar();
            this.entityHealthBar3 = new System.Windows.Forms.ProgressBar();
            this.entityHealthBar2 = new System.Windows.Forms.ProgressBar();
            this.entityHealthBar1 = new System.Windows.Forms.ProgressBar();
            this.playerHealthBar1 = new System.Windows.Forms.ProgressBar();
            this.entityTextBox4 = new System.Windows.Forms.TextBox();
            this.entityTextBox3 = new System.Windows.Forms.TextBox();
            this.entityTextBox2 = new System.Windows.Forms.TextBox();
            this.entityTextBox1 = new System.Windows.Forms.TextBox();
            this.playerTextBox1 = new System.Windows.Forms.TextBox();
            this.menuBox = new System.Windows.Forms.GroupBox();
            this.debugLabel = new System.Windows.Forms.Label();
            this.loadGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.levelProgressBar = new System.Windows.Forms.ProgressBar();
            this.saveGameDialog = new System.Windows.Forms.SaveFileDialog();
            this.playerNeededExp1 = new System.Windows.Forms.Label();
            this.playerNeededExp2 = new System.Windows.Forms.Label();
            this.playerNeededExp3 = new System.Windows.Forms.Label();
            this.playerNeededExp4 = new System.Windows.Forms.Label();
            this.combatBox.SuspendLayout();
            this.menuBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // newGameLabel
            // 
            this.newGameLabel.AutoSize = true;
            this.newGameLabel.Location = new System.Drawing.Point(106, 317);
            this.newGameLabel.Name = "newGameLabel";
            this.newGameLabel.Size = new System.Drawing.Size(67, 13);
            this.newGameLabel.TabIndex = 6;
            this.newGameLabel.Text = "NEW GAME";
            // 
            // loadGameLabel
            // 
            this.loadGameLabel.AutoSize = true;
            this.loadGameLabel.Location = new System.Drawing.Point(461, 317);
            this.loadGameLabel.Name = "loadGameLabel";
            this.loadGameLabel.Size = new System.Drawing.Size(70, 13);
            this.loadGameLabel.TabIndex = 8;
            this.loadGameLabel.Text = "LOAD GAME";
            // 
            // loadGameButton
            // 
            this.loadGameButton.Location = new System.Drawing.Point(398, 333);
            this.loadGameButton.Name = "loadGameButton";
            this.loadGameButton.Size = new System.Drawing.Size(190, 68);
            this.loadGameButton.TabIndex = 7;
            this.loadGameButton.UseVisualStyleBackColor = true;
            this.loadGameButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(49, 333);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(190, 68);
            this.newGameButton.TabIndex = 5;
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // combatBox
            // 
            this.combatBox.Controls.Add(this.playerNeededExp4);
            this.combatBox.Controls.Add(this.playerNeededExp3);
            this.combatBox.Controls.Add(this.playerNeededExp2);
            this.combatBox.Controls.Add(this.playerNeededExp1);
            this.combatBox.Controls.Add(this.exitGameButton);
            this.combatBox.Controls.Add(this.mainMenuButton);
            this.combatBox.Controls.Add(this.saveGameButton);
            this.combatBox.Controls.Add(this.returnToGameButton);
            this.combatBox.Controls.Add(this.pauseGameButton);
            this.combatBox.Controls.Add(this.endRoundButton);
            this.combatBox.Controls.Add(this.nextEntityButton);
            this.combatBox.Controls.Add(this.playerAttack4);
            this.combatBox.Controls.Add(this.playerAttack3);
            this.combatBox.Controls.Add(this.playerAttack2);
            this.combatBox.Controls.Add(this.playerHealthBar4);
            this.combatBox.Controls.Add(this.playerTextBox4);
            this.combatBox.Controls.Add(this.playerHealthBar3);
            this.combatBox.Controls.Add(this.playerTextBox3);
            this.combatBox.Controls.Add(this.playerHealthBar2);
            this.combatBox.Controls.Add(this.playerTextBox2);
            this.combatBox.Controls.Add(this.currentEntitylabel);
            this.combatBox.Controls.Add(this.combatStateLabel);
            this.combatBox.Controls.Add(this.selectedEntityLabel);
            this.combatBox.Controls.Add(this.chargeButton);
            this.combatBox.Controls.Add(this.defendButton);
            this.combatBox.Controls.Add(this.attackButton);
            this.combatBox.Controls.Add(this.entityAttack4);
            this.combatBox.Controls.Add(this.entityAttack3);
            this.combatBox.Controls.Add(this.entityAttack2);
            this.combatBox.Controls.Add(this.entityAttack1);
            this.combatBox.Controls.Add(this.playerAttack1);
            this.combatBox.Controls.Add(this.entityHealthBar4);
            this.combatBox.Controls.Add(this.entityHealthBar3);
            this.combatBox.Controls.Add(this.entityHealthBar2);
            this.combatBox.Controls.Add(this.entityHealthBar1);
            this.combatBox.Controls.Add(this.playerHealthBar1);
            this.combatBox.Controls.Add(this.entityTextBox4);
            this.combatBox.Controls.Add(this.entityTextBox3);
            this.combatBox.Controls.Add(this.entityTextBox2);
            this.combatBox.Controls.Add(this.entityTextBox1);
            this.combatBox.Controls.Add(this.playerTextBox1);
            this.combatBox.Enabled = false;
            this.combatBox.Location = new System.Drawing.Point(685, 1);
            this.combatBox.Name = "combatBox";
            this.combatBox.Size = new System.Drawing.Size(636, 548);
            this.combatBox.TabIndex = 11;
            this.combatBox.TabStop = false;
            this.combatBox.Text = "combatBox";
            this.combatBox.Visible = false;
            // 
            // exitGameButton
            // 
            this.exitGameButton.Location = new System.Drawing.Point(531, 500);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(84, 24);
            this.exitGameButton.TabIndex = 49;
            this.exitGameButton.Text = "EXIT";
            this.exitGameButton.UseVisualStyleBackColor = true;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(19, 500);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(84, 24);
            this.mainMenuButton.TabIndex = 48;
            this.mainMenuButton.Text = "MAIN MENU";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // saveGameButton
            // 
            this.saveGameButton.Location = new System.Drawing.Point(116, 500);
            this.saveGameButton.Name = "saveGameButton";
            this.saveGameButton.Size = new System.Drawing.Size(84, 24);
            this.saveGameButton.TabIndex = 47;
            this.saveGameButton.Text = "SAVE";
            this.saveGameButton.UseVisualStyleBackColor = true;
            this.saveGameButton.Click += new System.EventHandler(this.saveGameButton_Click);
            // 
            // returnToGameButton
            // 
            this.returnToGameButton.Location = new System.Drawing.Point(18, 460);
            this.returnToGameButton.Name = "returnToGameButton";
            this.returnToGameButton.Size = new System.Drawing.Size(84, 24);
            this.returnToGameButton.TabIndex = 46;
            this.returnToGameButton.Text = "RETURN";
            this.returnToGameButton.UseVisualStyleBackColor = true;
            this.returnToGameButton.Click += new System.EventHandler(this.returnToGameButton_Click);
            // 
            // pauseGameButton
            // 
            this.pauseGameButton.Location = new System.Drawing.Point(18, 500);
            this.pauseGameButton.Name = "pauseGameButton";
            this.pauseGameButton.Size = new System.Drawing.Size(84, 24);
            this.pauseGameButton.TabIndex = 45;
            this.pauseGameButton.Text = "PAUSE";
            this.pauseGameButton.UseVisualStyleBackColor = true;
            this.pauseGameButton.Click += new System.EventHandler(this.pauseGameButton_Click);
            // 
            // endRoundButton
            // 
            this.endRoundButton.Location = new System.Drawing.Point(244, 211);
            this.endRoundButton.Name = "endRoundButton";
            this.endRoundButton.Size = new System.Drawing.Size(112, 45);
            this.endRoundButton.TabIndex = 44;
            this.endRoundButton.Text = "END";
            this.endRoundButton.UseVisualStyleBackColor = true;
            this.endRoundButton.Click += new System.EventHandler(this.endRoundButton_Click);
            // 
            // nextEntityButton
            // 
            this.nextEntityButton.Location = new System.Drawing.Point(244, 378);
            this.nextEntityButton.Name = "nextEntityButton";
            this.nextEntityButton.Size = new System.Drawing.Size(112, 45);
            this.nextEntityButton.TabIndex = 43;
            this.nextEntityButton.Text = "NEXT";
            this.nextEntityButton.UseVisualStyleBackColor = true;
            this.nextEntityButton.Click += new System.EventHandler(this.nextEntityButton_Click);
            // 
            // playerAttack4
            // 
            this.playerAttack4.AutoSize = true;
            this.playerAttack4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerAttack4.Location = new System.Drawing.Point(103, 368);
            this.playerAttack4.Name = "playerAttack4";
            this.playerAttack4.Size = new System.Drawing.Size(0, 13);
            this.playerAttack4.TabIndex = 42;
            // 
            // playerAttack3
            // 
            this.playerAttack3.AutoSize = true;
            this.playerAttack3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerAttack3.Location = new System.Drawing.Point(103, 268);
            this.playerAttack3.Name = "playerAttack3";
            this.playerAttack3.Size = new System.Drawing.Size(0, 13);
            this.playerAttack3.TabIndex = 41;
            // 
            // playerAttack2
            // 
            this.playerAttack2.AutoSize = true;
            this.playerAttack2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerAttack2.Location = new System.Drawing.Point(103, 159);
            this.playerAttack2.Name = "playerAttack2";
            this.playerAttack2.Size = new System.Drawing.Size(0, 13);
            this.playerAttack2.TabIndex = 40;
            // 
            // playerHealthBar4
            // 
            this.playerHealthBar4.Location = new System.Drawing.Point(10, 368);
            this.playerHealthBar4.Name = "playerHealthBar4";
            this.playerHealthBar4.Size = new System.Drawing.Size(76, 19);
            this.playerHealthBar4.TabIndex = 39;
            // 
            // playerTextBox4
            // 
            this.playerTextBox4.Location = new System.Drawing.Point(10, 342);
            this.playerTextBox4.Name = "playerTextBox4";
            this.playerTextBox4.ReadOnly = true;
            this.playerTextBox4.Size = new System.Drawing.Size(190, 20);
            this.playerTextBox4.TabIndex = 38;
            this.playerTextBox4.TabStop = false;
            // 
            // playerHealthBar3
            // 
            this.playerHealthBar3.Location = new System.Drawing.Point(10, 262);
            this.playerHealthBar3.Name = "playerHealthBar3";
            this.playerHealthBar3.Size = new System.Drawing.Size(76, 19);
            this.playerHealthBar3.TabIndex = 37;
            // 
            // playerTextBox3
            // 
            this.playerTextBox3.Location = new System.Drawing.Point(10, 236);
            this.playerTextBox3.Name = "playerTextBox3";
            this.playerTextBox3.ReadOnly = true;
            this.playerTextBox3.Size = new System.Drawing.Size(190, 20);
            this.playerTextBox3.TabIndex = 36;
            this.playerTextBox3.TabStop = false;
            // 
            // playerHealthBar2
            // 
            this.playerHealthBar2.Location = new System.Drawing.Point(10, 153);
            this.playerHealthBar2.Name = "playerHealthBar2";
            this.playerHealthBar2.Size = new System.Drawing.Size(76, 19);
            this.playerHealthBar2.TabIndex = 35;
            // 
            // playerTextBox2
            // 
            this.playerTextBox2.Location = new System.Drawing.Point(10, 127);
            this.playerTextBox2.Name = "playerTextBox2";
            this.playerTextBox2.ReadOnly = true;
            this.playerTextBox2.Size = new System.Drawing.Size(190, 20);
            this.playerTextBox2.TabIndex = 34;
            this.playerTextBox2.TabStop = false;
            // 
            // currentEntitylabel
            // 
            this.currentEntitylabel.AutoSize = true;
            this.currentEntitylabel.Location = new System.Drawing.Point(297, 19);
            this.currentEntitylabel.Name = "currentEntitylabel";
            this.currentEntitylabel.Size = new System.Drawing.Size(0, 13);
            this.currentEntitylabel.TabIndex = 33;
            // 
            // combatStateLabel
            // 
            this.combatStateLabel.AutoSize = true;
            this.combatStateLabel.Location = new System.Drawing.Point(297, 45);
            this.combatStateLabel.Name = "combatStateLabel";
            this.combatStateLabel.Size = new System.Drawing.Size(0, 13);
            this.combatStateLabel.TabIndex = 32;
            // 
            // selectedEntityLabel
            // 
            this.selectedEntityLabel.AutoSize = true;
            this.selectedEntityLabel.Location = new System.Drawing.Point(297, 76);
            this.selectedEntityLabel.Name = "selectedEntityLabel";
            this.selectedEntityLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedEntityLabel.TabIndex = 31;
            // 
            // chargeButton
            // 
            this.chargeButton.Location = new System.Drawing.Point(244, 480);
            this.chargeButton.Name = "chargeButton";
            this.chargeButton.Size = new System.Drawing.Size(112, 45);
            this.chargeButton.TabIndex = 30;
            this.chargeButton.Text = "CHARGE";
            this.chargeButton.UseVisualStyleBackColor = true;
            this.chargeButton.Click += new System.EventHandler(this.chargeButton_Click);
            // 
            // defendButton
            // 
            this.defendButton.Location = new System.Drawing.Point(303, 429);
            this.defendButton.Name = "defendButton";
            this.defendButton.Size = new System.Drawing.Size(112, 45);
            this.defendButton.TabIndex = 29;
            this.defendButton.Text = "DEFEND";
            this.defendButton.UseVisualStyleBackColor = true;
            this.defendButton.Click += new System.EventHandler(this.defendButton_Click);
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(185, 429);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(112, 45);
            this.attackButton.TabIndex = 28;
            this.attackButton.Text = "ATTACK";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // entityAttack4
            // 
            this.entityAttack4.AutoSize = true;
            this.entityAttack4.Location = new System.Drawing.Point(528, 368);
            this.entityAttack4.Name = "entityAttack4";
            this.entityAttack4.Size = new System.Drawing.Size(0, 13);
            this.entityAttack4.TabIndex = 14;
            // 
            // entityAttack3
            // 
            this.entityAttack3.AutoSize = true;
            this.entityAttack3.Location = new System.Drawing.Point(528, 259);
            this.entityAttack3.Name = "entityAttack3";
            this.entityAttack3.Size = new System.Drawing.Size(0, 13);
            this.entityAttack3.TabIndex = 15;
            // 
            // entityAttack2
            // 
            this.entityAttack2.AutoSize = true;
            this.entityAttack2.Location = new System.Drawing.Point(528, 153);
            this.entityAttack2.Name = "entityAttack2";
            this.entityAttack2.Size = new System.Drawing.Size(0, 13);
            this.entityAttack2.TabIndex = 16;
            // 
            // entityAttack1
            // 
            this.entityAttack1.AutoSize = true;
            this.entityAttack1.Location = new System.Drawing.Point(528, 45);
            this.entityAttack1.Name = "entityAttack1";
            this.entityAttack1.Size = new System.Drawing.Size(0, 13);
            this.entityAttack1.TabIndex = 17;
            // 
            // playerAttack1
            // 
            this.playerAttack1.AutoSize = true;
            this.playerAttack1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerAttack1.Location = new System.Drawing.Point(103, 45);
            this.playerAttack1.Name = "playerAttack1";
            this.playerAttack1.Size = new System.Drawing.Size(0, 13);
            this.playerAttack1.TabIndex = 18;
            // 
            // entityHealthBar4
            // 
            this.entityHealthBar4.Location = new System.Drawing.Point(440, 368);
            this.entityHealthBar4.Name = "entityHealthBar4";
            this.entityHealthBar4.Size = new System.Drawing.Size(76, 19);
            this.entityHealthBar4.TabIndex = 27;
            this.entityHealthBar4.Click += new System.EventHandler(this.healthBar5_Click);
            // 
            // entityHealthBar3
            // 
            this.entityHealthBar3.Location = new System.Drawing.Point(440, 262);
            this.entityHealthBar3.Name = "entityHealthBar3";
            this.entityHealthBar3.Size = new System.Drawing.Size(76, 19);
            this.entityHealthBar3.TabIndex = 26;
            this.entityHealthBar3.Click += new System.EventHandler(this.healthBar4_Click);
            // 
            // entityHealthBar2
            // 
            this.entityHealthBar2.Location = new System.Drawing.Point(440, 153);
            this.entityHealthBar2.Name = "entityHealthBar2";
            this.entityHealthBar2.Size = new System.Drawing.Size(76, 19);
            this.entityHealthBar2.TabIndex = 25;
            this.entityHealthBar2.Click += new System.EventHandler(this.healthBar3_Click);
            // 
            // entityHealthBar1
            // 
            this.entityHealthBar1.Location = new System.Drawing.Point(440, 45);
            this.entityHealthBar1.Name = "entityHealthBar1";
            this.entityHealthBar1.Size = new System.Drawing.Size(76, 19);
            this.entityHealthBar1.TabIndex = 24;
            this.entityHealthBar1.Click += new System.EventHandler(this.healthBar2_Click);
            // 
            // playerHealthBar1
            // 
            this.playerHealthBar1.Location = new System.Drawing.Point(10, 45);
            this.playerHealthBar1.Name = "playerHealthBar1";
            this.playerHealthBar1.Size = new System.Drawing.Size(76, 19);
            this.playerHealthBar1.TabIndex = 23;
            // 
            // entityTextBox4
            // 
            this.entityTextBox4.Location = new System.Drawing.Point(440, 342);
            this.entityTextBox4.Name = "entityTextBox4";
            this.entityTextBox4.ReadOnly = true;
            this.entityTextBox4.Size = new System.Drawing.Size(190, 20);
            this.entityTextBox4.TabIndex = 22;
            this.entityTextBox4.TabStop = false;
            // 
            // entityTextBox3
            // 
            this.entityTextBox3.Location = new System.Drawing.Point(440, 236);
            this.entityTextBox3.Name = "entityTextBox3";
            this.entityTextBox3.ReadOnly = true;
            this.entityTextBox3.Size = new System.Drawing.Size(190, 20);
            this.entityTextBox3.TabIndex = 21;
            this.entityTextBox3.TabStop = false;
            // 
            // entityTextBox2
            // 
            this.entityTextBox2.Location = new System.Drawing.Point(440, 127);
            this.entityTextBox2.Name = "entityTextBox2";
            this.entityTextBox2.ReadOnly = true;
            this.entityTextBox2.Size = new System.Drawing.Size(190, 20);
            this.entityTextBox2.TabIndex = 20;
            this.entityTextBox2.TabStop = false;
            // 
            // entityTextBox1
            // 
            this.entityTextBox1.Location = new System.Drawing.Point(440, 19);
            this.entityTextBox1.Name = "entityTextBox1";
            this.entityTextBox1.ReadOnly = true;
            this.entityTextBox1.Size = new System.Drawing.Size(190, 20);
            this.entityTextBox1.TabIndex = 19;
            this.entityTextBox1.TabStop = false;
            // 
            // playerTextBox1
            // 
            this.playerTextBox1.Location = new System.Drawing.Point(10, 19);
            this.playerTextBox1.Name = "playerTextBox1";
            this.playerTextBox1.ReadOnly = true;
            this.playerTextBox1.Size = new System.Drawing.Size(190, 20);
            this.playerTextBox1.TabIndex = 13;
            this.playerTextBox1.TabStop = false;
            // 
            // menuBox
            // 
            this.menuBox.Controls.Add(this.debugLabel);
            this.menuBox.Controls.Add(this.newGameLabel);
            this.menuBox.Controls.Add(this.loadGameLabel);
            this.menuBox.Controls.Add(this.loadGameButton);
            this.menuBox.Controls.Add(this.newGameButton);
            this.menuBox.Location = new System.Drawing.Point(2, 1);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(634, 416);
            this.menuBox.TabIndex = 12;
            this.menuBox.TabStop = false;
            this.menuBox.Text = "menuBox";
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(475, 34);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(0, 13);
            this.debugLabel.TabIndex = 11;
            // 
            // loadGameDialog
            // 
            this.loadGameDialog.DefaultExt = "gameSave";
            this.loadGameDialog.InitialDirectory = "@..\\..\\saveData\\";
            this.loadGameDialog.Title = "LOAD GAME";
            this.loadGameDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadGameDialog_FileOk);
            // 
            // levelProgressBar
            // 
            this.levelProgressBar.Location = new System.Drawing.Point(51, 593);
            this.levelProgressBar.Name = "levelProgressBar";
            this.levelProgressBar.Size = new System.Drawing.Size(1226, 46);
            this.levelProgressBar.TabIndex = 13;
            // 
            // saveGameDialog
            // 
            this.saveGameDialog.Title = "SAVE GAME";
            this.saveGameDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveGameDialog_FileOk_1);
            // 
            // playerNeededExp1
            // 
            this.playerNeededExp1.AutoSize = true;
            this.playerNeededExp1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerNeededExp1.Location = new System.Drawing.Point(103, 67);
            this.playerNeededExp1.Name = "playerNeededExp1";
            this.playerNeededExp1.Size = new System.Drawing.Size(0, 13);
            this.playerNeededExp1.TabIndex = 50;
            // 
            // playerNeededExp2
            // 
            this.playerNeededExp2.AutoSize = true;
            this.playerNeededExp2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerNeededExp2.Location = new System.Drawing.Point(103, 181);
            this.playerNeededExp2.Name = "playerNeededExp2";
            this.playerNeededExp2.Size = new System.Drawing.Size(0, 13);
            this.playerNeededExp2.TabIndex = 51;
            // 
            // playerNeededExp3
            // 
            this.playerNeededExp3.AutoSize = true;
            this.playerNeededExp3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerNeededExp3.Location = new System.Drawing.Point(103, 290);
            this.playerNeededExp3.Name = "playerNeededExp3";
            this.playerNeededExp3.Size = new System.Drawing.Size(0, 13);
            this.playerNeededExp3.TabIndex = 52;
            // 
            // playerNeededExp4
            // 
            this.playerNeededExp4.AutoSize = true;
            this.playerNeededExp4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playerNeededExp4.Location = new System.Drawing.Point(103, 388);
            this.playerNeededExp4.Name = "playerNeededExp4";
            this.playerNeededExp4.Size = new System.Drawing.Size(0, 13);
            this.playerNeededExp4.TabIndex = 53;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 689);
            this.Controls.Add(this.levelProgressBar);
            this.Controls.Add(this.menuBox);
            this.Controls.Add(this.combatBox);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GAME";
            this.combatBox.ResumeLayout(false);
            this.combatBox.PerformLayout();
            this.menuBox.ResumeLayout(false);
            this.menuBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label newGameLabel;
        private System.Windows.Forms.Label loadGameLabel;
        private System.Windows.Forms.Button loadGameButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.GroupBox combatBox;
        private System.Windows.Forms.Button chargeButton;
        private System.Windows.Forms.Button defendButton;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Label entityAttack4;
        private System.Windows.Forms.Label entityAttack3;
        private System.Windows.Forms.Label entityAttack2;
        private System.Windows.Forms.Label entityAttack1;
        private System.Windows.Forms.Label playerAttack1;
        private System.Windows.Forms.ProgressBar entityHealthBar4;
        private System.Windows.Forms.ProgressBar entityHealthBar3;
        private System.Windows.Forms.ProgressBar entityHealthBar2;
        private System.Windows.Forms.ProgressBar entityHealthBar1;
        private System.Windows.Forms.ProgressBar playerHealthBar1;
        private System.Windows.Forms.TextBox entityTextBox4;
        private System.Windows.Forms.TextBox entityTextBox3;
        private System.Windows.Forms.TextBox entityTextBox2;
        private System.Windows.Forms.TextBox entityTextBox1;
        private System.Windows.Forms.TextBox playerTextBox1;
        private System.Windows.Forms.GroupBox menuBox;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.OpenFileDialog loadGameDialog;
        private System.Windows.Forms.Label selectedEntityLabel;
        private System.Windows.Forms.ProgressBar levelProgressBar;
        private System.Windows.Forms.Label combatStateLabel;
        private System.Windows.Forms.Label currentEntitylabel;
        private System.Windows.Forms.ProgressBar playerHealthBar4;
        private System.Windows.Forms.TextBox playerTextBox4;
        private System.Windows.Forms.ProgressBar playerHealthBar3;
        private System.Windows.Forms.TextBox playerTextBox3;
        private System.Windows.Forms.ProgressBar playerHealthBar2;
        private System.Windows.Forms.TextBox playerTextBox2;
        private System.Windows.Forms.Label playerAttack4;
        private System.Windows.Forms.Label playerAttack3;
        private System.Windows.Forms.Label playerAttack2;
        private System.Windows.Forms.Button nextEntityButton;
        private System.Windows.Forms.Button endRoundButton;
        private System.Windows.Forms.Button pauseGameButton;
        private System.Windows.Forms.Button saveGameButton;
        private System.Windows.Forms.Button returnToGameButton;
        private System.Windows.Forms.Button mainMenuButton;
        private System.Windows.Forms.SaveFileDialog saveGameDialog;
        private System.Windows.Forms.Button exitGameButton;
        private System.Windows.Forms.Label playerNeededExp4;
        private System.Windows.Forms.Label playerNeededExp3;
        private System.Windows.Forms.Label playerNeededExp2;
        private System.Windows.Forms.Label playerNeededExp1;
    }
}

