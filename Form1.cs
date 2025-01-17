﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platFromegame
{
    public partial class Form1 : Form
    {
        bool goleft = false;
        bool goright = false;
        bool jumping = false;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Top += jumpSpeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goleft)
            {
                player.Left -= 5;
            }

            if (goright)
            {
                player.Left += 5;
            }

            if (jumping)
            {
                jumpSpeed = -12;//12
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;//12
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }

                if (x is PictureBox && x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        this.Controls.Remove(x);
                        score++;
                    }
                }
            }
            if (player.Bounds.IntersectsWith(door.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("You WIN");
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goleft = true;

            if (e.KeyCode == Keys.Right)
                goright = true;

            if (e.KeyCode == Keys.Space && !jumping)
                jumping = true;
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goleft = false;
            
            if (e.KeyCode == Keys.Right)
                goright = false;

            if (jumping)
                jumping = false;
            
        }


        private void door_Click(object sender, EventArgs e)
        {
            
        }
    }
}
