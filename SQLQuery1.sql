create database WattPad
use WattPad
Create table tbl_Reg(        
 UserId int IDENTITY(1,1) NOT NULL,        
    Email varchar(20) NOT NULL,        
    Password varchar(20) NOT NULL
)
ALTER TABLE tbl_Reg ADD RoleId int
select *from tbl_Reg

Go
create or alter procedure [dbo].[Watt_AddUser]  
(  
@Email varchar(20)=NULL,  
@Password varchar(20)=NULL,  
@RoleId int
)
as  
begin  
insert into tbl_Reg(Email,Password,RoleId)values(@Email,@Password,@RoleId)  
end  


Go
create or alter procedure [dbo].[Watt_Login]  
(  
@Email varchar(20)=NULL,  
@Password varchar(20)=NULL
)
as  
begin  
select Email from tbl_Reg where Email=@Email and Password=@Password
end  

Create Table tbl_Role (
RoleId int IDENTITY (1,1) PRIMARY KEY NOT NULL,
Role varchar(20) NOT NULL)

insert into tbl_Role(Role) values('User')

select *from tbl_Role

CREATE TABLE BlogPost (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    PublishDate varchar(100)NOT NULL
);

alter table BlogPost ADD ImagePath varchar(Max);


select *from BlogPost

create or alter procedure [dbo].[SP_AddBlog]  
( 
@Title varchar(20)=NULL,  
@Content NVARCHAR(MAX)=NULL,  
@PublishDate varchar(255)=NULL,
@ImagePath Varchar(Max)
)
as  
begin  
insert into BlogPost(Title,Content,PublishDate,ImagePath)values(@Title,@Content,@PublishDate,@ImagePath)  
end

Go
Create or alter procedure [dbo].[sp_GetAllBlogs] 
as      
Begin      
    select *from BlogPost  	
End 

Go
Create or alter procedure [dbo].[sp_GetAllBlogsbyId] 
@Id int
as      
Begin      
    select *from BlogPost  where Id = @Id	
End 

Go
create or alter procedure [dbo].[SP_UpdateBlog]
@Id int,
@Title NVARCHAR(255),
@Content NVARCHAR(MAX),
@PublishDate varchar(255)
AS
BEGIN
    UPDATE BlogPost
    SET Title = @Title,
        Content = @Content,
        PublishDate = @PublishDate
    WHERE Id = @Id
END

Go
Create or alter procedure [dbo].[sp_DeleteBlog]   
@Id int
as      
Begin      
    delete from BlogPost where Id=@Id 	
End 