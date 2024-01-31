# BancoAtlantidaChallenge

Esta API proporciona un conjunto de endpoints para administrar Tarjetas de Credito, Pagos y Compras.

## Configurar el proyecto localmente

Para poder correr la API en local, es necesario dirigirse al código del proyecto y cambiar el string de conexión en el archivo:
```bash
 appsettings.json (en la raíz del proyecto)
```


Luego, es necesario ejecutar el siguiente comando:
```bash
dotnet ef database update --project src\Infrastructure --startup-project src\Web
```

Este comando ejecutará las migraciones y seed data correspondientes, ya que fue desarrollado con Entity Framework Core.

Cuando estos pasos se hayan completado y el servidor esté ejecutándose, puedes acceder a esta URL desde el navegador: https://localhost:5001.

## Endpoints

| Method   | endpoint                | parameters                        |
|----------|-------------------------|-----------------------------------|
| GET      | /Compras                | tarjetaDeCreditoId                |
| POST     | /Compras                |                                   |
| POST     | /Pagos                  |                                   |
| GET      | /TarjetasDeCredito      | pageSize, pageNumber, searchString|
| GET      | /TarjetasDeCredito/{id} | searchString                      |
| GET      | /Transacciones          | tarjetaDeCreditoId                |


Envío información más detallada sobre los endpoints por correo al momento de enviar esta prueba.

También está disponible la documentación de Swagger en la siguiente dirección (local): https://localhost:5001/api/index.html?url=/api/specification.json

## Modelo de datos
La base de datos para este proyecto consiste en 4 tablas, siendo la principal "TarjetasDeCredito", esta tabla se relaciona con la tabla "Clientes" a través de una llave foránea, 
y tiene relaciones con las tablas "Compras" y "Pagos" que guardan en sus registros la referencia a la tarjeta de crédito a la que va dirigida la operación.

![image](https://github.com/FabioGuardado/banco-atlantida-be/assets/47063285/e49e0db0-f201-42f8-becc-bf859d260407)

