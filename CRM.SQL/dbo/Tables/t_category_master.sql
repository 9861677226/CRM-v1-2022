CREATE TABLE [dbo].[t_category_master] (
    [company_id_fk] INT           NULL,
    [category_id]   INT           NULL,
    [category_name] NVARCHAR (50) NULL,
    [category_desc] NVARCHAR (50) NULL,
    [created_date]  DATETIME      NULL,
    [updated_date]  DATETIME      NULL
);

