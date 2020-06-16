

CREATE procedure [dbo].[proc_GetLogin]
@Email varchar(150),
@Password varchar(150)
as
begin
	 SELECT u.UserID,u.UserName,u.FirstName,u.LastName,u.Gender,u.Email
      ,u.IsActive,u.MobileNo,u.DateOfBirth,u.Country,u.RoleID,u.StatusID,i.ImageUrl, s.Status, rm.[Role] FROM Users u 
		INNER JOIN 
			Images i ON u.UserID= i.UserID
			INNER JOIN 
				dbo.[Status] s on s.StatusID = u.StatusID
				INNER JOIN 
					RoleMaster rm on rm.RoleID = u.RoleID
				WHERE u.UserName=@EMAIL AND PASSWORD = @PASSWORD AND ISACTIVE=1



      
end
