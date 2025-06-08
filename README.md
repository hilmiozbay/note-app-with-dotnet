# Note-Taking Application

## Overview

This is a web-based note-taking application built with ASP.NET Core MVC and PostgreSQL. It allows users to manage their notes with functionalities to create, view, edit, and delete notes. Admin users have additional privileges to manage other users.

## Technologies Used

- **ASP.NET Core MVC**: Framework for building the web application using the MVC architecture.
- **PostgreSQL**: Database system for storing user and note information.
- **Entity Framework Core**: ORM for data access and manipulation with PostgreSQL.

## Project Structure

### Models

- **User**: Represents users with properties such as `Id`, `Firstname`, `Surname`, `MailAddress`, `IsActive`, `IsAdmin`, `CreateTime`, and `LastUpdateTime`.
- **Note**: Represents notes with properties including `Id`, `Description`, `AccountId`, `CreateTime`, and `LastUpdateTime`.
- **Account**: Represents user accounts with properties like `Id`, `UserId`, `Username`, `Password`, and `IsActive`.

### Data Access

- **Entity Framework Core**: Handles interactions with the PostgreSQL database.
- **DbContext**: Configures DbSet properties for `Users`, `Notes`, and `Accounts`.

### Controllers

- **HomeController**: Manages basic pages like home, login, and registration.
- **NoteController**: Handles CRUD operations for notes.
- **UserController**: Manages user-related functionalities and admin tasks.

### Views

- **Razor Pages**: Used for the UI, organized under `admin`, `home`, and `user` folders.
  - **Admin Views**: For managing user accounts and viewing statistics.
  - **User Views**: For note operations such as adding, editing, and deleting notes.
  - 

### Configuration

- **PostgreSQL Connection**: Configured in `appsettings.json` for EF Core.
- **Migration**: EF Core migrations for creating and updating the database schema.

## Features

- **User Management**: Admins can add, edit, and delete users. Regular users can view and update their own information.
- **Note Management**: Users can create, view, edit, and delete notes.
- **Authentication**: Basic authentication for users to log in and manage their notes.

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/ozbayhilmi/note-app-with-dotnet


