using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        struct Person
        {
            public int x; //current x value
            public int y; //current y value
            public string status; //susceptible(blue), infected(red), removed(grey)
        };

        struct House
        {
            public int x;
            public int y;
            public List<Person> list;
        }

        struct Shop
        {
            public int x; //store start x point
            public int y; //store start y point
        };

        Person p1, p2;
        Shop s1, s2;
        House h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15;

        List<House> houses = new List<House> {};
        List<Shop> shops = new List<Shop> { };
        List<Person> people = new List<Person> { };


        public Form1()
        {
            InitializeComponent();
            //person 1
            p1.x = 10;
            p1.y = 10;
            p1.status = "Blue";
            people.Add(p1);

            //person 1
            p2.x = 0;
            p2.y = 0;
            p2.status = "Blue";
            people.Add(p2);

            //shop 1
            s1.x = 80;
            s1.y = 0;
            shops.Add(s1);
            //shop 2
            s2.x = 165;
            s2.y = 0;
            shops.Add(s2);

            //house 1
            h1.x = 0;
            h1.y = 0;
            houses.Add(h1);
            //house 2
            h2.x = 25;
            h2.y = 0;
            houses.Add(h2);
            //house 3
            h3.x = 50;
            h3.y = 0;
            houses.Add(h3);
            //house 4
            h4.x = 0;
            h4.y = 35;
            houses.Add(h4);
            //house 5
            h5.x = 25;
            h5.y = 35;
            houses.Add(h5);
            //house 6
            h6.x = 50;
            h6.y = 35;
            houses.Add(h6);
            //house 7
            h7.x = 0;
            h7.y = 60;
            houses.Add(h7);
            //house 8
            h8.x = 25;
            h8.y = 60;
            houses.Add(h8);
            //house 9
            h9.x = 50;
            h9.y = 60;
            houses.Add(h9);
            //house 10
            h10.x = 80;
            h10.y = 60;
            houses.Add(h10);
            //house 11
            h11.x = 105;
            h11.y = 60;
            houses.Add(h11);
            //house 12
            h12.x = 130;
            h12.y = 60;
            houses.Add(h12);
            //house 13
            h13.x = 165;
            h13.y = 60;
            houses.Add(h13);
            //house 14
            h14.x = 190;
            h14.y = 60;
            houses.Add(h14);
            //house 15
            h15.x = 215;
            h15.y = 60;
            houses.Add(h15);

        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            //houses
            for(int i = 0; i<houses.Count; i++)
                e.Graphics.FillRectangle(Brushes.DarkGray, houses[i].x, houses[i].y, 20, 20); //starting corner, distance from that point


            //shops
            for (int i = 0; i < shops.Count; i++)
                e.Graphics.FillRectangle(Brushes.Gray, shops[i].x, shops[i].y, 70, 50);

            //people
            Brush myBrush = new SolidBrush(Color.FromName(p1.status));
            e.Graphics.FillEllipse(myBrush, p1.x, p1.y, 10, 10);

            Brush myBrush2 = new SolidBrush(Color.FromName(p2.status));
            e.Graphics.FillEllipse(myBrush2, p2.x, p2.y, 10, 10);



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p1.x < s1.x + 35)
                p1.x++;
            if (p1.y < s1.y + 25)
                p1.y++;

            if (p2.x < s2.x + 35)
                p2.x++;
            if (p2.y < s2.y + 25)
                p2.y++;

            splitContainer1.Panel2.Refresh();
        }
    }
}
