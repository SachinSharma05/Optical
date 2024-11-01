create table productType (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null
 )

 create table category (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null,
   category_name nvarchar(50) not null
 )

 create table subCategory (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null,
   category_name nvarchar(50) not null,
   subCategory_name nvarchar(50) not null
 )

 create table inventoryMaster (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null,
   category_name nvarchar(50) not null,
   subCategory_name nvarchar(50) not null,
   product nvarchar(50) not null,
   price int not null,
   stock int not null,
   reorder int not null,
   limit int not null,
   tax_category nvarchar(50)
 )

  drop table productType
  drop table category
  drop table subCategory
  drop table inventoryMaster