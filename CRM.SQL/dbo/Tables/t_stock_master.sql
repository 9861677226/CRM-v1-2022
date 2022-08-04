CREATE TABLE [dbo].[t_stock_master] (
    [product_id]     INT           NULL,
    [company_id_fk]  INT           NULL,
    [category_id_fk] INT           NULL,
    [product_name]   NVARCHAR (50) NULL,
    [product_desc]   NVARCHAR (50) NULL,
    [product_mrp]    DECIMAL (18)  NULL,
    [stock]          INT           NULL,
    [fin_yr]         NVARCHAR (50) NULL,
    [created_date]   DATETIME      NULL,
    [updated_date]   DATETIME      NULL,
    [is_stock]       BIT           NULL
);

