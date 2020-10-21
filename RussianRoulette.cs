using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class RussianRoulette : Form
    {
        //  Random number generator
        private static Random generator = new Random();

        int totalPlayers = 2;
        int Winner = 0;
        int Loser = 0;
        bool loadGun = false;
        int chamberPosition = 0;
        int bulletPosition = 0;
        int round = 1;


        private void RussianRoulette_Load(object sender, EventArgs e)
        {
            btnSpinChamber.Enabled = false;
        }
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            btnSpinChamber.Enabled = false;
            btnLoadBullet.Enabled = true;
            btnFire.Enabled = false;
            chamberPosition = 0;
            bulletPosition = 0;
            lblDead.Visible = false;
            loadGun = false;


            lblResult.Visible = false;
            round = 1;
        }
        public async Task WaitForPlayerAsync()
        {
            await Task.Delay(1000);
        }
        public int spinChamber()
        {

            return generator.Next(1, 7);

        }

        public async Task<int> gamePlayAsync(int numPlayers, int currentChamber, int bulletChamber)
        {
            for (int i = 1; i <= numPlayers; i++)
            {

                if (i == 1)
                {
                    lblPlayer.Text = "Your Turn";

                }
                else
                {
                    lblPlayer.Text = "Player " + i + " trun";


                }


                if (currentChamber == bulletChamber)
                {
                    SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\FireSound\\Fire.wav");
                    simpleSound.Play();
                    lblDead.Visible = true;
                    if (i == 1)
                    {
                        lblDead.Text = "You Dead!!!";


                        lblResult.Text = "LOSE GAME!!!";

                        lblResult.Visible = true;
                        Loser++;
                        lblLose.Text = Loser.ToString();
                    }
                    else
                    {
                        lblDead.Text = "Player " + i + " is Dead!!!";


                        lblResult.Text = "WIN GAME!!!";

                        lblResult.Visible = true;
                        Winner++;
                        lblWin.Text = Winner.ToString();
                    }


                    return -1;

                }
                else
                {

                    if (i == 1)
                    {
                        lblResult.Text = "You Are Lucky";
                    }
                    else
                    {
                        lblResult.Text = "Player " + i + " is Lucky";
                    }

                    lblResult.Visible = true;
                    await WaitForPlayerAsync();

                    lblResult.Visible = false;


                }
                if (currentChamber == 6)
                {

                    currentChamber = 1;

                }
                else
                {

                    currentChamber++;

                }


            }
            return currentChamber;


        }



        private async void btnFire_ClickAsync(object sender, EventArgs e)
        {
            btnFire.Enabled = false;
            //Play the game on fire buuton click
            int currentChamber =await gamePlayAsync(totalPlayers, chamberPosition, bulletPosition);
            chamberPosition = currentChamber;

            if (currentChamber == -1)
            {

                lblPlayer.Text = "";
                btnFire.Enabled = false;
            }
            else
            {

                lblResult.Visible = false;

                lblPlayer.Text = "Your Turn";
                btnFire.Enabled = true;
                round++;
                lblResult.Text = "Round " + round;
                lblResult.Visible = true;
            }

        }
        

        private void btnSpinChamber_Click(object sender, EventArgs e)
        {
            if (loadGun == true)
            {


                chamberPosition = spinChamber(); //Set Chamber to start game
                bulletPosition = spinChamber(); //Bullet is which chamber
                lblPlayer.Text = "Your Turn";
                btnFire.Enabled = true;
                btnSpinChamber.Enabled = false;

                lblResult.Text = "Round 1";
                lblResult.Visible = true;

            }
            else
            {
                MessageBox.Show("Load Gun");
            }
        }
        private void btnLoadBullet_Click(object sender, EventArgs e)
        {
            loadGun = true;
            btnSpinChamber.Enabled = true;
            btnLoadBullet.Enabled = false;

            round = 1;
        }
        public RussianRoulette()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
