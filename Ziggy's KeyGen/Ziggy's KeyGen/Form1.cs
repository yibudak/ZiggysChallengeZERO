using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ziggy_s_KeyGen
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 5)
            {
                button1.Enabled = true;
            }
        }
        private string Reverse(string input)
        {

            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);
            string reverseInput = new string(inputArray);
            return reverseInput;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long magic = 1315632316;
            char[] CopyFromArray = new char[8];
            int a, tail = 0, head = 8;
 
            byte[] name = Encoding.Default.GetBytes(Reverse(textBox1.Text));
                var hexString = BitConverter.ToString(name);
                hexString = hexString.Replace("-", "");
                for (int c = 0; c < hexString.Length - 8; c++)
                {
                    if (hexString.Length - head < 0)
                    {
                        break;
                    }
                    a = 0;
                    for (int i = hexString.Length - head; i < hexString.Length - tail; i++)
                    {
                        CopyFromArray[a] = hexString[i];
                        a++;
                    }
                    
                    tail += 2;
                    head += 2;

                    string CopyFromArrayString = new string(CopyFromArray);
                    long decimalInput = Convert.ToInt64(CopyFromArrayString, 16);
                    magic = decimalInput ^ magic;
                }
                string finalWords = magic.ToString();
                textBox2.Text = "FIT-"+finalWords;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This KeyGen is for Ziggys KeygenMe #0 Challenge, written by yibudak.");
        }
    }
}
