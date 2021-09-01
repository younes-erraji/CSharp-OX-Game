using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOX
{
    public partial class FormOX : Form
    {
        public FormOX()
        {
            InitializeComponent();
        }

        private void FormOX_Load(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            label_Joueur1.Text = name1;
            label_Joueur2.Text = name2;CheckWinner();
        }
        bool t = true;
        int t_count = 0;
        static string name1, name2;
        private void buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (t) b.Text = "X";
            else   b.Text = "O";
            t = !t;
            b.Enabled = false;
            t_count++;
            CheckWinner();
        }
        private void CheckWinner()
        {
            bool b = false;
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            { b = true; }
            else
            {
                if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
                { b = true; }
                else
                {
                    if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
                    { b = true; }
                    else
                    {
                        if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                        { b = true; }
                        else
                        {
                            if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                            { b = true; }
                            else
                            {
                                if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                                { b = true; }
                                else
                                {
                                    if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                                    { b = true; }
                                    else
                                    {
                                        if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
                                        { b = true; }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (b)
            { string s;
                if (t)
                {
                    int a = Convert.ToInt32(label_Winner1.Text);
                    a++;
                    label_Winner1.Text = a.ToString();
                    s = label_Joueur1.Text;
                    EnableButtons();
                }
                else {
                    int a = Convert.ToInt32(label_Winner2.Text);
                    a++;
                    label_Winner2.Text = a.ToString();
                    s = label_Joueur2.Text;
                    EnableButtons();
                }
                MessageBox.Show(s + "Won");
                t_count = 0;
            }
            else if(t_count==9)
            {
                MessageBox.Show("Draw");
                t_count = 0;
                EnableButtons();
                int a = Convert.ToInt32(label_Draw.Text);
                a++;
                label_Draw.Text = a.ToString();
            }
        }
        private void EnableButtons()
        {
            foreach(Control c in Controls) {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (t && b.Enabled)
                b.Text = "X";
            if (!t && b.Enabled)
                b.Text = "O";
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableButtons();
            label_Winner1.Text = "0";
            label_Winner2.Text = "0";
            label_Draw.Text = "0";
            t_count = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static void PlayersName(string p1,string p2)
        {
            name1 = p1;
            name2 = p2;
        }
    }
}
