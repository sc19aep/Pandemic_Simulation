using LiveCharts;
using LiveCharts.Wpf;
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
            public Route current; //current point the person is on or heading to
            public int shopping; //checks if person is in a shop and how long they have been there already
            public int infected; //counts how long the person has been infected, to know when they are no longer ill
            public bool mask; //is the person wearing a mask
            public bool distance; //is the person trying to keep a distance from others
            public bool vaccine; //is the person vaccinated
            public int wait;
            public int essential; //-1 for not essential worker, or other number for shop index
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

        struct Data
        {
            public string type; //susceptible = 0, infected = 1; removed = 2
            public int count; //number of people in group
            public float day; //day when data point was submitted
        }

        Data d0, d1, d2;
        Person p1, p2, p3, p4, p5, p6;
        Building s1, h1; //shop 1 and house 1
        Route r1, r0; //route point

        int ticks = 0, N=1;
        float daynum = 0.0F;
        int infectionPercentage, maskUptake, vaccineUptake, distanceUptake, prevI, size;
        int day = 4000; //ticks in a day
        int days, asymp, latency, immune;
        int pandemic = 0, numInfected = 1, restarted = 0;
        bool lockdown = false;


        List<Building> houses = new List<Building> {};
        List<Building> shops = new List<Building> {};
        List<Person> people = new List<Person> {};
        List<Route> points = new List<Route> {};
        List<Data> chart = new List<Data> {};

        

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
            p1.vaccine = false;
            p1.wait = 0;
            p1.essential = -1;
            people.Add(p1);
            //person 2
            p2.x = x + 10;
            p2.y = y;
            p2.status = "Blue";
            p2.tasks = new List<Building> { };
            p2.house = h1;
            p2.current = r0;
            p2.shopping = 0;
            p2.infected = 0;
            p2.mask = false;
            p2.distance = false;
            p2.vaccine = false;
            p2.wait = 0;
            p2.essential = -1;
            people.Add(p2);
            if(size > 0)
            {
                //person 3
                p3.x = x;
                p3.y = y + 10;
                p3.status = "Blue";
                p3.tasks = new List<Building> { };
                p3.house = h1;
                p3.current = r0;
                p3.shopping = 0;
                p3.infected = 0;
                p3.mask = false;
                p3.distance = false;
                p3.vaccine = false;
                p3.wait = 0;
                p3.essential = -1;
                people.Add(p3);
                //person 4
                p4.x = x + 10;
                p4.y = y + 10;
                p4.status = "Blue";
                p4.tasks = new List<Building> { };
                p4.house = h1;
                p4.current = r0;
                p4.shopping = 0;
                p4.infected = 0;
                p4.mask = false;
                p4.distance = false;
                p4.vaccine = false;
                p4.wait = 0;
                p4.essential = -1;
                people.Add(p4);
            }
            if(size == 2)
            {
                //person 5
                p5.x = x;
                p5.y = y + 5;
                p5.status = "Blue";
                p5.tasks = new List<Building> { };
                p5.house = h1;
                p5.current = r0;
                p5.shopping = 0;
                p5.infected = 0;
                p5.mask = false;
                p5.distance = false;
                p5.vaccine = false;
                p5.wait = 0;
                p5.essential = -1;
                people.Add(p5);
                //person 6
                p6.x = x + 5;
                p6.y = y + 5;
                p6.status = "Blue";
                p6.tasks = new List<Building> { };
                p6.house = h1;
                p6.current = r0;
                p6.shopping = 0;
                p6.infected = 0;
                p6.mask = false;
                p6.distance = false;
                p6.vaccine = false;
                p6.wait = 0;
                p6.essential = -1;
                people.Add(p6);
            }
            
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

                if(pandemic > 0)
                {
                    int wait = rnd.Next(0, (int)day / 6);
                    p.wait = wait;
                }

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

        private void generateChart()
        {
            // initialising data
            cartesianChart1.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            var types = (from o in chart select new { type = o.type }).Distinct();
            
            foreach(var type in types)
            {
                List<double> values = new List<double>();
                for(float day = 0.0F; day <= daynum; day+=0.2F)
                {
                    double value = 0;
                    var data = from o in chart
                               where o.type.Equals(type.type) && o.day.Equals(day)
                               orderby o.day ascending
                               select new { o.count, o.day };
                    if (data.SingleOrDefault() != null)
                        value = data.SingleOrDefault().count;
                    values.Add(value);
                }
                series.Add(new LineSeries() { Title = type.type, Values = new ChartValues<double>(values) });
            }
            cartesianChart1.Series = series;
        }

        public Form1()
        {
            InitializeComponent();

            // null route point
            r0.x = 0;
            r0.y = 0;
            r0.neighbours = new List<Route> { };

            // variable initialization
            infectionPercentage = (int)infectionUpDown.Value;
            maskUptake = (int)maskUpDown.Value;
            vaccineUptake = (int)vaccineUpDown.Value;
            distanceUptake = (int)distanceUpDown.Value;
            days = (int)daysUpDown.Value; // length of being infectious and having symptoms
            asymp = (int)asymptomaticUpDown.Value; // length of being infectious prior to having symptoms
            latency = (int)latencyUpDown.Value; //length of being infected prior to being infectious
            immune = (int)ImmunityUpDown.Value; //length of removed status
            prevI = (int)InfectedUpDown.Value; //number of starting infected people, gets changed later to previous infected count

            // graph initialization
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Days",
                LabelFormatter = day => (day/5).ToString(),
                MinValue = 0.0F
            }) ;
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "People",
                LabelFormatter = value => value.ToString(),
                MinValue = 0
            }) ;
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
            
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            infectionPercentage = (int)infectionUpDown.Value;
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
            asymp = (int)asymptomaticUpDown.Value; 
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

        private void InfectedUpDown_ValueChanged(object sender, EventArgs e)
        {
            numInfected = (int)InfectedUpDown.Value;
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
            InfectedUpDown.Enabled = true;
            maskUpDown.Enabled = true;
            vaccineUpDown.Enabled = true;
            distanceUpDown.Enabled = true;
            Pandemic.Enabled = true;
            Start.Enabled = true;
            Stop.Enabled = false;
            Lockdown.Enabled = false;
            Freedom.Enabled = false;
            small.Enabled = true;
            medium.Enabled = true;
            large.Enabled = true;
            pandemic = 0;
            lockdown = false;
            restarted = 0;
            daynum = 0;

            houses.Clear();
            shops.Clear();
            people.Clear();
            points.Clear();
            chart.Clear();


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
            pandemic = 1;
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
            InfectedUpDown.Enabled = false;
            Stop.Enabled = true;
            Start.Enabled = false;
            Lockdown.Enabled = true;
            small.Enabled = false;
            medium.Enabled = false;
            large.Enabled = false;

            if (restarted == 0)
            {
                if (small.Checked)
                    size = 0;
                else if (medium.Checked)
                    size = 1;
                else
                    size = 2;

                //houses, shops and people
                generateMap();
                assignNeighbours();
                generateRoute();

                // generate starting infected agents
                for (int i = 0; i < numInfected; i++)
                {
                    Random gen = new Random();
                    int numgen = gen.Next(0, people.Count());
                    Person q = people[numgen];
                    q.status = "Violet";
                    people[numgen] = q;
                }
                restarted = 1;

                //generate essential workers - each shop gets a number of agents assigned to it
                for(int i = 0; i < shops.Count; i++)
                {
                    Random essrnd = new Random();
                    int count = 0;
                    int essentials = 0;
                    if (size == 0)
                        essentials = 5; //small population - 5 people per shop
                    else if (size == 1)
                        essentials = 10; //medium population - 10 people per shop
                    else
                        essentials = 15; //large population - 15 people per shop

                    while(count < essentials)
                    {
                        int essnum = essrnd.Next(0, people.Count);
                        if(people[essnum].essential == -1)
                        {
                            Person e1 = people[essnum];
                            e1.essential = i;
                            people[essnum] = e1;
                            count++;
                        }
                    }
                }

                // graph generation
                d0.type = "Susceptible";
                d0.count = people.Count() - (int)InfectedUpDown.Value;
                d0.day = daynum;
                chart.Add(d0);

                d1.type = "Infected";
                d1.count = (int)InfectedUpDown.Value;
                d1.day = daynum;
                chart.Add(d1);

                d2.type = "Removed";
                d2.count = 0;
                d2.day = daynum;
                chart.Add(d2);

                generateChart();

                //draw
                Render();
            }

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
            Random rnd = new Random();

            //check for nearby people
            for (int j = 0; j < people.Count(); j++)
            {
                // try to infect only if the other person is susceptible
                // try to infect only if both people are in the same room
                if (people[j].status == "Blue" && people[j].shopping == p.shopping)
                {
                    Person q = people[j];
                    float inf = infectionPercentage * 100;

                    //get the random chance number
                    int prob = rnd.Next(0, 10000);

                    if (p.shopping == 0)
                        inf = inf * 0.5f;

                    //if within 3 pixel vicinity, then the transmission probability is as chosen
                    if (q.x > p.x - 3 && q.x < p.x + 3 && q.y > p.y - 3 && q.y < p.y + 3)
                    {
                        if(pandemic == 2)
                        {
                            if (p.mask == false && q.mask == true)
                                inf = inf * 0.70f;
                            else if (p.mask == true && q.mask == false)
                                inf = inf * 0.05f;
                            else if (p.mask == true && q.mask == true)
                                inf = inf * 0.02f;

                            if (p.vaccine == true)
                                inf = inf * 0.001f;
                            if (q.vaccine == true)
                                inf = inf * 0.01f;
                        }
                        //else if no one has a mask, inf stays the same

                    }
                    // if within 6 pixels, then there is a good distance
                    else if (q.x > p.x - 6 && q.x < p.x + 6 && q.y > p.y - 6 && q.y < p.y + 6)
                    {
                        if (pandemic == 2)
                        {
                            if (p.mask == false && q.mask == true)
                                inf = inf * 0.35f;
                            else if (p.mask == true && q.mask == false)
                                inf = inf * 0.02f;
                            else if (p.mask == true && q.mask == true)
                                inf = inf * 0.01f;

                            if (p.vaccine == true)
                                inf = inf * 0.0001f;
                            if (q.vaccine == true)
                                inf = inf * 0.001f;
                        }
                        else
                            inf = inf * 0.5f;
                    }
                    else
                        continue;

                    if (p.shopping == 0) //is outdoors
                        inf = inf * 0.3f;

                    if (prob <= (int)inf)
                    {
                        Person r = people[j];
                        r.status = "Pink";
                        people[j] = r;
                    }

                } 
            }

            
        }

        private void enablePandemic()
        {
            //only enable once
            pandemic = 2;

            // people start wearing masks
            // people start keeping a distance
            // portion of the population is vaccinated - immune forever
            Random maskRnd = new Random();
            Random distRnd = new Random();
            Random vacRnd = new Random();

            for(int i = 0; i < people.Count(); i++)
            {
                Person p = people[i];
                int mask = maskRnd.Next(0, 100);
                int dist = distRnd.Next(0, 100);
                int vacc = vacRnd.Next(0, 100);

                if (mask <= maskUptake)
                    p.mask = true;
                if (dist <= distanceUptake)
                    p.distance = true;
                if (vacc <= vaccineUptake)
                    p.vaccine = true;

                people[i] = p;

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            int infected = 0;
            int susceptible = 0;

            if(pandemic == 1)
                enablePandemic();

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

                // become asymptomatic or show symptoms
                if (i.status == "Pink" && i.infected >= day * latency)
                    i.status = "Violet";

                if (i.status == "Violet" && i.infected >= day * (latency + asymp))
                    i.status = "Red";

                // end of infectious period, become removed
                if (i.infected == day * (days+latency))
                    i.status = "Gray";

                if (i.status == "Gray" || i.status == "Pink")
                    i.infected++;

                if (i.status == "Pink")
                    infected++;

                // end of immunity period, become susceptible
                if(i.status == "Gray" && i.infected == day * (days+latency+asymp+immune))
                {
                    i.status = "Blue";
                    i.infected = 0;
                }

                // count susceptible people
                if (i.status == "Blue")
                    susceptible++;

                // if infectious, spread disease
                if (i.status == "Red" ||  i.status == "Violet")
                {
                    infected++;
                    i.infected++;
                    if(susceptible != 0)
                        spreadInfection(j);
                }

                // assign target location to move towards
                float target_x, target_y;
                if(i.tasks.Count() > 0)
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

                if(i.status == "Red"  && target_x != i.house.x && pandemic==2)
                {
                    target_x = i.house.x;
                    target_y = i.house.y;
                    i.shopping = 299;

                }

                if(i.shopping == 0)
                {
                    if (i.current.x == 0 && i.current.y == 0)
                    {
                        // if not on a point, find closest point
                        int indx = FindClosest(i.x, i.y, points);
                        i.current = points[indx];
                    }
                    else if (i.x == i.current.x && i.y == i.current.y)
                    {
                        if(i.tasks.Count() > 0)
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

                // walk on different sides of the street 
                if(i.shopping < 1 && (i.x < target_x - 8 || i.x > target_x + 8 || i.y < target_y - 8 || i.y > target_y + 8))
                {
                    if (target_y > i.y) //moving down
                        target_x = target_x + 4;
                    else if (target_y < i.y) //moving up
                        target_x = target_x - 4;
                    if (target_x > i.x) //moving right
                        target_y = target_y - 4;
                    else if (target_x < i.x) //moving left
                        target_y = target_y + 4;
                }


                //move if social distancing is satisfied
                if (i.wait > 0 && i.x > i.house.x && i.x < i.house.x + 20 && i.y > i.house.y && i.y < i.house.y + 20)
                {
                    i.wait--;
                }
                else if (i.x > target_x - 8 && i.x < target_x + 8 && i.y > target_y - 8 && i.y < target_y + 8)
                {
                    if (i.x < target_x)//+35
                        i.x++;
                    else if (i.x > target_x)
                        i.x--;
                    if (i.y < target_y) //+25
                        i.y++;
                    else if (i.y > target_y)
                        i.y--;
                }
                else if((i.x > i.house.x+20 || i.x < i.house.x || i.y < i.house.y || i.y > i.house.y+20) && (pandemic == 2 && i.distance == true))
                {
                    int count = 0;

                    if (i.x < target_x)
                    {
                        for (int k = 0; k < people.Count(); k++)
                        {
                            if (k == j)
                                continue;
                            if (people[k].shopping != i.shopping)
                                continue;
                            if (people[k].x > i.x && people[k].x < i.x + 5 && people[k].y == i.y)
                            {
                                count = 1;
                                break;
                            }   
                        }
                        if(count == 0)
                            i.x++;
                    }        
                    else if (i.x > target_x)
                    {
                        for (int k = 0; k < people.Count(); k++)
                        {
                            if (k == j)
                                continue;
                            if (people[k].shopping != i.shopping)
                                continue;
                            if (people[k].x < i.x && people[k].x > i.x - 5 && people[k].y == i.y)
                            {
                                count = 1;
                                break;
                            }
                        }
                        if (count == 0)
                            i.x--;
                    }
                    count = 0;
                    if (i.y < target_y)
                    {
                        for (int k = 0; k < people.Count(); k++)
                        {
                            if (k == j)
                                continue;
                            if (people[k].shopping != i.shopping)
                                continue;
                            if (people[k].y > i.y && people[k].y < i.y + 5 && people[k].x == i.x)
                            {
                                count = 1;
                                break;
                            }
                        }
                        if (count == 0)
                            i.y++;
                    }
                    else if (i.y > target_y)
                    {
                        for (int k = 0; k < people.Count(); k++)
                        {
                            if (k == j)
                                continue;
                            if (people[k].shopping != i.shopping)
                                continue;
                            if (people[k].y < i.y && people[k].y > i.y - 5 && people[k].x == i.x)
                            {
                                count = 1;
                                break;
                            }
                        }
                        if (count == 0)
                            i.y--;
                    }
                }
                else
                {
                    if (i.x < target_x)//+35
                        i.x++;
                    else if (i.x > target_x)
                        i.x--;
                    if (i.y < target_y) //+25
                        i.y++;
                    else if (i.y > target_y)
                        i.y--;
                }

                people[j] = i;
            }
            Render();

            if (ticks == day)
            {
                ticks = 0;
                N = 1;
                generateRoute();
                double valueR = infected / (prevI * ((double)susceptible/people.Count));
                prevI = infected;
                label2.Text = valueR.ToString("#.###"); 
            }
            
            if(ticks == day/5 * N)
            {
                daynum += 0.2F;
                N++;

                d0.type = "Susceptible";
                d0.count = susceptible;
                d0.day = daynum;
                chart.Add(d0);

                d1.type = "Infected";
                d1.count = infected;
                d1.day = daynum;
                chart.Add(d1);

                d2.type = "Removed";
                d2.count = people.Count - susceptible - infected;
                d2.day = daynum;
                chart.Add(d2);

                generateChart();
            }
        }
    }
}
