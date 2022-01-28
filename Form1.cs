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

        Person p1, p2, p3, p4;
        Shop s1;
        House h1;

        List<House> houses = new List<House> {};
        List<Shop> shops = new List<Shop> { };
        List<Person> people = new List<Person> { };

        private void addHouse(int x, int y)
        {
            //house
            h1.x = x;
            h1.y = y;
            houses.Add(h1);
            //person 1
            p1.x = x;
            p1.y = y;
            p1.status = "Blue";
            people.Add(p1);
            //person 2
            p2.x = x + 10;
            p2.y = y;
            p2.status = "Blue";
            people.Add(p2);
            //person 3
            p3.x = x;
            p3.y = y + 10;
            p3.status = "Blue";
            people.Add(p3);
            //person 4
            p4.x = x + 10;
            p4.y = y + 10;
            p4.status = "Blue";
            people.Add(p4);
        }

        private void generateMap()
        {
            int x = 0, y = 0;
            while(x <= 510)
            {
                y = 0;
                while(y <= 360)
                {
                    if(((x==85 || x==170) && (y==0 || y==180 || y== 245)) || ((x == 340 || x == 425) && (y == 60 || y == 125)))
                    {
                        //add shop
                        s1.x = x;
                        s1.y = y;
                        shops.Add(s1);
                        if (y == 180 || y==60)
                            y += 5;
                        else if (y == 245 || y==125)
                            y -= 5;
                    }
                    else
                    {
                        //add row of houses
                        //row 1
                        addHouse(x, y);
                        addHouse(x + 25, y);
                        addHouse(x + 50, y);
                        //row 2
                        addHouse(x, y + 35);
                        addHouse(x + 25, y + 35);
                        addHouse(x + 50, y + 35);
                    }
                    y += 60;
                }
                x += 85;
            }
        }


        public Form1()
        {
            InitializeComponent();

            //houses, shops and people
            generateMap();
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
            for(int i = 0; i<people.Count; i++)
            {
                Brush myBrush = new SolidBrush(Color.FromName(people[i].status));
                e.Graphics.FillEllipse(myBrush, people[i].x, people[i].y, 10, 10);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p1.x < s1.x + 35)
                p1.x++;
            if (p1.y < s1.y + 25)
                p1.y++;

            splitContainer1.Panel2.Refresh();
        }
    }
}
