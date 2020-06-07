using System;
using System.Windows.Forms;

namespace CSharpClassMovingMonsters
{
    public partial class Form1 : Form
    {
        //Create my monsters
        //   Monster[] monster = new Monster[4];
        //   Punter[] myPunter = new Punter[3]; //all our punters

        //   Punter CurrentPunter = new Howard(); //used in the code for a default punter

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


        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            RunRace();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {


        }

        private void AllRB_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton fakeRB = new RadioButton();
            fakeRB = (RadioButton)sender;

            //if (fakeRB.Checked == true)
            //{
            //look for the name of the person we have clicked on


            // }


        }

        private void BtnBets_Click(object sender, EventArgs e)
        {

            CurrentPunter.Bet = (float)udBet.Value;

            lblBettorName.Text += CurrentPunter.PunterName + " Bets " + CurrentPunter.Bet + Environment.NewLine;


        }
    }
}
