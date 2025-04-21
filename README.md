# Stock Market App

[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-9.0+-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
[![Blazor](https://img.shields.io/badge/Blazor-9.0+-blue.svg)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
[![AlphaVantage](https://img.shields.io/badge/AlphaVantage-API-blue.svg)](https://www.alphavantage.co/)

A Blazor Server application for viewing real-time or historical stock market data.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
- [Usage](#usage)
  - [Viewing Stock Data](#viewing-stock-data)
  - [Using Candlestick Charts](#using-candlestick-charts)
  - [Other Features (if applicable)](#other-features-if-applicable)
- [Technology Stack](#technology-stack)
- [API Integration](#api-integration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Overview

Stock Market App is a user-friendly web application built with Blazor Server that allows users to track stock prices and visualize historical data using interactive candlestick charts. It aims to provide investors and enthusiasts with a clear and accessible way to monitor market trends.

## Features

> - **Real-time Stock Quotes:** Fetch and display up-to-date stock prices based on a stock symbol.
> - **Interactive Candlestick Charts:** Visualize price movements with interactive candlestick charts powered by Blazor-ApexCharts.
> - **Search Functionality:** Easily search for specific stocks by symbol or company.
> - **User-Friendly Interface:** Clean and intuitive design for easy navigation.

## Getting Started

### Prerequisites

> - [.NET SDK](https://dotnet.microsoft.com/download) (version 9.0 or higher recommended)
> - [Visual Studio](https://visualstudio.microsoft.com/) (with the ASP.NET and web development workload) or [Visual Studio Code](https://code.visualstudio.com/) with the C# extension.
> - A valid API key from your chosen stock data provider from [AlphaVantage](https://www.alphavantage.co/).

### Installation

> 1. Clone the repository to your local machine:
>
>    ```bash
>    git clone https://github.com/applesea2/StockMarketApp
>    cd StockMarketApp
>    ```
>
> 2. Navigate to the project directory.

### Configuration
> 1. **API Key:** This application requires an API key from [AlphaVantage](https://www.alphavantage.co/). You can sign up for a free or paid plan on their website: https://www.alphavantage.co/
> 2. **Add your API key:** Create or edit the secrets.json generated from .NET Secrets manager and add your API key as follows:
>
>    ```json
>    {
>      AlphaVantage:ApiKey = "ApiKey"
>    }
>    ```
>
>    **Important:** Do not commit your actual API key directly into the repository. Consider using user secrets for development and environment variables for production.

### Running the Application

> 1. Open the solution file (`.sln`) in Visual Studio or navigate to the project directory in your terminal.
>
> 2. **Build the application:**
>
>    - **Visual Studio:** Press `Ctrl+Shift+B` (Build Solution) or go to `Build > Build Solution`.
>    - **.NET CLI:** Run the following command in the root of your solution directory:
>
>      ```bash
>      dotnet build
>      ```
>
> 3. **Run the application:**
>
>    - **Visual Studio:** Press `F5` (Start Debugging) or `Ctrl+F5` (Start Without Debugging).
>    - **.NET CLI:** Navigate to the `Client` project directory and run:
>
>      ```bash
>      dotnet run
>      ```
>
> 4. The application should open in your default web browser, usually at `https://localhost:XXXX` (the port number may vary).

## Usage

### Viewing Stock Data

> 1. Enter a stock symbol (e.g., AAPL, MSFT, GOOGL) in the search bar located at the top of the page.
> 2. Click the "Search" button or press Enter.
> 3. The application will display the current stock quote and options to view historical data.

### Using Candlestick Charts

> 1. After searching for a stock, you will see an option to view a candlestick chart.
> 2. The interactive candlestick chart will be displayed, showing the open, high, low, and close prices for the selected period.
> 3. You can hover over individual candlesticks to see detailed price information.

## Technology Stack

> - [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)
> - [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0)
> - [C#](https://dotnet.microsoft.com/en-us/languages/csharp)
> - [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
> - [Blazor-ApexCharts](https://github.com/apexcharts/Blazor-ApexCharts)
> - [System.Net.Http](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-9.0http)

## API Integration
> This application utilizes the AlphaVantage API to retrieve real-time and historical stock market data. You can find their API documentation here: [API documentation](https://www.alphavantage.co/documentation/).

## Contributing

> Contributions are welcome! Please follow these steps:
>
> 1. Fork the repository.
> 2. Create a new branch for your feature or bug fix (`git checkout -b feature/your-feature-name`).
> 3. Make your changes and commit them (`git commit -am 'Add some feature'`).
> 4. Push to the branch (`git push origin feature/your-feature-name`).
> 5. Create a new Pull Request.

## License

> This project is licensed under the [MIT License](https://opensource.org/license/mit). See the `LICENSE` file for more information.

## Contact

> - Jesse Stroster - [stroster.jesse@gmail.com](mailto:stroster.jesse@gmail.com)
> - [Link to GitHub profile](https://github.com/applesea2)