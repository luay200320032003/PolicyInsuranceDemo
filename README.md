# InsurancePolicyDetailsAPI

This is a RESTful API for managing insurance policies, built using **.NET 8**. It provides functionality to retrieve insurance policy details, validate policy numbers, and return structured error responses using **ProblemDetails (RFC 7807)** format.

## Project Overview

- **Purpose**: This API allows the retrieval of insurance policy details based on a policy number. It supports validating the policy number format and returns errors in a structured format.
- **Tech Stack**:
  - Backend: **.NET 8**
  - Database: (If applicable, mention the database used, e.g., SQL Server, MongoDB, etc.)
  - Authentication: (Mention if you are using JWT, OAuth, etc.)
  - Documentation: The API is documented using **Swagger**.

## Prerequisites

Before running the project, make sure you have the following installed on your machine:

- **.NET 8 SDK**: You can download and install it from [here](https://dotnet.microsoft.com/download/dotnet).
- **Code Editor**: (Optional, depending on your preference) [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/).

### **Optional Tools**:
- **Postman** or **Curl**: You can use these tools to test the API.

## Setup Instructions

### Steps to Run Locally:

1. **Clone the repository**:

    ```bash
    git clone https://github.com/luay200320032003/PolicyInsuranceDemo.git
    ```

2. **Navigate to the project folder**:

    ```bash
    cd PolicyInsuranceDemo
    ```

3. **Restore project dependencies**:

    Run this command to restore all the necessary dependencies:

    ```bash
    dotnet restore
    ```

4. **Build the project**:

    Build the solution to make sure everything is set up correctly:

    ```bash
    dotnet build
    ```

5. **Run the project**:

    Finally, run the API locally:

    ```bash
    dotnet run --project InsurancePolicyDetailsAPI/InsurancePolicyDetailsAPI.csproj
    ```

    The API should now be accessible at `https://localhost:5001` by default.

---

## Example Requests and Responses

### **1. Retrieve Policy Details**

**GET** `/api/policies/{policyNumber}`

This endpoint retrieves the insurance policy details based on the provided policy number.

#### Example Request:

```bash
Example Response (Success):
{
    "success": true,
    "data": {
        "policyNumber": "TX123456",
        "effectiveDate": "2025-01-01T00:00:00",
        "premiumAmount": 1200.50,
        "limits": [
            { "coverage": "Property", "limit": 1000000 },
            { "coverage": "Liability", "limit": 500000 }
        ]
    },
    "message": "Policy fetched successfully."
}
