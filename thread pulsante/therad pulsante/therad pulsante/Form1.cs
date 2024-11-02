using System;
using System.Windows.Forms;

namespace therad_pulsante
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void spostaDx(object obj)
        {
            bool continua=true;
            Button nuovo = (Button)obj;

            while (continua==true )
            {
                
                int delay = random.Next(0, 50);
                Thread.Sleep(delay);

                
                nuovo.Location = new Point(nuovo.Location.X - 10, nuovo.Location.Y);

                
                if (nuovo.Location.X < 0)
                {
                    continua = false;
                }
            }
        }
        private void spostaSX(object obj)
        {
            bool continua = true;
            Button nuovo = (Button)obj;

            while (continua == true)
            {

                int delay = random.Next(0, 50);
                Thread.Sleep(delay);


                nuovo.Location = new Point(nuovo.Location.X + 10, nuovo.Location.Y);


                if (nuovo.Location.X > ClientSize.Width)
                {
                    continua = false;
                }
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Button nuovo = new Button();

            nuovo.Location = new Point(
            (this.ClientSize.Width / 2 - nuovo.Width/2),
            (this.ClientSize.Height / 2 -  nuovo.Height/2)
            );
            nuovo.Size = new Size(10, 10);
            nuovo.Text = "";
            this.Controls.Add(nuovo);
            Thread sinistro = new Thread(spostaDx);
            Thread destro = new Thread(spostaSX);

            sinistro.Start(nuovo);
            destro.Start(nuovo);
        }

    }
}
