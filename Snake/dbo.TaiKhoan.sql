CREATE TABLE [dbo].[TaiKhoan] (
    [TenTK]   VARCHAR (50) NOT NULL,
    [MatKhau] VARCHAR (50) NOT NULL,
    [Email]   VARCHAR (50) NOT NULL,
    [EasyPoint]   BIGINT       NULL,
    [HardPoint] BIGINT NULL, 
    PRIMARY KEY CLUSTERED ([TenTK] ASC)
);

