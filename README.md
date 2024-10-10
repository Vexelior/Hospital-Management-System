# Hospital Management System

## Overview

The **Hospital Management System** is a comprehensive web application designed to manage hospital operations efficiently. Built using **ASP.NET Core MVC** and **SQL Server**, this system follows **Clean Architecture** principles to ensure scalability, maintainability, and testability.

## Features

- **Patient Management:** Add, update, view, and delete patient records.
- **Appointment Scheduling:** Schedule and manage patient appointments with doctors.
- **Medical Records:** Maintain and view detailed medical records and histories.
- **Financial Management:** Review and process financial claims and histories.

## Architecture

This project adheres to the Clean Architecture principles, organized into distinct layers:

- **Core:** Contains domain entities and business logic.
- **Application:** Implements application logic and use cases.
- **Infrastructure:** Handles data access and external services.
- **Web:** Implements the ASP.NET Core MVC front-end.

## Technologies Used

- **ASP.NET Core MVC:** Framework for building web applications.
- **SQL Server:** Database management system for storing application data.
- **Entity Framework Core:** ORM for database interactions.
- **Clean Architecture:** Design pattern to ensure separation of concerns.
