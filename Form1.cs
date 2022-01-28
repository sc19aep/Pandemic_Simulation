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
        House h1, h2, h3, h4, h5, h6;

        List<House> houses = new List<House> {};
        List<Shop> shops = new List<Shop> { };
        List<Person> people = new List<Person> { };

        private void addHouses(int gapx, int gapy)
        {
            //house 1
            h1.x = gapx;
            h1.y = gapy;
            houses.Add(h1);
            //house 2
            h2.x = 25+gapx;
            h2.y = gapy;
            houses.Add(h2);
            //house 3
            h3.x = 50+gapx;
            h3.y = gapy;
            houses.Add(h3);
            //house 4
            h4.x = gapx;
            h4.y = 35+gapy;
            houses.Add(h4);
            //house 5
            h5.x = 25+gapx;
            h5.y = 35+gapy;
            houses.Add(h5);
            //house 6
            h6.x = 50+gapx;
            h6.y = 35+gapy;
            houses.Add(h6);
        }


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

            //houses 
            addHouses(0, 0);
            addHouses(0, 60);
            addHouses(80, 60);


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
