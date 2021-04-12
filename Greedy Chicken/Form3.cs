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
    public partial class Form3 : Form
    {
        private List<Panel> panels;
        private List<PictureBox> pictures;
        private int ActivePlayerIndex = 0;

        public Form3()
        {
            InitializeComponent();
            this.panels = new List<Panel> { this.panel1, this.panel2, this.panel3, this.panel4 };
            this.pictures = new List<PictureBox> { this.pictureBox1, this.pictureBox2, this.pictureBox3, this.pictureBox4, this.pictureBox5, this.pictureBox6 };
        }

        public void initGameWindow(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {
                this.panels[i].BackColor = Players.playersCollection[i].playerColor;
                this.panels[i].Visible = true;
                this.panels[i].Controls[4].Text = Players.playersCollection[i].name;
                setActivePlayerColor(Players.playersCollection[ActivePlayerIndex]);
                
            }
            this.Show();
        }


        private void setActivePlayerColor(Player player)
        {
            this.rollButton.BackColor = player.playerColor;
            this.SaveButton.BackColor = player.playerColor;

            this.turnText.Text = $"It`s {player.name} turn to roll!";
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            this.sorryText.Visible = false;

            int randomedScore = RandomScore();
            Player activePlayer = Players.playersCollection[ActivePlayerIndex];

            showScorePicture(randomedScore);

            if(randomedScore == 0)
            {
                activePlayer.bank = 0;
                this.sorryText.Visible = true;
                this.savePlayerScore();
            } else
            {
                activePlayer.bank += randomedScore++;

                initPlayerScores(activePlayer);

                this.SaveButton.Enabled = true;
            }

            
        }

        private int RandomScore()
        {
            Random rnd = new Random();
            return rnd.Next(0, 6);
        }

        private void showScorePicture(int index)
        {
            for(int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Visible = false;
            }

            pictures[index].Visible = true;
        }

        private void initPlayerScores(Player player)
        {
            this.panels[ActivePlayerIndex].Controls[0].Text = player.bank.ToString();
            this.panels[ActivePlayerIndex].Controls[2].Text = player.score.ToString();

        }

        private void savePlayerScore()
        {
            Player activePlayer = Players.playersCollection[ActivePlayerIndex];


            activePlayer.score += activePlayer.bank;
            activePlayer.bank = 0;
            initPlayerScores(activePlayer);

            if(activePlayer.score >= Players.gameTotalScore)
            {
                MessageBox.Show($"{activePlayer.name} won the game!");
                this.rollButton.Enabled = false;
                this.SaveButton.Enabled = false;
            }

            this.SaveButton.Enabled = false;

            ActivePlayerIndex++;
            if (ActivePlayerIndex > (Players.playersCollection.Count - 1))
            {
                ActivePlayerIndex = 0;
            }

            setActivePlayerColor(Players.playersCollection[ActivePlayerIndex]);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.savePlayerScore();
        }
    }
}
