## Second Semester 

![CI Status](https://github.com/psiblvdegod/second_semester/actions/workflows/ci.yml/badge.svg)

Homeworks and practices of second semester of TP at SPBU MM
- author: Balyshev A.M
- language: C#
- date: 2025

### How to run

- Ensure you have `dotnet-sdk-9.0` installed
- `git clone https://github.com/psiblvdegod/second_semester`
- You need to `git switch BRANCH_NAME` if solution you interested in is not yet in `main`
- Each directory in repository root contains a single solution.
- `dotnet build` to build all projects of this solution
- `dotnet test` to run tests (if there are any)
- Solution may contain console application which is usually located in directory `Program`,
- `cd Program` and `dotnet run` to run it.
