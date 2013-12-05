using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using EncryptionAlgorithms;

namespace VisualizedCrypto
{
    public partial class Form1 : Form
    {

        private SimpleCrypto.ICryptoService PBKDF2;
        private Hill HILL;
        private Ceaser CEASAR;
        private RowTransposition ROWT;
        public Form1()
        {
            InitializeComponent();
            InitializeTips();
            InitializeAlgorithms();
        }

        private void InitializeAlgorithms()
        {
            //pbkdf2
            PBKDF2 = new SimpleCrypto.PBKDF2();

            //hill
            int[,] matrix = new int[3, 3];

            matrix[0, 0] = 17;
            matrix[0, 1] = 21;
            matrix[0, 2] = 2;

            matrix[1, 0] = 17;
            matrix[1, 1] = 18;
            matrix[1, 2] = 2;

            matrix[2, 0] = 5;
            matrix[2, 1] = 21;
            matrix[2, 2] = 19;

            HILL = new Hill(matrix);

            //ceasar
            CEASAR = new Ceaser(3);

            //Row Transposition
            ROWT = new RowTransposition(new int[] {4,3,1,2,5,6,7});
        }

        private void InitializeTips()
        {
            ToolTip tips = new ToolTip();
            // Set up the delays for the ToolTip.
            tips.AutoPopDelay = 5000;
            tips.InitialDelay = 1000;
            tips.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tips.ShowAlways = true;
            //set em up
            tips.SetToolTip(label3, "The longer the salt the safer (until around 128 characters)");
            tips.SetToolTip(label2, "The more iterations, the longer it takes to hash");
            tips.SetToolTip(label4, "The password hash, which we store");
            tips.SetToolTip(label5, "The salt in the form of <length>.<salt>, which we store");
            tips.SetToolTip(label6, "This is how long it took to hash");
            tips.SetToolTip(label10, "A guess to validate; enter to submit, green/red color indicates result");
            tips.SetToolTip(label1, "A message to hash; enter to submit");
            tips.SetToolTip(label12, "A message to encrypt using a Hill cipher. if it's not /3, we pad it with a's");
            tips.SetToolTip(label16, "A message to encrypt using a Cesar cipher");
            tips.SetToolTip(label19, "A message to encrypt using a Row Transposition");

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Stopwatch t = new Stopwatch();
                t.Start();
                textBox3.Text = PBKDF2.Compute(textBox1.Text, trackBar1.Value, trackBar2.Value);
                t.Stop();
                textBox2.Text = PBKDF2.Salt;
                textBox4.Text = t.ElapsedMilliseconds.ToString() + "ms";
            }
        }


        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                String result = PBKDF2.Compute(textBox6.Text, textBox5.Text);
                if (textBox8.Text == result)
                {
                    textBox6.BackColor = Color.Green;
                }
                else
                {
                    textBox6.BackColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox3.Text;
            textBox5.Text = textBox2.Text;
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            //well this sucks but researching was slower
            switch(e.KeyCode)
            {
                case Keys.A:
                    break;
                case Keys.B:
                    break;
                case Keys.C:
                    break;
                case Keys.D:
                    break;
                case Keys.E:
                    break;
                case Keys.F:
                    break;
                case Keys.G:
                    break;
                case Keys.H:
                    break;
                case Keys.I:
                    break;
                case Keys.J:
                    break;
                case Keys.K:
                    break;
                case Keys.L:
                    break;
                case Keys.M:
                    break;
                case Keys.N:
                    break;
                case Keys.O:
                    break;
                case Keys.P:
                    break;
                case Keys.Q:
                    break;
                case Keys.R:
                    break;
                case Keys.S:
                    break;
                case Keys.T:
                    break;
                case Keys.U:
                    break;
                case Keys.V:
                    break;
                case Keys.W:
                    break;
                case Keys.X:
                    break;
                case Keys.Y:
                    break;
                case Keys.Z:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                default:
                    e.SuppressKeyPress = true;
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                while (textBox7.Text.Length % 3 !=0)
                {
                    textBox7.Text += 'a'; //pad with a's.....shutup, do you have a better idea?
                }

                textBox9.Text = HILL.Encrypt(textBox7.Text.ToLower()); //on enter we encrypt and show
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            //well this sucks but researching was slower
            switch (e.KeyCode)
            {
                case Keys.A:
                    break;
                case Keys.B:
                    break;
                case Keys.C:
                    break;
                case Keys.D:
                    break;
                case Keys.E:
                    break;
                case Keys.F:
                    break;
                case Keys.G:
                    break;
                case Keys.H:
                    break;
                case Keys.I:
                    break;
                case Keys.J:
                    break;
                case Keys.K:
                    break;
                case Keys.L:
                    break;
                case Keys.M:
                    break;
                case Keys.N:
                    break;
                case Keys.O:
                    break;
                case Keys.P:
                    break;
                case Keys.Q:
                    break;
                case Keys.R:
                    break;
                case Keys.S:
                    break;
                case Keys.T:
                    break;
                case Keys.U:
                    break;
                case Keys.V:
                    break;
                case Keys.W:
                    break;
                case Keys.X:
                    break;
                case Keys.Y:
                    break;
                case Keys.Z:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                default:
                    e.SuppressKeyPress = true;
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox10.Text = CEASAR.Encrypt(textBox11.Text.ToLower()); //on enter we encrypt and show
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            //well this sucks but researching was slower
            switch (e.KeyCode)
            {
                case Keys.A:
                    break;
                case Keys.B:
                    break;
                case Keys.C:
                    break;
                case Keys.D:
                    break;
                case Keys.E:
                    break;
                case Keys.F:
                    break;
                case Keys.G:
                    break;
                case Keys.H:
                    break;
                case Keys.I:
                    break;
                case Keys.J:
                    break;
                case Keys.K:
                    break;
                case Keys.L:
                    break;
                case Keys.M:
                    break;
                case Keys.N:
                    break;
                case Keys.O:
                    break;
                case Keys.P:
                    break;
                case Keys.Q:
                    break;
                case Keys.R:
                    break;
                case Keys.S:
                    break;
                case Keys.T:
                    break;
                case Keys.U:
                    break;
                case Keys.V:
                    break;
                case Keys.W:
                    break;
                case Keys.X:
                    break;
                case Keys.Y:
                    break;
                case Keys.Z:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                default:
                    e.SuppressKeyPress = true;
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox12.Text = ROWT.Encrypt(textBox13.Text.ToLower()); //on enter we encrypt and show
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This app demonstrates a variety of both hashing and "+
            "encrypting methods, commonly used in the real world, and that use linear/vector algebra."+
            " To get more information about any input fields, simply hover over their labels.","visualized-crypto help");
        }

        

    }
}
