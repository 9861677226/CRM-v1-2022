CREATE TABLE [dbo].[t_customer_master] (
    [customer_id]         INT            NULL,
    [customer_name]       NVARCHAR (50)  NULL,
    [customer_mobile]     NVARCHAR (50)  NULL,
    [customer_email]      NVARCHAR (50)  NULL,
    [customer_dob]        DATE           NULL,
    [customer_address]    NVARCHAR (200) NULL,
    [customer_occupation] NVARCHAR (50)  NULL,
    [channel]             NVARCHAR (50)  NULL,
    [created_date]        DATETIME       NULL,
    [updated_date]        DATETIME       NULL
);

