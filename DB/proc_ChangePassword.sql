

CREATE procedure [dbo].[proc_ChangePassword]
@UserID int,
@Password varchar(50)

as
begin
 UPDATE Users  SET Password=@Password
 where UserID = @UserID

 SELECT @UserID
 
 
end
