![Signal Chain logo](/client/src/assets/SignalChain_logo_600.png "Signal Chain application")

# Introduction
Thank you for reviewing my final, full-stack capstone project as part of my full-time studies in [Nashville Software School](https://nashvillesoftwareschool.com/)'s Cohort 80. The **Signal Chain** application was developed using C# .Net, React.js, React Bootstrap for styling, and custom CSS for enhanced styling. 

**Bonus**: I added Vite unit tests to cover the 13 main React components.

## Problem this solves
I have a small home studio. If you asked me to provide an inventory list of the instruments and gear I use, it would be difficult. And then, when I needed to catalogue everything for my insurance policy (which I did), it's a total headache. Others might have a similar predicament for different inventories - book and music collections, physical retail stock, or even antiques.

**Signal Chain** solves my problem by providing a modern web application to store, update, create, or delete items in my studio inventory. I can view and update an item's details, see a list of songs that use that item, connect additional songs, and add more gear items. 

At the same time, Signal Chain connects songs produced in the studio to gear items that were used on each song. I can also see the full list of songs, add songs, and view and update a song's details.

Admins have extra privileges: remove gear items, remove songs, and view the studio inventory count in the navigation bar.

### Screenshots
See screenshots of every page [here](/client/public/screenshots/screenshots.md)

### Technical Features
- Unit Tests
- Data validation with Data Annotations
- Role-based access: Owner admin, Client
- Many-to-many relationship: GearSongs join table
- AutoMapper
- Interface

### Installation
Install Signal Chain locally and get started! Instructions [here](/client/public/installation.md).

---

### Requirements
**Data Requirements**
1. You must have an ERD for your project.
1. You must have a user-related data scheme. This means that different people can authenticate with your application, and the resources that are created must be assigned to individual users.
1. You must have at least one one -> many relationship in your ERD.
1. You must have at least one many -> many relationship in your ERD.
1. You are required to use the persistent storage tool that you were taught (SQL Server, SQLite, etc.).

**Application Design Requirements**

*Client*
1. You must support CRUD in your application. Create data, Read data, Update data, Delete data
1. You are required to use React.
1. You must have a form that allows a user to create a new resource.
1. Your form must include `<select>` element, radio button group, or checkbox group that allows a user to choose a related resource.
1. You must show your proficiency with writing modular code that follows the the Single Responsibility Principle.
1. Your application must support multiple client routes to show different views to the user, and the user must be able to navigate to each route/view.
1. You must be able to implement a flexible layout for your UI by either (a) authoring your own CSS using Flexbox, or (b) using a 3rd party framework like Bootstrap.
1. All copy for your application must be legible, so pay attention to colors, margins, padding, and font sizes.

*Server*
1. Customer must be able to delete their own data, and be prevented from deleting other customers' data.
1. Customer must be able to edit their own data, and be prevented from editing other customers' data.
1. You are required to use the major framework that you learned during the course (e.g. ASP.NET).
1. You must implement the authentication scheme you learned during the course (Identity Framework, etc...).
