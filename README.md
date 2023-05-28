<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/vrmedina/d_Videogame_Store">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">.NET 7 Videogame Store API</h3>

  <p align="center">
    An awesome Videogame Store management API build with .NET 7!
    <br />
    <a href="https://github.com/vrmedina/d_Videogame_Store"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/vrmedina/d_Videogame_Store">View Demo</a>
    ·
    <a href="https://github.com/vrmedina/d_Videogame_Store/issues">Report Bug</a>
    ·
    <a href="https://github.com/vrmedina/d_Videogame_Store/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://google.com)

Welcome to the Videogame Rental Store API, a powerful management system designed specifically for videogame rental stores. This API is built using .NET 7.0, Entity Framework, and SQL Server 2022, offering a seamless and efficient solution for managing your rental operations.

With the Videogame Rental Store API, you can effortlessly handle game inventory, customer information, rentals, returns, and more. It provides a comprehensive set of endpoints that enable easy integration with your existing systems or front-end applications.

Key Features:

* Simplify inventory management with seamless tracking of game titles, availability, and stock levels.
* Efficiently handle customer profiles, enabling easy access to rental history, preferences, and personal information.
* Streamline rental operations with intuitive endpoints for checking out games, tracking due dates, and managing returns.
* Leverage the power of Entity Framework and SQL Server 2022 for robust and scalable data storage.

Get started with the Videogame Rental Store API today and elevate your rental business to new heights of efficiency and customer satisfaction.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![.NET][Dotnet7]][Dotnet7-url]
* [![Swagger][Swagger]][Swagger-url]
* [![MicrosoftSQLServer][MicrosoftSQLServer]][MicrosoftSQLServer-url]

This Videogame Rental Store API is built using cutting-edge technologies to ensure a seamless and efficient management system. The key technologies used in this project include:

* .NET 7: The API is developed using the latest version of .NET, providing a powerful and feature-rich framework for building robust applications.

* Swagger: The API documentation is generated using Swagger, which offers a clean and interactive interface to explore and test the API endpoints.

* Microsoft SQL Server 2022: The project utilizes the power of Microsoft SQL Server 2022 as the database management system, ensuring secure and reliable data storage for all rental store operations.

With this powerful combination of technologies, the Videogame Rental Store API delivers a modern, scalable, and user-friendly solution for managing your videogame rental store efficiently.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

Welcome to the Videogame Rental Store API! This section will guide you through the initial steps to get the API up and running in your development environment. You will find instructions on how to set up the necessary prerequisites, install dependencies, and run the API locally.

### Prerequisites

Before getting started with the Videogame Rental Store API, ensure that you have the following prerequisites installed:

1. Install .NET 7 SDK for your O.S.
   ```sh
   https://dotnet.microsoft.com/en-us/download/dotnet/7.0
   ```
2. Install Git for your O.S.
   ```sh
   https://git-scm.com/downloads
   ```
3. Install SQL Server 2022 Express with default settings
   ```sh
   https://www.microsoft.com/en-us/sql-server/sql-server-downloads
   ```
4. Install SQL Server Management Studio (SSMS)
   ```sh
   https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
   ```
   
Once you have the prerequisites ready, you can proceed to the next section to set up and configure the Videogame Rental Store API.

### Installation

_For this project to work properly you will need to have installed Visual Studio Code, SQL Server 2022 Express, .NET 7 SDK, Git._

1. Open an empty folder in VS Code
2. Open a new terminal
3. Clone the repo
   ```sh
   git clone https://github.com/vrmedina/d_Videogame_Store.git
   ```
4. Install dotnet-ef extension from terminal
   ```sh
   dotnet tool install --global dotnet-ef
   ```
5. Add migration with a random name like so
   ```sh
   dotnet ef migrations add Migracion
   ```
6. Create the database with entity framework
   ```sh
   dotnet ef database update
   ```

### Database population

_In order to have some data you can test the API with, you'll need to run a few scripts from your SQL Server Management Studio._

1. Run the SSMS program you previously installed
2. Connect to the default server <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/e589af30-5c84-4d83-8e99-90d27b0f35c4)
3. Open the 3 SQL files you'll find in the SQLScripts folder of the project <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/9138b7c7-be07-4689-835a-4c17bf810fb8)
4. Execute them in order, 01...02...03... <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/eb56d73d-d1a1-47d9-9f97-755b47f29339)


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

To get started with the usage of the project, follow the steps outlined below:

1. Now you can run the project. Execute the following command in your terminal to start the project.
   ```sh
   dotnet watch run
   ```
2. You will see the following screen <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/96f261e0-c0c3-4ba5-9d19-f72e152565f9)
3. In order to have access to the endpoints, you need to register <br>
* Under Auth, clic in Register <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/05495f4f-9672-4703-950a-c7df37a6545d)
* Now clic in "Try it out" <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/da28960c-adca-4b5c-8931-e329c8077056)
* In the Request Body insert the username and password you want <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/a169aa32-aeb3-455d-92f7-b937db7f66b0)
* Finally clic "Execute" <br>
![image](https://github.com/vrmedina/d_Videogame_Store/assets/12649707/5c892847-6d95-4d6f-9113-d30a63c666ce)
* Congrats, your user has been created! Now you can log in to the API.


_For more examples, please refer to the [Documentation](https://swagger.io/)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Add Changelog
- [x] Add back to top links
- [ ] Add Additional Templates w/ Examples
- [ ] Add "components" document to easily copy & paste sections of the readme
- [ ] Multi-language Support
    - [ ] Chinese
    - [ ] Spanish

See the [open issues](https://github.com/vrmedina/d_Videogame_Store/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Victor Medina - [@vrmedina98](https://twitter.com/vrmedina98) - vrmm1998@gmail.com

Project Link: [https://github.com/vrmedina/d_Videogame_Store](https://github.com/vrmedina/d_Videogame_Store)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/vrmedina/d_Videogame_Store.svg?style=for-the-badge
[contributors-url]: https://github.com/vrmedina/d_Videogame_Store/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/vrmedina/d_Videogame_Store.svg?style=for-the-badge
[forks-url]: https://github.com/vrmedina/d_Videogame_Store/network/members
[stars-shield]: https://img.shields.io/github/stars/vrmedina/d_Videogame_Store.svg?style=for-the-badge
[stars-url]: https://github.com/vrmedina/d_Videogame_Store/stargazers
[issues-shield]: https://img.shields.io/github/issues/vrmedina/d_Videogame_Store.svg?style=for-the-badge
[issues-url]: https://github.com/vrmedina/d_Videogame_Store/issues
[license-shield]: https://img.shields.io/github/license/vrmedina/d_Videogame_Store.svg?style=for-the-badge
[license-url]: https://github.com/vrmedina/d_Videogame_Store/blob/main/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/victor-medina-meza
[product-screenshot]: images/screenshot.png
[Dotnet7]: https://img.shields.io/badge/-.NET%207.0-blueviolet?style=for-the-badge&logo=.net&logoColor=white
[Dotnet7-url]: https://dotnet.microsoft.com/en-us/download/dotnet/7.0
[MicrosoftSQLServer]: https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white
[MicrosoftSQLServer-url]: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
[Swagger]: https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white
[Swagger-url]: https://swagger.io/
