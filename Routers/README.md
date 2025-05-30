## Routers
- author : psiblvdegod
- date : 2025
- license : MIT

---

### how to run :
```shell
git clone https://github.com/psiblvdegod/second_semester
cd ./second_semester/Routers/Program
dotnet run PATH_TO_YOUR_FILE
```

---

### features :
- reads topology specified in the file
- builds network model using this topology
- builds optimal configuration of this network (builds MST)
- creates new file named YOUR_FILE.optimal in the same directory 
- writes optimal configuration to the new file

---

### syntax of topology description
- every connection must be described as three integers separated by space symbol on the only one line
- example: `1 2 3\n` means nodes 1 and 2 connected with bandwidth 3.
