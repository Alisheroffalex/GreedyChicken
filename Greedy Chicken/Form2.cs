using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greedy_Chicken
{
    public partial class Form2 : Form
    {
        private int playerCount = 0;
        private List<GroupBox> playerBoxes;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenColorPallate(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var myBtn = (Panel)sender;
                myBtn.BackColor = colorDialog1.Color;
            }
        }

        private void confirmClick(object sender, EventArgs e)
        {
            int playersNumber = Convert.ToInt32(this.playersNumber.Text);
            int goals = Convert.ToInt32(this.goals.Text);
            if (playersNumber <= 4 && playersNumber > 0 )
            {
                if(goals > 0)
                {
                    this.switchPlayerBoxes(playersNumber);
                } else
                {
                    MessageBox.Show("Parameters was out of range. Must be non-negative number. \nParameter name: Goals");
                }
            } else
            {
                MessageBox.Show("Parameters was out of range. Must be non-negative and less than the size of the collection. \nParameter name: Number of Players");
            }
        }

        private void switchPlayerBoxes(int playersCount)
        {
            this.playerCount = playersCount;
            this.groupBox2.Enabled = true;
            this.playerBoxes = new List<GroupBox>() { this.groupBox3, this.groupBox4, this.groupBox5, this.groupBox6 };

            for (int i = 0; i < playerCount; i++)
            {
                playerBoxes[i].Enabled = true;
            }

            this.groupBox1.Enabled = false;
            this.button6.Enabled = true;
        }

        private void startGameClick(object sender, EventArgs e)
        {
            for (int i = 0; i < playerCount; i++)
            {
                string playerName = playerBoxes[i].Controls[2].Text;
                System.Drawing.Color playerColor = playerBoxes[i].Controls[0].BackColor;

                Players.playersCollection.Add(
                    new Player(playerName, playerColor)
                ) ;

                
            }
            Players.gameTotalScore = Convert.ToInt32(goals.Text);



            this.Hide();

            Form3 form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.initGameWindow(playerCount);
        }
    }
}
