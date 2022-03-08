using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4KNativeEditor
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        
         string LittleEndian(string num)
        {
            int number = Convert.ToInt32(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
            { retval += b.ToString("X2"); }

            retval = retval.Substring(0, 4);
            return retval;
        }
        private void button1_Click(object sender, EventArgs e)
        {

         
            int Width = Int32.Parse(txtFPS.Text);
            
            
          


          
          
         

           
            using (FileStream sr = File.OpenWrite(@"GameAssembly.dll"))
            {
                sr.Seek(0x34401A, SeekOrigin.Begin);
                sr.WriteByte((byte)Width);
       
               
                sr.Close();
              
                MessageBox.Show("New Maximum Framerate saved.");

            }


        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
           
       

            string curFile = @"GameAssembly.dll";
          
            if (File.Exists(curFile))
            {
            }
            else
            { MessageBox.Show("Please put this application in the game executable directory.");
                System.Environment.Exit(1);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFPS_TextChanged(object sender, EventArgs e)
        {
            try {
                if (Int32.Parse(txtFPS.Text) > 255)
                    txtFPS.Text = "255";
            }
            catch { }

            
        }
    }
}
