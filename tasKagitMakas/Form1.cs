using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasKagitMakas
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        internal readonly static Bitmap tas = new Bitmap(Application.StartupPath+"\\tas.png");
        internal readonly static Bitmap kagit = new Bitmap(Application.StartupPath +"\\kagit.png");
        internal readonly static Bitmap makas = new Bitmap(Application.StartupPath +"\\makas.png");
        Random r = new Random();
        PictureBox pictureBox = new PictureBox();
        private async void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Width = 1000;
            this.Height = 1000;
            Draw(); 
            await Play();
        }
        private void Draw()
        {
            for (int i = 0; i < 33; i++)
            {
                pictureBox = new PictureBox();
                int x = r.Next(20, 300);
                int y = r.Next(20, 300);
                pictureBox.Location = new Point(x, y);
                pictureBox.Name = "tas";
                pictureBox.Image = tas;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 25;
                pictureBox.Height = 25;
                pictureBox.BackColor = Color.Transparent;
                pictureBoxList.Add(pictureBox);
            }
            for (int i = 0; i < 33; i++)
            {
                pictureBox = new PictureBox();
                int x = r.Next(500, 780);
                int y = r.Next(20, 300);
                pictureBox.Location = new Point(x, y);
                pictureBox.Name = "kagit";
                pictureBox.Image = kagit;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 25;
                pictureBox.Height = 25;

                pictureBox.BackColor = Color.Transparent;
                pictureBoxList.Add(pictureBox);
            }
            for (int i = 0; i < 33; i++)
            {
                pictureBox = new PictureBox();
                int x = r.Next(350, 650);
                int y = r.Next(500, 780);
                pictureBox.Location = new Point(x, y);
                pictureBox.Name = "makas";
                pictureBox.Image = makas;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 25;
                pictureBox.Height = 25;
                pictureBox.BackColor = Color.Transparent;
                pictureBoxList.Add(pictureBox);
            }
            foreach (var item in pictureBoxList)
            {
                this.Controls.Add(item);
            }

        }
        private Task Play()
        {
            return Task.Run(async () =>
            {
                bool play = true;
                int tsayi;
                int ksayi;
                int msayi;
                string name;
                while (play)
                {
                    foreach (var item in pictureBoxList)
                    {
                        int i = r.Next(-20, 20);
                        int j = r.Next(-20, 20);
                        if (item.Left < 100 && i < 0)
                        {
                            i = i * -1;
                        }
                        else if (item.Left > 600 && i > 0)
                        {
                            i = i * -1;
                        }
                        if (item.Top < 100 && j < 0)
                        {
                            j = j * -1;
                        }
                        else if (item.Top > 600 && j > 0)
                        {
                            j = j * -1;
                        }
                        item.Left = item.Left + i;
                        item.Top = item.Top + j;

                        name = item.Name;
                        switch (name)
                        {
                    
                            case "kagit":
                                var enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("tas")).FirstOrDefault();
                                if (enemy != null)
                                {
                                    enemy.Name = "kagit";
                                    enemy.Image = kagit;
                                }
                                break;
                            case "tas":
                                enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("makas")).FirstOrDefault();
                                if (enemy != null)
                                {
                                    enemy.Name = "tas";
                                    enemy.Image = tas;
                                }
                                break;
                            case "makas":
                                enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("kagit")).FirstOrDefault();
                                if (enemy != null)
                                {
                                    enemy.Name = "makas";
                                    enemy.Image = makas;
                                }
                                break;
                        }

                        //if (item.Name.StartsWith("kagit"))
                        //{
                        //    var enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("tas")).FirstOrDefault();
                        //    if (enemy != null)
                        //    {
                        //        enemy.Name = "kagit";
                        //        enemy.Image = kagit;
                        //    }
                        //}
                        //else if (item.Name.StartsWith("tas"))
                        //{
                        //    var enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("makas")).FirstOrDefault();
                        //    if (enemy != null)
                        //    {
                        //        enemy.Name = "tas";
                        //        enemy.Image = tas;
                        //    }
                        //}
                        //else
                        //{
                        //    var enemy = pictureBoxList.Where(x => x.Left > item.Left && x.Left < item.Left + 35 && x.Top > item.Top && x.Top < item.Top + 35 && x.Name.StartsWith("kagit")).FirstOrDefault();
                        //    if (enemy != null)
                        //    {

                        //        enemy.Name = "makas";
                        //        enemy.Image = makas;
                        //    }
                        //}


                    }
                    ksayi = pictureBoxList.Where(x => x.Name.StartsWith("kagit")).Count();
                    tsayi = pictureBoxList.Where(x => x.Name.StartsWith("tas")).Count();
                    msayi = pictureBoxList.Where(x => x.Name.StartsWith("makas")).Count();
                    label1.Text = "kagit" + ksayi;
                    label2.Text = "tas" + tsayi;
                    label3.Text = "makas" + msayi;
                    if (ksayi == 0)
                    {
                        play = false;
                        MessageBox.Show("Tas kazandı");
                    }
                    else if (msayi == 0)
                    {
                        play = false;
                        MessageBox.Show("kağıt kazandı");
                    }
                    else if (tsayi == 0)
                    {
                        play = false;
                        MessageBox.Show("makas kazandı");
                    }
                    await Task.Delay(25);
                }
            });
        }
    }
}
