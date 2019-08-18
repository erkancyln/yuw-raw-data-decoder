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


namespace YazLab3
{
    public partial class Form1 : Form
    {

        byte[] array;
        int width , heigth , frame = 0;
        byte[] yArray;
        Color[] color;
        string file = "";
        public Form1()
        {
            InitializeComponent();
        
        }
        int time = 0,sayac = 0, imageSayac = 1;
        
        private void button1_Click(object sender, EventArgs e)
        {


            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty(comboBox2.Text)) {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !!! ");
            }


            else
            {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    try
                    {
                        string text = File.ReadAllText(file);
                    
                        array = File.ReadAllBytes(file);
                    }
                    catch (IOException)
                    {
                    }
                }


                width = Convert.ToInt32(textBox1.Text);
                heigth = Convert.ToInt32(textBox2.Text);

                int size = array.Length;

                yArray = new byte[size];
                color = new Color[size];


                Console.WriteLine("girdi");

                string a = comboBox2.SelectedItem.ToString();
                Console.WriteLine(Convert.ToInt32(1000 / Convert.ToDouble(a)));
    
                timer1.Interval = Convert.ToInt32(1000 / Convert.ToDouble(a)) ;
                timer1.Enabled = true;
                
   
            
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if(comboBox1.SelectedItem.ToString() == "4:4:4"){_444format();}
            if (comboBox1.SelectedItem.ToString() == "4:2:2") { _422format(); }
            if (comboBox1.SelectedItem.ToString() == "4:2:0") { _420format(); }

        }

        void _444format()
        {
            sayac++;

            
            frame = array.Length / (width * heigth * 3);

            Console.WriteLine(frame);
            for (int i = time; i < (width * heigth) + time; i++)
            {
                yArray[i] = array[i];
                color[i] = Color.FromArgb(yArray[i], yArray[i], yArray[i]);
            }
            Bitmap myBitmap = new Bitmap(width, heigth);

            int a = time;

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    myBitmap.SetPixel(j, i, color[a]);
                    a++;
                }
            }

            pictureBox1.Image = myBitmap;

            if (checkBox1.Checked)
            {
                myBitmap.Save(@"C:\Users\PASAVAT\Desktop\Images\image" + imageSayac + ".bmp");
                imageSayac++;
            }

            if (sayac < frame) {
                time += width * heigth * 3;
            }
            else
            {
                timer1.Stop();
                time = 0;
                sayac = 0;
                pictureBox1.Image = null;
            }
            
        }

        void _422format()
        {
            sayac++;


            frame = array.Length / (width * heigth * 2);

            Console.WriteLine(frame);
            for (int i = time; i < (width * heigth) + time; i++)
            {
                yArray[i] = array[i];
                color[i] = Color.FromArgb(yArray[i], yArray[i], yArray[i]);
            }
            Bitmap myBitmap = new Bitmap(width, heigth);

            int a = time;

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    myBitmap.SetPixel(j, i, color[a]);
                    a++;
                }
            }

            pictureBox1.Image = myBitmap;

            if (checkBox1.Checked)
            {
                myBitmap.Save(@"C:\Users\PASAVAT\Desktop\Images\image" + imageSayac + ".bmp");
                imageSayac++;
            }

            if (sayac < frame)
            {
                time += width * heigth * 2;
            }
            else
            {
                timer1.Stop();
                time = 0;
                sayac = 0;
                pictureBox1.Image = null;
            }

        }

        void _420format()
        {
            sayac++;


            frame = array.Length / Convert.ToInt32(width * heigth * 1.5);

            Console.WriteLine(frame);
            for (int i = time; i < (width * heigth) + time; i++)
            {
                yArray[i] = array[i];
                color[i] = Color.FromArgb(yArray[i], yArray[i], yArray[i]);
            }
            Bitmap myBitmap = new Bitmap(width, heigth);

            int a = time;

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    myBitmap.SetPixel(j, i, color[a]);
                    a++;
                }
            }

            pictureBox1.Image = myBitmap;

            if (checkBox1.Checked)
            {
                myBitmap.Save(@"C:\Users\PASAVAT\Desktop\Images\image" + imageSayac + ".bmp");
                imageSayac++;
            }

            if (sayac < frame)
            {
                time += Convert.ToInt32(width * heigth * 1.5);
            }
            else
            {
                timer1.Stop();
                time = 0;
                sayac = 0;
                pictureBox1.Image = null;
            }

        }
    }
}
