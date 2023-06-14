# banking-management-system
step-1 :- download zip file (banking-management-system-main.zip)

step-2 : extract this file in any location

step-3 : import database file in sql server management studio
	=> open sql server management studio right click on databases 
	=> import data-tier application 
	=> click next 
	=> browse database file from banking management system project 
	=> fill new database name as "Bank Management System"	
	=> click on next and finish
 
step-4 : connect database to our project
	=> open our project in visual studio IDE
	=> click on view select other windows and choose data sources 
	=> click Add new data source 
	=> choose database => dataset
	=> click on New connection select Microsoft SQL server
	=> copy server name from sql server and it in server name
	=> select database (Bank Management System)
	=> finish

step-5 : open app.config file in their project 
	=> find connectionString and replace with own connectionString  
	
done!!!
	

