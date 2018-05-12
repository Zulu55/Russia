namespace RussiaX.Helpers
{
    using Models;
    public static class Transform
    {
        public static UserLocal ToUserLocal(User user)
        {
            return new UserLocal
            {
                Email = user.Email,
                FirstName = user.FirstName,
                ImageArray = user.ImageArray,
                ImagePath = user.ImagePath,
                LastName = user.LastName,
                Password = user.Password,
                Telephone = user.Telephone,
                UserId = user.UserId,
                UserTypeId = user.UserTypeId,
            };
        }
    }
}
