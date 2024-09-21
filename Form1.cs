using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        StringBuilder _formattedTimer = new StringBuilder();
        
        TimeSpan _timer = new TimeSpan(0, 0, 60);

        short _counter = 0;

        List<Button> _lstButtons = new List<Button>();

        Button _currentButton = null;

        enum enTagNames { Green, Blue, Yellow, Pink, Red, Unknown};

        private Image _pink = Properties.Resources.cropped__2_;
        private Image _green = Properties.Resources.cropped__6_;
        private Image _yellow = Properties.Resources.cropped__3_;
        private Image _blue = Properties.Resources.cropped__5_;
        private Image _red = Properties.Resources.cropped__1_;
        private Image _unknown = Properties.Resources.photo_2023_11_03_23_45_31;


        private void AddButtonsToList()
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button btn)
                {
                    _lstButtons.Add(btn);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddButtonsToList();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn10.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan OneSecond = new TimeSpan(0, 0, 1);
            

            _timer -= OneSecond;

            _formattedTimer.AppendFormat("{0:00}:{1:00}", _timer.Minutes, _timer.Seconds);

            lblTimer.Text = _formattedTimer.ToString();

            _formattedTimer.Clear();

            if(_timer.Seconds == 10)
            {
                lblTimer.ForeColor = Color.Red;
            }

            if (_timer <= TimeSpan.Zero)
            {
                timer1.Stop();

                MessageBox.Show("You lost", "Time's up");

                ResetGame();
            }

            if (Stars.Value == 5)
            {
                timer1.Stop();

                MessageBox.Show("You won", "Congratulations");
            }
        }
        
        private void ResetGame()
        {
            AddButtonsToList();

            //Timer

            timer1.Stop();

            _timer = new TimeSpan(0, 0, 60);

            TimeSpan Zero = TimeSpan.Zero;

            _formattedTimer.AppendFormat("{0:00}:{1:00}", Zero.Minutes, Zero.Seconds);

            lblTimer.Text = _formattedTimer.ToString();

            _formattedTimer.Clear();

            lblTimer.ForeColor = Color.White;

            //Moves
            _counter = 0;
            lblMoves.Text = _counter.ToString();

            //Score
            Stars.Value = 0;

            //Buttons
            btn1.Image = _unknown;
            btn2.Image = _unknown;
            btn3.Image = _unknown;
            btn4.Image = _unknown;
            btn5.Image = _unknown;
            btn6.Image = _unknown;
            btn7.Image = _unknown;
            btn8.Image = _unknown;
            btn9.Image = _unknown;
            btn10.Image = _unknown;

            btn1.Tag = "";
            btn2.Tag = "";
            btn3.Tag = "";
            btn4.Tag = "";
            btn5.Tag = "";
            btn6.Tag = "";
            btn7.Tag = "";
            btn8.Tag = "";
            btn9.Tag = "";
            btn10.Tag = "";

            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn10.Enabled = false;
        }
        
        private void btnRestart_Click(object sender, EventArgs e)
        {           
            ResetGame();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Image =_green;

            if(_counter == 0)
                _counter++;

            lblMoves.Text = _counter.ToString();

            btn1.Tag = enTagNames.Green;


            if (btn1.Tag.ToString() == enTagNames.Green.ToString() &&
                btn9.Tag.ToString() == enTagNames.Green.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn1);
                _lstButtons.Remove(btn9);
            }

            else
            {               
                TimeOfShowThePicture.Start();
            }
        }

        private void btn9_Click(object sender, EventArgs e)                       
        {
            if (_counter == 0)
                _counter++;

            btn9.Image = _green;

            btn9.Tag = enTagNames.Green;
          
            lblMoves.Text = _counter.ToString();

            if (btn1.Tag.ToString() == enTagNames.Green.ToString() &&
                btn9.Tag.ToString() == enTagNames.Green.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn9);
                _lstButtons.Remove(btn1);
            }

            else
            {
                TimeOfShowThePicture.Start();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn5.Image = _blue;

            btn5.Tag = enTagNames.Blue;           

            lblMoves.Text = _counter.ToString();

            if (btn3.Tag.ToString() == enTagNames.Blue.ToString() &&
               btn5.Tag.ToString() == enTagNames.Blue.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn3);
                _lstButtons.Remove(btn5);
            }

            else
            {           
                TimeOfShowThePicture.Start();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn3.Image = _blue;

            btn3.Tag = enTagNames.Blue;
         
            lblMoves.Text = _counter.ToString();

            if (btn3.Tag.ToString() == enTagNames.Blue.ToString() &&
                btn5.Tag.ToString() == enTagNames.Blue.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn3);
                _lstButtons.Remove(btn5);
            }

            else
            {              
                TimeOfShowThePicture.Start();
            }
        }
     
        private void btn2_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn2.Image = _yellow;

            btn2.Tag = enTagNames.Yellow;            

            lblMoves.Text = _counter.ToString();

            if (btn2.Tag.ToString() == enTagNames.Yellow.ToString() &&
                btn10.Tag.ToString() == enTagNames.Yellow.ToString())
            {
                Stars.Value += 1;              

                _lstButtons.Remove(btn2);
                _lstButtons.Remove(btn10);
            }

            else
            {        
                TimeOfShowThePicture.Start();
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn10.Image = _yellow;

            btn10.Tag = enTagNames.Yellow;

            lblMoves.Text = _counter.ToString();

            if (btn2.Tag.ToString() == enTagNames.Yellow.ToString() &&
                btn10.Tag.ToString() == enTagNames.Yellow.ToString())
            {
                Stars.Value += 1;

                _lstButtons.Remove(btn2);
                _lstButtons.Remove(btn10);
            }

            else
            {            
                TimeOfShowThePicture.Start();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn4.Image = _pink;

            btn4.Tag = enTagNames.Pink;           

            lblMoves.Text = _counter.ToString();


            if (btn4.Tag.ToString() == enTagNames.Pink.ToString() &&
               btn7.Tag.ToString() == enTagNames.Pink.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn4);
                _lstButtons.Remove(btn7);
            }

            else
            {               
                TimeOfShowThePicture.Start();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn7.Image =_pink;

            btn7.Tag = enTagNames.Pink;

            lblMoves.Text = _counter.ToString();

            if (btn4.Tag.ToString() == enTagNames.Pink.ToString() &&
               btn7.Tag.ToString() == enTagNames.Pink.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn4);
                _lstButtons.Remove(btn7);
            }

            else
            {           
                TimeOfShowThePicture.Start();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn6.Image = _red;        

            btn6.Tag = enTagNames.Red;

            lblMoves.Text = _counter.ToString();

            if (btn6.Tag.ToString() == enTagNames.Red.ToString() &&
               btn8.Tag.ToString() == enTagNames.Red.ToString())
            {
                Stars.Value += 1;
                
                _lstButtons.Remove(btn6);
                _lstButtons.Remove(btn8);
            }

            else
            {              
                TimeOfShowThePicture.Start();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
                _counter++;

            btn8.Image = _red;

            btn8.Tag = enTagNames.Red;

            lblMoves.Text = _counter.ToString();

            if (btn6.Tag.ToString() == enTagNames.Red.ToString() &&
               btn8.Tag.ToString() == enTagNames.Red.ToString())
            {
                Stars.Value += 1;             

                _lstButtons.Remove(btn6);
                _lstButtons.Remove(btn8);
            }

            else
            {             
                TimeOfShowThePicture.Start();
            }
        }

        private void TimeOfShowThePicture_Tick(object sender, EventArgs e)
        {
            _counter++;

            for (int i = 0; i < _lstButtons.Count; i++)
            {
                _currentButton = _lstButtons[i];
             
                _currentButton.Tag = enTagNames.Unknown;
                _currentButton.Image = _unknown;
            }

            TimeOfShowThePicture.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
