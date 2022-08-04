CREATE proc [dbo].[usp_categorymaster]
@company_id int  =null,
@category_id int  =null,
@category_name nvarchar(50)=null, 
@category_desc nvarchar(50)=null,
@flag int 
as
begin

if(@flag=1)
begin
set @category_id=(SELECT isnull(max(category_id),0) FROM t_category_master)
insert into t_category_master(company_id_fk,category_id,category_name,category_desc,created_date)
values(@company_id,@category_id+1,@category_name,@category_desc,getdate())
end
else if(@flag=2)
begin
update t_category_master
set
company_id_fk=@company_id,
category_name=@category_name,
category_desc=@category_desc,
updated_date=getdate()
where category_id=@category_id
end

else if(@flag=3)
begin
delete from t_category_master where category_id=@category_id
end

else if(@flag=4)
begin
select category.company_id_fk as 'CompanyId', company.company_name as 'CompanyName',category.category_id as 'CategoryId',
category.category_name as 'CategoryName', category.category_desc as 'CategoryDesc'
from t_category_master  as category
left join t_company_master as company on category.company_id_fk=company.company_id
where category.category_id=@category_id
end

else if(@flag=5)
begin
select company_id as 'CompanyId',company_name as 'CompanyName' from t_company_master
end
else if(@flag=6)
begin
SELECT isnull(max(category_id),0)+1 FROM t_category_master
end
else if(@flag=7)
begin
select category.company_id_fk as 'CompanyId', company.company_name as 'CompanyName',category.category_id as 'CategoryId',
category.category_name as 'CategoryName', category.category_desc as 'CategoryDesc'
from t_category_master  as category
left join t_company_master as company on category.company_id_fk=company.company_id
end
end

