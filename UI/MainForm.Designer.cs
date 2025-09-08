namespace PredatorAndPreySimulation.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.FlowLayoutPanel panelLeft;

        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.GroupBox grpParams;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.NumericUpDown nudGridSize;
        private System.Windows.Forms.Label lblPrey;
        private System.Windows.Forms.NumericUpDown nudPrey;
        private System.Windows.Forms.Label lblPred;
        private System.Windows.Forms.NumericUpDown nudPredators;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.NumericUpDown nudObstacles;
        private System.Windows.Forms.Label lblOverpop;
        private System.Windows.Forms.NumericUpDown nudOverpop;
        private System.Windows.Forms.Label lblReproRate;
        private System.Windows.Forms.NumericUpDown nudReproRate;
        private System.Windows.Forms.Label lblEnergyGain;
        private System.Windows.Forms.NumericUpDown nudEnergyGain;
        private System.Windows.Forms.Label lblEnergyRepro;
        private System.Windows.Forms.NumericUpDown nudEnergyRepro;
        private System.Windows.Forms.Button btnApplyParams;

        private System.Windows.Forms.GroupBox grpEditor;
        private System.Windows.Forms.RadioButton radioPrey;
        private System.Windows.Forms.RadioButton radioPred;
        private System.Windows.Forms.RadioButton radioObs;
        private System.Windows.Forms.RadioButton radioErase;

        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.lblGrid = new System.Windows.Forms.Label();
            this.nudGridSize = new System.Windows.Forms.NumericUpDown();
            this.lblPrey = new System.Windows.Forms.Label();
            this.nudPrey = new System.Windows.Forms.NumericUpDown();
            this.lblPred = new System.Windows.Forms.Label();
            this.nudPredators = new System.Windows.Forms.NumericUpDown();
            this.lblObs = new System.Windows.Forms.Label();
            this.nudObstacles = new System.Windows.Forms.NumericUpDown();
            this.lblOverpop = new System.Windows.Forms.Label();
            this.nudOverpop = new System.Windows.Forms.NumericUpDown();
            this.lblReproRate = new System.Windows.Forms.Label();
            this.nudReproRate = new System.Windows.Forms.NumericUpDown();
            this.lblEnergyGain = new System.Windows.Forms.Label();
            this.nudEnergyGain = new System.Windows.Forms.NumericUpDown();
            this.lblEnergyRepro = new System.Windows.Forms.Label();
            this.nudEnergyRepro = new System.Windows.Forms.NumericUpDown();
            this.btnApplyParams = new System.Windows.Forms.Button();
            this.grpEditor = new System.Windows.Forms.GroupBox();
            this.radioPrey = new System.Windows.Forms.RadioButton();
            this.radioPred = new System.Windows.Forms.RadioButton();
            this.radioObs = new System.Windows.Forms.RadioButton();
            this.radioErase = new System.Windows.Forms.RadioButton();
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPredators)).BeginInit();
            this.grpEditor.SuspendLayout();
            this.grpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // Left
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft);
            this.splitContainer1.Panel1MinSize = 260;
            // Right
            this.splitContainer1.Panel2.Controls.Add(this.panelCanvas);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 650);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLeft.WrapContents = false;
            this.panelLeft.Controls.Add(this.grpControl);
            this.panelLeft.Controls.Add(this.grpParams);
            this.panelLeft.Controls.Add(this.grpEditor);
            this.panelLeft.Controls.Add(this.grpFile);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(8);
            this.panelLeft.Size = new System.Drawing.Size(280, 650);
            this.panelLeft.TabIndex = 0;
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnStart);
            this.grpControl.Controls.Add(this.btnPause);
            this.grpControl.Controls.Add(this.btnStep);
            this.grpControl.Controls.Add(this.btnReset);
            this.grpControl.Location = new System.Drawing.Point(11, 11);
            this.grpControl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(250, 120);
            this.grpControl.TabIndex = 0;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Ovládání";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(130, 25);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 30);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(15, 70);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(100, 30);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "Krok";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(130, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.lblGrid);
            this.grpParams.Controls.Add(this.nudGridSize);
            this.grpParams.Controls.Add(this.lblPrey);
            this.grpParams.Controls.Add(this.nudPrey);
            this.grpParams.Controls.Add(this.lblPred);
            this.grpParams.Controls.Add(this.nudPredators);
            this.grpParams.Controls.Add(this.btnApplyParams);
            this.grpParams.Controls.Add(this.lblObs);
            this.grpParams.Controls.Add(this.nudObstacles);
            this.grpParams.Controls.Add(this.lblOverpop);
            this.grpParams.Controls.Add(this.nudOverpop);
            this.grpParams.Controls.Add(this.lblReproRate);
            this.grpParams.Controls.Add(this.nudReproRate);
            this.grpParams.Controls.Add(this.lblEnergyGain);
            this.grpParams.Controls.Add(this.nudEnergyGain);
            this.grpParams.Controls.Add(this.lblEnergyRepro);
            this.grpParams.Controls.Add(this.nudEnergyRepro);
            this.grpParams.Location = new System.Drawing.Point(11, 144);
            this.grpParams.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(250, 350);
            this.grpParams.TabIndex = 1;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Parametry";
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(12, 28);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(82, 15);
            this.lblGrid.TabIndex = 0;
            this.lblGrid.Text = "Velikost mřížky";
            // 
            // nudGridSize
            // 
            this.nudGridSize.Location = new System.Drawing.Point(140, 26);
            this.nudGridSize.Minimum = 10;
            this.nudGridSize.Maximum = 200;
            this.nudGridSize.Value = 50;
            this.nudGridSize.Name = "nudGridSize";
            this.nudGridSize.Size = new System.Drawing.Size(90, 23);
            this.nudGridSize.TabIndex = 1;
            // 
            // lblPrey
            // 
            this.lblPrey.AutoSize = true;
            this.lblPrey.Location = new System.Drawing.Point(12, 63);
            this.lblPrey.Name = "lblPrey";
            this.lblPrey.Size = new System.Drawing.Size(80, 15);
            this.lblPrey.TabIndex = 2;
            this.lblPrey.Text = "Počet kořisti";
            // 
            // nudPrey
            // 
            this.nudPrey.Location = new System.Drawing.Point(140, 61);
            this.nudPrey.Minimum = 0;
            this.nudPrey.Maximum = 10000;
            this.nudPrey.Value = 200;
            this.nudPrey.Name = "nudPrey";
            this.nudPrey.Size = new System.Drawing.Size(90, 23);
            this.nudPrey.TabIndex = 3;
            // 
            // lblPred
            // 
            this.lblPred.AutoSize = true;
            this.lblPred.Location = new System.Drawing.Point(12, 98);
            this.lblPred.Name = "lblPred";
            this.lblPred.Size = new System.Drawing.Size(95, 15);
            this.lblPred.TabIndex = 4;
            this.lblPred.Text = "Počet predátorů";
            // 
            // nudPredators
            // 
            this.nudPredators.Location = new System.Drawing.Point(140, 96);
            this.nudPredators.Minimum = 0;
            this.nudPredators.Maximum = 10000;
            this.nudPredators.Value = 30;
            this.nudPredators.Name = "nudPredators";
            this.nudPredators.Size = new System.Drawing.Size(90, 23);
            this.nudPredators.TabIndex = 5;
            //
            // lblObs
            //
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 133);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(100, 15);
            this.lblObs.Text = "Počet překážek";
            //
            // nudObstacles
            //
            this.nudObstacles.Location = new System.Drawing.Point(140, 131);
            this.nudObstacles.Minimum = 0;
            this.nudObstacles.Maximum = 10000;
            this.nudObstacles.Value = 20;
            this.nudObstacles.Name = "nudObstacles";
            this.nudObstacles.Size = new System.Drawing.Size(90, 23);
            //
            // lblOverpop
            //
            this.lblOverpop.AutoSize = true;
            this.lblOverpop.Location = new System.Drawing.Point(12, 168);
            this.lblOverpop.Name = "lblOverpop";
            this.lblOverpop.Size = new System.Drawing.Size(120, 15);
            this.lblOverpop.Text = "Limit přemnož. (0=off)";
            //
            // nudOverpop
            //
            this.nudOverpop.Location = new System.Drawing.Point(140, 166);
            this.nudOverpop.Minimum = 0;
            this.nudOverpop.Maximum = 8;
            this.nudOverpop.Value = 0;
            this.nudOverpop.Name = "nudOverpop";
            this.nudOverpop.Size = new System.Drawing.Size(90, 23);
            //
            // lblReproRate
            //
            this.lblReproRate.AutoSize = true;
            this.lblReproRate.Location = new System.Drawing.Point(12, 203);
            this.lblReproRate.Name = "lblReproRate";
            this.lblReproRate.Size = new System.Drawing.Size(122, 15);
            this.lblReproRate.Text = "Rozmnožování (tahy)";
            //
            // nudReproRate
            //
            this.nudReproRate.Location = new System.Drawing.Point(140, 201);
            this.nudReproRate.Minimum = 1;
            this.nudReproRate.Maximum = 100;
            this.nudReproRate.Value = 8;
            this.nudReproRate.Name = "nudReproRate";
            this.nudReproRate.Size = new System.Drawing.Size(90, 23);
            //
            // lblEnergyGain
            //
            this.lblEnergyGain.AutoSize = true;
            this.lblEnergyGain.Location = new System.Drawing.Point(12, 238);
            this.lblEnergyGain.Name = "lblEnergyGain";
            this.lblEnergyGain.Size = new System.Drawing.Size(121, 15);
            this.lblEnergyGain.Text = "Energie za kořist";
            //
            // nudEnergyGain
            //
            this.nudEnergyGain.Location = new System.Drawing.Point(140, 236);
            this.nudEnergyGain.Minimum = 1;
            this.nudEnergyGain.Maximum = 100;
            this.nudEnergyGain.Value = 4;
            this.nudEnergyGain.Name = "nudEnergyGain";
            this.nudEnergyGain.Size = new System.Drawing.Size(90, 23);

            //
            // lblEnergyRepro
            //
            this.lblEnergyRepro.AutoSize = true;
            this.lblEnergyRepro.Location = new System.Drawing.Point(12, 273);
            this.lblEnergyRepro.Name = "lblEnergyRepro";
            this.lblEnergyRepro.Size = new System.Drawing.Size(111, 15);
            this.lblEnergyRepro.Text = "Energie k rozmnož.";
            //
            // nudEnergyRepro
            //
            this.nudEnergyRepro.Location = new System.Drawing.Point(140, 271);
            this.nudEnergyRepro.Minimum = 1;
            this.nudEnergyRepro.Maximum = 500;
            this.nudEnergyRepro.Value = 20;
            this.nudEnergyRepro.Name = "nudEnergyRepro";
            this.nudEnergyRepro.Size = new System.Drawing.Size(90, 23);
            //
            // btnApplyParams
            //
            this.btnApplyParams.Location = new System.Drawing.Point(15, 310);
            this.btnApplyParams.Name = "btnApplyParams";
            this.btnApplyParams.Size = new System.Drawing.Size(215, 30);
            this.btnApplyParams.TabIndex = 6;
            this.btnApplyParams.Text = "Použít parametry";
            this.btnApplyParams.UseVisualStyleBackColor = true;
            this.btnApplyParams.Click += new System.EventHandler(this.btnApplyParams_Click);    
            // 
            // grpEditor
            // 
            this.grpEditor.Controls.Add(this.radioPrey);
            this.grpEditor.Controls.Add(this.radioPred);
            this.grpEditor.Controls.Add(this.radioObs);
            this.grpEditor.Controls.Add(this.radioErase);
            this.grpEditor.Location = new System.Drawing.Point(11, 347);
            this.grpEditor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Size = new System.Drawing.Size(250, 150);
            this.grpEditor.TabIndex = 2;
            this.grpEditor.TabStop = false;
            this.grpEditor.Text = "Editor mřížky";
            // 
            // radioPrey
            // 
            this.radioPrey.AutoSize = true;
            this.radioPrey.Location = new System.Drawing.Point(15, 25);
            this.radioPrey.Name = "radioPrey";
            this.radioPrey.Size = new System.Drawing.Size(91, 19);
            this.radioPrey.TabIndex = 0;
            this.radioPrey.Text = "Přidat kořist";
            this.radioPrey.CheckedChanged += new System.EventHandler(this.radioPrey_CheckedChanged);
            // 
            // radioPred
            // 
            this.radioPred.AutoSize = true;
            this.radioPred.Location = new System.Drawing.Point(15, 50);
            this.radioPred.Name = "radioPred";
            this.radioPred.Size = new System.Drawing.Size(114, 19);
            this.radioPred.TabIndex = 1;
            this.radioPred.Text = "Přidat predátora";
            this.radioPred.CheckedChanged += new System.EventHandler(this.radioPred_CheckedChanged);
            // 
            // radioObs
            // 
            this.radioObs.AutoSize = true;
            this.radioObs.Location = new System.Drawing.Point(15, 75);
            this.radioObs.Name = "radioObs";
            this.radioObs.Size = new System.Drawing.Size(109, 19);
            this.radioObs.TabIndex = 2;
            this.radioObs.Text = "Přidat překážku";
            this.radioObs.CheckedChanged += new System.EventHandler(this.radioObs_CheckedChanged);
            // 
            // radioErase
            // 
            this.radioErase.AutoSize = true;
            this.radioErase.Location = new System.Drawing.Point(15, 100);
            this.radioErase.Name = "radioErase";
            this.radioErase.Size = new System.Drawing.Size(59, 19);
            this.radioErase.TabIndex = 3;
            this.radioErase.Text = "Guma";
            this.radioErase.CheckedChanged += new System.EventHandler(this.radioErase_CheckedChanged);
            // 
            // grpFile
            // 
            this.grpFile.Controls.Add(this.btnSave);
            this.grpFile.Controls.Add(this.btnLoad);
            this.grpFile.Location = new System.Drawing.Point(11, 510);
            this.grpFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(250, 100);
            this.grpFile.TabIndex = 3;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "Soubor";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(130, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Načíst";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // btnStats
            //
            this.btnStats = new System.Windows.Forms.Button();
            this.btnStats.Location = new System.Drawing.Point(15, 65);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(215, 30);
            this.btnStats.TabIndex = 2;
            this.btnStats.Text = "Statistiky";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            this.grpFile.Controls.Add(this.btnStats);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCanvas.Location = new System.Drawing.Point(0, 0);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(716, 650);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Predator & Prey – Simulace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.grpControl.ResumeLayout(false);
            this.grpParams.ResumeLayout(false);
            this.grpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPredators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudObstacles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverpop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReproRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergyGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergyRepro)).EndInit();
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            this.grpFile.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
