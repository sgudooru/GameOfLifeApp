using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using GameOfLifeLib;

namespace GameOfLifeUI
{
    public partial class GameOfLifeBoard : Form
    {

        bool[,] pattern;
        Generator generator;
        int boxSize = 15;

        public GameOfLifeBoard()
        {
            generator = new Generator();
            InitializeComponent();
            InitControls();
        }

        private void tickerTickAction(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < pattern.GetLength(0); i++)
                    for (int j = 0; j < pattern.GetLength(1); j++)
                    {
                        DrawBox(new Point(j, i), true);

                        if (pattern[i, j])
                            DrawBox(new Point(j, i), false);
                    }
                pattern = generator.NextGeneration(pattern);
            }
            catch (NullReferenceException)
            {
                ticker.Stop();
                MessageBox.Show("Pattern doesn't have any cells. NULL found.", this.Text);
            }
        }

        private void DrawBox(Point location, bool isErase)
        {
            int rectFillSize = boxSize + 2;
            Color cellColour = Color.Green;

            if (isErase) cellColour = mainPanel.BackColor;

            mainPanel.CreateGraphics().FillRectangle(new SolidBrush(cellColour), new Rectangle(rectFillSize * location.X + 1, rectFillSize * location.Y + 1, boxSize, boxSize));
        }

        private void InitControls()
        {
            DataTable dtPatterns = new DataTable("Pattern");
            dtPatterns.Columns.Add("Name");
            dtPatterns.Columns.Add("Rows");
            dtPatterns.Columns.Add("Columns");
            dtPatterns.Columns.Add("Values");

            try
            {
                dtPatterns.Rows.Add("Select a Pattern", 0, 0, "0");
                dtPatterns.ReadXml("patterns.xml");
                dtPatterns.Rows.Add("<Custom>", 0, 0, "0");
                cbPatternSelector.DataSource = dtPatterns;
                cbPatternSelector.DisplayMember = "Name";

                this.cbPatternSelector.SelectedIndexChanged += new EventHandler(cbPatternSelector_SelectedIndexChanged);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Pattern XML File Not Found.", this.Text);
            }
        }

        void ClearBoard()
        {
            if (pattern != null)
            {
                for (int i = 0; i < pattern.GetLength(0); i++)
                    for (int j = 0; j < pattern.GetLength(1); j++)
                        DrawBox(new Point(j, i), true);
            }
        }

        int[] ConvertStringArrayToIntArray(String[] strings)
        {
            int[] liveCells = new int[strings.Length];

            int number = -1;

            for (int i = 0; i < strings.Length; i++)
            {
                if (Int32.TryParse(strings[i], out number))
                    liveCells[i] = number;
                else
                    liveCells[i] = -1;
            }

            return liveCells;
        }

        void cbPatternSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ticker.Stop();

            ClearBoard();

            DataRowView rowView = (DataRowView)(cbPatternSelector.SelectedItem);

            customPanel.Enabled = rowView.Row[0].Equals("<Custom>");

            if (!customPanel.Enabled)
            {
                pattern = GameOfLifeHelper.CreatePattern(new int[] { Convert.ToInt32(rowView.Row[1]), Convert.ToInt32(rowView.Row[2]) }, ConvertStringArrayToIntArray(rowView.Row[3].ToString().Split(',')));
                ticker.Start();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            pattern = GameOfLifeHelper.CreatePattern(new int[] { Convert.ToInt32(numRows.Value), Convert.ToInt32(numColumns.Value) }, ConvertStringArrayToIntArray(tbLiveCells.Text.Split(',')));
            ticker.Start();
            customPanel.Enabled = false;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < mainPanel.Size.Width; i += boxSize + 2)
                for (int j = 0; j < mainPanel.Size.Height; j += boxSize + 2)
                    mainPanel.CreateGraphics().DrawRectangle(new Pen(Color.LightGray), new Rectangle(i, j, boxSize + 1, boxSize + 1));
        }
    }
}
