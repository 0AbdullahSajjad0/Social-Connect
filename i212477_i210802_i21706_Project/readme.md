### Windows Forms Social Media Application

#### Project Overview

    This project is a social media application built using Windows Forms in C#. It provides users with the ability to register, log in, create posts, view trending content, search for users and posts, receive notifications, and manage their profiles.

### Features

    Login: Users can log in using their username and password.
    Registration: New users can register by providing necessary information such as name, email, username, and password.
    Home: A feed of posts created by users followed by the logged-in user.
    Trending: A view displaying posts that are currently trending.
    Search: A search feature allowing users to find other users or posts.
    Notifications: A section where users can view their notifications (e.g., new followers, likes on posts).
    Create Post: Users can create new posts with text and images.
    Profile: Users can view and edit their profile information, as well as manage their posts.

### Setup Instructions

    To run this project, you'll need:

    Visual Studio (version 2019 or later)
    .NET Framework (4.7.2 or later)
    SQL Server for the backend database
    Appropriate database connection strings

### Setting Up the Project

    Clone the Repository: Clone this repository to your local environment.
    bash
    Copy code
    git clone <repository-url>
    Open the Solution: Open the cloned solution in Visual Studio.
    Configure Database Connection: Update the connectionString variable in the code to point to your SQL Server instance.
    Run Database Migrations: If the project includes database migrations, run them to set up the necessary tables and data.
    Build and Run the Project: Build the project in Visual Studio and run it.

### Database Schema

    The following tables are used in the project:

    Users: Stores user information, including ID, name, email, username, password, and privacy settings.
    Posts: Contains post data, such as ID, user ID, image, likes, and trend status.
    Followers: Represents relationships between users, with each row indicating that one user follows another.
    Likes: Contains all the likes a user makes to a post
    ProfilePictures: Contains all the profile pictures of any user who uploads one.

### Usage

    Registration: New users should register to create an account.
    Login: Existing users can log in with their username and password.
    Home: After logging in, users are taken to the home screen, where they can see posts from users they follow.
    Trending: Users can view trending posts in this section.
    Search: Users can search for other users or specific posts.
    Notifications: Users can view their notifications, including new followers and likes on their posts.
    Create Post: Users can create new posts with text and images.
    Profile: Users can view their profile, update personal information, and manage their posts.

### Contribution Guidelines

    If you'd like to contribute to this project, please follow these steps:

    Fork the repository.
    Create a new branch for your feature or bug fix.
    Commit your changes and push to your fork.
    Submit a pull request to the original repository.

### License

    This project is licensed under the MIT License. Please refer to the LICENSE file for more information.
