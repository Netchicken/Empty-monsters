using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpClassMovingMonsters.Business;
using CSharpClassMovingMonsters.Business.AllPunters;

namespace CSharpClassMovingMonsters
{
    public partial class Form1 : Form
    {
        //Create my monsters
        Monster[] monster = new Monster[4];
        Punter[] myPunter = new Punter[3]; //all our punters

        Punter CurrentPunter = new Howard(); //used in the code for a default punter

        //which monster wins
        private string MonsterWinner;

        public Form1()
        {
            InitializeComponent();
            LoadMonsters();
            LoadPunters();

        }

        #region Load The Monsters and Punters
        private void LoadMonsters()
        {
            //make an instance of our monster
            monster[0] = new Monster { Length = 0, myPB = pb1, Name = "Agor" };
            monster[0].myPB.BackgroundImage = Resource1.Agor;
            monster[1] = new Monster { Length = 0, myPB = pb2, Name = "Igor" };
            monster[1].myPB.BackgroundImage = Resource1.Igor;
            monster[2] = new Monster { Length = 0, myPB = pb3, Name = "Ogor" };
            monster[2].myPB.BackgroundImage = Resource1.Ogor;
            monster[3] = new Monster { Length = 0, myPB = pb4, Name = "Ugor" };
            monster[3].myPB.BackgroundImage = Resource1.Ugor;
        }

        private void LoadPunters()
        {
            for (int i = 0; i < 3; i++)
            {
                myPunter[i] = Factory.GetAPunter(i);
                //myPunter[0] which is howard is a New Howard
                myPunter[i].LabelWinner = lblWinner;

            }

        }
        #endregion


        private void RunRace()
        {

            bool end = false;
            //create a random number generator
            Random myrand = new Random();
            Random myrandStop = new Random();

            //while we havn't reached the end then keep on looping

            while (end != true) // while the end is not true
            {
                for (int i = 0; i < 4; i++)
                { //use the random generator
                    monster[i].myPB.Left += myrand.Next(1, 11);

                    //50% of the time it takes 8 off the left wwhich makes it go back
                    if (myrandStop.Next(1, 3) == 2)
                    {
                        monster[i].myPB.Left -= 4;
                    }
                    //    Application.DoEvents();
                    //if the monster greater than  the form minue the width of the picturebox then stop
                    if (monster[i].myPB.Left > Form1.ActiveForm.Width - monster[i].myPB.Width - 40)
                    {
                        end = true; //loop until end = true

                        this.Text = monster[i].Name + " THE MONSTER HAS WON!!!";
                        //this is the monster that won the race
                        MonsterWinner = monster[i].Name;
                    }
                }
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            RunRace();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.Text = "";
            //reset the left to 10 for the next race
            for (int i = 0; i < 4; i++)
            {
                monster[i].myPB.Left = 10;
            }


        }

        private void AllRB_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton fakeRB = new RadioButton();
            fakeRB = (RadioButton)sender;

            //if (fakeRB.Checked == true)
            //{
            //look for the name of the person we have clicked on
            switch (fakeRB.Text)
            {
                //instantiate that punter
                case "Howard":
                    CurrentPunter = myPunter[0];
                    break;
                case "Susan":
                    CurrentPunter = myPunter[1];
                    break;
                case "John":
                    CurrentPunter = myPunter[2];
                    break;
            }

            // }
            udBet.Maximum = (decimal)CurrentPunter.Cash;

        }

        private void BtnBets_Click(object sender, EventArgs e)
        {

            CurrentPunter.Bet = (float)udBet.Value;

            lblBettorName.Text += CurrentPunter.PunterName + " Bets " + CurrentPunter.Bet + Environment.NewLine;


        }
    }
}
