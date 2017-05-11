using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdmissionCal
{
    public partial class Form1 : Form
    {
        private static double gpax;
        private static double[] onet = new double[5];
        private static double[] gatpat = new double[3];

        private static int[] gatpatPercent = new int[3];
        private static double[] totalScore = new double[3]; //gpax onet gatpat

        private static double ans;

        private double gatFull = 300;
        private double onetFull = 100;
        private double gpaxFull = 4;

        public Form1()
        {
            InitializeComponent();
        }

        private void reset()
        {
            //onet
            for (int i = 0; i < onet.Length; i++)
            {
                onet[i] = 0;
            }

            //gatpat
            for (int i = 0; i < gatpat.Length; i++)
            {
                gatpat[i] = 0;
            }

            for (int i = 0; i < totalScore.Length; i++)
            {
                totalScore[i] = 0;
            }
            ans = 0;
        }

        private void resetLabel()
        {
            label1.Text = "0";
            label15.Text = "0";
            label17.Text = "0";
            label19.Text = "0";
        }
        private bool isTextBoxError(TextBox textbox, double full)
        {
            string text = textbox.Text;
            bool ans;
            double score;

            if (Double.TryParse(text, out score))
            {
                ans = (score > full) || (score < 0);
            }
            else
            {
                return true;
            }
            return ans;
        }

        private void getInput()
        {
            gatpatPercent[0] = 15;
            gatpatPercent[1] = 15;
            gatpatPercent[2] = 20;

            gpax = Convert.ToDouble(gpaxInput.Text);
            onet[0] = Convert.ToDouble(onet0.Text);
            onet[1] = Convert.ToDouble(onet1.Text);
            onet[2] = Convert.ToDouble(onet2.Text);
            onet[3] = Convert.ToDouble(onet3.Text);
            onet[4] = Convert.ToDouble(onet4.Text);
            gatpat[0] = Convert.ToDouble(gat.Text);
            gatpat[1] = Convert.ToDouble(pat2.Text);
            gatpat[2] = Convert.ToDouble(pat3.Text);
        }

        private bool isError()
        {
            if (isTextBoxError(gpaxInput, gpaxFull)) return true;
            if (isTextBoxError(onet0, onetFull)) return true;
            if (isTextBoxError(onet1, onetFull)) return true;
            if (isTextBoxError(onet2, onetFull)) return true;
            if (isTextBoxError(onet3, onetFull)) return true;
            if (isTextBoxError(onet4, onetFull)) return true;
            if (isTextBoxError(gat, gatFull)) return true;
            if (isTextBoxError(pat2, gatFull)) return true;
            if (isTextBoxError(pat3, gatFull)) return true;
            return false;
        }

        private void calculate()
        {
            totalScore[0] = gpax * 1500;
            //onet
            for(int i=0; i < onet.Length; i++)
            {
                totalScore[1] += onet[i] * 18;
            }

            //gatpat
            for(int i=0; i < gatpat.Length; i++)
            {
                totalScore[2] += gatpat[i] * gatpatPercent[i];
            }

            for(int i=0; i < totalScore.Length; i++)
            {
                ans += totalScore[i];
            }
        }

        private void showAns()
        {
            label1.Text = Convert.ToString(ans);
            label15.Text = Convert.ToString(totalScore[0]);
            label17.Text = Convert.ToString(totalScore[1]);
            label19.Text = Convert.ToString(totalScore[2]);
        
        }
        private void showError()
        {
            string message = "Score Error";
            MessageBox.Show(message);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isError())
         //   if(true)
            {
                getInput();
                calculate();
                showAns();
                reset();
            }
            else
            {
                showError();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            gpaxInput.Text = "";
            onet0.Text = "";
            onet1.Text = "";
            onet2.Text = "";
            onet3.Text = "";
            onet4.Text = "";
            gat.Text = "";
            pat2.Text = "";
            pat3.Text = "";
            reset();
            resetLabel();
        }
    }
}
