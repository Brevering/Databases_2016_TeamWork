<p align="center">
<a href="http://academy.telerik.com/">
<img src="https://camo.githubusercontent.com/08ecbe7b67d65cc7c6990787e2836b27b4296f2d/68747470733a2f2f7261772e6769746875622e636f6d2f666c65787472792f54656c6572696b2d41636164656d792f6d61737465722f50726f6772616d6d696e6725323077697468253230432532332f436f6465732f4f746865722f54656c6572696b2e706e67"/>
</a>

<h1 align="center">CSharp Databases October 2016 - Team "Russian-Spring-Punch"</h1>

###:mortar_board:Team Members
| Name              | Academy Username      	|
|-------------------|-------------------|
|                   | :white_check_mark:|
|Александър Несторов |__Alexander.N__	        |
|Ангел Ангелов |__angel.angelov.7146557__    	|	
|Иван Първанов |__ivan.parvanov.1__ |
|Калоян Стефанов |__kaloyanchost__            	|		
|Спасимира Хаджиева|__SpasimiraHadzhieva__    	 	|	
|Станимир Стоев|__Stanimir_Stoev__       	|		

#   Databases 2016: Project Documentation

#   Car Factory Database
* A car dealership factory which holds information about its cars, models, dealers, manufacturers, dealer towns in MongoDB database consisting of 8 tables.
* See examples for the following schema for car dealership factory:

### Problem 1.

#### Cars

| Id | ModelId | DealerId | OrderId | BasePrice | Year |
|----|----------|---------------------|-----------|------------|---|
| 1  | 2       | 1      | 100       | 25 000       | 10.10.2008 |
| 2  | 3       | 2 | 100       | 35 000       | 12.12.2006 |
| 3  | 4       | 3       | 300       | 55 000       | 09.09.2014 |
| 4  | 5       | 4   | 200       | 12 000       | 01.01.2007 |
| …  | …        | …                   | …         | …          | … |
ModelId, DealerId and OrderId are foreign keys to:
  * Models
  * Dealers
  * Orders

The relationships between them are as follows:
  * Cars - Models : Many to One
  * Cars - Dealers : Many to One
  * Cars - Orders : One to Many
 
#### Models

| Id |             ModelName             | Year | ManufacturerId | EngineId | PlatformId |
|----|-------------------------------------|---- | ---- | ---- | ---- |
| 1 | BMW E320                  | 10.10.2008 | 1 | 5 | 2 |
| 2 | Audi TT                       | 12.12.2006 | 2 | 6 | 1 |
| 3 | Toyota    Ltd. | 09.09.2014 | 3 | 6 | 2 |
| 4 | Volkswagen Golf | 01.01.2007 | 4 | 3 | 2|
| …  | …                                   | … | … | … | … |
 ManufacturerId, EngineId and PlatformId are foreign keys to:
  * Manufacturers
  * Engines
  * Platforms
  
The relationships between them are as follows:
  * Models - Manufacturers : Many to One
  * Models - Engines : Many to One
  * Models - Platforms : Many to One

#### DealerTowns

| Id  | DealerTown |
|-----|--------------|
| 1 | Sofia       |
| 2 | Plovdiv       |
| 3 | Varna       |
| 4 | Burgas       |
| …   | …            |

#### Engines

| Id  | FuelType |   HorsePower    |
|-----|----------|----------|
| 1 | Benzin      |   100   |
| 2 | Electric       |   150   |
| 3 | Diesel      |   200   |
| 4 | Benzin       |   180   |
| …   | …            |    …     |
 Any FuelType in Engines is inserted with the corresponding indexes as follows:
 * 1000 - Benzin
 * 2000 - Electric
 * 3000 - Diesel

#### Platforms

| Id  | PlatformType |   NumberOfDoors    |
|-----|----------|----------|
| 1 | Compact      |   2   |
| 2 | Sedan       |   4   |
| 3 | Van      |   6   |
| …   | …            |  …   |
 Any PlatformType in Platforms is inserted with the corresponding indexes as follows:
 * 100 - Compact 
 * 200 - Sedan 
 * 300 - Suv 
 * 400 - Van
  
#### Dealers

| Id  | DealerName |   TownId   |
|-----|----------|----------|
| 1 | West Coast Z-Mobile Group |   3   |
| 2 | National Space Explore Corp. |   1   |
| 3 | Global Space Explore Group     |   4  |
| 4 | Professional Space Research Group     |   2  |
| …   | …            |  …   |
TownId is foreign key to:
 * Towns

The relationship is as follows:
  * Dealers - Towns : Many to Many
 

#### Manufacturers

| Id  | ManufacturerName |
|-----|----------|
| 1 | BMW      |
| 2 |  Audi     |
| 3 |    Toyota  |
| 4 |   Volkswagen   |
| …   | …   |

#### Orders

| Id  | Date |   OrderStatus    |
|-----|----------|----------|
| 1 | 2015-03-19 11:41:57.110 |  4     |
| 2 | 2015-01-01 01:16:06.280   |   3    |
| 3 | 2015-01-01 00:00:01.690        |   3     |
| 4 | 2015-01-03 01:51:46.880        |   3    |
| …   | …            |    …     |
 Any  OrderStatus in  Orders is inserted with the corresponding indexes as follows:
  * 0 - Open
  * 1 - Pending
  * 2 - Shipped
  * 3 - Closed
  * 4 - Cancelled


