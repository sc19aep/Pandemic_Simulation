﻿using System;
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
            public Route current; //current point the person is on or heading to
            public int shopping; //checks if person is in a shop and how long they have been there already
            public int infected; //counts how long the person has been infected, to know when they are no longer ill
            public bool mask;
            public bool distance;
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


        Person p1;
        Building s1, h1; //shop 1 and house 1
        Route r1, r0; //route point

        int ticks = 0;
        decimal infectionPercentage = 0.10M;
        decimal asymp = 0.01M;
        int maskUptake = 50;
        int vaccineUptake = 50;
        int distanceUptake = 70;
        int day = 4000; //ticks in a day
        int days = 2; // length of infection
        int latency = 0;
        int immune = 4; //length of removed status
        int prevI = 1;
        bool pandemic = false;
        bool lockdown = false;


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
            p1.current = r0;
            p1.shopping = 0;
            p1.infected = 0;
            p1.mask = false;
            p1.distance = false;
            people.Add(p1);
            //person 2
            p1.x = x + 10;
            people.Add(p1);
            //person 3
            p1.x = x;
            p1.y = y + 10;
            people.Add(p1);
            //person 4
            p1.x = x + 10;
            people.Add(p1);
        }

        private void generateMap()
        {
            int x = 0, y = 0;
            while(x <= 510)
            {
                y = 0;
                while(y <= 360)
                {
                    if (((x==85 || x==170) && (y==0 || y==180 || y== 245)) || ((x == 340 || x == 425) && (y == 60 || y == 125)) || ((x==255 || x==340) && y==360))
                    {
                        if (y == 360)
                            y += 5;

                        //add shop
                        s1.x = x;
                        s1.y = y;
                        shops.Add(s1);
                        
                        if (y == 180 || y==60 )
                            y += 5;
                        else if (y == 245 || y==125 )
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
                Person p = people[i];
                p.current = r0;
                p.shopping = 0;
                for(int j = 0; j<3; j++)
                {
                    int num = rnd.Next(0, shops.Count());
                    p.tasks.Add(shops[num]);
                }
                people[i] = p;
            }
        }

        private void assignNeighbours()
        {
            int x = 0, y = 0;
            while (x <= 510)
            {
                y = 0;
                while (y <= 360)
                {
                    if (x < 510)
                    {
                        //route point
                        r1.x = x + 74;
                        r1.y = y + 24;
                        r1.neighbours = new List<Route> { };
                        r1.neighbours.Add(r1);
                        points.Add(r1);
                    }
                    y += 60;
                }
                x += 85;
            }


                    for (int i = 0; i<points.Count(); i++)
            {
                Route r = points[i];
                //find left neighbor
                int left = points.FindIndex(n => n.x == r.x - 85 && n.y == r.y);
                if(left >= 0)
                    r.neighbours.Add(points[left]);

                //find right neighbor
                int right = points.FindIndex(n => n.x == r.x + 85 && n.y == r.y);
                if (right >= 0)
                    r.neighbours.Add(points[right]);

                //find up neighbor
                int up = points.FindIndex(n => n.x == r.x && n.y == r.y-60);
                if (up >= 0)
                    r.neighbours.Add(points[up]);

                //find down neighbor
                int down = points.FindIndex(n => n.x == r.x && n.y == r.y+60);
                if (down >= 0)
                    r.neighbours.Add(points[down]);
                points[i] = r;
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
                    e.FillEllipse(myBrush, people[i].x, people[i].y, 3, 3);
                }

                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmp.Clone();
            }
        }

        public Form1()
        {
            InitializeComponent();

            // null route point
            r0.x = 0;
            r0.y = 0;
            r0.neighbours = new List<Route> { };

            //houses, shops and people
            generateMap();
            assignNeighbours();
            generateRoute();

            //initial infected person
            Random rnd = new Random();
            int num = rnd.Next(0, people.Count());
            Person p = people[num];
            p.status = "Red";
            people[num] = p;

            //draw the map
            Render();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            infectionPercentage = infectionUpDown.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            maskUptake = (int)maskUpDown.Value;
        }

        private void daysUpDown_ValueChanged(object sender, EventArgs e)
        {
            days = (int)daysUpDown.Value;
        }

        private void latencyUpDown_ValueChanged(object sender, EventArgs e)
        {
            latency = (int)latencyUpDown.Value;
        }

        private void asymptomaticUpDown_ValueChanged(object sender, EventArgs e)
        {
            asymp = asymptomaticUpDown.Value; 
        }

        private void vaccineUpDown_ValueChanged(object sender, EventArgs e)
        {
            vaccineUptake = (int)vaccineUpDown.Value;
        }

        private void distanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            distanceUptake = (int)distanceUpDown.Value;
        }

        private void ImmunityUpDown_ValueChanged(object sender, EventArgs e)
        {
            immune = (int)ImmunityUpDown.Value;
        }

        private void Lockdown_Click(object sender, EventArgs e)
        {
            //start lockdown
            Lockdown.Enabled = false;
            Freedom.Enabled = true;
            lockdown = true;
        }

        private void Freedom_Click(object sender, EventArgs e)
        {
            //end lockdown
            Freedom.Enabled = false;
            Lockdown.Enabled = true;
            lockdown = false;
            
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            //restart the simulation
            timer1.Stop();
            ticks = 0;
            infectionUpDown.Enabled = true;
            daysUpDown.Enabled = true;
            latencyUpDown.Enabled = true;
            asymptomaticUpDown.Enabled = true;
            ImmunityUpDown.Enabled = true;
            maskUpDown.Enabled = true;
            vaccineUpDown.Enabled = true;
            distanceUpDown.Enabled = true;
            Pandemic.Enabled = true;
            Start.Enabled = true;
            Stop.Enabled = false;
            Lockdown.Enabled = false;
            Freedom.Enabled = false;
            pandemic = false;
            lockdown = false;


            //reset people location to house
            for (int i=0; i<people.Count(); i++)
            {
                Person p = people[i];
                p.x = p.house.x;
                p.y = p.house.y;

                if (i % 4 == 1)
                    p.x += 10;
                else if (i % 4 == 2)
                    p.y += 10;
                else if( i%4 == 3)
                {
                    p.x += 10;
                    p.y += 10;
                }

                p.status = "Blue";
                p.current = r0;
                p.shopping = 0;
                p.infected = 0;
                p.mask = false;
                p.distance = false;

                p.tasks.RemoveRange(0, p.tasks.Count());

                people[i] = p;
            }

            //generate new tasks
            generateRoute();

            //initial infected person
            Random rnd = new Random();
            int num = rnd.Next(0, people.Count());
            Person q = people[num];
            q.status = "Red";
            people[num] = q;

            //draw the map
            Render();
        }

        private void Pandemic_Click(object sender, EventArgs e)
        {
            //call pandemic
            maskUpDown.Enabled = false;
            vaccineUpDown.Enabled = false;
            distanceUpDown.Enabled = false;
            Pandemic.Enabled = false;
            Lockdown.Enabled = true;
            pandemic = true;

            // people start wearing masks
            Random rnd = new Random();
            int maskPercentage = (int)((maskUptake / 100.0) * people.Count());
            var masks = people.OrderBy(x => rnd.Next()).Take(maskPercentage).ToList();

            for(int i = 0; i<masks.Count(); i++)
            {
                int j = people.IndexOf(masks[i]);
                Person p = masks[i];
                p.mask = true;
                people[i] = p;
            }

            // people start keeping a distance
            int distancePercentage = (int)((distanceUptake / 100.0) * people.Count());
            var distance = people.OrderBy(x => rnd.Next()).Take(distancePercentage).ToList();
            for(int i = 0; i<distance.Count(); i++)
            {
                int j = people.IndexOf(distance[i]);
                Person p = distance[i];
                p.distance = true;
                people[i] = p;
            }

        }



        private void Start_Click(object sender, EventArgs e)
        {
            //start simulation
            timer1.Start();
            infectionUpDown.Enabled = false;
            daysUpDown.Enabled = false;
            latencyUpDown.Enabled = false;
            asymptomaticUpDown.Enabled = false;
            ImmunityUpDown.Enabled = false;
            Stop.Enabled = true;
            Start.Enabled = false;

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            //pause simulation
            timer1.Stop();
            Start.Enabled = true;
            Stop.Enabled = false;
        }

        private int FindClosest(float x, float y, List<Route> route)
        {
            int index = 0;
            float minx = (route[0].x - x) * (route[0].x - x); 
            float miny = (route[0].y - y) * (route[0].y - y);

            for (int i = 1; i< route.Count(); i++)
            {
                float X = (route[i].x - x) * (route[i].x - x);
                float Y = (route[i].y - y) * (route[i].y - y);
                if(X+Y < minx+miny)
                {
                    minx = X;
                    miny = Y;
                    index = i;
                }
            }
            return index;
        }

        private void spreadInfection(int i)
        {
            Person p = people[i];

            //check for nearby people
            for(int j = 0; j < people.Count(); j++)
            {
                //persons middle point
                int px = people[j].x + 5;
                int py = people[j].y + 5;

                //check if within 5 pixel vicinity and if in the same building/outside
                if(px > p.x-5 && px < p.x+5 && py > p.y-5 && py < p.y+5 && people[j].shopping==p.shopping && people[j].status =="Blue")
                {
                    //infect neraby people
                    Random rnd = new Random();
                    int prob = rnd.Next(0, 10000);
                    int inf = (int)(infectionPercentage * 100);
                    if(prob <= inf)
                    {
                        Person r = people[j];
                        r.status = "Pink";
                        people[j] = r;
                    }

                }
            }

            
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            int infected = 0;
            int susceptible = 0;

            //find nearest route point
            //follow neighbour route points to the location
            //go into the location
            //spend some time in the location
            //repeat x3
            //go home following the same logic
            //wait till morning
            //repeat everyhting with new locations

            for(int j = 0; j<people.Count(); j++)
            {
                Person i = people[j];

                if(i.status == "Red" || i.status == "Pink" || i.status == "Violet")
                {
                    infected++;
                    i.infected++;
                    spreadInfection(j);
                }

                if(i.status == "Pink" && i.infected == day * latency)
                {
                    //check if asymptomatic
                    Random rnd = new Random();
                    int prob = rnd.Next(0, 10000);
                    int inf = (int)(asymp * 100);
                    if (prob <= inf)
                        i.status = "Violet";
                    else
                        i.status = "Red";
                }

                if (i.infected == day * (days+latency))
                    i.status = "Gray";

                if(i.status == "Gray" && i.infected == day * (days+latency+immune))
                {
                    i.status = "Blue";
                    i.infected = 0;
                }

                if (i.status == "Blue")
                    susceptible++;
                    

                float target_x, target_y;
                if(i.tasks.Count > 0)
                {
                    //check if there are any tasks left
                    target_x = i.tasks[0].x;
                    target_y = i.tasks[0].y;
                }
                else
                {
                    //if tasks finished go home
                    target_x = i.house.x;
                    target_y = i.house.y;
                }

                if(i.shopping == 0)
                {
                    if (i.current.x == 0 && i.current.y == 0)
                    {
                        // if not on a point, find closest point
                        int indx = FindClosest(i.x, i.y, points);
                        i.current = points[indx];
                    }
                    else if (i.current.x == i.x && i.current.y == i.y)
                    {
                        if(i.tasks.Count > 0)
                        {
                            //find neighbour closest to the target
                            int indx = FindClosest(target_x + 31.5f, target_y + 25, i.current.neighbours);
                            i.current = i.current.neighbours[indx];

                            //check if self is the closest neighbour to target
                            if (indx == 0)
                                i.shopping = 1;
                        }
                        else
                        {
                            //find neighbour closest to the house
                            int indx = FindClosest(target_x + 10, target_y + 10, i.current.neighbours);
                            i.current = i.current.neighbours[indx];

                            //check if self is the closest neighbour to target
                            if (indx == 0)
                                i.shopping = -1;
                        }  
                    }
                }
                else
                {
                    if(i.shopping > 0)
                    {
                        //move into the shop and then move around there for a while

                        if (i.x == i.current.x && i.y == i.current.y)
                        {
                            Random rnd = new Random();
                            int num_x = rnd.Next(0, 66);
                            int num_y = rnd.Next(0, 46);
                            i.current.x = (int)target_x + num_x;
                            i.current.y = (int)target_y + num_y;
                        }

                        i.shopping++;

                        if (i.shopping == 300)
                        {
                            i.tasks.RemoveAt(0);
                            i.shopping = 0;
                            i.current = r0;
                        }
                    }
                    else
                    {
                        if (i.x == i.current.x && i.y == i.current.y)
                        {
                            Random rnd = new Random();
                            int num_x = rnd.Next(0, 16);
                            int num_y = rnd.Next(0, 16);
                            i.current.x = (int)target_x + num_x;
                            i.current.y = (int)target_y + num_y;
                        }
                    }
                }
                target_x = i.current.x;
                target_y = i.current.y;


                if (i.x < target_x )//+35
                    i.x++;
                else if (i.x > target_x)
                    i.x--;
                else if (i.y < target_y ) //+25
                    i.y++;
                else if (i.y > target_y )
                    i.y--;

                people[j] = i;
            }
            Render();

            if (ticks % day == 0)
            {
                generateRoute();
                double valueR = infected / (prevI * ((double)susceptible/people.Count));
                prevI = infected;
                label2.Text = valueR.ToString("#.###");
            }
        }
    }
}
