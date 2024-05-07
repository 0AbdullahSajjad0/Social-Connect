using System;

namespace WinFormsApp1
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        // Constructor for initialization
        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }

    public static class SessionData
    {
        // Property to store the current user object
        public static User CurrentUser { get; set; }
    }

    // Static class to store search related data
    public static class SearchClass
    {
        // Properties to store search related information
        public static int SearchId { get; set; }
        public static string SearchIdName { get; set; }
    }

    // Static class to store the current trend
    public static class Trends
    {
        // Property to store the current trend
        public static string Trend { get; set; }
    }
}
