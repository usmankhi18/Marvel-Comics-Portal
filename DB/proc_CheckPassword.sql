
CREATE procedure [dbo].[proc_CheckPassword]
@UserID int,
@Password varchar(50)

as
begin
 
 IF EXISTS (SELECT * FROM Users where UserID=@UserID and Password=@Password)
BEGIN
SELECT 'Exist' IsActive;
END
ELSE
BEGIN
SELECT 'NotExist' ISActive;
END
end