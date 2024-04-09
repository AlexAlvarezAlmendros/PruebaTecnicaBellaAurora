# Gestor de Inventario

El Gestor de Inventario es una aplicación web desarrollada con ASP.NET Core Razor Pages que permite gestionar productos, categorías y transacciones de inventario de manera eficiente y fácil.

## Configuración Local

Para ejecutar este proyecto localmente, necesitarás tener instalado .NET 6 SDK, un IDE (como Visual Studio o Visual Studio Code) y SQL Server. Sigue los pasos a continuación para configurar el entorno de desarrollo.

### Prerrequisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Puedes utilizar SQL Server Express para un entorno de desarrollo)
- Un editor de código o IDE compatible, como [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/) con la [extensión C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp), o [JetBrains Rider](https://www.jetbrains.com/rider/).

### Pasos para Ejecutar Localmente

1. **Clonar el Repositorio**

   Abre una terminal y clona el repositorio utilizando Git:
   ```
   git clone https://github.com/tu-usuario/gestor-de-inventario.git
   cd gestor-de-inventario
   ```

2. **Configurar la Cadena de Conexión a la Base de Datos**

   En el archivo `appsettings.json`, ajusta la cadena de conexión `DefaultConnection` para apuntar a tu instancia local de SQL Server:
   
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GestorInventarioDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
3. **Aplicar Migraciones de EF Core para Configurar la Base de Datos**
   
   Utiliza la CLI de .NET Core para aplicar migraciones y crear la base de datos. Asegúrate de estar en el directorio del proyecto que contiene el archivo .csproj:

   ```
    dotnet ef database update
   ```

   Si aún no has generado ninguna migración, primero ejecuta dotnet ef migrations add InitialCreate para generar una migración inicial basada en tus modelos.

4. **Ejecutar la Aplicación**

   ```
   dotnet run
   ```

   Esto iniciará el servidor localmente y la aplicación será accesible desde un navegador web en http://localhost:5000 o https://localhost:5001.



## Contenido del Proyecto

- **Pages**: Contiene las Razor Pages organizadas por funcionalidad (`Productos`, `Categorias`, `Transacciones`).
  - **Productos**: Páginas para listar, añadir, editar y eliminar productos.
  - **Categorias**: Páginas para listar, añadir, editar y eliminar categorías de productos.
  - **Transacciones**: (Opcional) Páginas para visualizar y gestionar transacciones de inventario.
- **Models**: Modelos de entidades como `Producto`, `Categoria`, y `Transaccion`.
- **Data**: Incluye el `AppDbContext` para la configuración de Entity Framework Core.
- **Services**: (Opcional) Servicios de aplicación para lógica de negocio compleja.
- **wwwroot**: Archivos estáticos como CSS personalizado, JavaScript y imágenes.



