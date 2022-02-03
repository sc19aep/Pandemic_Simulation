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
            public Building house; //the house the person returns to at the end of the day
            public List<Building> tasks;
        };

        struct Building
        {
            public int x; //start point x location
            public int y; //start point y location
        };

        struct Route
        {
            public int x;
            public int y;
            public List<Route> neighbours;
        };


        Person p1, p2, p3, p4;
        Building s1, h1; //shop 1 and house 1

        List<Building> houses = new List<Building> {};
        List<Building> shops = new List<Building> {};
        List<Person> people = new List<Person> {};
        List<Route> points = new List<Route> {};

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
            p1.tasks = new List<Building> { };
            p1.house = h1;
            people.Add(p1);
            //person 2
            p2.x = x + 10;
            p2.y = y;
            p2.status = "Blue";
            p2.tasks = new List<Building> { };
            p2.house = h1;
            people.Add(p2);
            //person 3
            p3.x = x;
            p3.y = y + 10;
            p3.status = "Blue";
            p3.tasks = new List<Building> { };
            p3.house = h1;
            people.Add(p3);
            //person 4
            p4.x = x + 10;
            p4.y = y + 10;
            p4.status = "Blue";
            p4.tasks = new List<Building> { };
            p4.house = h1;
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

        private void generateRoute()
        {
            Random rnd = new Random();

            for (int i=0; i<people.Count(); i++)
            {
                for(int j = 0; j<3; j++)
                {
                    int num = rnd.Next(0, shops.Count());
                    people[i].tasks.Add(shops[num]);
                }
            }
        }

        private void Render()
        {
            using (var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            using (var e = Graphics.FromImage(bmp))
            {
                //houses
                for (int i = 0; i < houses.Count; i++)
                    e.FillRectangle(Brushes.DarkGray, houses[i].x, houses[i].y, 20, 20); //starting corner, distance from that point

                //shops
                for (int i = 0; i < shops.Count; i++)
                    e.FillRectangle(Brushes.Gray, shops[i].x, shops[i].y, 70, 50);

                //people
                for (int i = 0; i < people.Count; i++)
                {
                    Brush myBrush = new SolidBrush(Color.FromName(people[i].status));
                    e.FillEllipse(myBrush, people[i].x, people[i].y, 10, 10);
                }

                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmp.Clone();
            }
        }

        public Form1()
        {
            InitializeComponent();

            //houses, shops and people
            generateMap();
            generateRoute();
            Render();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //for(int i = 0; i<people.Count(); i++)
            Parallel.ForEach<Person>(people, i =>
            {
                int index = people.IndexOf(i);
                int target_x = i.tasks[0].x;
                int target_y = i.tasks[0].y;

                if (i.x < target_x + 35)
                    i.x = i.x + 1;
                if (i.y < target_y + 25)
                    i.y = i.y + 1;
                if (i.x > target_x + 35)
                    i.x = i.x - 1;
                if (i.y > target_y + 25)
                    i.y = i.y - 1;

                people[index] = i;
            });

            Render();
        }
    }
}
