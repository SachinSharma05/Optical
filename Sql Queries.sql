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
   productType nvarchar(50) not null,
   categoryName nvarchar(50) not null,
   subCategoryName nvarchar(50) not null,
   productName nvarchar(50) not null,
   sellingPrice nvarchar(50) not null,
   stockLimit nvarchar(50) not null,
   stockReorderPoint nvarchar(50) not null,
   stockInHand nvarchar(50) not null,
   taxCategory nvarchar(50),
   createdOn date
 )

 create table customerMaster (
   id int not null identity(1,1) primary key,
   customerName nvarchar(50) not null,
   address nvarchar(100),
   contactNo nvarchar(50),
   alternateContact nvarchar(50),
   age nvarchar(50),
   gender nvarchar(50),
   email nvarchar(50),
   remarks nvarchar(50)
 )

  drop table productType
  drop table category
  drop table subCategory
  drop table inventoryMaster
  drop table customerMaster