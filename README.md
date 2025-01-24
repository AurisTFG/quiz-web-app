# quiz-web-app

A full-stack quiz web application developed as part of an internship for Present Connection.

## Overview

This web application allows users to participate in a quiz by solving various types of questions. After completing the quiz, users can submit their scores along with an email address. The app also displays high scores from previous attempts, stored in the database.

### Tools & Libraries

- **ASP.NET Core (.NET 8)**
- **Entity Framework Core In-Memory Database**
- **React + TypeScript + SWC**
- **Material UI**

## Setup

### Prerequisites

- .NET Core SDK
- Node.js
- pnpm

## How to Run the Application

- Clone the repository.
  ```bash
  git clone https://github.com/AurisTFG/quiz-web-app
  cd .\quiz-web-app\
  ```

### 1. **Backend**:

- Run the following commands:
  ```bash
  cd .\Backend\QuizApi\
  dotnet restore
  dotnet build
  dotnet run
  ```
- The backend server will run on `http://localhost:5052`

### 2. **Frontend**:

- Run the following commands:
  ```bash
  cd .\Frontend\
  pnpm install
  pnpm start
  ```
- The frontend will run on `http://localhost:5174`
