# Pandemic_Simulation

Before running the program make sure to install LiveCharts by going to Project - Manage NuGet Packages in Visual Studio and installing LiveCharts.WinForms.NetCore3 by Beto Rodriguez, version 0.9.7



Number of Houses = 222  
Number of Shops = 12  
Number of People = small - 444, medium - 888, large - 1332  

People living in a house = 2 (small population), 4 (medium population) or 6 (large population)  
Max people in shop = unlimited, in future works could be modified to limit customer amount at one time.  

To start the simulation, must press the "Simulate" button, which starts the timer and therefore the simulation. To pause the simulation, must press the "Stop" button, which pauses the timer and therefore the simulation.  

After a while of running the simulation, the user can decide to call a pandemic, by pressing the "Call Pandemic" button. This button puts into effect the settings for Masks, Distance and Vaccines. It also makes symptomatic agents return home until they recover, in hopes of slowing the spread.  
It also unlocks the "Start Lockdown" button, which means that all people with symptoms will stay home and people will leave their homes less.

The "End Lockdown" button means people will start going to stores the regular amount again. 

The "Restart" button restarts the simulation letting the user change all settings and start again from the begining.

Shopping: more than 0 - in shop, exactly zero - outdoors, less than zero - in house.  

Essential workers equal a bit less than 33% percent of the population.  
