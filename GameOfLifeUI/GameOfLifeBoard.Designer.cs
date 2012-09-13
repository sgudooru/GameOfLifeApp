namespace GameOfLifeUI
{
    partial class GameOfLifeBoard
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
            this.components = new System.ComponentModel.Container();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.customPanel = new System.Windows.Forms.Panel();
            this.lbLiveCellsExample = new System.Windows.Forms.Label();
            this.lbLiveCells = new System.Windows.Forms.Label();
            this.lbColumn = new System.Windows.Forms.Label();
            this.lbRows = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.tbLiveCells = new System.Windows.Forms.TextBox();
            this.numColumns = new System.Windows.Forms.NumericUpDown();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.cbPatternSelector = new System.Windows.Forms.ComboBox();
            this.selectionPanel.SuspendLayout();
            this.customPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.SuspendLayout();
            // 
            // ticker
            // 
            this.ticker.Interval = 750;
            this.ticker.Tick += new System.EventHandler(this.tickerTickAction);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 113);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(344, 299);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // selectionPanel
            // 
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectionPanel.Controls.Add(this.customPanel);
            this.selectionPanel.Controls.Add(this.cbPatternSelector);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectionPanel.Location = new System.Drawing.Point(0, 0);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(344, 113);
            this.selectionPanel.TabIndex = 2;
            // 
            // customPanel
            // 
            this.customPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel.Controls.Add(this.lbLiveCellsExample);
            this.customPanel.Controls.Add(this.lbLiveCells);
            this.customPanel.Controls.Add(this.lbColumn);
            this.customPanel.Controls.Add(this.lbRows);
            this.customPanel.Controls.Add(this.btStart);
            this.customPanel.Controls.Add(this.tbLiveCells);
            this.customPanel.Controls.Add(this.numColumns);
            this.customPanel.Controls.Add(this.numRows);
            this.customPanel.Enabled = false;
            this.customPanel.Location = new System.Drawing.Point(12, 31);
            this.customPanel.Name = "customPanel";
            this.customPanel.Size = new System.Drawing.Size(318, 74);
            this.customPanel.TabIndex = 1;
            // 
            // lbLiveCellsExample
            // 
            this.lbLiveCellsExample.AutoSize = true;
            this.lbLiveCellsExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLiveCellsExample.ForeColor = System.Drawing.Color.Red;
            this.lbLiveCellsExample.Location = new System.Drawing.Point(69, 56);
            this.lbLiveCellsExample.Name = "lbLiveCellsExample";
            this.lbLiveCellsExample.Size = new System.Drawing.Size(49, 13);
            this.lbLiveCellsExample.TabIndex = 7;
            this.lbLiveCellsExample.Text = "Ex: 2,3,4";
            // 
            // lbLiveCells
            // 
            this.lbLiveCells.AutoSize = true;
            this.lbLiveCells.Location = new System.Drawing.Point(12, 34);
            this.lbLiveCells.Name = "lbLiveCells";
            this.lbLiveCells.Size = new System.Drawing.Size(51, 13);
            this.lbLiveCells.TabIndex = 6;
            this.lbLiveCells.Text = "Live cells";
            // 
            // lbColumn
            // 
            this.lbColumn.AutoSize = true;
            this.lbColumn.Location = new System.Drawing.Point(169, 6);
            this.lbColumn.Name = "lbColumn";
            this.lbColumn.Size = new System.Drawing.Size(47, 13);
            this.lbColumn.TabIndex = 5;
            this.lbColumn.Text = "Columns";
            // 
            // lbRows
            // 
            this.lbRows.AutoSize = true;
            this.lbRows.Location = new System.Drawing.Point(12, 8);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(34, 13);
            this.lbRows.TabIndex = 4;
            this.lbRows.Text = "Rows";
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.Location = new System.Drawing.Point(245, 29);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(66, 23);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbLiveCells
            // 
            this.tbLiveCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLiveCells.Location = new System.Drawing.Point(69, 31);
            this.tbLiveCells.Name = "tbLiveCells";
            this.tbLiveCells.Size = new System.Drawing.Size(170, 20);
            this.tbLiveCells.TabIndex = 2;
            // 
            // numColumns
            // 
            this.numColumns.Location = new System.Drawing.Point(222, 4);
            this.numColumns.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColumns.Name = "numColumns";
            this.numColumns.Size = new System.Drawing.Size(75, 20);
            this.numColumns.TabIndex = 1;
            this.numColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(69, 6);
            this.numRows.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(75, 20);
            this.numRows.TabIndex = 0;
            this.numRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbPatternSelector
            // 
            this.cbPatternSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatternSelector.FormattingEnabled = true;
            this.cbPatternSelector.Location = new System.Drawing.Point(12, 4);
            this.cbPatternSelector.Name = "cbPatternSelector";
            this.cbPatternSelector.Size = new System.Drawing.Size(121, 21);
            this.cbPatternSelector.TabIndex = 0;
            this.cbPatternSelector.SelectedIndexChanged += new System.EventHandler(this.cbPatternSelector_SelectedIndexChanged);
            // 
            // GameOfLifeBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(344, 412);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.selectionPanel);
            this.MinimumSize = new System.Drawing.Size(360, 450);
            this.Name = "GameOfLifeBoard";
            this.Text = "Game of Life";
            this.selectionPanel.ResumeLayout(false);
            this.customPanel.ResumeLayout(false);
            this.customPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ticker;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.ComboBox cbPatternSelector;
        private System.Windows.Forms.Panel customPanel;
        private System.Windows.Forms.NumericUpDown numColumns;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbLiveCells;
        private System.Windows.Forms.Label lbLiveCells;
        private System.Windows.Forms.Label lbColumn;
        private System.Windows.Forms.Label lbRows;
        private System.Windows.Forms.Label lbLiveCellsExample;
    }
}

