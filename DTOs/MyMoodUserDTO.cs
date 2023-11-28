namespace LoveLink.DTOs
{
    public class MyMoodUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public MyMoodDto? MyMood { get; set; }
        // Add other properties from the User entity that you want to expose
    }
}
