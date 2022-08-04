CREATE proc [dbo].[usp_companymaster]
@company_id int  =null,
@company_name nvarchar(50)=null, 
@company_desc nvarchar(50)=null,
@flag int 
as
begin

if(@flag=1)
begin
set @company_id=(SELECT isnull(max(company_id),0) FROM t_company_master)
insert into t_company_master(company_id,company_name,company_desc,created_date)
values(@company_id+1,@company_name,@company_desc,getdate())
end
else if(@flag=2)
begin
update t_company_master
set company_name=@company_name,
company_desc=@company_desc,
updated_date=getdate()
where company_id=@company_id
end

else if(@flag=3)
begin
delete from t_company_master where company_id=@company_id
end

else if(@flag=4)
begin
select company_id as 'CompanyId',company_name as 'CompanyName',company_desc as'CompanyDesc' from t_company_master where company_id=@company_id
end

else if(@flag=5)
begin
select company_id as 'CompanyId',company_name as 'CompanyName',company_desc as'CompanyDesc' from t_company_master
end
else if(@flag=6)
begin
SELECT isnull(max(company_id),0)+1 FROM t_company_master
end
end

