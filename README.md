# DominoesApi

Descargar el proyecto y ejecutarlo.

Esperar a que el swagger se cargue para empezar a realizar peticiones

![image](https://user-images.githubusercontent.com/40804118/223290385-7318858b-8906-4b4b-b1bf-4ed9fcee409d.png)

Cuando swagger este arriba abrir postman y autenticarse con el correo: mendietajimmy7@gmail.com

POST 
https://localhost:44379/api/User/login

enviando en el body la siguiente estructura

{
  "email": "mendietajimmy7@gmail.com"
}

el regresará un token que vamos a utilizar en el siguiente paso

![image](https://user-images.githubusercontent.com/40804118/223290988-b479df29-63ac-4d24-9f70-84e2e0ceed59.png)



Este método retorna todas las posibles permutaciones correctas (debes enviar el token como bearer token)

POST 

https://localhost:44379/api/TokenChain/calculateAll

![image](https://user-images.githubusercontent.com/40804118/223291154-3fe859b4-210c-48a9-8f21-4a637536a744.png)

enviando la siguiente estructura json

[
  {
    "left": 2,
    "right": 1
  },
{
    "left": 2,
    "right": 3
  },
{
    "left": 1,
    "right": 3
  }
]


![image](https://user-images.githubusercontent.com/40804118/223290707-0d4fc632-2ee2-4ba5-ae39-4646b6e4adfa.png)

este último método devuelve solo un valor aleatorio (enviar nuevamente el token y la misma cadena del endpoint anterior)

POST 
https://localhost:44379/api/TokenChain/firstCalculated

[
  {
    "left": 2,
    "right": 1
  },
{
    "left": 2,
    "right": 3
  },
{
    "left": 1,
    "right": 3
  }
]

![image](https://user-images.githubusercontent.com/40804118/223291734-70598bb2-d5ec-4033-b9bf-aa19288da604.png)

![image](https://user-images.githubusercontent.com/40804118/223291788-08eeb41e-d362-4711-8192-e60422517f24.png)


