### Application architecture 

+---------+ +---------+ +--------+
|         | |         | |        |
|   Web   | | Mobile  | |  ...   |
|         | |         | |        |
+---------+ +---------+ +--------+
+--------------------------------+
|                                |
|              API               |
|                                |
+--------------------------------+         +--------+
         +---------------+                 |Mongo DB|		<--- (just for example)
         |               +---------------> +--------+
         |Infrastructure |
         |               +------->  +----------+
         +---------------+          |SQL Server|
          +-------------+           +----------+
          |             |
          |   Domain    |
          |             |
          +-------------+



# Domain - main entities in application
# Infrastructure (DAL) - takes data from databases and map it to app entities from 'Domain' layer
# API - unified solid access to app data
# ... - all applications that using 'API layer' to interact with app data